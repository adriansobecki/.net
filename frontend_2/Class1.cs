using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend_2
{
    public class database
    {
        public int ID { set; get; }
        public string name { set; get; }
        public string datatime { set; get; }
        public double temp { set; get; }
        public string description { set; get; }
    }

    public class databaseWeather : DbContext
    {
        public virtual DbSet<database> databaseWeathers { get; set; }
    }

}
