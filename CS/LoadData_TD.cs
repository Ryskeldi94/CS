using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Version2
{
    public partial class LoadData_TD : Form
    {
        private double[,,] data;
        private double _density;
        private double _specificHeat;
        private double _thermalConductivity;

        private void InitializeTextBoxes()
        {
            for (int i = 1; i <= 10; i++)
            {
                TextBox textBox = (TextBox)this.Controls.Find("line" + i, true)[0];
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = Color.Beige;
                textBox.ForeColor = Color.DarkBlue;
                textBox.Font = new Font("Courier New", 10, FontStyle.Bold);
            }
        }


        public LoadData_TD(double[] result, double density, double specificHeat, double thermalConductivity)
        {
            InitializeComponent();
            PopulateData(result);

            _density = density;
            _specificHeat = specificHeat;
            _thermalConductivity = thermalConductivity;

            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;

            // Add MouseWheel event handler for the entire form
            this.MouseWheel += new MouseEventHandler(Form_MouseWheel);

            line1.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line2.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line3.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line4.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line5.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line6.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line7.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line8.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line9.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            line10.MouseWheel += new MouseEventHandler(textBox_MouseWheel);

            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged; // Ensure this event handler is connected

            InitializeTextBoxes(); // Initialize text boxes with styles
        }

        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && numericUpDown1.Value < numericUpDown1.Maximum) // Scroll up
            {
                numericUpDown1.Value++;
            }
            else if (e.Delta < 0 && numericUpDown1.Value > numericUpDown1.Minimum) // Scroll down
            {
                numericUpDown1.Value--;
            }
        }

        private void textBox_MouseWheel(object sender, MouseEventArgs e)
        {
            Form_MouseWheel(sender, e); // Delegate to Form_MouseWheel for consistency
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Back(sender, e);
            }
        }

        private void PopulateData(double[] result)
        {
            int nx = 10;
            int numSteps = result.Length / (nx * nx);

            data = new double[numSteps, nx, nx]; // Change to three-dimensional array

            for (int step = 0; step < numSteps; step++)
            {
                for (int i = 0; i < nx; i++)
                {
                    for (int j = 0; j < nx; j++)
                    {
                        data[step, i, j] = result[step * nx * nx + i * nx + j]; // Update array indexing
                    }
                }
            }

            numericUpDown1.Maximum = numSteps; // Set the maximum value for numericUpDown1
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int stepIndex = (int)numericUpDown1.Value - 1; // Get the step index
            Console.WriteLine("numericUpDown1_ValueChanged: stepIndex = " + stepIndex); // Debug log
            UpdateTextBoxes(stepIndex);
        }

        private void UpdateTextBoxes(int stepIndex)
        {
            if (stepIndex >= 0 && stepIndex < data.GetLength(0))
            {
                int nx = data.GetLength(1); // Get the size of the second dimension (number of rows)
                // Display data for the selected step and corresponding rows in text boxes
                for (int row = 0; row < nx; row++)
                {
                    int textBoxIndex = row + 1; // Text box index starts from 1
                    TextBox textBox = (TextBox)this.Controls.Find("line" + textBoxIndex, true)[0];
                    textBox.Font = new Font("Courier New", 10); // Use monospaced font for better alignment
                    textBox.Text = GetRowData(stepIndex, row);
                }
            }
            else
            {
                Console.WriteLine("UpdateTextBoxes: Invalid stepIndex = " + stepIndex); // Debug log
            }
        }

        private string GetRowData(int stepIndex, int rowIndex, string format = "F3", string delimiter = " ")
        {
            StringBuilder rowData = new StringBuilder();
            for (int col = 0; col < data.GetLength(2); col++)
            {
                rowData.Append(data[stepIndex, rowIndex, col].ToString(format).PadLeft(7)); // Ensure fixed width
                if (col < data.GetLength(2) - 1)
                {
                    rowData.Append(delimiter);
                }
            }
            return rowData.ToString();
        }

        private void SaveDataToFile()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        for (int stepIndex = 0; stepIndex < data.GetLength(0); stepIndex++)
                        {
                            writer.WriteLine($"Step {stepIndex + 1}:");
                            for (int i = 0; i < data.GetLength(1); i++)
                            {
                                for (int j = 0; j < data.GetLength(2); j++)
                                {
                                    writer.Write(data[stepIndex, i, j].ToString("F3") + " "); // Write each element of the matrix
                                }
                                writer.WriteLine(); // Move to the next line after writing a row of the matrix
                            }
                            writer.WriteLine(); // Empty line between steps
                        }
                    }

                    MessageBox.Show("Data saved successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Back(sender, e);
        }

        private void Back(object sender, EventArgs e)
        {
            TDimen dimen = new TDimen(_density, _specificHeat, _thermalConductivity);
            dimen.Show();
            this.Close();
        }
    }
}
