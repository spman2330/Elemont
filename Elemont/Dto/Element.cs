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
        private int[] weak;
        public int[] Weak
        {
            get { return weak; }
            set { weak = value; }
        }
        private int[] strong;
        public int[] Strong
        {
            get { return strong; }
            set { strong = value; }
        }

        private string environment;
        public string Environment { get => environment; set => environment = value; }

        public Element(DataRow rowElement, int[] weaks, int[] strongs)
        {
            Name = rowElement["name"].ToString();
            Icon = rowElement["icon"].ToString();
            ElementId = Convert.ToInt32(rowElement["elementId"].ToString());
            Environment = rowElement["environment"].ToString();
            Weak = weaks;
            Strong = strongs;
        }
        public Element(DataRow rowElement)
        {
            Name = rowElement["name"].ToString();
            Icon = rowElement["icon"].ToString();
            ElementId = Convert.ToInt32(rowElement["elementId"].ToString());
            Environment = rowElement["environment"].ToString();
        }
    }
}
