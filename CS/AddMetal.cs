using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Version2
{
    public partial class AddMetal : Form
    {
        private DBMetals DBMetals;
        private readonly string jsonFilePath = @"C:\My projects\CS\metals.json";
        private List<Metal> metals = new List<Metal>();

        public AddMetal()
        {
            InitializeComponent();
            AlphaBox.KeyPress += alpha_KeyPress;
            NameBox.KeyPress += nameTextBoxt_KeyPress;
            SpecificHeatBox.KeyPress += specificHeat_KeyPress;
            DensityBox.KeyPress += density_KeyPress;
            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;

            textBox2.ReadOnly = true;
            textBox2.TabStop = false;

            textBox3.ReadOnly = true;
            textBox3.TabStop = false;

            textBox1.ReadOnly = true;
            textBox1.TabStop = false;

            textBox4.ReadOnly = true;
            textBox4.TabStop = false;

            NameBox.TabIndex = 0;
            DensityBox.TabIndex = 1;
            SpecificHeatBox.TabIndex = 2;
            AlphaBox.TabIndex = 3;
            ViewButton.TabIndex = 4;
            AddButton.TabIndex = 5;
            Back.TabIndex = 6;
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Back_Click(sender, e);
            }
        }

        private void density_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Проверка на ввод только числовых символов, Backspace и точку
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Проверка на точку или запятую для ввода дробных чисел
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }

            // Замена запятой на точку для правильного ввода дробных чисел
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            // Если пользователь начинает вводить десятичную часть с запятой или точки, автоматически добавляем "0."
            if ((textBox.SelectionStart == 0 || textBox.Text == "") && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                textBox.Text = "0" + e.KeyChar;
                textBox.SelectionStart = 2; // Переместить курсор в конец
                e.Handled = true; // Предотвращаем добавление второй точки или запятой
            }

            // Проверка на количество цифр после десятичной точки
            if (textBox.Text.Contains('.'))
            {
                int indexOfDot = textBox.Text.IndexOf('.');
                if (textBox.Text.Length - indexOfDot > 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            // Разрешаем вводить точку только после ввода двух цифр
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Length < 2)
            {
                e.Handled = true;
            }
        }

        private void nameTextBoxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            /// Проверка на ввод только буквенных символов
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
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

        private void Back_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            // Создаем экземпляр формы MainPage (если еще не создан)
            if (DBMetals == null)
            {
                DBMetals = new DBMetals();
                DBMetals.TopLevel = false;
                DBMetals.FormBorderStyle = FormBorderStyle.None;
                DBMetals.Dock = DockStyle.Fill;
            }

            // Добавляем форму MainPage на панель panel1
            panel1.Controls.Add(DBMetals);

            // Отображаем форму MainPage на панели panel1
            DBMetals.Show();
        }

        private void highTempLocation_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстовых полей
            string name = NameBox.Text;
            if (double.TryParse(DensityBox.Text, out double densityValue) &&
                double.TryParse(SpecificHeatBox.Text, out double specificHeatValue) &&
                double.TryParse(AlphaBox.Text, out double alphaValue))
            {
                // Читаем существующие данные из файла
                string jsonString = string.Empty;

                if (File.Exists(jsonFilePath))
                {
                    jsonString = File.ReadAllText(jsonFilePath);
                    try
                    {
                        var metalData = JsonSerializer.Deserialize<MetalData>(jsonString);
                        metals = metalData.Metals;
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show($"Ошибка десериализации JSON: {ex.Message}");
                        metals = new List<Metal>();
                    }
                }
                else
                {
                    metals = new List<Metal>();
                }

                // Создаем новый объект Metal
                int number = metals.Count + 1; // Присваиваем номер следующего элемента
                Metal newMetal = new Metal
                {
                    Number = number,
                    Name = name,
                    Density = densityValue,
                    SpecificHeat = specificHeatValue,
                    Alpha = alphaValue
                };

                // Добавляем новый объект в список
                metals.Add(newMetal);

                // Сериализуем список обратно в JSON
                var metalDataToUpdate = new MetalData { Metals = metals };
                jsonString = JsonSerializer.Serialize(metalDataToUpdate, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, jsonString);

                // Очищаем текстовые поля после добавления
                NameBox.Clear();
                DensityBox.Clear();
                SpecificHeatBox.Clear();
                AlphaBox.Clear();

                MessageBox.Show("Металл успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.");
            }
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Названия металла: {NameBox.Text}\n" +
                $"Плотность: {DensityBox.Text} г/см³\n" +
                $"Удельная теплоемкость: {SpecificHeatBox.Text} Дж/г·°C\n" +
                $"Коэффициент теплопроводности: {AlphaBox.Text} Вт/м·°C");
        }

        public class Metal
        {
            [JsonPropertyName("номер")]
            public int Number { get; set; }

            [JsonPropertyName("название")]
            public string Name { get; set; }

            [JsonPropertyName("Плотность")]
            public double Density { get; set; }

            [JsonPropertyName("удельнаяТеплоемкость")]
            public double SpecificHeat { get; set; }

            [JsonPropertyName("КоэффициентТеплопроводности")]
            public double Alpha { get; set; }
        }

        public class MetalData
        {
            [JsonPropertyName("металлы")]
            public List<Metal> Metals { get; set; }
        }
    }
}
