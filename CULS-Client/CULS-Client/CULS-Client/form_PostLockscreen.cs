using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;

namespace CULS_Client
{
    public partial class form_PostLockscreen : Form
    {
        public static string _terminal_status = "IDLE";
        public static string _time_remaining = "0";
        public static string _UID = "empty";
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        string _ini_path = Application.StartupPath + @"\IniFiles\Configuration.ini";
        public form_PostLockscreen()
        {
            InitializeComponent();

          //  SC_orientation();
            timer_get_time.Start();
            timer_shuffle_image.Start();
            label_pc_no.Text = System.Environment.MachineName;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
            
        }

        private void picturebox_slideshow_Click(object sender, EventArgs e)
        {

        }
        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        int imageNumber = 1;
        private void LoadNext()
        {
            if (imageNumber == 6)
            {
                imageNumber = 1;
            }
            picturebox_slideshow.ImageLocation = Application.StartupPath + string.Format(@"\Images\{0}.jpg", imageNumber);

            imageNumber++;
        }
        public void SC_orientation()
        {
            //maximize image orientation
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void timer_get_time_Tick(object sender, EventArgs e)
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
            if (_terminal_status == "LIMITED" || _terminal_status == "UNLIMITED")
            {
                timer_get_time.Stop();
                timer_shuffle_image.Stop();
                //   MessageBox.Show(_terminal_status);
                form_Timer f1 = new form_Timer();      
          
                this.Hide();
                f1.Show();
            }
        }

        private void timer_shuffle_image_Tick(object sender, EventArgs e)
        {
            LoadNext();
        }

        private void form_PostLockscreen_Load(object sender, EventArgs e)
        {
            form_Timer f1 = new form_Timer();
            f1.Hide();
        }
    }
}
