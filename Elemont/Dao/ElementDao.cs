using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Elemont.Dto;

namespace Elemont.Dao
{
    class ElementDao
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
        public Element getElement()
        {
            string query = "SELECT name ,icon  , elementId  FROM dbo.element WHERE dbo.element.elementId=2";
            object[] parameter = { };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameter);
            Element nhanVien = new Element(data.Rows[0]);
            return nhanVien;
        }
    }
}
