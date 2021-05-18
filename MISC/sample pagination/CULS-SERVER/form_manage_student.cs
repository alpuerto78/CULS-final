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

namespace CULS_SERVER
{
    public partial class form_manage_student : Form
    {
        NFCReader NFC = new NFCReader();
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB dbcon = new ClassDB();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_manage_student()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            load_dept_data();
            load_course_records();
            Reader_Status();
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
        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_browse_student_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            // chose the images type
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                // get the image returned by OpenFileDialog 
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void form_manage_student_Load(object sender, EventArgs e)
        {

        }
        public void load_dept_data()
        {
            try
            {
                combobox_display_dept.Items.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT [dept_name] From  tbl_department", cn);
                cm.ExecuteNonQuery();
                da = new SqlDataAdapter(cm);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    combobox_display_dept.Items.Add(dr["dept_name"].ToString());

                }

                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void combobox_display_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            combobox_display_course.Enabled = true;
            combobox_display_course.SelectedIndex=-1;
            combobox_display_course.Items.Clear();
            try
            {
                cn.Open();
                string q = "Select dept_id from tbl_department where dept_name='" + combobox_display_dept.SelectedItem + "'";
                cm = new SqlCommand(q, cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lbl_dept_handler.Text = dr[0].ToString();
                    //textbox_dept_description.Text = dr[0].ToString();
                }
                dr.Close();
                cn.Close();
                load_course_records();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void load_course_records()
        {
         
            try
            {
              
                cn.Open();
                cm = new SqlCommand("Select course_name from tbl_course where dept_id='" + lbl_dept_handler.Text + "'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    combobox_display_course.Items.Add(dr["course_name"].ToString());
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

        private void combobox_display_course_SelectedIndexChanged(object sender, EventArgs e)
        {
      
          
        }

        private void lbl_dept_handler_Click(object sender, EventArgs e)
        {

        }

        private void Reader_Status()
        {
            /*string reader = (NFC.GetReadersList()[0]);
            NFC.Connect();
            if (NFC.connActive==true)
            {
                lbl_reader_status.Text = "Connected";
            }
            else
            {
                lbl_reader_status.Text = "Not Connected";
            }
            */
            NFCReader nfc = new NFCReader();

            try
            {
                nfc.Connect();
                lbl_reader_status.Text = "Connected";
            }
            catch
            {
                lbl_reader_status.Text = "Not Connected";
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
          
        }

        private void timer_reader_status_Tick(object sender, EventArgs e)
        {
            Reader_Status();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer_reader_card_Tick(object sender, EventArgs e)
        {
            if (lbl_reader_status.Text == "Connected")
            {
                try
                {

                    NFC.Connect();
                    NFC.GetCardUID();
                    txt_RFID_UID.Text = NFC.GetCardUID();
                }
                catch {
                    MessageBox.Show("Reader has been removed!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void txt_RFID_UID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
