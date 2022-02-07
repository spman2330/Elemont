using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;
using Elemont.Gui;
using Elemont.Gui.FormAdmin;
using Elemont.Gui.Game;
using Elemont.Gui.GameManager;

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
            Application.Run(new fMap());
        }
    }
}
