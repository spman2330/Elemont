using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    public class SkinDao
    {
        private static SkinDao instance;
        public static SkinDao Instance
        {
            get
            {
                if (instance == null) instance = new SkinDao();
                return instance;
            }
        }
        public Skin[] GetSkins()
        {
            string query = "SELECT * FROM dbo.Skin ";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Skin(item)).ToArray();
        }
        public Skin GetSkinById(int skinId)
        {
            string query = String.Format("SELECT * FROM dbo.Skin WHERE dbo.Skin.skinId = " +
                "N'{0}'", skinId);
            return new Skin(DataProvider.Instance.ExecuteQuery(query).Rows[0]);
        }
        public bool AddSkin(Skin skin)
        {
            string query = String.Format("insert into Skin (avatar, up, down, " +
                "[right], [left], name)" +
                "values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')",
                skin.Avatar, skin.Up, skin.Down, skin.Right, skin.Left, skin.Name);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool ChangeSkin(Skin skin)
        {
            string query = String.Format("UPDATE Skin " +
                "SET avatar = N'{0}', up = N'{1}', down = N'{2}'," +
                " [right] = N'{3}', [left] = N'{4}', name = N'{5}'" +
                "WHERE skinID = N'{6}'",
               skin.Avatar, skin.Up, skin.Down, skin.Right, skin.Left, skin.Name, skin.SkinId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
        public bool DeleteSkin(Skin skin)
        {
            string query = String.Format("DELETE FROM Skin " +
                "WHERE skinID = N'{0}'",
               skin.SkinId);
            return DataProvider.Instance.ExecuteNonQuery(query) > 0;
        }
    }
}
