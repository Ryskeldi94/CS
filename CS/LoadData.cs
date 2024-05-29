using CS;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Version2
{
    public partial class LoadData : Form
    {
        private double[,] data;
        public LoadData(double[] result)
        {
            InitializeComponent();
            PopulateData(result);

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

        private void PopulateData(double[] result)
        {
            int nx = 10;  // assuming nx is 10 as in your socket method
            int numSteps = result.Length / nx;

            double[,] data = new double[numSteps, nx];

            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < numSteps; j++)
                {
                    data[j, i] = result[i * numSteps + j];
                }
            }

            // Настройка столбцов
            for (int col = 0; col < data.GetLength(1); col++)
            {
                dataGridView2.Columns.Add($"Column{col}", $"Column {col + 1}");
            }

            // Добавление данных в DataGridView
            for (int row = 0; row < data.GetLength(0); row++)
            {
                object[] rowData = new object[data.GetLength(1)];
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    rowData[col] = data[row, col];
                }
                dataGridView2.Rows.Add(rowData);
            }

            // Дополнительные настройки DataGridView
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.ReadOnly = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Singl singl = new Singl();
            singl.Show();
            this.Close();
        }
    }
}
