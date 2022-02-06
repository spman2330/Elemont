using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Trainer
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private Skin skin;
        public Skin Skin
        {
            get { return skin; }
            set { skin = value; }
        }
        private int exp;
        public int Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        private int gold;
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        private int ball1Num;
        public int Ball1Num
        {
            get { return ball1Num; }
            set { ball1Num = value; }
        }
        private int ball2Num;
        public int Ball2Num
        {
            get { return ball2Num; }
            set { ball2Num = value; }
        }
        private int ball3Num;
        public int Ball3Num
        {
            get { return ball3Num; }
            set { ball3Num = value; }
        }
        private int trainerId;
        public int TrainerId
        {
            get { return trainerId; }
            set { trainerId = value; }
        }
        private int accountId;
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }

        private Pokemon[] pokemons;
        public Pokemon[] Pokemons { get => pokemons; set => pokemons = value; }


        public Trainer(DataRow row)
        {
            Name = row["name"].ToString();
            Skin = SkinDao.Instance.GetSkinById(Convert.ToInt32(row["skinId"].ToString()));
            Exp = Convert.ToInt32(row["exp"].ToString());
            Gold = Convert.ToInt32(row["gold"].ToString());
            Ball1Num = Convert.ToInt32(row["ball1Num"].ToString());
            Ball2Num = Convert.ToInt32(row["ball2Num"].ToString());
            Ball3Num = Convert.ToInt32(row["ball3Num"].ToString());
            TrainerId = Convert.ToInt32(row["trainerId"].ToString());
            AccountId = Convert.ToInt32(row["accountId"].ToString());
            Pokemons = PokemonDao.Instance.GetPokemonsByTrainerId(TrainerId);
        }
        public Trainer(int accountId, string name, int skinId)
        {
            AccountId = accountId;
            Name = name;
            Skin = SkinDao.Instance.GetSkinById(skinId);
            Exp = 0;
            Gold = 100;
            Ball1Num = 10;
            ball2Num = 5;
            ball3Num = 5;
        }
    }
}
