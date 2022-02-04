using System;
using System.Data;
using Elemont.Dao;

namespace Elemont.Dto
{
    public class Cell
    {
        private int height;
        private int width;
        private int locationX;
        private int locationY;
        private string type;
        private string background;
        private int mapId;
        private int cellId;
        private Pokemon[] pokemons;

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public int LocationX { get => locationX; set => locationX = value; }
        public int LocationY { get => locationY; set => locationY = value; }
        public string Type { get => type; set => type = value; }
        public string Background { get => background; set => background = value; }
        public int MapId { get => mapId; set => mapId = value; }
        public int CellId { get => cellId; set => cellId = value; }
        public Pokemon[] Pokemons { get => pokemons; set => pokemons = value; }

        public Cell(DataRow row)
        {
            Height = Convert.ToInt32(row["height"].ToString());
            Width = Convert.ToInt32(row["width"].ToString());
            LocationX = Convert.ToInt32(row["locationX"].ToString());
            LocationY = Convert.ToInt32(row["locationY"].ToString());
            Type = row["type"].ToString();
            Background = row["background"].ToString();
            MapId = Convert.ToInt32(row["mapId"].ToString());
            CellId = Convert.ToInt32(row["cellId"].ToString());
            Pokemons = PokemonDao.Instance.GetPokemonsByCellId(CellId);
        }
    }
}
