using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace CULS_Client
{
    public partial class form_Timer : Form
    {
        double time;
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        SqlDataReader dr;
       
        int second, minute, hour;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";

        public static string _terminal_status = "IDLE";
        public static string _time_remaining = "0";
        public static string _UID = "empty";
        public form_Timer()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
            //transparent
            //this.BackColor = Color.LimeGreen;
            //this.TransparencyKey = Color.LimeGreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
        }
        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Timer_Load(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_terminal_status", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _terminal_status = dr["terminal_status"].ToString();
                    _time_remaining = dr["time_remaining"].ToString();
                    _UID = dr["UID"].ToString();
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        if (_terminal_status == "LIMITED")
            {
                SessionLimited();
            }
        else if (_terminal_status == "UNLIMITED")
            {
                //Format nito ay 24:00 not 12:00 kalito kasi haha
                //Get the initial state of start time
                DateTime _start_time = DateTime.Now;
                lbl_start_time.Text = _start_time.ToString("HH: mm tt");

                //Get the value of end time
          
                lbl_end_time.Text = "00:00 AM";
                lbl_hour.Text = "UNLIMITED";
                lbl_hour.Font = new Font("Serif", 12);
                lbl_minute.Visible = false;
                lbl_second.Visible = false;
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void client_timer_Tick(object sender, EventArgs e)
        {
            //Until the second is greater than 0 it will decrement the time
       
                second--;
        
         

            //when the timer reach the 5 minute time it will display a warning message 
            if (hour==0 && minute==5 && second== 1)
            {
                string _terminal = System.Environment.MachineName;
                string _terminal_status_timeout = "TIMEOUT";

                PopupNotifier warning_5mins = new PopupNotifier();
                    //   warning_5mins.Image = Properties.Resources.Background_Sample_1;
                    warning_5mins.TitleText = "CULS Client";
                    warning_5mins.ContentText ="Terminal: " + System.Environment.MachineName + ">> 5 minutes left";
                    warning_5mins.Popup();


                     NetworkClient.SendCommandToServer("COMMAND|TIMEOUT|" + _terminal + "|" + _terminal_status_timeout + "|" );


            }
            if (hour == 0 && minute == 0 && second == 0)
            {

                string _remaining_time = "0";
                string _terminal = System.Environment.MachineName;
                NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|" + _terminal_status + "|" + _UID + "|" + _remaining_time + "|");
                Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");
                form_Lockscreen f1 = new form_Lockscreen();
                this.Hide();
                f1.Show();
            }
            else if (second<0 && minute >0)
            {
                second = 59;
                minute -= 1;
            }
            if (minute<0 && hour>0)
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

        private void lbl_separator1_Click(object sender, EventArgs e)
        {
                    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            if (MessageBox.Show("Are you sure you want to logout?" ,_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

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

                        NetworkClient.SendCommandToServer("COMMAND|LOGOUT|" + _terminal + "|"+_terminal_status+"|" + _UID + "|" + _remaining_time + "|");
                      
                        Timer_Client.UpdateTerminalStatus("IDLE", "0", "EMPTY");
                        form_Lockscreen f1 = new form_Lockscreen();
                        this.Hide();
                        f1.Show();
                    
                  
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
                    form_Lockscreen f1 = new form_Lockscreen();
                    this.Hide();
                    f1.Show();
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            PopupNotifier warning_5mins = new PopupNotifier();
            //   warning_5mins.Image = Properties.Resources.Background_Sample_1;
            warning_5mins.TitleText = "CULS Client";
            warning_5mins.ContentText = "Terminal: " + System.Environment.MachineName + ">> 5 minutes left";
            warning_5mins.Popup();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

     public void SessionLimited()
        {
            time = int.Parse(_time_remaining);
            double cal = time / 60;

            if (cal >= 1)
            {
                //math floor returns largest integer val
                //math ceiling returns smallest integer val
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

            //Format nito ay 24:00 not 12:00 kalito kasi haha
            //Get the initial state of start time
            DateTime _start_time = DateTime.Now;
            lbl_start_time.Text = _start_time.ToString("HH:mm tt");

            //Get the value of end time
            DateTime _end_time = DateTime.Now.AddMinutes(minute + 1);
            _end_time = _end_time.AddHours(hour);
            lbl_end_time.Text = _end_time.ToString("HH:mm tt");

            //when computation is done setting is variables are good then the timer will start
            client_timer.Start();
        }
    }
}
