using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Species
    {
        private string name;
        private string image;
        private int baseAttack;
        private int baseDefense;
        private int baseHp;
        private Element element;
        private int speciesId;
        private Skill[] skills;

        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public int BaseAttack { get => baseAttack; set => baseAttack = value; }
        public int BaseDefense { get => baseDefense; set => baseDefense = value; }
        public int BaseHp { get => baseHp; set => baseHp = value; }
        public int SpeciesId { get => speciesId; set => speciesId = value; }
        public Element Element { get => element; set => element = value; }
        public Skill[] Skills { get => skills; set => skills = value; }

        public Species(DataRow row)
        {
            Name = row["name"].ToString();
            Image = row["image"].ToString();
            BaseAttack = Convert.ToInt32(row["baseAttack"].ToString());
            BaseDefense = Convert.ToInt32(row["baseDefense"].ToString());
            BaseHp = Convert.ToInt32(row["baseHp"].ToString());
            Element = ElementDao.Instance.GetElementById(Convert.ToInt32(row["elementId"].ToString()));
            SpeciesId = Convert.ToInt32(row["speciesId"].ToString());
            Skills = SkillDao.Instance.GetSkillInConnection(SpeciesId);
        }
    }
}
