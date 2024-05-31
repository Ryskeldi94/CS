using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Version2
{
    public partial class LoadData_2 : Form
    {
        private double[,] data; 

        public LoadData_2(double[] result)
        {
            InitializeComponent();
            PopulateData(result);
            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;

            // Add MouseWheel event handler for the entire form
            this.MouseWheel += new MouseEventHandler(Form_MouseWheel);

            nextLine.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            currentLine.MouseWheel += new MouseEventHandler(textBox_MouseWheel);
            previousLine.MouseWheel += new MouseEventHandler(textBox_MouseWheel);

            stylLines();
        }

        private void stylLines()
        {
            nextLine.BorderStyle = BorderStyle.FixedSingle;
            nextLine.BackColor = Color.Beige;
            nextLine.ForeColor = Color.DarkBlue;
            nextLine.Font = new Font("Courier New", 10, FontStyle.Bold);

            previousLine.BorderStyle = BorderStyle.FixedSingle;
            previousLine.BackColor = Color.Beige;
            previousLine.ForeColor = Color.DarkBlue;
            previousLine.Font = new Font("Courier New", 10, FontStyle.Bold);

            currentLine.BorderStyle = BorderStyle.FixedSingle;
            currentLine.BackColor = Color.Beige;
            currentLine.ForeColor = Color.DarkBlue;
            currentLine.Font = new Font("Courier New", 10, FontStyle.Bold);

            N_nextLine.BorderStyle = BorderStyle.FixedSingle;
            N_nextLine.BackColor = Color.Beige;
            N_nextLine.ForeColor = Color.DarkBlue;
            N_nextLine.Font = new Font("Courier New", 10, FontStyle.Bold);

            N_previousLine.BorderStyle = BorderStyle.FixedSingle;
            N_previousLine.BackColor = Color.Beige;
            N_previousLine.ForeColor = Color.DarkBlue;
            N_previousLine.Font = new Font("Courier New", 10, FontStyle.Bold);

            N_currentLine.BorderStyle = BorderStyle.FixedSingle;
            N_currentLine.BackColor = Color.Beige;
            N_currentLine.ForeColor = Color.DarkBlue;
            N_currentLine.Font = new Font("Courier New", 10, FontStyle.Bold);
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
                back_Click(sender, e);
            }
        }

        private void PopulateData(double[] result)
        {
            int nx = 10;  // Assuming nx is 10 as in your socket method
            int numSteps = result.Length / nx;

            data = new double[numSteps, nx];

            for (int i = 0; i < numSteps; i++)
            {
                for (int j = 0; j < nx; j++)
                {
                    data[i, j] = result[i * nx + j];
                }
            }

            // Hide column headers
            dataGridView1.ColumnHeadersVisible = false;

            // Add a column for row numbering
            dataGridView1.Columns.Add("RowNumber", "№");
            dataGridView1.Columns["RowNumber"].ReadOnly = true; // Read-only
            dataGridView1.Columns["RowNumber"].Frozen = true; // Freeze the column

            // Set up the other columns
            for (int col = 0; col < data.GetLength(1); col++)
            {
                dataGridView1.Columns.Add($"Column{col}", $"Column {col + 1}");
            }

            // Add data to the DataGridView
            for (int row = 0; row < data.GetLength(0); row++)
            {
                object[] rowData = new object[data.GetLength(1) + 1];
                rowData[0] = row + 1; // Row numbering
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    rowData[col + 1] = data[row, col];
                }
                dataGridView1.Rows.Add(rowData);
            }

            // Additional settings for the DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;

            numericUpDown1.Maximum = numSteps; // Set the maximum value for numericUpDown1
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int rowIndex = (int)numericUpDown1.Value - 1; // Get the row index (minus 1 because NumericUpDown starts from 1)
            UpdateTextBoxes(rowIndex);
        }

        private void UpdateTextBoxes(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < data.GetLength(0))
            {
                // Current row
                currentLine.Text = GetRowData(rowIndex);
                N_currentLine.Text = "Step:" + (rowIndex + 1).ToString();

                // Previous row
                if (rowIndex > 0)
                {
                    previousLine.Text = GetRowData(rowIndex - 1);
                    N_previousLine.Text = "Step:" + rowIndex.ToString();
                }
                else
                {
                    previousLine.Text = string.Empty; // Empty if there is no previous row
                    N_previousLine.Text = string.Empty;
                }

                // Next row
                if (rowIndex < data.GetLength(0) - 1)
                {
                    nextLine.Text = GetRowData(rowIndex + 1);
                    N_nextLine.Text = "Step:" + (rowIndex + 2).ToString();
                }
                else
                {
                    nextLine.Text = string.Empty; // Empty if there is no next row
                    N_nextLine.Text = string.Empty;
                }
            }
        }

        private string GetRowData(int rowIndex, string format = "F3", string delimiter = " ")
        {
            StringBuilder rowData = new StringBuilder();
            for (int col = 0; col < data.GetLength(1); col++)
            {
                rowData.Append(data[rowIndex, col].ToString(format)); // Format with specified decimal places
                if (col < data.GetLength(1) - 1)
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
                        for (int row = 0; row < data.GetLength(0); row++)
                        {
                            string rowData = $"Step {row + 1}: {GetRowData(row)}";
                            writer.WriteLine(rowData);
                        }
                    }

                    MessageBox.Show("Data saved successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Singl singl = new Singl();
            singl.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }
    }
}
