using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dto;
using System.Linq;
namespace Elemont.Dao
{
    public class ElementDao
    {
        private static ElementDao instance;
        public static ElementDao Instance
        {
            get
            {
                if (instance == null) instance = new ElementDao();
                return instance;
            }
        }
        public Element GetElementById(int elementId)
        {
            string query = String.Format("SELECT * FROM dbo.element WHERE dbo.element.elementId = " +
               "N'{0}'", elementId);
            DataRow rowElement = DataProvider.Instance.ExecuteQuery(query).Rows[0];

            query = String.Format("SELECT element2id FROM dbo.Weak WHERE dbo.Weak.element1Id = " +
               "N'{0}'", elementId);
            DataTable weakTable = DataProvider.Instance.ExecuteQuery(query);
            int[] weaks = weakTable.AsEnumerable().Select(item => Convert.ToInt32(item["element2Id"].ToString())).ToArray();

            query = String.Format("SELECT element2id FROM dbo.Strong WHERE dbo.Strong.element1Id = " +
              "N'{0}'", elementId);
            DataTable strongTable = DataProvider.Instance.ExecuteQuery(query);
            int[] strongs = strongTable.AsEnumerable().Select(item => Convert.ToInt32(item["element2Id"].ToString())).ToArray();

            return new Element(rowElement, weaks, strongs);
        }
    }
}
