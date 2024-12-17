using CS;
using CS.Properties;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace Version2
{
    public partial class MainPage : Form
    {
        private DBMetals dbMetalsForm;
        private SettingsPage SetForm;
        ResourceManager rm = new ResourceManager("CS.Resources.MessageBox", typeof(MainPage).Assembly);

        public MainPage()
        {
            var savedLanguage = CS.Properties.Settings.Default.UserSetLanguage;

            // Если язык не задан, по умолчанию ставим русский
            if (string.IsNullOrEmpty(savedLanguage))
            {
                savedLanguage = "ru-RU";
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(savedLanguage);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(savedLanguage);
            
            ThemeHelper.UpdateTheme(this);
            ThemeHelper.ApplyLanguage(this);
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e) //функция для начало
        {
            panel1.Controls.Clear();

            if (dbMetalsForm == null)
            {
                dbMetalsForm = new DBMetals();
                dbMetalsForm.TopLevel = false;
                dbMetalsForm.FormBorderStyle = FormBorderStyle.None;
                dbMetalsForm.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(dbMetalsForm);

            dbMetalsForm.Show();
          
        }

        private void SettingsButton_Click(object sender, EventArgs e) //функция для перехода к окну настройка
        {
            panel1.Controls.Clear();

            if (SetForm == null)
            {
                SetForm = new SettingsPage();
                SetForm.TopLevel = false;
                SetForm .FormBorderStyle = FormBorderStyle.None;
                SetForm .Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(SetForm);

            SetForm.Show();
        }

    }
}
