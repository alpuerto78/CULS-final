using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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

        public static void UpdateTerminalStatus(string terminal_status,string time_Remaining,string UID)
        {
            DB_conn dbcon = new DB_conn();
            cn = new SqlConnection(dbcon.GetConnection());
            string _idle = "IDLE";
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_TERMINAL_STATUS_UPDATE";
           
                cm.Parameters.AddWithValue("terminal_status", terminal_status);
                cm.Parameters.AddWithValue("time_remaining", time_Remaining);
                cm.Parameters.AddWithValue("UID", UID);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
            public static void ExecFormTimer()
        {
            form_Timer T1 = new form_Timer();
            form_Lockscreen L1 = new form_Lockscreen();
            T1.Show();
            L1.Hide();
        }
    }
}
