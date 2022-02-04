using System;
using System.Collections.Generic;
using System.Text;

namespace Elemont.Dto
{
    public class Gameplay
    {
        Map map;
        Trainer trainer;
        public Map Maps
        {
            get { return map; }
            set { map = value; }
        }
        public Trainer Trainers
        {
            get { return trainer; }
            set { trainer = value; }
        }
    }
}
