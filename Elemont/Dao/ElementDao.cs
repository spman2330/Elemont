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
        public Element[] GetAllElements()
        {
            string query = "SELECT * FROM Element";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Element(item)).ToArray();
        }
        public bool DeleteElement(int elementId)
        {
            string query1 = String.Format("DELETE FROM dbo.Element WHERE dbo.Element.elementId =" +
                "N'{0}'", elementId);
            string query2 = String.Format("DELETE FROM dbo.Weak WHERE dbo.Weak.element1Id =" +
                "N'{0}' OR dbo.Weak.element2Id = N'{1}'", elementId, elementId);
            string query3 = String.Format("DELETE FROM dbo.Strong WHERE dbo.Strong.element1Id =" +
                "N'{0}' OR dbo.Strong.element2Id = N'{1}'", elementId, elementId);
            return (DataProvider.Instance.ExecuteNonQuery(query1) > 0 |
                DataProvider.Instance.ExecuteNonQuery(query2) > 0 |
                DataProvider.Instance.ExecuteNonQuery(query3) > 0);
        }

        public bool AddElement(Element element)
        {
            string query1 = String.Format("insert into Element (name,environment) " +
                "values (N'{0}' ,N'{1}') ", element.Name, element.Environment);
            bool ok = true;
            ok = ok | DataProvider.Instance.ExecuteNonQuery(query1) > 0;
            element.ElementId = instance.GetElementIdByName(element.Name);
            foreach (int id in element.Weak)
            {
                string query = String.Format("insert into Weak (element1Id, element2Id) " +
                "values (N'{0}' ,N'{1}') ", element.ElementId, id);
                ok = ok | DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            foreach (int id in element.Strong)
            {
                string query = String.Format("insert into Strong (element1Id, element2Id) " +
                "values (N'{0}' ,N'{1}') ", element.ElementId, id);
                ok = ok | DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            return ok;
        }
        public int GetElementIdByName(string name)
        {
            string query = String.Format("SELECT * FROM dbo.element WHERE dbo.element.name = " +
              "N'{0}'", name);
            return new Element(DataProvider.Instance.ExecuteQuery(query).Rows[0]).ElementId;
        }
        public bool ChangeElement(Element element)
        {
            string query1 = String.Format("UPDATE Element " +
                "SET name = N'{0}' ,environment = N'{1}' " +
                "WHERE elementId = N'{2}'", element.Name, element.Environment, element.ElementId);
            bool ok = true;
            string query2 = String.Format("DELETE FROM dbo.Weak WHERE dbo.Weak.element1Id =" +
                "N'{0}'", element.ElementId);
            string query3 = String.Format("DELETE FROM dbo.Strong WHERE dbo.Strong.element1Id =" +
                "N'{0}'", element.ElementId);

            ok = ok | DataProvider.Instance.ExecuteNonQuery(query1) > 0
                | DataProvider.Instance.ExecuteNonQuery(query2) > 0
                | DataProvider.Instance.ExecuteNonQuery(query3) > 0;
            foreach (int id in element.Weak)
            {
                string query = String.Format("insert into Weak (element1Id, element2Id) " +
                "values (N'{0}' ,N'{1}') ", element.ElementId, id);
                ok = ok | DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            foreach (int id in element.Strong)
            {
                string query = String.Format("insert into Strong (element1Id, element2Id) " +
                "values (N'{0}' ,N'{1}') ", element.ElementId, id);
                ok = ok | DataProvider.Instance.ExecuteNonQuery(query) > 0;
            }
            return ok;
        }
        public Pokemon[] GetAllPoke()
        {
            string query = "SELECT * FROM Account";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);
            return table.AsEnumerable().Select(item => new Pokemon(item)).ToArray();
        }
    }
}
