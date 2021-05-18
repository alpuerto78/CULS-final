using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MaterialSkin;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CULS_SERVER
{

    public partial class Login : MaterialSkin.Controls.MaterialForm

    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        ClassDB dbcon = new ClassDB();

        public Login()
        {
            InitializeComponent();
            //panel_login have tranparency             
            panel_login.BackColor = Color.FromArgb(105, Color.FromArgb(228, 229, 230));
            button_show_pass.Visible = false;

            cn = new SqlConnection(dbcon.GetConnection());
            //test if database is connected
            // cn.Open();
            // MessageBox.Show("Connected");
        }
        //public form
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Login"];

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

        private void Login_Load(object sender, EventArgs e)
        {

            button_hide_pass.Visible = false;
            SetMaximumLength(txt_username, 10);
            SetMaximumLength(txt_password, 10);



        }


        private void button_hide_pass_Click(object sender, EventArgs e)
        {
            button_hide_pass.Visible = false;
            button_show_pass.Visible = true;
            txt_password.isPassword = true;
        }

        private void button_show_pass_Click_1(object sender, EventArgs e)
        {
            button_hide_pass.Visible = true;
            button_show_pass.Visible = false;
            txt_password.isPassword = false;
            //txt_password.passwordchar
        }
       public void ClearAll()
        {
            txt_username.Text="";
            txt_password.Text="";
            txt_username.Focus();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if ((txt_username.Text == String.Empty) || (txt_password.Text == String.Empty))

                {
                    MessageBox.Show("Required Missing Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    label_alert.Text = "*Required Missing Field";
                    label_alert.ForeColor = Color.Red;
                    ClearAll();
                }
                else
                {
                    cn.Open();
                    cm = new SqlCommand("select * from tbl_user ", cn);  
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        if (txt_username.Text.Equals(dr["username"].ToString()) && txt_password.Text.Equals(dr["password"].ToString()))
                        {
                            MessageBox.Show("Login Successfully!", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            label_alert.Text = "*Fill out Credentials";
                            label_alert.ForeColor = Color.DarkGray;
                            ClearAll();
                            Dashboard f1 = new Dashboard();
                            this.Hide();
                            f1.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Credentials is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            label_alert.Text = "*Credentials is Incorrect";
                            label_alert.ForeColor = Color.Red;
                            ClearAll();
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
  
        }

      

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
        
            if (button_hide_pass.Visible == true)
            {
                txt_password.isPassword = false;
            }


        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }
        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
            }
        }
        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txt_password.Text == "Password")
            {
                txt_password.Text = "";
            }
            //if (button_hide_pass.Visible==true)
           // {
               // txt_password.isPassword = false;
           // }
        }
        private void txt_username_Click(object sender, EventArgs e)
        {

            if (txt_username.Text == "Username")
            {
                txt_username.Text = "";
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
            //when click button show will be visible
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
                txt_password.isPassword = false;
                txt_password.ForeColor = Color.Gray;
                button_show_pass.Visible = false;
                
            }
          
            if (txt_password.Text != "")
            {
                txt_password.ForeColor = Color.Gray;
                txt_password.isPassword = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Module_Close f1 = new Module_Close();    
          
            f1.ShowDialog();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            lbl_Close.BackColor = Color.FromArgb(255, 106, 112, 117);
            lbl_Close.ForeColor = Color.FromArgb(228, 229, 230);
        }

        private void lbl_Close_MouseLeave(object sender, EventArgs e)
        {
            lbl_Close.BackColor = Color.FromArgb(228, 229, 230);
            lbl_Close.ForeColor = Color.DarkGray;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_alert_Click(object sender, EventArgs e)
        {

        }

     
    }
}
    