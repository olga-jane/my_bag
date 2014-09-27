using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxDemoTest
{
    class Language
    {
        public Language(string lngName, string lngValue)
        {
            LngName = lngName;
            LngValue = lngValue;
        }

        public string LngName { get; set; }

        public string LngValue { get; set; }

        override public string ToString()
        {
            return LngName;
        }
    }
}
