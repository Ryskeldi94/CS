using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Linq;
using CS;
using System.Resources;

namespace Version2
{
    public partial class Singl : Form
    {
        private double _density;
        private double _specificHeat;
        private double _alpha;

        private DBMetals DBMetals;
        private LoadData_2 LoadData_2;

        ResourceManager rm = new ResourceManager("CS.Resources.MessageBox", typeof(MainPage).Assembly);

        public Singl(double density, double specificHeat, double alpha)
        {
            InitializeComponent();
            highTempLocation.KeyPress += (s, e) => HandleNumericInput(s, e);
            ambientTemperature.KeyPress += (s, e) => HandleNumericInput(s, e, true);
            initialTemperature.KeyPress += (s, e) => HandleNumericInput(s, e, true);


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

            highTempLocation.Text = CS.Properties.Settings.Default.SavedHighTempLocationSingl;
            ambientTemperature.Text = CS.Properties.Settings.Default.SavedAmbientTemperatureSingl;
            initialTemperature.Text = CS.Properties.Settings.Default.SavedInitialTemperatureSingl;

            ThemeHelper.UpdateTheme(this);
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

        private void HandleNumericInput(object sender, KeyPressEventArgs e, bool allowDecimal = false)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                !(allowDecimal && (e.KeyChar == '.' || e.KeyChar == ',')))
            {
                e.Handled = true;
            }

            if (allowDecimal && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                if (textBox.Text.Contains('.') || string.IsNullOrEmpty(textBox.Text))
                {
                    e.Handled = true;
                }
                else
                {
                    e.KeyChar = '.';
                }
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                Calculate_Click(sender, e);
                e.Handled = true;
            }
        }


        private void Calculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(highTempLocation.Text) || string.IsNullOrEmpty(ambientTemperature.Text) || string.IsNullOrEmpty(initialTemperature.Text))
            {
                MessageBox.Show(rm.GetString("FieldsNotFilled"));
            }
            else
            {
                double density = _density;
                double specificHeat = _specificHeat;
                double alpha = _alpha;

                int highTempValue = int.Parse(highTempLocation.Text);
                float ambientTempValue = float.Parse(ambientTemperature.Text);
                float initialTempValue = float.Parse(initialTemperature.Text);

                CS.Properties.Settings.Default.SavedAmbientTemperatureSingl = ambientTemperature.Text;
                CS.Properties.Settings.Default.SavedHighTempLocationSingl= highTempLocation.Text;
                CS.Properties.Settings.Default.SavedInitialTemperatureSingl = initialTemperature.Text;

                Socket(density, specificHeat, alpha, highTempValue, initialTempValue, ambientTempValue);
            }
        }

        private void Socket(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature)
        {
            ProcessStartInfo serverStartInfo = new ProcessStartInfo
            {
                FileName = CS.Properties.Settings.Default.UserFilePathForServer,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process serverProcess = Process.Start(serverStartInfo);

            TcpClient client = new TcpClient("127.0.0.1", 54000);

            NetworkStream stream = client.GetStream();
            int numSteps = 100, nx = 10;
            double dt = 1, dx = 0.1;

            stream.Write(BitConverter.GetBytes(1), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
            stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));
            stream.Write(BitConverter.GetBytes(dt), 0, sizeof(double));
            stream.Write(BitConverter.GetBytes(dx), 0, sizeof(double));

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

            panel1.Controls.Clear();

            if (LoadData_2 == null)
            {
                LoadData_2 = new LoadData_2(result);
                LoadData_2.TopLevel = false;
                LoadData_2.FormBorderStyle = FormBorderStyle.None;
                LoadData_2.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(LoadData_2);

            LoadData_2.Show();
        }


        private void back_Click(object sender, EventArgs e)
        {
            
                panel1.Controls.Clear();

                if (DBMetals == null)
                {
                    DBMetals = new DBMetals();
                    DBMetals.TopLevel = false;
                    DBMetals.FormBorderStyle = FormBorderStyle.None;
                    DBMetals.Dock = DockStyle.Fill;
                }

                panel1.Controls.Add(DBMetals);

                DBMetals.Show();
            
           
        }

        private void Singl_Load(object sender, EventArgs e)
        {

        }
    }
}
