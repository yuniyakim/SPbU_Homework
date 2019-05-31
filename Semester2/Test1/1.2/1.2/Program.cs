using System;
using System.Windows.Forms;

namespace _1._2
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormWithClickOnMeButton());
        }
    }
}

// Сделать форму с кнопкой, и чтобы кнопка "убегала" от курсора мыши. 
// По нажатию на кнопку программа должна заканчивать работу. Комментарии обязательны, юнит-тесты нSет.