using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Version2.AddMetal;
using System.Text.Json.Serialization;

namespace Version2
{
    public partial class DBMetals : Form
    {

        private MainPage mainPageForm;
        private AddMetal addMetal;
        private Singl Singl;
        private TDimen dimen1;
        private readonly string jsonFilePath = @"C:\My projects\CS\metals.json";
        private List<Metal> metalsList; // объявляем переменную как член класса
        int selectedMetod = 0;
        public DBMetals()
        {
            InitializeComponent();
            comboBoxMetals.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadMetalsData();
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

            AlphaBox.KeyPress += alpha_KeyPress;
            NameBox.KeyPress += nameTextBoxt_KeyPress;
            SpecificHeatBox.KeyPress += specificHeat_KeyPress;
            DensityBox.KeyPress += density_KeyPress;

            SetTabIndexes();
        }

        private void density_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

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

        private void SetTabIndexes()
        {
            comboBoxMetals.TabIndex = 0;
            ShowItems.TabIndex = 1;
            AddMetal.TabIndex = 2;
            button1.TabIndex = 3;
            button2.TabIndex = 4;
            SelectThis.TabIndex = 5;
            back.TabIndex = 6;
        }

        private void LoadMetalsData()
        {
            string jsonFilePath = @"C:\My projects\CS\metals.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                metalsList = JsonConvert.DeserializeObject<MetalsList>(jsonData).Металлы;
                foreach (var metal in metalsList)
                {
                    comboBoxMetals.Items.Add(metal.Название);
                }
            }
            else
            {
                MessageBox.Show("Файл 'metals.json' не найден!");
            }
        }

        private async void FadeIn()
        {
            for (double i = 0.0; i <= 1.0; i += 0.1)
            {
                this.Opacity = i;
                await Task.Delay(50); // Регулируйте задержку для скорости появления
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            FadeIn();
        }

        private void Singl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                back_Click(sender, e);
            }
        }



        private void ShowItems_Click(object sender, EventArgs e)
        {
            if (comboBoxMetals.SelectedIndex == -1)
            {
                MessageBox.Show("Металл не выбран!");
            }
            else
            {
                // Получаем выбранный металл из ComboBox
                string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
                Metal selectedMetal = metalsList.FirstOrDefault(m => m.Название == selectedMetalName);

                if (selectedMetal != null)
                {
                    // Отображаем свойства выбранного металла в MessageBox
                    MessageBox.Show(
                                    $"Плотность: {selectedMetal.Плотность} г/см³\n" +
                                    $"Удельная теплоемкость: {selectedMetal.УдельнаяТеплоемкость} Дж/г·°C\n" +
                                    $"Коэффициент теплопроводности: {selectedMetal.КоэффициентТеплопроводности} Вт/м·°C");

                }

                else
                {
                    MessageBox.Show("Металл не выбран!");
                }
            }
        }

        private void SelectThis_Click(object sender, EventArgs e)
        {
            if (comboBoxMetals.SelectedIndex == -1)
            {
                MessageBox.Show("Металл не выбран!");
            }
            else
            {
                string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
                Metal selectedMetal = metalsList.FirstOrDefault(m => m.Название == selectedMetalName);

                if (selectedMetal != null)
                {
                    double density = selectedMetal.Плотность;
                    double specificHeat = selectedMetal.УдельнаяТеплоемкость;
                    double alpha = selectedMetal.КоэффициентТеплопроводности;

                    if (selectedMetod == 0)
                    {
                        MessageBox.Show("Выберите метод типа решения");
                    }
                    else
                    {
                        if (Program.GlobalVariables.selectedMethod == true)
                        {

                            // Очищаем панель panel1 перед добавлением нового контента
                            panel1.Controls.Clear();

                            // Создаем экземпляр формы MainPage (если еще не создан)
                            if (Singl == null)
                            {
                                Singl = new Singl(density, specificHeat, alpha);
                                Singl.TopLevel = false;
                                Singl.FormBorderStyle = FormBorderStyle.None;
                                Singl.Dock = DockStyle.Fill;
                            }

                            // Добавляем форму MainPage на панель panel1
                            panel1.Controls.Add(Singl);

                            // Отображаем форму MainPage на панели panel1
                            Singl.Show();
                        }
                        else
                        {
                            // Очищаем панель panel1 перед добавлением нового контента
                            panel1.Controls.Clear();

                            // Создаем экземпляр формы MainPage (если еще не создан)
                            if (dimen1 == null)
                            {
                                dimen1 = new TDimen(density, specificHeat, alpha);
                                dimen1.TopLevel = false;
                                dimen1.FormBorderStyle = FormBorderStyle.None;
                                dimen1.Dock = DockStyle.Fill;
                            }

                            // Добавляем форму MainPage на панель panel1
                            panel1.Controls.Add(dimen1);

                            // Отображаем форму MainPage на панели panel1
                            dimen1.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Металл не найден в списке!");
                }
            }

        }


        private void button1_Click(object sender, EventArgs e)
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
            // Очищаем панель panel1 перед добавлением нового контента
            panel1.Controls.Clear();

            // Создаем экземпляр формы MainPage (если еще не создан)
            if (mainPageForm == null)
            {
                mainPageForm = new MainPage();
                mainPageForm.TopLevel = false;
                mainPageForm.FormBorderStyle = FormBorderStyle.None;
                mainPageForm.Dock = DockStyle.Fill;
            }

            // Добавляем форму MainPage на панель panel1
            panel1.Controls.Add(mainPageForm);

            // Отображаем форму MainPage на панели panel1
            mainPageForm.Show();
        }


        private void AddMetal_Click(object sender, EventArgs e)
        {

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

        private void comboBoxMetals_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DBMetals_Load(object sender, EventArgs e)
        {

        }

    }

    // Classes for deserializing JSON
    public class Metal
    {
        public int Номер { get; set; }
        public string Название { get; set; }
        public double Плотность { get; set; }
        public double УдельнаяТеплоемкость { get; set; }
        public double КоэффициентТеплопроводности { get; set; }
    }

    public class MetalsList
    {
        public List<Metal> Металлы { get; set; }
    }
}
