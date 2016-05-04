using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.globals
{
    public static class Global
    {

        static Database db = new Database();

        public static Database data
        {
            get
            {
                return db;
            }
            set {  }
        }
    }
}