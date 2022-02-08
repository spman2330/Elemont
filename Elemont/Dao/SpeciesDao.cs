using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class SpeciesDao
    {
        private static SpeciesDao instance;
        public static SpeciesDao Instance
        {
            get
            {
                if (instance == null) instance = new SpeciesDao();
                return instance;
            }
        }
        public Species GetSpeciesById(int speciesId)
        {
            string query = String.Format("SELECT * From dbo.Species WHERE dbo.Species.speciesId =" +
              "N'{0}'", speciesId);
            return new Species(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public Species[] GetAllSpecies()
        {
            string query = "SELECT * From Species";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Species(item)).ToArray();
        }
        public bool AddSpecies(Species species)
        {
            string query = String.Format("insert into Species (name, elementId, baseAttack, " +
                "baseDefense, baseHp, image)" +
                "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",
                species.Name, species.Element.ElementId, species.BaseAttack, species.BaseDefense,
                species.BaseDefense, species.Image);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeSpecies(Species species)
        {
            string query = String.Format("Update Species " +
                "SET name = N'{0}', elementId = N'{1}' , baseAttack = N'{2}', " +
                "baseDefense=N'{3}', baseHp = N'{4}', image=N'{5}' " +
                "WHERE speciesId = N'{6}'",
                species.Name, species.Element.ElementId, species.BaseAttack, species.BaseDefense,
                species.BaseDefense, species.Image, species.SpeciesId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool RemoveSpeciesById(int speciesId)
        {
            string query = String.Format("DELETE FROM dbo.Species WHERE dbo.Species.speciesId =" +
              "N'{0}'", speciesId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
