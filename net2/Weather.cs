using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net2
{
    public class Weather
    {
        public int visibility { set; get; }
        public Main main { get; set; }

        public List<weatherDescription> weather { get; set; }

        public class Main
        {
            public double temp { set; get; }
            public double temp_min { set; get; }
            public double temp_max { set; get; }
            public double pressure { set; get; }

        }

        public class weatherDescription
        {
            public string id { set; get; }
            public string main { set; get; }
            public string description { set; get; }
            public string icon { set; get; }
        }

    }
}
