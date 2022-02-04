using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Map
    {
        private string name;
        private string background;
        private int height;
        private int width;
        private int mapId;
        private Cell[] cells;
        public string Name { get => name; set => name = value; }
        public string Background { get => background; set => background = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public int MapId { get => mapId; set => mapId = value; }
        public Cell[] Cells { get => cells; set => cells = value; }

        public Map(DataRow row)
        {
            Name = row["name"].ToString();
            Background = row["background"].ToString();
            Height = Convert.ToInt32(row["height"].ToString());
            Width = Convert.ToInt32(row["height"].ToString());
            MapId = Convert.ToInt32(row["mapId"].ToString());
            Cells = CellDao.Instance.GetCellsByMapId(MapId);
        }
    }
}
