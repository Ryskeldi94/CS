using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;

namespace Version2
{
    public partial class DBMetals : Form
    {
        private MainPage mainPageForm;
        private Singl Singl;
        private TDimen dimen1;
        private readonly string jsonFilePath = @"C:\My projects\CS\metals.json";
        int selectedMetod = 0;
        private List<Metal> metals = new List<Metal>();

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
        }

        private void nameTextBoxt_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            comboBoxMetals.Items.Clear();
            string jsonFilePath = @"C:\My projects\CS\metals.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                metals = System.Text.Json.JsonSerializer.Deserialize<MetalData>(jsonData).Metals;
                foreach (var metal in metals)
                {
                    comboBoxMetals.Items.Add(metal.Name); 
                }

            }
            else
            {
                MessageBox.Show("Файл 'metals.json' не найден!");
            }
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
                string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
                Metal selectedMetal = metals.FirstOrDefault(m => m.Name == selectedMetalName);

                if (selectedMetal != null)
                {
                    MessageBox.Show(
                                    $"Плотность: {selectedMetal.Density} г/см³\n" +
                                    $"Удельная теплоемкость: {selectedMetal.SpecificHeat} Дж/г·°C\n" +
                                    $"Коэффициент теплопроводности: {selectedMetal.Alpha} Вт/м·°C");

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
                Metal selectedMetal = metals.FirstOrDefault(m => m.Name == selectedMetalName);

                if (selectedMetal != null)
                {
                    double density = selectedMetal.Density;
                    double specificHeat = selectedMetal.SpecificHeat;
                    double alpha = selectedMetal.Alpha;

                    if (selectedMetod == 0)
                    {
                        MessageBox.Show("Выберите метод типа решения");
                    }
                    else
                    {
                        if (Program.GlobalVariables.selectedMethod == true)
                        {

                            panel1.Controls.Clear();

                            if (Singl == null)
                            {
                                Singl = new Singl(density, specificHeat, alpha);
                                Singl.TopLevel = false;
                                Singl.FormBorderStyle = FormBorderStyle.None;
                                Singl.Dock = DockStyle.Fill;
                            }

                            panel1.Controls.Add(Singl);

                            Singl.Show();
                        }
                        else
                        {
                            panel1.Controls.Clear();

                            if (dimen1 == null)
                            {
                                dimen1 = new TDimen(density, specificHeat, alpha);
                                dimen1.TopLevel = false;
                                dimen1.FormBorderStyle = FormBorderStyle.None;
                                dimen1.Dock = DockStyle.Fill;
                            }

                            panel1.Controls.Add(dimen1);

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
            this.Update_Fore(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedMetod = 2;
            Program.GlobalVariables.selectedMethod = false;
            this.Update_Fore(sender, e);
        }


        private void back_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            if (mainPageForm == null)
            {
                mainPageForm = new MainPage();
                mainPageForm.TopLevel = false;
                mainPageForm.FormBorderStyle = FormBorderStyle.None;
                mainPageForm.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(mainPageForm);

            mainPageForm.Show();
        }

        private void AddMetal_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text;
            if (double.TryParse(DensityBox.Text, out double densityValue) &&
                double.TryParse(SpecificHeatBox.Text, out double specificHeatValue) &&
                double.TryParse(AlphaBox.Text, out double alphaValue))
            {
                string jsonString = string.Empty;

                if (File.Exists(jsonFilePath))
                {
                    jsonString = File.ReadAllText(jsonFilePath);
                    try
                    {
                        var metalData = System.Text.Json.JsonSerializer.Deserialize<MetalData>(jsonString);
                        metals = metalData.Metals;
                    }
                    catch (System.Text.Json.JsonException ex)
                    {
                        MessageBox.Show($"Ошибка десериализации JSON: {ex.Message}");
                        metals = new List<Metal>();
                    }
                }
                else
                {
                    metals = new List<Metal>();
                }

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

                var metalDataToUpdate = new MetalData { Metals = metals };
                jsonString = System.Text.Json.JsonSerializer.Serialize(metalDataToUpdate, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, jsonString);

                // Очищаем текстовые поля после добавления
                NameBox.Clear();
                DensityBox.Clear();
                SpecificHeatBox.Clear();
                AlphaBox.Clear();

                LoadMetalsData();

                MessageBox.Show("Металл успешно добавлен!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения.");
            }

        }

        private void DBMetals_Load(object sender, EventArgs e)
        {

        }

        private void DelMetal_Click(object sender, EventArgs e)
        {
            if (comboBoxMetals.SelectedIndex == -1)
            {
                MessageBox.Show("Металл не выбран для удаления!");
                return;
            }

            string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
            Metal selectedMetal = metals.FirstOrDefault(m => m.Name == selectedMetalName);

            if (selectedMetal != null)
            {
                // Удаление металла из списка
                metals.Remove(selectedMetal);

                // Обновление данных в файле metals.json
                UpdateMetalsFile();

                // Обновление выпадающего списка
                LoadMetalsData();

                MessageBox.Show($"Металл '{selectedMetal.Name}' успешно удален!");
            }
            else
            {
                MessageBox.Show("Ошибка при удалении металла!");
            }
        }

        private void UpdateMetalsFile()
        {
            var metalDataToUpdate = new MetalData { Metals = metals };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(metalDataToUpdate, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonString);
        }



    }

    // Classes for deserializing JSON
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
