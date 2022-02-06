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
        public Trainer GetTrainerById(int trainerId)
        {
            string query = String.Format("SELECT * From dbo.Trainer WHERE dbo.Trainer.trainerId =" +
              "N'{0}'", trainerId);
            return new Trainer(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public bool RemoveTrainerById(int trainerId)
        {
            string query = String.Format("DELETE FROM dbo.Trainer WHERE dbo.Trainer.trainerId =" +
              "N'{0}'", trainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool AddTrainer(Trainer trainer)
        {
            string query = String.Format("insert into Trainer (name, skin, exp, gold, ball1Num, " +
                "ball2Num, ball3Num ,accountId)" +
                "values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')",
                trainer.Name, trainer.Skin, trainer.Exp, trainer.Gold, trainer.Ball1Num, trainer.Ball2Num,
                trainer.Ball3Num, trainer.AccountId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool Rename(Trainer trainer,string name)
        {
            string query = String.Format("UPDATE dbo.Trainer " +
                "SET dbo.Trainer.Name = N'{0}' " +
                "WHERE TrainerId = N'{1}'", name,trainer.TrainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool buyball(Trainer trainer, int ball)
        {
            string query = String.Format("UPDATE dbo.Trainer " +
                "SET dbo.Trainer.ball1Num = N'{0}' " +
                "WHERE TrainerId = N'{1}'", ball, trainer.TrainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool updateexp(Trainer trainer, int exp)
        {
            string query = String.Format("UPDATE dbo.Trainer " +
                "SET dbo.Trainer.Exp = N'{0}' " +
                "WHERE TrainerId = N'{1}'", exp, trainer.TrainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool updategold(Trainer trainer, int gold)
        {
            string query = String.Format("UPDATE dbo.Trainer " +
                "SET dbo.Trainer.gold = N'{0}' " +
                "WHERE TrainerId = N'{1}'", gold, trainer.TrainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
