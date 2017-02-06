using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
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
