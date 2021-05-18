using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CULS_Client
{
    public partial class form_Lockscreen : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        SqlDataReader dr;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
       
        public form_Lockscreen()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
            label_pc_no.Text = System.Environment.MachineName;      
        }

        int imageNumber = 1;
        private void LoadNext()
        {
            if (imageNumber == 4)
            {
                imageNumber = 1;
            }
            picturebox_slideshow.ImageLocation =Application.StartupPath+(@"Images\{0}.jpg", imageNumber);
            MessageBox.Show(Application.StartupPath + (@"Images\{0}.jpg", imageNumber));
            imageNumber++;
        }
        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //   SC_orientation();
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
            //Redirect to CULS_timer form
            form_Timer Load = new form_Timer();
            {
                Load.Show();
                this.Hide();
            }
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

        private void btn_signin_Click(object sender, EventArgs e)
        {
            timer_get_time.Stop();
            try
            {
                if ((txt_username.Text == String.Empty) || (txt_password.Text == String.Empty))
                {
                    MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAll();
                }
                else
                {

                    //if ((txt_username.Text == "admin") && (txt_password.Text == "admin"))
                    //{
                    //    MessageBox.Show("Welcome Administrator!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    ClearAll();

                    //    form_admin_setting frm_show = new form_admin_setting();
                    //    frm_show.Show();
                    //    this.Hide();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Credentials is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    ClearAll();
                    //}


                    cn.Open();
                    cm = new SqlCommand("select * from tbl_admin_credentials ", cn);
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        if (txt_username.Text.Equals(dr["adm_username"].ToString()) && txt_password.Text.Equals(dr["adm_password"].ToString()))
                        {
                            MessageBox.Show("Log in Successfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearAll();
                            form_admin_setting frm_show = new form_admin_setting();
                    
                            frm_show.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Credentials is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);                         
                            ClearAll();
                        }
                    }
                    cn.Close();
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

        public static string _terminal_status = "IDLE";
        public static string _time_remaining = "0";
        public static string _UID = "empty";
        private void timer_get_time_Tick(object sender, EventArgs e)
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
            if (_terminal_status== "LIMITED"|| _terminal_status == "UNLIMITED"  )
            {
                timer_get_time.Stop();
                MessageBox.Show(_terminal_status);
                form_Timer f1 = new form_Timer();
                f1.Show();
                this.Hide();
        
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
            NetworkClient.close_client();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string _terminal = System.Environment.MachineName;
            string _terminal_status_timeout = "TIMEOUT";
            NetworkClient.SendCommandToServer("COMMAND|TIMEOUT|" + _terminal + "|" + _terminal_status_timeout + "|");
        }
    }
}

