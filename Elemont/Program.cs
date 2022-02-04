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
            Map[] a = MapDao.Instance.GetMaps();
            Account b = AccountDao.Instance.GetAccount("tk1", "tk1");
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fBattle(b.Trainers[0].Pokemons[0], a[0].Cells[0].Pokemons[0]));
        }
    }
}
