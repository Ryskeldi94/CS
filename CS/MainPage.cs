using CS.Properties;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Version2
{
    public partial class MainPage : Form
    {
        private DBMetals dbMetalsForm;


        public MainPage()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
            InitializeComponent();

            languageComboBox.SelectedIndex = 0;
            languageComboBox.SelectedIndexChanged += LanguageComboBox_SelectedIndexChanged;
        }

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedLanguage = (string)comboBox.SelectedItem;

            if (selectedLanguage == "English")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            }
            else if (selectedLanguage == "Русский")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            }
            else if (selectedLanguage == "Қазақша")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("");
            }

            UpdateFormTexts();
        }

        private void UpdateFormTexts()
        {
            
            this.ThemeComboBox.Items.AddRange(new object[] {
            Program.ResourceManager.GetString("ThemeWhite"),
            Program.ResourceManager.GetString("ThemeDark"),
            Program.ResourceManager.GetString("ThemeSystem")
            });

            label1.Text = Program.ResourceManager.GetString("WelcomeMessage");
            ChoiceShow.Text = Program.ResourceManager.GetString("Start");
            label2.Text = Program.ResourceManager.GetString("ChangeLanguage");
            label3.Text = Program.ResourceManager.GetString("ChangeTheme");

        }


        private void ChoiceShow_Click_1(object sender, EventArgs e)
        {
            // Очищаем панель panel1 перед добавлением нового контента
            panel1.Controls.Clear();

            // Создаем экземпляр формы DBMetals (если еще не создан)
            if (dbMetalsForm == null)
            {
                dbMetalsForm = new DBMetals();
                dbMetalsForm.TopLevel = false;
                dbMetalsForm.FormBorderStyle = FormBorderStyle.None;
                dbMetalsForm.Dock = DockStyle.Fill;
            }

            // Добавляем форму DBMetals на панель panel1
            panel1.Controls.Add(dbMetalsForm);

            // Отображаем форму DBMetals на панели panel1
            dbMetalsForm.Show();
        }

    }
}
