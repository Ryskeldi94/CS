using CS;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Version2
{
    public partial class TDimen : Form
    {
        private double _density;
        private double _specificHeat;
        private double _thermalConductivity;

        private DBMetals dbMetalsForm;
        private EnterPro enterProForm;
        private LoadData_TD LoadData_TD;

        public TDimen(double density, double specificHeat, double thermalConductivity)
        {
            InitializeComponent();
            initialTemperature.KeyPress += textBox1_KeyPress;
            highTempX.KeyPress += textBox1_KeyPress;
            ambientTemperature.KeyPress += textBox1_KeyPress;
            highTempY.KeyPress += textBox1_KeyPress;

            _density = density;
            _specificHeat = specificHeat;
            _thermalConductivity = thermalConductivity;

            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;

            textBox1.ReadOnly = true;
            textBox1.TabStop = false;

            textBox2.ReadOnly = true;
            textBox2.TabStop = false;

            textBox3.ReadOnly = true;
            textBox3.TabStop = false;

            textBox4.ReadOnly = true;
            textBox4.TabStop = false;

            highTempX.TabIndex = 0;
            highTempY.TabIndex = 1;
            initialTemperature.TabIndex = 2;
            ambientTemperature.TabIndex = 3;
            calculate.TabIndex = 4;
            
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                back_Click(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

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
                button1_Click_1(sender, e);
                e.Handled = true; // Предотвращение дальнейшей обработки нажатия клавиши Enter
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Program.GlobalVariables.selectedMethod == true)
            {
                // Очищаем панель panel1 перед добавлением нового контента
                panel1.Controls.Clear();

                // Создаем экземпляр формы DBMetals (если еще не создан)
                if (dbMetalsForm == null)
                {
                    dbMetalsForm = new DBMetals();
                    dbMetalsForm.TopLevel = false;
                    dbMetalsForm.FormBorderStyle = FormBorderStyle.None;
                    dbMetalsForm.Dock = DockStyle.Fill;
                }

                // Добавляем форму DBMetals на панель panel1
                panel1.Controls.Add(dbMetalsForm);

                // Отображаем форму DBMetals на панели panel1
                dbMetalsForm.Show();
            }
            else if (Program.GlobalVariables.selectedMethod == false)
            {
                // Очищаем панель panel1 перед добавлением нового контента
                panel1.Controls.Clear();

                // Создаем экземпляр формы EnterPro (если еще не создан)
                if (enterProForm == null)
                {
                    enterProForm = new EnterPro();
                    enterProForm.TopLevel = false;
                    enterProForm.FormBorderStyle = FormBorderStyle.None;
                    enterProForm.Dock = DockStyle.Fill;
                }

                // Добавляем форму EnterPro на панель panel1
                panel1.Controls.Add(enterProForm);

                // Отображаем форму EnterPro на панели panel1
                enterProForm.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(highTempY.Text) || string.IsNullOrEmpty(initialTemperature.Text) || string.IsNullOrEmpty(highTempX.Text) || string.IsNullOrEmpty(ambientTemperature.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
            else
            {
                double density = _density;
                double specificHeat = _specificHeat;
                double alpha = _thermalConductivity;

                string highTempValueX = highTempX.Text;
                string highTempValueY = highTempY.Text;
                string ambientTemp = ambientTemperature.Text;
                string initialTemp = initialTemperature.Text;

                int highTempVX = int.Parse(highTempValueX);
                int highTempVY = int.Parse(highTempValueY);
                float ambientTempValue = float.Parse(ambientTemp);
                float initialTempValue = float.Parse(initialTemp);

                soket(density, specificHeat, alpha, highTempVX, highTempVY, initialTempValue, ambientTempValue);
            }
        }

        private void soket(double density, double specificHeat, double alpha, int highTempX, int highTempY, float initialTemperature, float ambientTemperature)
        {
            ProcessStartInfo serverStartInfo = new ProcessStartInfo();
            serverStartInfo.FileName = @"C:\My projects\Server for app\server.exe";
            serverStartInfo.UseShellExecute = false;

            Process serverProcess = Process.Start(serverStartInfo);

            TcpClient client = new TcpClient("127.0.0.1", 54000); 

            NetworkStream stream = client.GetStream();

            int calculationType = 2;
            int numSteps = 100, nx = 10, ny = 10;

            stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempX), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(highTempY), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(ny), 0, sizeof(int));

            byte[] buffer = new byte[sizeof(double) * nx * ny * numSteps];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            double[] result = new double[nx * ny * numSteps];

            if (bytesRead == sizeof(double) * nx * ny * numSteps)
            {
                
                for (int i = 0; i < nx * ny * numSteps; i++)
                {
                    result[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
                }

            }
            stream.Close();
            client.Close();

            panel1.Controls.Clear();

            if (LoadData_TD == null)
            {
                LoadData_TD = new LoadData_TD(result, _density, _specificHeat, _thermalConductivity);
                LoadData_TD.TopLevel = false;
                LoadData_TD.FormBorderStyle = FormBorderStyle.None;
                LoadData_TD.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(LoadData_TD);

            LoadData_TD.Show();
        }
    }
}
