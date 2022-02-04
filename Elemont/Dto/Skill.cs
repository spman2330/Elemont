using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Elemont.Dto
{
    public class Skill
    {
        private string name;
        private string type;
        private int num;
        private int manaCost;
        private int skillId;

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Num { get => num; set => num = value; }
        public int ManaCost { get => manaCost; set => manaCost = value; }
        public int SkillId { get => skillId; set => skillId = value; }
        public Skill(DataRow row)
        {
            Name = row["name"].ToString();
            Type = row["type"].ToString();
            Num = Convert.ToInt32(row["num"].ToString());
            ManaCost = Convert.ToInt32(row["manaCost"].ToString());
            SkillId = Convert.ToInt32(row["skillId"].ToString());
        }
    }
}
