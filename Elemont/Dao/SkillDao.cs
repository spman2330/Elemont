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
    }
}
