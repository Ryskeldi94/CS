using System;
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
        }
    }
}
