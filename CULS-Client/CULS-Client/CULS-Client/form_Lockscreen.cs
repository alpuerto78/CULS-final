using System;
using System.Drawing;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.Data.SqlClient;
using IniParser;
using IniParser.Model;
namespace CULS_Client
{
    public partial class form_Lockscreen : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        SqlDataReader dr;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        string _ini_path = Application.StartupPath + @"\IniFiles\Configuration.ini";

        double time;
        bool flag_timeout = true;
        int second, minute, hour;
        static bool _flag_logout = true;
        public static string _terminal_status = "IDLE";
        public static string _time_remaining = "0";
        public static string _UID = "empty";

        public form_Lockscreen()
        {
            InitializeComponent();
            SC_orientation();
            cn = new SqlConnection(dbcon.GetConnection());
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
            label_pc_no.Text = System.Environment.MachineName;
            label_pc_no.Location = new Point(27, 25);
            timer_get_time.Start();
            timer_shuffle.Start();
            centertimerform();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        int imageNumber = 1;
        private void LoadNext()
        {
            if (imageNumber == 6)
            {
                imageNumber = 1;
            }
            picturebox_slideshow.ImageLocation =Application.StartupPath+ string.Format(@"\Images\{0}.jpg", imageNumber);

            imageNumber++;
        }
        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SC_orientation();
            button_hide_pass.Visible = false;
            SetMaximumLength(txt_username, 10);
            SetMaximumLength(txt_password, 10);
            NetworkClient.ConnectClient();
            timer_get_time.Start();
        }

