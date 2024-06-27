using System;
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

            public static string ButForeColor { get; set; }
        }

        public static class ResourceManager
        {
            private static System.Resources.ResourceManager _resourceManager;

            static ResourceManager()
            {
                _resourceManager = new System.Resources.ResourceManager("Version2.Resources", typeof(ResourceManager).Assembly);
            }

            public static string GetString(string key)
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
                return _resourceManager.GetString(key, currentCulture);
            }
        }

    }
}
