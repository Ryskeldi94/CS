using CS;
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
        private SettingsPage SetForm;

        public MainPage()
        {
            InitializeComponent();
            ThemeHelper.UpdateTheme(this);
            ThemeHelper.ApplyLanguage(this); 
        }

        private void ChoiceShow_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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
