using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Version2.AddMetal;

namespace Version2
{
    public partial class DBMetals : Form
    {
        private List<Metal> metalsList; // объявляем переменную как член класса
        int selectedMetod = 0;
        public DBMetals()
        {
            InitializeComponent();
            comboBoxMetals.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadMetalsData();
            this.KeyPreview = true;
            this.KeyDown += Singl_KeyDown;
            SetTabIndexes();
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
                            Singl form = new Singl(density, specificHeat, alpha); // Передача значений в конструктор
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            TDimen dimen = new TDimen(density, specificHeat, alpha);
                            dimen.Show();
                            this.Hide();
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
            // Create an instance of MainPage and show it
            MainPage mainPage = new MainPage();
            mainPage.Show(); // Show the instance
            this.Close(); // Close the current form
        }

        private void AddMetal_Click(object sender, EventArgs e)
        {
            AddMetal Addmetal = new AddMetal();
            Addmetal.Show();
            this.Hide();
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
