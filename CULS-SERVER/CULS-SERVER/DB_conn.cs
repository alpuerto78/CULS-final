using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CULS_SERVER
{
    class DB_conn
    {


    public string GetConnection()
        {
            //string cn = @"Data Source=.\SQLExpress; AttachDbFilename=|DataDirectory|\ComputerUsageLimiterSystem.mdf;Initial Catalog=ComputerUsageLimiterSystem;Integrated Security=True";  
            //return cn;
            string _data_source = System.Environment.MachineName;

            string cn = @"Data Source='"+_data_source+"'; Initial Catalog=ComputerUsageLimiterSystem;Integrated Security=True";  
            return cn;
        }
    }
}

