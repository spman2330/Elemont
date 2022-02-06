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
        public Cell GetCellById(int cellId)
        {
            string query = String.Format("SELECT * From dbo.Cell WHERE Dbo.Cell.cellId =" +
                "N'{0}'", cellId);
            return new Cell(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public bool AddCell(Cell cell)
        {
            string query = String.Format("insert into Cell (height, width, locationX, locationY, type, background, mapID)" +
                "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}',N'{5}', N'{6}')",
               cell.Height, cell.Width,cell.LocationX,cell.LocationY,cell.Type,cell.Background,cell.MapId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeCell(Cell cell)
        {         
            string query = String.Format("UPDATE Cell " +
                "SET height = N'{0}', width = N'{1}', locationX = N'{2}'," +
                " locationY = N'{3}'" +
                ",type = N'{4}'"+
                ",background = N'{5}'"+
                ", mapID = N'{6}'"+

                "WHERE cellId = N'{7}'",
            cell.Height,cell.Width,cell.LocationX,cell.LocationY,cell.Type,cell.Background,cell.MapId,cell.CellId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool DeleteCell(Cell cell)
        {
            string query = String.Format("DELETE FROM Cell " +
                "WHERE cellID = N'{0}'",
               cell.CellId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }

    }
}
