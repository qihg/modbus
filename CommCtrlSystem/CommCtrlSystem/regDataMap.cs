using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommCtrlSystem
{
    class regDataMap
    {
        public int controlItmeIndex{get; set;}
        public int regIndex { get; set; }
        public int valueType { get; set; }
        public Dictionary<int, string> strValue;
    }
}
