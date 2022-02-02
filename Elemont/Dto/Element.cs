using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Elemont.Dto
{
    public class Element
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string icon;
        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private int elementId;
        public int ElementId
        {
            get { return elementId; }
            set { elementId = value; }
        }

        public Element(DataRow row)
        {
            Name = row["name"].ToString();
            Icon = row["icon"].ToString();
            ElementId = Convert.ToInt32(row["elementId"].ToString());

        }
    }
}
