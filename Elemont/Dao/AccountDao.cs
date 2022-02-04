using System;
using System.Collections.Generic;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class AccountDao
    {
        private static AccountDao instance;
        public static AccountDao Instance
        {
            get
            {
                if (instance == null) instance = new AccountDao();
                return instance;
            }
        }
        public bool CheckAccount(string userName, string password)
        {
            string query = String.Format("SELECT * FROM dbo.account WHERE dbo.account.username = " +
                "N'{0}' AND dbo.account.password = N'{1}'", userName, password);
            return DataProvider.Instance.ExecuteQuery(query).Rows.Count > 0;
        }
        public Account GetAccount(string userName, string password)
        {
            string query = String.Format("SELECT * FROM dbo.account WHERE dbo.account.username = " +
               "N'{0}' AND dbo.account.password = N'{1}'", userName, password);
            return new Account(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
    }
}
