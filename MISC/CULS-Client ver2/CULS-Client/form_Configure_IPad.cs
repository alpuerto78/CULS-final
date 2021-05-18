using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace CULS_Client
{
    public partial class IP_Configuration : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public IP_Configuration()
        {
            cn = new SqlConnection(dbcon.GetConnection());
            InitializeComponent();
          //  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

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
        private void IP_Configuration_Load(object sender, EventArgs e)
        {
            txt_ipAD.Focus();
            
            txt_ipAD.Text = "   .   .   .   ";
            txt_ipAD.PromptChar = ' ';
            txt_ipAD.Mask = "###.###.###.###";
            txt_ipAD.ResetOnSpace = false;
            txt_ipAD.SkipLiterals = false;
          
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public bool IsValidateIP(string Address)
        {
            //Match pattern for IP address    
            string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //Regular Expression object    
            Regex check = new Regex(Pattern);

            //check to make sure an ip address was provided    
            if (string.IsNullOrEmpty(Address))
                //returns false if IP is not provided    
                return false;
            else
                //Matching the pattern    
                return check.IsMatch(Address, 0);
        }
        public static bool IsIPv4(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            string[] splitValues = value.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }



        private void button_ipAD_save_Click(object sender, EventArgs e)
        {
            if (IsIPv4(txt_ipAD.Text))
            {
                try
                {
                    //ttanggalin yung mga spaces
                    string trimmed = String.Concat(txt_ipAD.Text.Where(c => !Char.IsWhiteSpace(c)));
        
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_Network_Configuration_Update";
                    cm.Parameters.AddWithValue("@server_ipAD", trimmed);
           

                    cm.ExecuteNonQuery();
                    cn.Close();
                
                    MessageBox.Show("Successfully Configure the IP Address! Please Restart the Terminal", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ipAD.Clear();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Invalid IP Address: " + txt_ipAD.Text, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            form_admin_setting f1 = new form_admin_setting();
            f1.Show();
            this.Hide();
        }
    }
}
