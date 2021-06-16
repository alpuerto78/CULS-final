using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using IniParser;
using IniParser.Model;

namespace CULS_Client
{
    class Handlers
    {
    }
    class Timer_Client
    {
        static string _ipAd = "127.0.0.1";
        static SqlConnection cn = new SqlConnection();
        static SqlCommand cm = new SqlCommand();
        static SqlDataReader dr;

        static string _title = "COMPUTER USAGE LIMITER SYSTEM";
        static string _ini_path = Application.StartupPath + @"\IniFiles\Configuration.ini";

        public static void UpdateTerminalStatus(string terminal_status,string time_Remaining,string UID)
        {
            //DB_conn dbcon = new DB_conn();
            //cn = new SqlConnection(dbcon.GetConnection());
            string _idle = "IDLE";
            //try
            //{
            //    cn.Open();
            //    cm.Connection = cn;
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "SP_TERMINAL_STATUS_UPDATE";

            //    cm.Parameters.AddWithValue("terminal_status", terminal_status);
            //    cm.Parameters.AddWithValue("time_remaining", time_Remaining);
            //    cm.Parameters.AddWithValue("UID", UID);
            //    cm.ExecuteNonQuery();
            //    cm.Parameters.Clear();
            //    cn.Close();
            //}


            try
            {
                var parser = new FileIniDataParser();
                IniData exec_ini = parser.ReadFile(_ini_path);
                exec_ini["Terminal Status"]["terminal_status"] = terminal_status;
                exec_ini["Terminal Status"]["time_remaining"] = time_Remaining;
                exec_ini["Terminal Status"]["UID"] = UID;

                parser.WriteFile(_ini_path, exec_ini);
            }
            catch 
            {
              //  MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }     
    }
    class Handler_Connection_Flag
    {

        private static bool handler_conn_flag;

        public bool Handler_conn_flag
        {
            get
            {
                return handler_conn_flag;
            }
            set
            {
                handler_conn_flag = value;
            }
        }
    }
}
