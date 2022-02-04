using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class CellDao
    {
        private static CellDao instance;
        public static CellDao Instance
        {
            get
            {
                if (instance == null) instance = new CellDao();
                return instance;
            }
        }
        public Cell[] GetCellsByMapId(int mapId)
        {
            string query = String.Format("SELECT * FROM dbo.Cell WHERE dbo.Cell.mapId =" +
                "N'{0}'", mapId);
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Cell(item)).ToArray();
        }
    }
}
