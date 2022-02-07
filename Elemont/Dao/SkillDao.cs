using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class SkillDao
    {
        private static SkillDao instance;
        public static SkillDao Instance
        {
            get
            {
                if (instance == null) instance = new SkillDao();
                return instance;
            }
        }
        public Skill GetskillById(int skillId)
        {
            string query = String.Format("SELECT * From dbo.skill WHERE dbo.skill.skillId =" +
              "N'{0}'", skillId);
            return new Skill(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public Skill[] GetSkillInConnection(int speciesId)
        {
            string query = String.Format("SELECT dbo.Skill.* FROM dbo.SkillConnection JOIN dbo.Skill ON dbo.Skill.skillId" +
                "=dbo.SkillConnection.skillId WHERE dbo.SkillConnection.speciesID =" +
                "N'{0}'", speciesId);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Skill(item)).ToArray();
        }
        public Skill[] GetAllSkill()
        {
            string query = "SELECT * From Skill";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Skill(item)).ToArray();
        }
        public bool AddSkill(Skill skill)
        {
            string query = String.Format(" INSERT INTO Skill(name, type, num, manaCost) " +
                "values(N'{0}', N'{1}', N'{2}', N'{3}')",
                skill.Name, skill.Type, skill.Num, skill.ManaCost);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeSkill(Skill skill)
        {
            string query = String.Format(" UPDATE Skill " +
               "SET name = N'{0}', type = N'{1}', num = N'{2}', manaCost = N'{3}'" +
               "WHERE skillId = N'{4}'",
               skill.Name, skill.Type, skill.Num, skill.ManaCost, skill.SkillId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}