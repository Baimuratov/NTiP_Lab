using System;
using System.Windows.Forms;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            switch (args.Length)
            {
                case 0:
                    Application.Run(new MainForm(string.Empty));
                    break;
                case 1:
                    Application.Run(new MainForm(args[0]));
                    break;
            }
        }
    }
}
