using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CULS_SERVER
{
    class ClassDB
    {
    public string GetConnection()
        {
            string cn = @"Data Source=localhost;Initial Catalog=ComputerUsageLimiterSystem;Integrated Security=True";
            return cn;
        }
    }
}
