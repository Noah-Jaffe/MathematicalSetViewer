using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MathematicalSetViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UnitTests UnitTester = new UnitTests();
            UnitTester.RunAllTests();
            Application.Run(new MainForm());
        }
    }
}
