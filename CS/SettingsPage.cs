using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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

        public SettingsPage()
        {
            InitializeComponent();
            PathJson = CS.Properties.Settings.Default.UserFilePathForJson;
            PathServer = CS.Properties.Settings.Default.UserFilePathForServer;
        }

        string SelectedLanguage;
        string SelectedTheme;
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
                MessageBox.Show("Указанный файл с данными не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (System.IO.Path.GetExtension(filePath).ToLower() != ".json")
            {
                MessageBox.Show("Неверный формат файла данных. Ожидался файл формата JSON.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string jsonContent = System.IO.File.ReadAllText(filePath);
                var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonContent); // Если формат неверный, выбросит ошибку
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при чтении JSON файла. Проверьте его содержимое.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
 
        private bool IsServerFileValid(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("Указанный серверный файл не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверка расширения файла
            if (System.IO.Path.GetExtension(filePath).ToLower() != ".exe")
            {
                MessageBox.Show("Неверный формат файла сервера. Ожидался файл формата .exe.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Process serverProcess = null;
            try
            {
                ProcessStartInfo serverStartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = false,
                    CreateNoWindow = true, // Скрываем консольное окно
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                // Запуск сервера
                serverProcess = Process.Start(serverStartInfo);
                if (serverProcess == null)
                {
                    MessageBox.Show("Не удалось запустить сервер.");
                    return false;
                }

                // Даем серверу время для запуска
                System.Threading.Thread.Sleep(1000);

                // Попытка подключения к серверу
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", 54000); // Попытка подключения
                    NetworkStream stream = client.GetStream();

                    // Отправка тестовых данных на сервер для проверки
                    double density = 7.78;
                    double specificHeat = 0.449;
                    double alpha = 80.2;
                    int highTempLocation = 5;
                    float initialTemperature = 100.0f;
                    float ambientTemperature = 20.0f;
                    int nx = 10;
                    int calculationType = 1;
                    int numSteps = 10;

                    // Отправка данных
                    stream.Write(BitConverter.GetBytes(calculationType), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(density), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(specificHeat), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(alpha), 0, sizeof(double));
                    stream.Write(BitConverter.GetBytes(highTempLocation), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(initialTemperature), 0, sizeof(float));
                    stream.Write(BitConverter.GetBytes(ambientTemperature), 0, sizeof(float));
                    stream.Write(BitConverter.GetBytes(numSteps), 0, sizeof(int));
                    stream.Write(BitConverter.GetBytes(nx), 0, sizeof(int));

                    // Ожидание ответа от сервера
                    byte[] buffer = new byte[sizeof(double) * nx * numSteps];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    // Закрытие соединения
                    stream.Close();

                    if (bytesRead == sizeof(double) * nx * numSteps)
                    {
                        return true; // Сервер корректен и ответил
                    }
                    else
                    {
                        MessageBox.Show("Сервер дал некорректный ответ.");
                        return false;
                    }
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Не удалось подключиться к серверу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка проверки сервера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //finally
            //{
            //    // завершение работы сервера
            //    if (serverprocess != null && !serverprocess.hasexited)
            //    {
            //        serverprocess.kill(); 
            //    }
            //}
        }


    }
}
