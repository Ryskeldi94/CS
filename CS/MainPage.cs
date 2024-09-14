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
            InitializeComponent();
            ThemeHelper.UpdateTheme(this);
            ThemeHelper.ApplyLanguage(this);
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.Text == "English")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                Program.GlobalVariables.Language = "en";
            }
            
            if (languageComboBox.Text == "Русский")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
                Program.GlobalVariables.Language = "ru";
            }
            
            if (languageComboBox.Text == "Қазақша")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("kk-KZ");
                Program.GlobalVariables.Language = "kz";
            }

            this.Controls.Clear();
            
            InitializeComponent();
            ThemeHelper.UpdateTheme(this);

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
