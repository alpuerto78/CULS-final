using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace CULS_SERVER
{
    //object
    //object+function=method
    //object+variables=instance variables or attributes
    class User
    {
        //instance variable
        private static string id_handler;
        private static string image_handler;
        private static string uid_handler;
        private static string time_limit_handler;
        //  private static TcpClient tcp_handler;
        //set and get ID_Handler use in Dash
        //
        public string ID_handler
        {
            get
            {
                return id_handler;
            }
            set
            {
                id_handler = value;
            }
        }

        //set and get Image_Handler use in Dash
        public string Image_handler
        {
            get
            {
                return image_handler;
            }
            set
            {
                image_handler = value;
            }
        }

        //set and get UID use in Manage user svalidation update
        public string UID_handler
        {
            get
            {
                return uid_handler;
            }
            set
            {
                uid_handler = value;
            }
        }
        //set and get UID use in Manage user svalidation update
        public string Time_limit_handler
        {
            get
            {
                return time_limit_handler;
            }
            set
            {
                time_limit_handler = value;
            }
        }



    }
    //Usertype
    class Usertype
    {

        public string student = "student";
        public string employee = "employee";
        public string alumni = "alumni";
        public string visitor = "visitor";

    }
    class Terminal_handler
    {
        //count pc handler 
        private static string count_PC;
        private static string count_IDLE;
        private static string count_OFF;
        private static string count_USE;

        public string Count_PC
        {
            get
            {
                return count_PC;
            }
            set
            {
                count_PC = value;
            }
        }
        //status og pc 
        public string Count_IDLE
        {
            get
            {
                return count_IDLE;
            }
            set
            {
                count_IDLE = value;
            }
        }
        public string Count_OFF
        {
            get
            {
                return count_OFF;
            }
            set
            {
                count_OFF = value;
            }
        }
        public string Count_USE
        {
            get
            {
                return count_USE;
            }
            set
            {
                count_USE = value;
            }
        }


        //set max pc
        private int max_PC = 20;

        public int Max_PC
        {
            get
            {
                return max_PC;
            }
            set
            {
                max_PC = value;
            }
        }
    }
    class User_Sessions
    {

        private static string uid;

        public string RFID_UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }
    }
    class Current_Sessions
    {

        private static string uid;
        private static string login;
        public string RFID_UID
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
    }
    class Handler_Logout
    {

        private static string pre_logout_id;
        private static string post_logout_id;
        public string PRE_Logout_id
        {
            get
            {
                return pre_logout_id;
            }
            set
            {
                pre_logout_id = value;
            }
        }
        public string POST_Logout_id
        {
            get
            {
                return post_logout_id;
            }
            set
            {
                post_logout_id = value;
            }
        }
    }
    //REPORTS HANDLERS//
    class Daily_Report_Fields
    {
        private static string daily_report_field_date;
        public string Daily_report_field_date
        {
            get
            {
                return daily_report_field_date;
            }
            set
            {
                daily_report_field_date = value;
            }
        }
        private static string daily_report_field_area;
        public string Daily_report_field_area
        {
            get
            {
                return daily_report_field_area;
            }
            set
            {
                daily_report_field_area = value;
            }
        }
        private static string daily_report_field_prepared;
        public string Daily_report_field_prepared
        {
            get
            {
                return daily_report_field_prepared;
            }
            set
            {
                daily_report_field_prepared = value;
            }
        }
        private static string daily_report_field_noted;
        public string Daily_report_field_noted
        {
            get
            {
                return daily_report_field_noted;
            }
            set
            {
                daily_report_field_noted = value;
            }
        }
    }



    class Monthly_Report_Fields
    {
        private static string monthly_report_field_month;
        public string Monthly_report_field_month
        {
            get
            {
                return monthly_report_field_month;
            }
            set
            {
                monthly_report_field_month = value;
            }
        }
        private static string monthly_report_field_year;
        public string Monthly_report_field_year
        {
            get
            {
                return monthly_report_field_year;
            }
            set
            {
                monthly_report_field_year = value;
            }
        }
        private static string monthly_report_field_area;
        public string Monthly_report_field_area
        {
            get
            {
                return monthly_report_field_area;
            }
            set
            {
                monthly_report_field_area = value;
            }
        }
        private static string monthly_report_field_prepared;
        public string Monthly_report_field_prepared
        {
            get
            {
                return monthly_report_field_prepared;
            }
            set
            {
                monthly_report_field_prepared = value;
            }
        }
        private static string monthly_report_field_noted;
        public string Monthly_report_field_noted
        {
            get
            {
                return monthly_report_field_noted;
            }
            set
            {
                monthly_report_field_noted = value;
            }
        }
        private static string monthly_report_field_concat_date;
        public string Monthly_report_field_concat_date
        {
            get
            {
                return monthly_report_field_concat_date;
            }
            set
            {
                monthly_report_field_concat_date = value;
            }
        }
    }


    class Annual_Report_Fields
    {
        private static string annual_report_field_year;
        public string Annual_report_field_year
        {
            get
            {
                return annual_report_field_year;
            }
            set
            {
                annual_report_field_year = value;
            }
        }
        private static string annual_report_field_area;
        public string Annual_report_field_area
        {
            get
            {
                return annual_report_field_area;
            }
            set
            {
                annual_report_field_area = value;
            }
        }
        private static string annual_report_field_prepared;
        public string Annual_report_field_prepared
        {
            get
            {
                return annual_report_field_prepared;
            }
            set
            {
                annual_report_field_prepared = value;
            }
        }
        private static string annual_report_field_noted;
        public string Annual_report_field_noted
        {
            get
            {
                return annual_report_field_noted;
            }
            set
            {
                annual_report_field_noted = value;
            }
        }
    }

    class GetCurrentPCStatus
    {
        private static string current_pc_stat_pc_name;

        public string Current_pc_stat_pc_name
        {
            get
            {
                return current_pc_stat_pc_name;
            }
            set
            {
                current_pc_stat_pc_name = value;
            }
        }
        private static string current_pc_stat_pc_session;
        public string Current_pc_stat_pc_session
        {
            get
            {
                return current_pc_stat_pc_session;
            }
            set
            {
                current_pc_stat_pc_session = value;
            }
        }




    }

}
