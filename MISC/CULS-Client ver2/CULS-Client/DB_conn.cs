using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CULS_Client
{
    class DB_conn
    {
        public string GetConnection()
        {
         //   string cn = @"Data Source=.\SQLExpress; AttachDbFilename=|DataDirectory|\CULS-Client.mdf;Initial Catalog=ComputerUsageLimiterSystem;Integrated Security=True";  
          //  return cn;

           string cn = @"Data Source=.\SQLExpress; Initial Catalog=CULS-Client;Integrated Security=True";
           return cn;
        }
    }
}
