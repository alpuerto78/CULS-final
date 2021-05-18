using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CULS_Client
{
    class Digit_counter
    {

        //Digit counter external
        private static int counter;
        public int Counter()
        {
                        
            int count = 0;
            while (counter != 0)
            {
                counter = counter / 10;
                ++count;
            }
            
            return count;


        }
        //Digit Counter handler -Sec
        private static string dc_sec;
        public string DC_sec
        {
            get
            {
                return dc_sec;
            }
            set
            {
                dc_sec = value;
            }
        }
        //Digit Counter handler -Min
        private static string dc_min;
        public string DC_min
        {
            get
            {
                return dc_min;
            }
            set
            {
                dc_min = value;
            }
        }
        //Digit Counter handler -Hour
        private static string dc_hour;
        public string DC_hour
        {
            get
            {
                return dc_hour;
            }
            set
            {
                dc_hour = value;
            }
        }
    }
}
