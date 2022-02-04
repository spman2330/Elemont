using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class TrainerDao
    {
        private static TrainerDao instance;
        public static TrainerDao Instance
        {
            get
            {
                if (instance == null) instance = new TrainerDao();
                return instance;
            }
        }
        public Trainer[] GetTrainersByAccountId(int accountId)
        {
            string query = String.Format("SELECT * From dbo.Trainer WHERE dbo.Trainer.accountId =" +
              "N'{0}'", accountId);
            DataTable datatable = DataProvider.Instance.ExecuteQuery(query);
            Trainer[] trainers = datatable.AsEnumerable().Select(item => new Trainer(item)).ToArray();
            return trainers;
        }
    }
}
