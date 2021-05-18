using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CULS_Client
{
    public partial class form_admin_setting : Form
    {
        public form_admin_setting()
        {
            InitializeComponent();
           // this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
        }

        private void form_admin_setting_Load(object sender, EventArgs e)
        {
           

        }

        private void btn_restart_Click(object sender, EventArgs e)

        { 
             CmdClass cm = new CmdClass();
        
        cm.ExecuteCommand("shutdown -f -t -t3 -s");
           

        }

        private void btn_exit_client_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lbl_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IP_Configuration form_ip_config = new IP_Configuration();
            form_ip_config.Show();
            this.Hide();
        }

        private void btn_change_credentials_Click(object sender, EventArgs e)
        {
            form_update_credential f1 = new form_update_credential();
            f1.Show();
            this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            form_Lockscreen f1 = new form_Lockscreen();
            f1.Show();
            this.Hide();
        }

     
    }
}
