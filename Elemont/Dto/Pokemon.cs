using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Pokemon
    {
        private string name;
        private Species species;
        private int exp;
        private int? cellId;
        private int? trainerId;
        private Skill skill1;
        private Skill skill2;
        private int pokemonId;
        public int Level { get => exp/10; }
        public int Attack { get => Level+species.BaseAttack; }
        public int Defense { get => Level + species.BaseDefense; }
        public int HP { get => Level + species.BaseHp; }
        public string Name { get => name; set => name = value; }
        public Species Species { get => species; set => species = value; }
        public int Exp { get => exp; set => exp = value; }
        public int? CellId { get => cellId; set => cellId = value; }
        public int? TrainerId { get => trainerId; set => trainerId = value; }
        public Skill Skill1 { get => skill1; set => skill1 = value; }
        public Skill Skill2 { get => skill2; set => skill2 = value; }
        public int PokemonId { get => pokemonId; set => pokemonId = value; }
        public Pokemon(DataRow row)
        {
            Name = row["name"].ToString();
            Exp = Convert.ToInt32(row["exp"].ToString());
            if (!row.IsNull("cellId"))
                CellId = Convert.ToInt32(row["cellId"].ToString());
            if (!row.IsNull("trainerId"))
                TrainerId = Convert.ToInt32(row["trainerId"].ToString());
            PokemonId = Convert.ToInt32(row["pokemonId"].ToString());
            Species = SpeciesDao.Instance.GetSpeciesById(Convert.ToInt32(row["speciesId"].ToString()));
            Skill1 = SkillDao.Instance.GetskillById(Convert.ToInt32(row["skill1Id"].ToString()));
            Skill2 = SkillDao.Instance.GetskillById(Convert.ToInt32(row["skill2Id"].ToString()));
        }
        public Pokemon ()
        { }
    }

}
