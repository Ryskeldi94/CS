using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version2;

namespace CS
{
    public partial class SettingsPage : Form
    {
        private MainPage mainPage;
        ResourceManager rm = new ResourceManager("CS.Resources.MessageBox", typeof(MainPage).Assembly);
        
        public SettingsPage()
        {

            InitializeComponent();
            PathJson = CS.Properties.Settings.Default.UserFilePathForJson;
            PathServer = CS.Properties.Settings.Default.UserFilePathForServer;
            SelectedLanguage = CS.Properties.Settings.Default.UserSetLanguage;
            SelectedTheme = Program.GlobalVariables.Theme;
        }

        string SelectedLanguage = Program.GlobalVariables.Language;
        string SelectedTheme = Program.GlobalVariables.Theme;
        string PathServer;
        string PathJson;

        
        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.Text == "English")
            {
                SelectedLanguage = "en";
            }

            if (languageComboBox.Text == "Русский")
            {
                SelectedLanguage = "ru";
            }

            if (languageComboBox.Text == "Қазақша")
            {
                SelectedLanguage = "kz";
            }
        }

        private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ThemeComboBox.SelectedIndex == 2)
            {

                if (ThemeHelper.IsDarkModeEnabled())
                {
                    SelectedTheme = "dark";
                }
                else
                {
                    SelectedTheme = "White";
                }
            }
            else if (ThemeComboBox.SelectedIndex == 1)
            {
                SelectedTheme = "dark";
            }
            else if (ThemeComboBox.SelectedIndex == 0)
            {
                SelectedTheme = "White";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!IsJsonFileValid(PathJson))
            {
                return;
            }

            if (!IsServerFileValid(PathServer))
            {
                return;
            }

            // Сохраняем язык и тему в глобальные переменные
            CS.Properties.Settings.Default.UserSetLanguage = SelectedLanguage;
            Program.GlobalVariables.Language = SelectedLanguage;
            Program.GlobalVariables.Theme = SelectedTheme;

            // Сохраняем пути в пользовательские настройки
            CS.Properties.Settings.Default.UserFilePathForJson = PathJson;
            CS.Properties.Settings.Default.UserFilePathForServer = PathServer;

            // Сохраняем изменения в файл конфигурации
            CS.Properties.Settings.Default.Save();

            panel1.Controls.Clear();

            if (mainPage == null)
            {
                mainPage = new MainPage();
                mainPage.TopLevel = false;
                mainPage.FormBorderStyle = FormBorderStyle.None;
                mainPage.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(mainPage);

            mainPage.Show();
        }

        private void CancerButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            if (mainPage == null)
            {
                mainPage = new MainPage();
                mainPage.TopLevel = false;
                mainPage.FormBorderStyle = FormBorderStyle.None;
                mainPage.Dock = DockStyle.Fill;
            }

            panel1.Controls.Add(mainPage);

            mainPage.Show();
        }

        private void BrowsButtonServer_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"; // Фильтр для exe-файлов и всех файлов
                openFileDialog.Title = "Выберите файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sender == BrowseButtonServer)
                    {
                        serverPathTextBox.Text = openFileDialog.FileName; 
                        PathServer = serverPathTextBox.Text;
                    }
                }
            }
        }

        private void BrowsButtonJson_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл с данными";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    JsonPathTextBox.Text = openFileDialog.FileName;
                    PathJson = JsonPathTextBox.Text;
                }
            }
        }

        private bool IsJsonFileValid(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show(rm.GetString("MetalsJsonNotF"), rm.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (System.IO.Path.GetExtension(filePath).ToLower() != ".json")
            {
                MessageBox.Show("Неверный формат файла данных. Ожидался файл формата JSON.", rm.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string jsonContent = System.IO.File.ReadAllText(filePath);
                var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonContent); // Если формат неверный, выбросит ошибку
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при чтении JSON файла. Проверьте его содержимое.", rm.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsServerFileValid(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("Указанный серверный файл не существует!", rm.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка расширения файла
            if (System.IO.Path.GetExtension(filePath).ToLower() != ".exe")
            {
                MessageBox.Show("Неверный формат файла сервера. Ожидался файл формата .exe.", rm.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
