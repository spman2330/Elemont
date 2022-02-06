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
            string query = String.Format("insert into Trainer (name, skinId, exp, gold, ball1Num, " +
                "ball2Num, ball3Num ,accountId)" +
                "values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')",
                trainer.Name, trainer.Skin.SkinId, trainer.Exp, trainer.Gold, trainer.Ball1Num, trainer.Ball2Num,
                trainer.Ball3Num, trainer.AccountId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }     
        public bool Updatetrainer(Trainer trainer)
        {
            string query = String.Format("UPDATE Trainer " +
                "SET name = N'{0}', skinId = N'{1}'," +
                " exp = N'{2}', gold = N'{3}' " +
                ",ball1Num = N'{4}'"+
                ",ball2Num = N'{5}'" +
                 ",ball3Num = N'{6}'" +
                "WHERE trainerId = N'{7}'",
              trainer.Name,trainer.Skin.SkinId,trainer.Exp,trainer.Gold,trainer.Ball1Num,trainer.Ball2Num,trainer.Ball3Num,trainer.TrainerId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
       
    }
}
