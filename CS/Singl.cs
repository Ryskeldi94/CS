using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Linq;
using CS;

namespace Version2
{
    public partial class Singl : Form
    {
        private double _density;
        private double _specificHeat;
        private double _alpha;
        int calculationType = 1;
        public int SelectedMethod { get; set; }

        public Singl(double density, double specificHeat, double alpha)
        {
            InitializeComponent();
            highTempLocation.KeyPress += textBox1_KeyPress;
            ambientTemperature.KeyPress += textBox2_KeyPress;
            initialTemperature.KeyPress += textBox3_KeyPress;

            _density = density;
            _specificHeat = specificHeat;
            _alpha = alpha;

            textBox1.ReadOnly = true; 
            textBox1.TabStop = false; 

            textBox2.ReadOnly = true;
            textBox2.TabStop = false;

            textBox3.ReadOnly = true;
            textBox3.TabStop = false;

            calculate.TabIndex = 4;

            this.KeyPreview = true; 
            this.KeyDown += Singl_KeyDown;
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                back_Click(sender, e); 
            }
        }

        public Singl()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                // Вызываем метод, обрабатывающий событие Click для кнопки calculate
                button1_Click(sender, e);
                e.Handled = true; // Предотвращение дальнейшей обработки нажатия клавиши Enter
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            if ((textBox.SelectionStart == 0 || textBox.Text == "") && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                textBox.Text = "0" + e.KeyChar;
                textBox.SelectionStart = 2;
                e.Handled = true;
            }

            if (textBox.Text.Contains('.'))
            {
                int indexOfDot = textBox.Text.IndexOf('.');
                if (textBox.Text.Length - indexOfDot > 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Length < 2)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                // Вызываем метод, обрабатывающий событие Click для кнопки calculate
                button1_Click(sender, e);
                e.Handled = true; // Предотвращение дальнейшей обработки нажатия клавиши Enter
            }
        }

        


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2_KeyPress(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(highTempLocation.Text) || string.IsNullOrEmpty(ambientTemperature.Text) || string.IsNullOrEmpty(initialTemperature.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
            else
            {
                double density = _density;
                double specificHeat = _specificHeat;
                double alpha = _alpha;

                int highTempValue = int.Parse(highTempLocation.Text);
                float ambientTempValue = float.Parse(ambientTemperature.Text);
                float initialTempValue = float.Parse(initialTemperature.Text);

                soket(density, specificHeat, alpha, highTempValue, initialTempValue, ambientTempValue);
            }
        }

        private void ambientTemperature_TextChanged(object sender, EventArgs e)
        {

        }

        private void soket(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature)
        {
            ProcessStartInfo serverStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\My projects\Server for app\server.exe", 
                UseShellExecute = false
            };

            Process serverProcess = Process.Start(serverStartInfo);

            TcpClient client = new TcpClient("127.0.0.1", 54000);

            NetworkStream stream = client.GetStream();
            int numSteps = 100, nx = 10;

            stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));

            byte[] buffer = new byte[sizeof(double) * nx * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            double[] result = new double[nx * numSteps];
            if (bytesRead == sizeof(double) * nx * numSteps)
            {
                for (int i = 0; i < nx * numSteps; i++)
                {
                    result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                }
            }

            stream.Close();
            client.Close();


            LoadData_2 loadData_2 = new LoadData_2(result);
            loadData_2.Show();

            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Program.GlobalVariables.selectedMethod == true)
            {
                DBMetals dbMetalsForm = new DBMetals();
                dbMetalsForm.Show();
                this.Close();
            }
            else if (SelectedMethod == 2)
            {
                EnterPro enterProForm = new EnterPro();
                enterProForm.Show();
                this.Close();
            }
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
