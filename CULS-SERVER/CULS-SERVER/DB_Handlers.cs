using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace CULS_SERVER
{
    class DB_Handlers
    {
        static SqlConnection cn = new SqlConnection();
        static SqlCommand cm = new SqlCommand();
        static SqlDataReader dr;

        static string _title = "COMPUTER USAGE LIMITER SYSTEM";

        public static void UpdateSubtractRemainingTime(string UID, string remaining_time)
        {
            DB_conn dbcon = new DB_conn();
            cn = new SqlConnection(dbcon.GetConnection());
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_USER_REMAINING_TIME_LOGOUT_UPDATE";
                cm.Parameters.AddWithValue("time_remaining", remaining_time);
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
        //kapag sumapit na ng 12:00 AM marereset na yung oras ng mga users
        public static void Daily_TimeCredit_Refresher()
        {
            DB_conn dbcon = new DB_conn();
            cn = new SqlConnection(dbcon.GetConnection());
            string _current_time_limit = "0";
            string _current_date = DateTime.Now.ToString("MM/dd/yyyy");
            string _date_now = DateTime.Now.ToString("MM/dd/yyyy");
            //get current date
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_DAILY_TIMECREDIT_REFRESHER_SELECT";
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //  _current_date = (dr["date_refresher"].ToString());              
                    DateTime dateTime = DateTime.Parse(dr["date_refresher"].ToString());
                    _current_date = dateTime.ToString("MM/dd/yyyy");

                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //if date doesnt match then refresh all time credit

            if (_date_now != _current_date)
            {
                //get current time limit
                try
                {
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_TIME_CURRENTLIMIT_SELECT";
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        _current_time_limit = (dr["time_limit"].ToString());
                    }
                   
                    dr.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                try
                {
                    //UPDATE ALL TIME_REMAINING IN USERS

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_SETTINGS_TIME_REMAINING_UPDATE";
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@time_remaining", _current_time_limit);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    cm.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //update date of refresher 
                try
                {
                    //UPDATE ALL TIME_REMAINING IN USERS

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_DAILY_TIMECREDIT_REFRESHER_UPDATE";
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@date_refresher", _date_now);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    cm.Parameters.Clear();
                    MessageBox.Show("Daily time credit has been refreshed", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //get current user profiles 
        public static void AddToSessionLogs(string _UID, DateTime _login,string _purpose,string _terminal,string _session)
        {
            try
            {
                //INsert new session logs

                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_SESSION_LOGS_INSERT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@UID", _UID);
                cm.Parameters.AddWithValue("@login", _login);
                cm.Parameters.AddWithValue("@purpose", _purpose);
                cm.Parameters.AddWithValue("@terminal", _terminal);
                cm.Parameters.AddWithValue("@session", _session);
         //       cm.Parameters.AddWithValue("@log_date", _log_date);
                cm.ExecuteNonQuery();
                cn.Close();
                cm.Parameters.Clear();           
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void UpdateToSessionLogs(int _log_id, DateTime _logout)
        {
            try
            {
                //Update logs

                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_SESSION_LOGS_UPDATE";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@log_id", _log_id);
                cm.Parameters.AddWithValue("@logout", _logout);
                cm.ExecuteNonQuery();
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void Select_log_id(string _terminal, DateTime log_in)
        {
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_LOGOUT_ID_SELECT";

                cm.Parameters.AddWithValue("@UID",_terminal);
                cm.Parameters.AddWithValue("@login",log_in);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Handler_Logout hd_lg = new Handler_Logout();
                    hd_lg.PRE_Logout_id = dr["log_id"].ToString();
                   // MessageBox.Show(hd_lg.PRE_Logout_id);
                }
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void AddToCurrentSession(string _pc_name)
        {
            try
            {
                // current sessiion mag add ng default pag nag add ka ng pc 
                //wa gkalimutan idelete si current sesssion pag nagdelete ng pc

                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_CURRENT_SESSION_INSERT";
                cm.Parameters.Clear();             
                cm.Parameters.AddWithValue("@PC_name", _pc_name);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                }
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void UpdateToCurrentSession(string _UID, int log_id, string _terminal, string _session)
        {
            
            try
            {
                //INsert new session logs
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_CURRENT_SESSION_UPDATE";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@UID", _UID);
                cm.Parameters.AddWithValue("@log_id", log_id);
                cm.Parameters.AddWithValue("@PC_name", _terminal);
                cm.Parameters.AddWithValue("@session_type", _session);
                //       cm.Parameters.AddWithValue("@log_date", _log_date);
                cm.ExecuteNonQuery();
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Account settings
        public static bool IsCurrentPass(string current_pass)
        {
            bool ret = true;
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from tbl_user ", cn);

                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {

                    if (current_pass.Equals(dr["password"].ToString()))
                    {
                        ret = false;
                    }
                    else
                    {
                        ret = true;
                    }
                }
                cn.Close();
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public static void AccountChangePass(string adm_user,string adm_password)
        {
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_CREDENTIALS_PASSWORD_UPDATE";
                cm.Parameters.AddWithValue("@adm_username", adm_user);
                cm.Parameters.AddWithValue("@adm_password", adm_password);
                cm.ExecuteNonQuery();
                cn.Close();
                cm.Parameters.Clear();
                MessageBox.Show("Succesfully change password!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        static GetCurrentPCStatus GC = new GetCurrentPCStatus();
        //pang retrieve kapag na dc si client
        public static void GetCurrentStatusPC(string terminal)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_current_session where PC_name = '"+terminal+"'", cn);
                dr = cm.ExecuteReader();
                {
                    while (dr.Read())
                                            
                    GC.Current_pc_stat_pc_session = dr["session_type"].ToString();    
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
