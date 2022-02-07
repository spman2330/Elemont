using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Account
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int accountId;
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        private Trainer[] trainers;
        public Trainer[] Trainers { get => trainers; set => trainers = value; }

        public Account() { }
        public Account(DataRow row)
        {
            UserName = row["userName"].ToString();
            Password = row["password"].ToString();
            Type = Convert.ToInt32(row["type"].ToString());
            Name = row["name"].ToString();
            AccountId = Convert.ToInt32(row["accountId"].ToString());
            Trainers = TrainerDao.Instance.GetTrainersByAccountId(AccountId);
        }

        public Account(string userName, string password, int type, string name)
        {
            UserName = userName;
            Password = password;
            Type = type;
            Name = name;
        }
    }
}
