using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CULS_SERVER
{
    public partial class form_User_Sessions : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        SqlDataReader dr;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_User_Sessions()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
        }
        //Shadow in form
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_User_Sessions_Load(object sender, EventArgs e)
        {
            get_user_profiles();
            load_user_sessions_logs();            
            grid_user_sessions.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
        }
        public void get_user_profiles()
        {
            User_Sessions Usr_sssn = new User_Sessions();
            string _UID = Usr_sssn.RFID_UID;
            txt_RFID_UID.Text = _UID;
            try
            {

                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_ADD_TIME_USERS_DETAILS_SELECT";
                cm.Parameters.AddWithValue("@UID", _UID);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    
                    txt_stud_id_no.Text = (dr["stud_id_no"].ToString());
                   txt_firstname.Text = (dr["firstname"].ToString());
                    txt_lastname.Text = (dr["lastname"].ToString());

                    txt_dept.Text = (dr["dept_name"].ToString());
                    txt_course.Text = (dr["course_name"].ToString());
                    ConvertTimeFormat(dr["time_remaining"].ToString());
                   txt_usertype.Text= (dr["usertype_name"].ToString());
                    //basta pangcall to ng picture galing sa folder
                    string paths = Application.StartupPath;
                    picbox_student.Image = Image.FromFile(paths + dr["imagepath"].ToString());


                    //      _time_remaining_check = (dr["time_remaining"].ToString());
                    //                    image_id = (dr["imagepath"].ToString());
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

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid_user_sessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void load_user_sessions_logs()
        {
            grid_user_sessions.Rows.Clear();
            try
            {
                grid_user_sessions.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("Select * from tbl_session_logs  where  UID = '" +txt_RFID_UID.Text + "'  ORDER BY log_id DESC", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    string dt_logout = null;
                    DateTime res_dt_logout;
                    DateTime dt_login = DateTime.Parse(dr["login"].ToString());
                    if (DateTime.TryParse(dr["logout"].ToString(), out res_dt_logout))
                    {
                        dt_logout = res_dt_logout.ToString("hh:mm");

                    }
                    else
                    {
                        dt_logout = "";
                    }
                    string _date = dt_login.ToString("yyyy/MM/dd"), _login = dt_login.ToString("hh:mm"), _logout = dt_logout;
                    grid_user_sessions.Rows.Add(i, _date, _login, _logout, dr["session"].ToString(), dr["terminal"].ToString(), dr["purpose"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ConvertTimeFormat(string time_rmn)
        {
            int time = 0;
            int get_hour = 0, get_minute = 0, get_second = 0;
            time = int.Parse(time_rmn);
            double cal = time / 60;


            if (cal >= 1)
            {
                //math floor returns largest integer val
                //math ceiling returns smallest integer val
                get_hour = (int)Math.Floor(cal);
                cal = cal - (int)Math.Floor(cal);
                get_minute = (int)Math.Ceiling(cal * 60);
                if (get_minute > 0)
                {
                    get_minute -= 1;
                    get_second = 60;
                }
                else if (get_second == 0 && get_minute == 0 && get_hour > 0)
                {
                    get_minute = 0;
                    get_second = 0;
                    //baka pwedeng tanggalin an ito

                }
                else
                {
                    get_second = 0;
                }
            }
            else
            {
                get_hour = 0;
                get_minute = time;
                get_second = 60;
            }

            if (get_minute < 10)
            {
                txt_remaining_time.Text = "0" + get_hour.ToString() + ":0" + get_minute.ToString();
            }
            else
            {
                txt_remaining_time.Text = "0" + get_hour.ToString() + ":" + get_minute.ToString();

            }
        }
    }
}
