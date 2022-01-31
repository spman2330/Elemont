using System;
using System.Collections.Generic;
using System.Text;

namespace Elemont.Dto
{
    public class Element
    {
        public string name;
        public string icon;
        public List<Element> effective;
        public List<Element> noteffective;
        public int id;

    }
}
