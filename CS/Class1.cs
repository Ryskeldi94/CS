using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Version2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPage());
        }

        public static class GlobalVariables
        {
            public static bool selectedMethod { get; set; }

            public static string Back_Color { get; set; }

            public static string Theme { get; set; } = "light";

            public static string Language { get; set; } = "ru";
        }
    }

    public static class ThemeHelper
    {
        public static bool IsDarkModeEnabled()
        {
            bool isDarkMode = false;

            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                if (key != null)
                {
                    object registryValue = key.GetValue("AppsUseLightTheme");
                    if (registryValue != null && registryValue is int && (int)registryValue == 0)
                    {
                        isDarkMode = true;
                    }
                }
            }

            return isDarkMode;
        }

        public static void UpdateTheme(Form form)
        {
            if (Program.GlobalVariables.Theme == null)
            {
                return;
            }

            Color backColor, foreColor, buttonBackColor, buttonForeColor, textBoxBackColor, textBoxForeColor;

            if (Program.GlobalVariables.Theme == "dark")
            {
                backColor = System.Drawing.Color.FromArgb(36, 36, 36); // Темно-серый фон
                foreColor = System.Drawing.Color.White; // Белый текст
                buttonBackColor = System.Drawing.Color.FromArgb(50, 50, 50); // Темно-серый фон для кнопок
                buttonForeColor = System.Drawing.Color.White; // Белый текст для кнопок
                textBoxBackColor = System.Drawing.Color.FromArgb(50, 50, 50); // Темно-серый фон для текстовых полей
                textBoxForeColor = System.Drawing.Color.White; // Белый текст для текстовых полей
            }
            else
            {
                backColor = System.Drawing.Color.White;
                foreColor = System.Drawing.Color.DarkBlue;
                buttonBackColor = System.Drawing.Color.LightGray;
                buttonForeColor = System.Drawing.Color.DarkBlue;
                textBoxBackColor = System.Drawing.Color.White;
                textBoxForeColor = System.Drawing.Color.Black;
            }

            form.BackColor = backColor;
            form.ForeColor = foreColor;

            foreach (Control control in form.Controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = backColor;
                    UpdateControlColors(panel.Controls, backColor, foreColor, buttonBackColor, buttonForeColor, textBoxBackColor, textBoxForeColor);
                }
                else if (control is Button button)
                {
                    if (button.Name == "back")
                    {

                    }
                    else
                    {
                        button.BackColor = buttonBackColor;
                        button.ForeColor = buttonForeColor;
                        button.FlatAppearance.BorderSize = 0;
                        button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(80, 80, 80); // Цвет при наведении мыши
                    }
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = textBoxBackColor;
                    textBox.ForeColor = textBoxForeColor;
                }
                else
                {
                    control.BackColor = backColor;
                    control.ForeColor = foreColor;
                }
            }
        }

        private static void UpdateControlColors(Control.ControlCollection controls, Color backColor, Color foreColor, Color buttonBackColor, Color buttonForeColor, Color textBoxBackColor, Color textBoxForeColor)
        {
            foreach (Control control in controls)
            {
                if (control is Panel panel)
                {
                    panel.BackColor = backColor;
                    UpdateControlColors(panel.Controls, backColor, foreColor, buttonBackColor, buttonForeColor, textBoxBackColor, textBoxForeColor);
                }
                else if (control is Button button)
                {
                    button.BackColor = buttonBackColor;
                    button.ForeColor = buttonForeColor;
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(80, 80, 80); // Цвет при наведении мыши
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = textBoxBackColor;
                    textBox.ForeColor = textBoxForeColor;
                }
                else
                {
                    control.BackColor = backColor;
                    control.ForeColor = foreColor;
                }
            }
        }

        public static void ApplyLanguage(Form form)
        {
            if (Program.GlobalVariables.Language == "en")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            else if (Program.GlobalVariables.Language == "ru")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            }
            else if (Program.GlobalVariables.Language == "kz")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("kk-KZ");
            }
        }

        private static void Button_Paint(object sender, PaintEventArgs e) {
            Button btn = sender as Button;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(btn.Width - 21, 0, 20, 20, 270, 90);
            path.AddArc(btn.Width - 21, btn.Height - 21, 20, 20, 0, 90);
            path.AddArc(0, btn.Height - 21, 20, 20, 90, 90);
            path.CloseAllFigures();
            btn.FlatAppearance.BorderSize = 0;
            btn.Region = new Region(path);
        }

    }
}
