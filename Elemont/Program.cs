using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Elemont.Dao;
using Elemont.Dto;
using Elemont.Gui;
using Elemont.Gui.Game;

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
            Account b = AccountDao.Instance.GetAccount("tk1", "tk1");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BeginForm(b));
        }
    }
}
