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
        public bool AddMap(Map map)
        {
            string query = String.Format("insert into Map (name, background, height, width)" +
                "values (N'{0}', N'{1}', N'{2}', N'{3}')",
                map.Name, map.Background, map.Height, map.Width);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeMap(Map map)
        {
            string query = String.Format("UPDATE Map " +
                "SET name = N'{0}', background = N'{1}', height = N'{2}'," +
                " width = N'{3}'" +
                "WHERE mapId = N'{4}'",
               map.Name, map.Background, map.Height, map.Width, map.MapId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool DeleteMap(Map map)
        {
            string query = String.Format("DELETE FROM Map " +
                "WHERE mapID = N'{0}'",
               map.MapId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
