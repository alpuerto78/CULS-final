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
using IniParser;
using IniParser.Model;

namespace CULS_Client
{
    public partial class form_update_credential : Form
    {
        static SqlConnection cn = new SqlConnection();
        static SqlCommand cm = new SqlCommand();  
        static DB_conn dbcon = new DB_conn();
        static string _title = "COMPUTER USAGE LIMITER SYSTEM";
        static string _ini_path = Application.StartupPath + @"\IniFiles\Configuration.ini";

        public form_update_credential()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
         //   this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
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
        private void lbl_minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //form_admin_setting f1 = new form_admin_setting();
            //f1.Show();
            //this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            form_admin_setting f1 = new form_admin_setting();
            f1.Show();
            this.Hide();
        }

        private void button_ipAD_save_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txt_current_password.Text == String.Empty) || (txt_new_password.Text == String.Empty) || (txt_confirm_password.Text == String.Empty))
                {
                    MessageBox.Show("Required Missing Field!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearAll();
                }
                else if (IsCurrentPass(txt_current_password.Text))
                {
                    MessageBox.Show("Current password is not correct",_title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_current_password.Text="";
                    txt_current_password.Focus();
                }
                else if (txt_new_password.Text != txt_confirm_password.Text)
                {
                    MessageBox.Show("Password doesn't match!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txt_confirm_password.Text = "";
                    txt_confirm_password.Focus();
                }
                else 
                {                
                    try
                    {
                        var parser = new FileIniDataParser();
                        IniData exec_ini = parser.ReadFile(_ini_path);
                        exec_ini["Credentials"]["Password"] = txt_new_password.Text;
                        parser.WriteFile(_ini_path, exec_ini);
                        MessageBox.Show("Succesfully change password!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,_title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
            txt_new_password.Text = "";
            txt_current_password.Text = "";
            txt_confirm_password.Text = "";
            txt_new_password.Focus();
        }
        public static bool IsCurrentPass(string current_pass)
        {
            bool ret = true;
            try
            {
                // cn.Open();
                // cm = new SqlCommand("select * from tbl_admin_credentials ", cn);

                // SqlDataReader dr = cm.ExecuteReader();
                // if (dr.Read())
                // {

                //     if (current_pass.Equals(dr["adm_password"].ToString()))
                //     {
                //             ret=false;
                //     }               
                //     else
                //     {
                //             ret= true;
                //     }                   
                //}        
                // cn.Close();
                //    return ret;
                var parser = new FileIniDataParser();
                IniData exec_ini = parser.ReadFile(_ini_path);
                if (current_pass.Equals(exec_ini["Credentials"]["Password"]))
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
            return ret;
        }  
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

    }
}
