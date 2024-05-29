﻿using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Version2
{
    public partial class EnterPro : Form
    {
        int selectedMetod = 0;

        public EnterPro()
        {
            InitializeComponent();
            density.KeyPress += density_KeyPress;
            specificHeat.KeyPress += specificHeat_KeyPress;
            alpha.KeyPress += alpha_KeyPress;

            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;

            textBox1.ReadOnly = true;
            textBox1.TabStop = false;

            textBox2.ReadOnly = true;
            textBox2.TabStop = false;

            textBox3.ReadOnly = true;
            textBox3.TabStop = false;

            density.TabIndex = 0;
            specificHeat.TabIndex = 1;
            alpha.TabIndex = 2;
            button3.TabIndex = 3;
            button2.TabIndex = 4;
            calculat.TabIndex = 5;
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                back_Click(sender, e);
            }

        }

        private void density_KeyPress(object sender, KeyPressEventArgs e)
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

        private void specificHeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            density_KeyPress(sender, e); 
        }

        private void alpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            density_KeyPress(sender, e); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(alpha.Text) || string.IsNullOrEmpty(specificHeat.Text))
            {
                MessageBox.Show("Please fill in all fields!");
            }
            else if (selectedMetod == 0)
            {
                MessageBox.Show("Method not selected!");
            }
            else if (Program.GlobalVariables.selectedMethod == true)
            {
                double densityValue = double.Parse(density.Text);
                double specificHeatValue = double.Parse(specificHeat.Text);
                double alphaValue = double.Parse(alpha.Text);
                selectedMetod = 2;
                Singl singl = new Singl(densityValue, specificHeatValue, alphaValue);
                singl.Show();
                this.Hide();
            }
            else if (Program.GlobalVariables.selectedMethod == false)
            {
                double densityValue = double.Parse(density.Text);
                double specificHeatValue = double.Parse(specificHeat.Text);
                double alphaValue = double.Parse(alpha.Text);
                TDimen dimen = new TDimen(densityValue, specificHeatValue, alphaValue);
                dimen.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedMetod = 1;
            Program.GlobalVariables.selectedMethod = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedMetod = 2;
            Program.GlobalVariables.selectedMethod = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }
    }
}
