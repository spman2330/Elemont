using System;
using System.Windows.Forms;
using Elemont.Gui;
using Elemont.Gui.AccountManager;

namespace Elemont
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fPlayerManage());
        }
    }
}
