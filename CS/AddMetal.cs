using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace Version2
{
    public partial class AddMetal : Form
    {
        private readonly string jsonFilePath = @"C:\Users\Ryskeldi\Documents\Clone\ParallelHeatFlowAnalysis\metals.json";
        private List<Metal> metals = new List<Metal>();

        public AddMetal()
        {
            InitializeComponent();
            alpha.KeyPress += alpha_KeyPress;
            NameTextBoxt.KeyPress += nameTextBoxt_KeyPress;
            specificHeat.KeyPress += specificHeat_KeyPress;
            density.KeyPress += density_KeyPress;
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

        private void back_Click(object sender, EventArgs e)
        {
            DBMetals dBMetals = new DBMetals();
            dBMetals.Show();
            this.Close();
        }

        private void highTempLocation_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Получаем данные из текстовых полей
            string name = NameTextBoxt.Text;
            if (double.TryParse(density.Text, out double densityValue) &&
                double.TryParse(specificHeat.Text, out double specificHeatValue) &&
                double.TryParse(alpha.Text, out double alphaValue))
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
                NameTextBoxt.Clear();
                density.Clear();
                specificHeat.Clear();
                alpha.Clear();

                MessageBox.Show("Металл успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.");
            }
        }

        private void ViewButoon_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Названия металла: {NameTextBoxt.Text}\n" +
                $"Плотность: {density.Text} г/см³\n" +
                $"Удельная теплоемкость: {specificHeat.Text} Дж/г·°C\n" +
                $"Коэффициент теплопроводности: {alpha.Text} Вт/м·°C");
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
