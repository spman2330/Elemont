using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public Account GetAccountById(int accountId)
        {
            string query = String.Format("SELECT * FROM dbo.account WHERE dbo.account.accountId = " +
               "N'{0}'", accountId);
            return new Account(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public bool AddAccount(Account account)
        {
            string query = String.Format("insert into Account (userName, password, type, name)" +
                "values (N'{0}', N'{1}', N'{2}', N'{3}')",
                account.UserName, account.Password, account.Type, account.Name);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeAccount(Account account)
        {
            string query = String.Format("UPDATE Account " +
                "SET userName = N'{0}', password = N'{1}'," +
                " type = N'{2}', name = N'{3}' " +
                "WHERE accountId = N'{4}'",
              account.UserName, account.Password, account.Type, account.Name, account.AccountId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool DeleteAccount(Account account)
        {
            string query = String.Format("DELETE FROM Account " +
                "WHERE accountId = N'{0}'",
               account.AccountId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public Account[] GetAllAccounts()
        {
            string query = "SELECT * FROM Account";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Account(item)).ToArray();
        }
    }
}