        ///<param name="metroTextbox">txt_username.</param>
        /// <param name="maximumLength">5.</param>
        private void SetMaximumLength(Bunifu.Framework.UI.BunifuMaterialTextbox metroTextbox, int maximumLength)
        {
            foreach (Control ctl in metroTextbox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    var txt = (TextBox)ctl;
                    txt.MaxLength = maximumLength;

                    // Set other properties & events here...
                }
            }
        }
        private void Button_Redirect_Click(object sender, EventArgs e)
        {
           
        }
        public void SC_orientation()
        {
            //maximize image orientation
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            panel_configure.Location = new Point(
            this.ClientSize.Width / 2 - panel_configure.Size.Width / 2,
            this.ClientSize.Height / 2 - panel_configure.Size.Height / 2);
            panel_configure.Anchor = AnchorStyles.None;


        }
        private void centertimerform()
        {
            panel_timer.Location = new Point(
    this.ClientSize.Width / 2 - panel_timer.Size.Width / 2,
    this.ClientSize.Height / 2 - panel_timer.Size.Height / 2);
            panel_timer.Anchor = AnchorStyles.None;
        }
        private void button_configure_Click(object sender, EventArgs e)
        {
          //  Admin_Login f1 = new Admin_Login();
           // f1.ShowDialog();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel_configure.Visible == false)
            {
                panel_configure.Visible = true;
            }
            else
            {
                panel_configure.Visible = false;
            }
        }

        private void timer_shuffle_Tick(object sender, EventArgs e)
        {
          
            LoadNext();
        }

        private void panel_configure_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_close_Click(object sender, EventArgs e)
        {       
                panel_configure.Visible = false;          
        }
        int _shutdown_counter=3;
        private void btn_signin_Click(object sender, EventArgs e)
        {
            timer_get_time.Stop();
            timer_shuffle.Stop();
            try
            {
                if ((txt_username.Text == String.Empty) || (txt_password.Text == String.Empty))
                {

                    MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAll();
                }
                else if ((txt_username.Text == "Emergency") || (txt_password.Text == "Emergency"))
                {
                    var parser = new FileIniDataParser();
                    IniData exec_ini = parser.ReadFile(_ini_path);
                    MessageBox.Show("Emergency mode!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    ClearAll();
                    form_admin_setting frm_show = new form_admin_setting();
                    MessageBox.Show(exec_ini["Credentials"]["Password"]);
                    frm_show.Show();
                    this.Hide();
                }
                else
                {
                    var parser = new FileIniDataParser();
                    IniData exec_ini = parser.ReadFile(_ini_path);
                    if (txt_username.Text.Equals(exec_ini["Credentials"]["Username"]) && txt_password.Text.Equals(exec_ini["Credentials"]["Password"]))
                    {
                        MessageBox.Show("Log in Successfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                        form_admin_setting frm_show = new form_admin_setting();
                        frm_show.Show();
                        this.Hide();
                    }
                    else
                    {
                        _shutdown_counter--;
                        if (_shutdown_counter > 0)
                        {

                            MessageBox.Show("Credentials is Incorrect! You only have " + _shutdown_counter + " trial(s) before the system shutdown ", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ClearAll();
                        }
                        else if (_shutdown_counter == 0)
                        {
                            CmdClass cmd = new CmdClass();
                            MessageBox.Show("System will shutdown ", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmd.ExecuteCommand("shutdown -s");
                           
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ClearAll()
        {
            txt_username.Text = "";
            txt_password.Text = "";
            txt_username.Focus();
        }

        private void button_hide_pass_Click(object sender, EventArgs e)
        {
            button_hide_pass.Visible = false;
            button_show_pass.Visible = true;
            txt_password.isPassword = true;
        }



        private void button_show_pass_Click(object sender, EventArgs e)
        {
            button_hide_pass.Visible = true;
            button_show_pass.Visible = false;
            txt_password.isPassword = false;
        }

        private void button_hide_pass_Click_2(object sender, EventArgs e)
        {
            button_hide_pass.Visible = false;
            button_show_pass.Visible = true;
            txt_password.isPassword = true;
        }

        private void txt_password_OnValueChanged(object sender, EventArgs e)
        {
            if (button_hide_pass.Visible == true)
            {
                txt_password.isPassword = false;
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
            }
        }

        private void txt_username_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
            }
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
            }
        }

        private void txt_username_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
            }
        }

        private void txt_password_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
            }
        }

        private void txt_username_Enter(object sender, EventArgs e)
        {
            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
                txt_username.ForeColor = Color.Black;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            button_show_pass.Visible = true;
            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";

            }
            txt_password.ForeColor = Color.Black;
            txt_password.isPassword = true;
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                txt_username.Text = "Username";
                txt_username.ForeColor = Color.Gray;
            }

            if (txt_username.Text != "")
            {
                //    txt_username.ForeColor = Color.Black;
            }
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text == "")
            {
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.Gray;
            }

            if (txt_password.Text != "")
            {
                //    txt_username.ForeColor = Color.Black;
            }
        }

        private void label_close_MouseHover(object sender, EventArgs e)
        {
            label_close.BackColor = Color.FromArgb(255, 106, 112, 117);
            label_close.ForeColor = Color.FromArgb(228, 229, 230);
        }

        private void label_close_MouseLeave(object sender, EventArgs e)
        {
            label_close.BackColor = Color.FromArgb(228, 229, 230);
            label_close.ForeColor = Color.DarkGray;
        }


        private void timer_get_time_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    cn.Open();
            //    cm = new SqlCommand("Select * from tbl_terminal_status", cn);
            //    dr = cm.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        _terminal_status = dr["terminal_status"].ToString();
            //       _time_remaining = dr["time_remaining"].ToString();
            //        _UID = dr["UID"].ToString();
            //    }
            //    dr.Close();
            //    cn.Close();

            //}
            try
            {
                var parser = new FileIniDataParser();
                IniData exec_ini = parser.ReadFile(_ini_path);
                _terminal_status = exec_ini["Terminal Status"]["terminal_status"];
                _time_remaining = exec_ini["Terminal Status"]["time_remaining"];
                _UID = exec_ini["Terminal Status"]["UID"];
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }         
            if (_terminal_status== "LIMITED"|| _terminal_status == "UNLIMITED"  )
            {
                timer_shuffle.Stop();
                timer_get_time.Enabled = false;
                //   MessageBox.Show(_terminal_status);
                //form_Timer f1 = new form_Timer();              
                //f1.Show();
                //this.Hide();

                //---timerorientation
                TimerOrientation();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NetworkClient.SendCommandToServer("check status:goods");
        }

        private void timer_keepAlive_Tick(object sender, EventArgs e)
        {
            NetworkClient.KeepAlive("COMMAND|CHECKSTATUS");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _terminal = System.Environment.MachineName;
            string _terminal_status_timeout = "TIMEOUT";
            NetworkClient.SendCommandToServer("COMMAND|TIMEOUT|" + _terminal + "|" + _terminal_status_timeout + "|");
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void timer_load_server_Tick(object sender, EventArgs e)
        {

        }
        private void TimerOrientation()
        {
            //oritentation
            //this.TopMost = false;
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Normal;

            panel_configure.Visible = false;
            label_pc_no.Visible = false;
            picturebox_slideshow.Visible = false;
            //set values
           this.Size = new Size(223, 306);
            this.CenterToScreen();
            StartTime();
            timer_server_logout.Enabled=true;
        }
        private void LockscreenOrientation()
        {
            lbl_hour.Text = "00";
            lbl_minute.Text = "00";
            lbl_second.Text = "00";
            lbl_hour.Font = new Font("Microsoft Sans Serif", 12);
            lbl_minute.Font = new Font("Microsoft Sans Serif", 12);
            lbl_second.Font = new Font("Microsoft Sans Serif", 12);
            timer_get_time.Enabled = true;
            label_pc_no.Visible = true;
            picturebox_slideshow.Visible = true;
            label_pc_no.Location = new Point(27, 25);
            //set values
            SC_orientation();
            client_timer.Enabled = false;
            timer_server_logout.Enabled = false;
            timer_shuffle.Start();


        }
        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            string _terminal = System.Environment.MachineName;
            double time_to_int = 0;
            double cal2 = minute;
            double cal3 = hour;
            if (MessageBox.Show("Are you sure you want to logout?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (hour > 0)
                {
                    //convert time to integer
                    time_to_int = (cal3 + (cal2 / 60));
                    time_to_int = (time_to_int * 60) + 1;
                    string _remaining_time = time_to_int.ToString();
                    // MessageBox.Show(_remaining_time);
                    //receiveTextSplit[1]=logout
                    //receiveTextSplit[2]=terminal name
                    //receiveTextSplit[3]=terminal status
                    //receiveTextSplit[4]=UID
                    //receiveTextSplit[5]=remaining time
                    NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");

                    Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");

                }
                else
                {
                    time_to_int = minute;
                    string _remaining_time = time_to_int.ToString();

                    //receiveTextSplit[1]=logout
                    //receiveTextSplit[2]=terminal name
                    //receiveTextSplit[3]=terminal status
                    //receiveTextSplit[4]=UID
                    //receiveTextSplit[5]=remaining time

                    NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");

                    Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");
                }
               
                client_timer.Stop();
                flag_timeout = true;
                LockscreenOrientation();
            }
        
            }

        private void StartTime()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData exec_ini = parser.ReadFile(_ini_path);
                _terminal_status = exec_ini["Terminal Status"]["terminal_status"];
                _time_remaining = exec_ini["Terminal Status"]["time_remaining"];
                _UID = exec_ini["Terminal Status"]["UID"];
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_terminal_status == "LIMITED")
            {
                lbl_minute.Visible = true;
                lbl_second.Visible = true;
                lbl_hour.Text = "00";
                lbl_hour.Font = new Font("Microsoft Sans Serif", 12);
                lbl_minute.Font = new Font("Microsoft Sans Serif", 12);
                lbl_second.Font = new Font("Microsoft Sans Serif", 12);
                SessionLimited();
            }
            else if (_terminal_status == "UNLIMITED")
            {
                DateTime _start_time = DateTime.Now;
                lbl_start_time.Text = _start_time.ToString("HH: mm tt");
                lbl_end_time.Text = "00:00 AM";
                lbl_hour.Text = "UNLIMITED";
                lbl_hour.Font = new Font("Microsoft Sans Serif", 12);
                lbl_minute.Visible = false;
                lbl_second.Visible = false;
            }
        }

        private void TimerTick()
        {
            //Until the second is greater than 0 it will decrement the time

            second--;


           // MessageBox.Show(second.ToString());
            //when the timer reach the 5 minute time it will display a warning message 

            if (hour == 0 && minute < 5)
            {
                string _terminal = System.Environment.MachineName;
                string _terminal_status_timeout = "TIMEOUT";
                if (flag_timeout)
                {
                    PopupNotifier warning_5mins = new PopupNotifier();
                    warning_5mins.Image = Properties.Resources.C_blue_logo_v2;
                    warning_5mins.TitleText = "CULS Client";
                    warning_5mins.ContentText = "Terminal: " + System.Environment.MachineName + ">>Less than 5 minutes left";
                    warning_5mins.Popup();
                    NetworkClient.SendCommandToServer("COMMAND|TIMEOUT|" + _terminal + "|" + _terminal_status_timeout + "|");
                    flag_timeout = false;
                }
            }
            if (hour == 0 && minute == 0 && second == 0)
            {

                string _remaining_time = "0";
                string _terminal = System.Environment.MachineName;
                NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");
                Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");
                client_timer.Stop();
                flag_timeout = true;
                LockscreenOrientation();
            }
            else if (second < 0 && minute > 0)
            {
                second = 59;
                minute -= 1;
            }
            if (minute < 0 && hour > 0)
            {
                minute = 59;
                hour -= 1;
            }
            if (second < 0 && minute == 0 && hour > 0)
            {
                minute = 59;
                second = 59;
                hour -= 1;

            }

            Digit_counter DC_count = new Digit_counter();

            //Digit Counter Min
            int dc_minute = minute;
            int count_min = 0;
            while (dc_minute != 0)
            {
                dc_minute = dc_minute / 10;
                ++count_min;
            }
            DC_count.DC_min = count_min.ToString();

            if (count_min == 2)
            {
                lbl_minute.Text = minute.ToString() + ":";

            }
            else
            {
                lbl_minute.Text = "0" + minute.ToString() + ":";
            }


            //Digit Counter Sec
            int dc_sec = second;
            int count_sec = 0;
            while (dc_sec != 0)
            {
                dc_sec = dc_sec / 10;
                ++count_sec;
            }
            DC_count.DC_sec = count_sec.ToString();

            if (count_sec == 2)
            {
                lbl_second.Text = second.ToString();

            }
            else
            {
                lbl_second.Text = "0" + second.ToString();
            }

            //Digit Counter Hour
            int dc_hour = hour;
            int count_hour = 0;
            while (dc_sec != 0)
            {
                dc_hour = dc_hour / 10;
                ++count_hour;
            }
            DC_count.DC_hour = count_hour.ToString();

            if (count_hour == 2)
            {
                lbl_hour.Text = hour.ToString() + ":";

            }
            else
            {
                lbl_hour.Text = "0" + hour.ToString() + ":";
            }

            //lbl_second.Text = second.ToString();
            //lbl_minute.Text = minute.ToString();
            //lbl_hour.Text = hour.ToString();
            lbl_time_catcher.Text = time.ToString();
        }

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
        public void ServerLogout()
        {
            string _terminal = System.Environment.MachineName;
            double time_to_int = 0;
            double cal2 = minute;
            double cal3 = hour;

            if (hour > 0)
            {
                //convert time to integer
                time_to_int = (cal3 + (cal2 / 60));
                time_to_int = (time_to_int * 60) + 1;
                string _remaining_time = time_to_int.ToString();

                //receiveTextSplit[1]=logout
                //receiveTextSplit[2]=terminal name
                //receiveTextSplit[3]=terminal status
                //receiveTextSplit[4]=UID
                //receiveTextSplit[5]=remaining time

                NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");
                Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");

            }
            else
            {
                time_to_int = minute;
                string _remaining_time = time_to_int.ToString();

                //receiveTextSplit[1]=logout
                //receiveTextSplit[2]=terminal name
                //receiveTextSplit[3]=terminal status
                //receiveTextSplit[4]=UID
                //receiveTextSplit[5]=remaining time

                NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");
                Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");

            }
            flag_timeout = true;
            client_timer.Stop();
            LockscreenOrientation();
        }

        private void client_timer_Tick(object sender, EventArgs e)
        {
            TimerTick();   
        }

        private void timer_server_logout_Tick(object sender, EventArgs e)
        {
            ServerLogoutTick();
        }

        private void ServerLogoutTick()
        {
            Logout fc = new Logout();
            string _com_logout = "COMMAND|LOGOUT";
            try
            {
                if (_com_logout == fc.Logout_command)
                {
                    timer_server_logout.Stop();
                    ServerLogout();
                    fc.Logout_command = "NULL";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title);
            }
        }
        public void SessionLimited()
        {

            time = int.Parse(_time_remaining);
           // MessageBox.Show(time.ToString());
            double cal = time / 60;
            if (cal >= 1)
            {
                hour = (int)Math.Floor(cal);
                cal = cal - (int)Math.Floor(cal);
                minute = (int)Math.Ceiling(cal * 60);
                if (minute > 0)
                {
                    minute -= 1;
                    second = 60;
                }
                else if (second == 0 && minute == 0 && hour > 0)
                {
                    minute = 59;
                    second = 60;
                    hour -= 1;
                }
                else
                {
                    second = 0;
                }
            }
            else
            {
                hour = 0;
                minute = (int)time - 1;
                second = 60;
            }
            DateTime _start_time = DateTime.Now;
            lbl_start_time.Text = _start_time.ToString("HH:mm tt");

            //Get the value of end time
            DateTime _end_time = DateTime.Now.AddMinutes(minute + 1);
            _end_time = _end_time.AddHours(hour);
            lbl_end_time.Text = _end_time.ToString("HH:mm tt");

            //when computation is done setting is variables are good then the timer will start
            client_timer.Enabled=true;
        }
    }
}

