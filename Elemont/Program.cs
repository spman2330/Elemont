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
            //account c = new account("tk2", "tk2", 0, "name");
            //account d = new account("tk2", "tk2", 0, "name");
            //account e = new account("tk2", "tk2", 0, "name");
            //account f = accountdao.instance.getaccountbyid(1);
            //accountdao.instance.addaccount(c);
            //c = accountdao.instance.getaccountbyid(2);
            //accountdao.instance.addaccount(d);
            //d = accountdao.instance.getaccountbyid(3);
            //accountdao.instance.addaccount(e);
            //e = accountdao.instance.getaccountbyid(4);
            //e.name = "gà";
            //accountdao.instance.deleteaccount(d);
            //accountdao.instance.changeaccount(e);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BeginForm(b));
        }
    }
}
