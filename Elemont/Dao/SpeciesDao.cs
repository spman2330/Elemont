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
    }
}
