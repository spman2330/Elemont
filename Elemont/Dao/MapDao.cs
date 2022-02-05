using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class MapDao
    {
        private static MapDao instance;
        public static MapDao Instance
        {
            get
            {
                if (instance == null) instance = new MapDao();
                return instance;
            }
        }
        public Map[] GetMaps()
        {
            string query = "SELECT * From dbo.Map";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Map(item)).ToArray();
        }
        public Map GetMapById(int mapId)
        {
            string query = String.Format("SELECT * From dbo.Map WHERE Dbo.Map.mapId =" +
                "N'{0}'", mapId);
            return new Map(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
    }
}
