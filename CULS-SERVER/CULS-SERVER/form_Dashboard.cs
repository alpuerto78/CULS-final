using CULS_SERVER.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using Separator = LiveCharts.Wpf.Separator;
using System.Globalization;
using DGVPrinterHelper;

namespace CULS_SERVER
{
    public partial class form_Dashboard : Form
    {
        //variable for Database connection
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        DB_conn dbcon = new DB_conn();
        SqlDataAdapter da = new SqlDataAdapter();

        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        private bool Collapse;

        //RFID variable handlers
        NFCReader NFC = new NFCReader();
        int retCode;
        int hCard;
        int hContext;
        int Protocol;
        public bool connActive = false;
        string readername = "";      // change depending on reader
        public byte[] SendBuff = new byte[263];
        public byte[] RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol, dwProtocol, cbPciLength;
        public Card.SCARD_READERSTATE RdrState;
        public Card.SCARD_IO_REQUEST pioSendRequest;

        bool _flag_reader_remove = true;
      //  string image_id;

        //Variable use for Connection Terminal
        //listener for SERVER andito si IP at port
        TcpListener listener = null;    
        TcpClient client;
        Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>();
        CancellationTokenSource cancellation = new CancellationTokenSource();
        List<string> chat = new List<string>();
        
        public form_Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            dashboard_onload();
            //RFID needs to loads right after the program start
            SelectDevice();
            establishContext();
            Reader_Status();
            _load_piechart_users();
            _load_bargraph_users();
            _load_bargraph_usage_monthly();
            _load_bargraph_usage_annual();
            grid_cells_color();
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

        private void grid_cells_color()
        {
            grid_student.DefaultCellStyle.ForeColor = Color.FromArgb(47,47,47);
            grid_logs.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
            grid_dept.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
            grid_courses.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
            grid_daily_logs.DefaultCellStyle.ForeColor= Color.FromArgb(47, 47, 47);
            grid_monthly_logs.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
            grid_annual_logs.DefaultCellStyle.ForeColor = Color.FromArgb(47, 47, 47);
        }
        private void label1_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Are you sure you want to exit?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                listener.Stop();
                updateUI("Server Stopped");
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    broadcastSocket.Close();
                }
                this.Dispose();
                Environment.Exit(0);
            }
        }
        private void lbl_close_MouseHover(object sender, EventArgs e)
        {
            lbl_close.BackColor = Color.FromArgb(255, 106, 112, 117);
        }
        private void lbl_close_MouseLeave(object sender, EventArgs e)
        {
            lbl_close.BackColor = Color.FromArgb(255, 67, 71, 74);
        }
        private void lbl_windows_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void lbl_windows_minimize_MouseHover(object sender, EventArgs e)
        {
            lbl_windows_minimize.BackColor = Color.FromArgb(255, 106, 112, 117);
        }
        private void lbl_windows_minimize_MouseLeave(object sender, EventArgs e)
        {
            lbl_windows_minimize.BackColor = Color.FromArgb(255, 67, 71, 74);
        }
        private void button_manage_users_Click(object sender, EventArgs e)
        {
            collapse_user.Start();
        }
        private void collapse_user_Tick(object sender, EventArgs e)
        {
            if (Collapse)
            {
                button_manage_users.Iconimage_right = Resources.Icon_DropDown_Minimize_Portable;
                panel_user.Height += 20;
                if (panel_user.Size == panel_user.MaximumSize)
                {
                    collapse_user.Stop();
                    Collapse = false;
                }
            }
            else
            {
                button_manage_users.Iconimage_right = Resources.Icon_DropDown_Maximize_Portable;
                panel_user.Height -= 20;
                if (panel_user.Size == panel_user.MinimumSize)
                {
                    collapse_user.Stop();
                    Collapse = true;
                }
            }
        }
        private void label_current_time_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_manage_users.Iconimage_right = Resources.Icon_DropDown_Maximize_Portable;
            button_report.Iconimage_right = Resources.Icon_DropDown_Maximize_Portable;
            timer_clock.Start();
            label_current_date.Text = DateTime.Now.ToString("MM/dd/yyyy");
            label_current_time.Text = DateTime.Now.ToString("HH:mm");
            onLoadupdateUI();
            DB_Handlers.Daily_TimeCredit_Refresher();
            cancellation = new CancellationTokenSource(); //resets the token when the server restarts
            startServer();
            load_daily_logs_records();
            load_monthly_logs_records();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_current_time.Text = DateTime.Now.ToLongTimeString();
            timer_clock.Start();
        }

        private void label_current_date_Click(object sender, EventArgs e)
        {
         
        }
        private void button_logs_Click(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_logs);
            lbl_pages.Text = "Session Logs";
            load_logs_records();
        }

        private void bunifuFlatButton2_Click_2(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_Computer_Terminal);
            lbl_pages.Text = "Computer Terminal";
            tabcontrol_terminal.SelectTab(tab_pc);
            GetData_PC();
            clear_login_user_credentials();

            //initial na pagbukas ay makikita ay yung recent or yung pinakadulong data ng server logs
            txt_server_logs.SelectionStart = txt_server_logs.TextLength;
            txt_server_logs.ScrollToCaret();
        }

        private void bunifuFlatButton6_Click_2(object sender, EventArgs e)
        {
            lbl_pages.Text = "Manage User/Search User";
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_Dashboard);
            lbl_pages.Text = "Dashboard";
            _1stcardcounter();
            _2ndcardcounter();
            _3rdcardcounter();
            _4thcardcounter();
            _load_piechart_users();
            _load_bargraph_users();
            _load_bargraph_usage_monthly();
            _load_bargraph_usage_annual();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button_report_Click(object sender, EventArgs e)
        {
            collapse_report.Start();
        }
        private void collapse_report_Tick(object sender, EventArgs e)
        {
            if (Collapse)
            {
                button_report.Iconimage_right = Resources.Icon_DropDown_Minimize_Portable;
                panel_report.Height += 15;
                if (panel_report.Size == panel_report.MaximumSize)
                {
                    collapse_report.Stop();
                    Collapse = false;
                }
            }
            else
            {
                button_report.Iconimage_right = Resources.Icon_DropDown_Maximize_Portable;
                panel_report.Height -= 15;
                if (panel_report.Size == panel_report.MinimumSize)
                {
                    collapse_report.Stop();
                    Collapse = true;
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            lbl_pages.Text = "Logs";
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", _title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                listener.Stop();
                updateUI("Server Stopped");
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    broadcastSocket.Close();
                }


                form_Login f1 = new form_Login();
                this.Hide();
                f1.ShowDialog();
            }
            else
            {
                //retain lang 
                //do nothing
            }
        }
        private void panel_sidemenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_titlebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_add_user_Click(object sender, EventArgs e)
        {
            //open to student section
            tabcontrol_multipage_handler.SelectTab(tab_manage_student);
            lbl_pages.Text = "Management/Users";
            load_student_records();
        }



        private void button_daily_report_Click(object sender, EventArgs e)
        {
            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };

            t1.Start();


            void Method1()
            {
                form_Preload f1 = new form_Preload();
                f1.ShowDialog();
            }

            tabcontrol_multipage_handler.SelectTab(tab_daily_report);
                   lbl_pages.Text = "Manage User/Daily Report";
            //      load_daily_logs_records();
            
        }
            private void button_Monthly_report_Click(object sender, EventArgs e)
        {
            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };

            t1.Start();


            void Method1()
            {
                form_Preload f1 = new form_Preload();
                f1.ShowDialog();
            }
            tabcontrol_multipage_handler.SelectTab(tab_monthly_report);
            lbl_pages.Text = "Manage User/Monthly Report";
        //    dtpicker_sort_by_date_monthly_logs_mm.SelectedIndex = 0;
          //  dtpicker_sort_by_date_monthly_logs_yyyy.SelectedIndex = 0;
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tab_Dashboard_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_pages_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_annual_report_Click(object sender, EventArgs e)
        {
    

            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };

            t1.Start();


            void Method1()
            {
                form_Preload f1 = new form_Preload();
                f1.ShowDialog();
            }

            tabcontrol_multipage_handler.SelectTab(tab_annual_report);
            lbl_pages.Text = "Manage User/Annual Report";
            dtpicker_sort_by_date_annual_logs_yyyy.SelectedIndex = 0;
           

        }

        private void tabcontrol_multipage_handler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button_manage_dept_Click(object sender, EventArgs e)
        {
            //open to dept section
            tabcontrol_multipage_handler.SelectTab(tab_manage_department);
            lbl_pages.Text = "Management/Department";
            load_dept_records();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            form_department_add f1 = new form_department_add(this);
            f1.button_save.Text = "SAVE";
            f1.lbl_dept_add.Text = "ADD DEPARTMENT";
            f1.ShowDialog();
        }

        private void grid_dept_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {

            string colName = grid_dept.Columns[e.ColumnIndex].Name;
            if (colName == "dept_colEdit")
            {
                form_department_add f1 = new form_department_add(this);
                f1.lbl_dept_value.Text = grid_dept.Rows[e.RowIndex].Cells[1].Value.ToString();
                f1.textbox_department.Text = grid_dept.Rows[e.RowIndex].Cells[2].Value.ToString();
                f1.textbox_dept_description.Text = grid_dept.Rows[e.RowIndex].Cells[3].Value.ToString();
                f1.button_save.Text = "UPDATE";
                f1.lbl_dept_add.Text = "UPDATE DEPARTMENT";

                f1.ShowDialog();
            }
            else if (colName == "dept_colDelete")
            {

                if (MessageBox.Show("Delete this record?", _title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        cn.Open();
                        cm = new SqlCommand("DELETE FROM tbl_department where dept_id like '" + grid_dept.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Record has been successfully deleted.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn.Close();
                        load_dept_records();
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }

                }
            }
        }
        public void load_dept_records()
        {
            try
            {
                grid_dept.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("SELECT * FROM  tbl_department ORDER BY dept_id DESC", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_dept.Rows.Add(i, dr["dept_id"].ToString(), dr["dept_name"].ToString(), dr["dept_description"].ToString());
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


        private void button_manage_courses_Click(object sender, EventArgs e)
        {
            //open to course section
            tabcontrol_multipage_handler.SelectTab(tab_manage_courses);
            lbl_pages.Text = "Management/Courses";
            load_course_records();
            //  this.combo_sort_category_dept.Items.Clear();
            load_category_dept_sort();

            combo_sort_category_dept.SelectedIndex = 0;
        }

        private void button_courses_add_Click(object sender, EventArgs e)
        {

            form_course_add f1 = new form_course_add(this);
            f1.button_course_save.Text = "SAVE";
            f1.lbl_course_add.Text = "ADD COURSES";
            f1.ShowDialog();
        }

        private void grid_courses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = grid_courses.Columns[e.ColumnIndex].Name;


            if (colName == "course_colEdit")
            {

                form_course_add f1 = new form_course_add(this);
                f1.lbl_course_value.Text = grid_courses.Rows[e.RowIndex].Cells[1].Value.ToString();
                f1.lbl_dept_value.Text = grid_courses.Rows[e.RowIndex].Cells[2].Value.ToString();
                f1.txt_course_name.Text = grid_courses.Rows[e.RowIndex].Cells[3].Value.ToString();
                f1.txt_course_descript.Text = grid_courses.Rows[e.RowIndex].Cells[4].Value.ToString();

                //potang ina gumana hahahahah nanghuhula lang ako ng code
                try
                {
                    cn.Open();
                    cm = new SqlCommand("Select dept_name from tbl_department where dept_id='" + f1.lbl_dept_value.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        f1.combobox_display_dept.Text = (dr["dept_name"].ToString());
                    }
                    dr.Close();
                    cn.Close();
                    f1.button_course_save.Text = "UPDATE";
                    f1.lbl_course_add.Text = "UPDATE COURSE";
                    f1.ShowDialog();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "course_colDelete")
            {

                if (MessageBox.Show("Delete this record?", _title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM tbl_course where course_id like '" + grid_courses.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();

                    MessageBox.Show("Record has been successfully deleted.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    load_course_records();

                }
            }
        }
        public void load_course_records()
        {
            try
            {
                grid_courses.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("SELECT * FROM  tbl_course ORDER BY course_id DESC", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_courses.Rows.Add(i, dr["course_id"].ToString(), dr["dept_id"].ToString(), dr["course_name"].ToString(), dr["course_description"].ToString());
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


        public void load_course_records_category()
        {
            try
            {
                grid_courses.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("Select * from tbl_course where dept_id='" + lbl_dept_handler.Text + "'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_courses.Rows.Add(i, dr["course_id"].ToString(), dr["dept_id"].ToString(), dr["course_name"].ToString(), dr["course_description"].ToString());
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

        private void load_category_dept_sort()
        {
            combo_sort_category_dept.Items.Clear();

            try
            {
                this.combo_sort_category_dept.Items.AddRange(new object[] { "ALL RECORDS" });
                cn.Open();
                cm = new SqlCommand("SELECT [dept_name] From  tbl_department", cn);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    // this.combo_sort_category_dept.Items.Clear();
                    combo_sort_category_dept.Items.Add(dr[0].ToString());
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

        private void combo_sort_category_dept_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // load_category_dept_sort();

            try
            {
                cn.Open();
                string q = "Select dept_id from tbl_department where dept_name='" + combo_sort_category_dept.SelectedItem + "'";
                cm = new SqlCommand(q, cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lbl_dept_handler.Text = dr[0].ToString();
                    //textbox_dept_description.Text = dr[0].ToString();
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            load_course_records_category();


            if (combo_sort_category_dept.Text == "ALL RECORDS")
            {
                load_course_records();
            }
            /*

                try
                {
                    grid_courses.Rows.Clear();
                    int i = 0;
                    cn.Open();

                    cm = new SqlCommand("SELECT dept_id FROM  tbl_department where dept_name =@dept_id ", cn);
                    cm.CommandType = CommandType.Text;
                    cm.Parameters.AddWithValue("@dept_id", department_id);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        i++;
                        grid_courses.Rows.Add(i, dr["course_name"].ToString(), dr["Course_description"].ToString());
                    }
                    dr.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                */

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_search_course_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_search_course_OnValueChanged(object sender, EventArgs e)
        {
            //make the combo_dept be clear when search is use

            //code for smart search
            try
            {
                grid_courses.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("Select * from tbl_course where course_name like'%" + txt_search_course.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_courses.Rows.Add(i, dr["course_id"].ToString(), dr["dept_id"].ToString(), dr["course_name"].ToString(), dr["course_description"].ToString());
                }
                dr.Close();
                cn.Close();
                combo_sort_category_dept.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //DASHBOARD

        //Counter ng cards 
        //Function 
  
        public void _1stcardcounter()
        {
            try
            {
                lbl_1st_card_counter.Text = "";
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(CASE WHEN PC_status = 'IDLE' THEN 1 END) FROM tbl_PC", cn);
                Int32 count = Convert.ToInt32(cm.ExecuteScalar());
                lbl_1st_card_counter.Text = Convert.ToString(count.ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void _2ndcardcounter()
        {
            try
            {
                lbl_2nd_card_counter.Text = "";
                cn.Open();
                cm = new SqlCommand("SELECT (count_LIMITED +count_UNLIMITED) FROM( SELECT COUNT(CASE WHEN PC_status ='LIMITED' THEN 1 END) as count_LIMITED,COUNT(CASE WHEN PC_status = 'UNLIMITED' THEN 1 END) as count_UNLIMITED FROM tbl_PC)x", cn);
                Int32 count = Convert.ToInt32(cm.ExecuteScalar());
                lbl_2nd_card_counter.Text = Convert.ToString(count.ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void _3rdcardcounter()
        {
            try
            {
                lbl_3rd_card_counter.Text = "";
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(CASE WHEN PC_status = 'OFF' THEN 1 END) FROM tbl_PC", cn);
                Int32 count = Convert.ToInt32(cm.ExecuteScalar());
                lbl_3rd_card_counter.Text = Convert.ToString(count.ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void _4thcardcounter()
        {
            try
            {
                lbl_4th_card_counter.Text = "";
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(CASE WHEN PC_status = 'TIMEOUT' THEN 1 END) FROM tbl_PC", cn);
                Int32 count = Convert.ToInt32(cm.ExecuteScalar());
                lbl_4th_card_counter.Text = Convert.ToString(count.ToString());
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void _load_piechart_users()
        {
            piechart_users.Series["Series1"].Points.Clear();
            piechart_users.PaletteCustomColors = new Color[] { Color.FromArgb(223, 173, 93), Color.FromArgb(224, 93, 111), Color.FromArgb(65, 139, 202), Color.FromArgb(21, 159, 133) };

            int _total_users_chart = 0;

            try
            {
                cn.Open();
                cm = new SqlCommand("select sum(TotalUsertypes) as TotalCount from(SELECT usertype_name, COUNT(usertype_name) as TotalUsertypes FROM tbl_users GROUP BY usertype_name)a", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    _total_users_chart = int.Parse(dr["TotalCount"].ToString());
                   
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
           //     MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pie_chart_total_users_result.Text = _total_users_chart.ToString();
            try
            {               
                cn.Open();
                cm = new SqlCommand("SELECT usertype_name, COUNT(usertype_name)as TotalUsertypes FROM tbl_users GROUP BY usertype_name; ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    piechart_users.Series["Series1"].IsValueShownAsLabel = true;
                    
                   string x = dr["usertype_name"].ToString();
                    double  y = int.Parse(dr["TotalUsertypes"].ToString());
                    double _percentage_total_users_chart = y/_total_users_chart;
                    string result_percent = _percentage_total_users_chart.ToString("P", CultureInfo.InvariantCulture);
              
                    piechart_users.Series["Series1"].Points.AddXY(x,_percentage_total_users_chart);
                  //  charts_pie_users.Series.Add(dr['usertype_name'].ToString())
                }
                dr.Close();
                cn.Close();             
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            piechart_users.Series[0].ChartType = SeriesChartType.Doughnut;
           // piechart_users.Series[0].Points.DataBindXY(x, y);
            piechart_users.Legends[0].Enabled = true;
            //   piechart_users.ChartAreas[0].Area3DStyle.Enable3D = true;

      
        }
        private void _load_bargraph_users()
        {
            bargraph_users.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            bargraph_users.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            bargraph_users.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            bargraph_users.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            bargraph_users.PaletteCustomColors = new Color[] { Color.FromArgb(21, 159, 133), Color.FromArgb(224, 93, 111), Color.FromArgb(65, 139, 202), Color.FromArgb(223, 173, 93) };
            bargraph_users.Series["student"].Points.Clear();
            bargraph_users.Series["alumni"].Points.Clear();
            bargraph_users.Series["employee"].Points.Clear();
            bargraph_users.Series["visitor"].Points.Clear();
            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_DAILY_LOGS_CHARTS_SELECT";
                cm.Parameters.Clear();             
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    this.bargraph_users.Series["student"].Points.AddXY(dr["time_span"].ToString(), Int32.Parse(dr["student"].ToString()));
                    this.bargraph_users.Series["alumni"].Points.AddXY(dr["time_span"].ToString(), Int32.Parse(dr["alumni"].ToString()));
                    this.bargraph_users.Series["employee"].Points.AddXY(dr["time_span"].ToString(), Int32.Parse(dr["employee"].ToString()));
                    this.bargraph_users.Series["visitor"].Points.AddXY(dr["time_span"].ToString(), Int32.Parse(dr["visitor"].ToString()));
                    // bargraph_users.Series[1].XValueMember = dr["dept_name"].ToString();
                    //        bargraph_users.Series[1].YValueMembers = dr["7:00-8:00"].ToString();
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void _load_bargraph_usage_monthly()
        {
            bargraph_usage_monthly.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            bargraph_usage_monthly.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            bargraph_usage_monthly.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            bargraph_usage_monthly.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            bargraph_usage_monthly.PaletteCustomColors = new Color[] { Color.FromArgb(21, 159, 133), Color.FromArgb(224, 93, 111), Color.FromArgb(65, 139, 202), Color.FromArgb(223, 173, 93) };
            bargraph_usage_monthly.Series["student"].Points.Clear();
            bargraph_usage_monthly.Series["alumni"].Points.Clear();
            bargraph_usage_monthly.Series["employee"].Points.Clear();
            bargraph_usage_monthly.Series["visitor"].Points.Clear();
            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_MONTHLY_LOGS_CHARTS_SELECT";
                cm.Parameters.Clear();
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    this.bargraph_usage_monthly.Series["student"].Points.AddXY(dr["date_span"].ToString(), Int32.Parse(dr["student"].ToString()));
                    this.bargraph_usage_monthly.Series["alumni"].Points.AddXY(dr["date_span"].ToString(), Int32.Parse(dr["alumni"].ToString()));
                    this.bargraph_usage_monthly.Series["employee"].Points.AddXY(dr["date_span"].ToString(), Int32.Parse(dr["employee"].ToString()));
                    this.bargraph_usage_monthly.Series["visitor"].Points.AddXY(dr["date_span"].ToString(), Int32.Parse(dr["visitor"].ToString()));
                    // bargraph_users.Series[1].XValueMember = dr["dept_name"].ToString();
                    //        bargraph_users.Series[1].YValueMembers = dr["7:00-8:00"].ToString();
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void _load_bargraph_usage_annual()
        {
            bargraph_usage_annual.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            bargraph_usage_annual.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            bargraph_usage_annual.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            bargraph_usage_annual.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            bargraph_usage_annual.PaletteCustomColors = new Color[] { Color.FromArgb(21, 159, 133), Color.FromArgb(224, 93, 111), Color.FromArgb(65, 139, 202), Color.FromArgb(223, 173, 93) };
            bargraph_usage_annual.Series["student"].Points.Clear();
            bargraph_usage_annual.Series["alumni"].Points.Clear();
            bargraph_usage_annual.Series["employee"].Points.Clear();
            bargraph_usage_annual.Series["visitor"].Points.Clear();
            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_ANNUAL_LOGS_CHARTS_SELECT";
                cm.Parameters.Clear();
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    this.bargraph_usage_annual.Series["student"].Points.AddXY(dr["month_span"].ToString(), Int32.Parse(dr["student"].ToString()));
                    this.bargraph_usage_annual.Series["alumni"].Points.AddXY(dr["month_span"].ToString(), Int32.Parse(dr["alumni"].ToString()));
                    this.bargraph_usage_annual.Series["employee"].Points.AddXY(dr["month_span"].ToString(), Int32.Parse(dr["employee"].ToString()));
                    this.bargraph_usage_annual.Series["visitor"].Points.AddXY(dr["month_span"].ToString(), Int32.Parse(dr["visitor"].ToString()));
                    // bargraph_users.Series[1].XValueMember = dr["dept_name"].ToString();
                    //        bargraph_users.Series[1].YValueMembers = dr["7:00-8:00"].ToString();
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //onload para di mahaba sa taas ang declaration
        private void dashboard_onload()
        {
            _1stcardcounter();
            _2ndcardcounter();
            _3rdcardcounter();
            _4thcardcounter();
        }
        //STUDENT SECTION
        private void button_student_add_Click(object sender, EventArgs e)
        {
            form_manage_users f1 = new form_manage_users(this);


            f1.button_save_student.Text = "SAVE";
            f1.lbl_student_details.Text = "ADD USER DETAILS";
            f1.ShowDialog();
        }

        private void dash_pagination_previous_Click(object sender, EventArgs e)
        {


        }
        public void load_student_records()
        {
            grid_student.Rows.Clear();
            try
            {

                grid_courses.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("Select * from tbl_users ORDER BY user_id DESC", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_student.Rows.Add(i, dr["user_id"].ToString(), dr["UID"].ToString(), dr["stud_id_no"].ToString(), dr["firstname"].ToString(), dr["lastname"].ToString(), dr["dept_name"].ToString(), dr["course_name"].ToString(), dr["usertype_name"].ToString(), dr["imagepath"].ToString());
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
        public void load_logs_records()
        {
            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
           
            grid_student.Rows.Clear();
            try
            {
                grid_logs.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("Select * from tbl_session_logs  where  cast ([login] as date) = '" +_currentdate + "'  ORDER BY log_id DESC", cn);
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
                    string _login = dt_login.ToString("hh:mm"), _logout = dt_logout;
                    grid_logs.Rows.Add(i, dr["UID"].ToString(), _login, _logout, dr["session"].ToString(), dr["terminal"].ToString(), dr["purpose"].ToString());
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
        public void load_daily_logs_records()
        {
            //------------pampabilis daw ng pagload ng data---------------------------------------///
            //grid_daily_logs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //// or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            //// set it to false if not needed
            //grid_daily_logs.RowHeadersVisible = false;

            //--------------------------------------------------------------------------------------//


            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            dtpicker_sort_by_date_daily_logs.Text = DateTime.Now.ToString("MM/dd/yyyy");
            grid_daily_logs.Rows.Clear();
            try
            {
                grid_daily_logs.Rows.Clear();
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_DAILY_LOGS_SELECT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@current_Date", _currentdate);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    grid_daily_logs.Rows.Add(dr["dept_name"].ToString().ToUpper(), dr["course_name"].ToString().ToUpper(), dr["7:00-8:00"].ToString(), dr["8:00-9:00"].ToString(), dr["9:00-10:00"].ToString(), dr["10:00-11:00"].ToString(), dr["11:00-12:00"].ToString(), dr["12:00-1:00"].ToString(), dr["1:00-2:00"].ToString(), dr["2:00-3:00"].ToString(), dr["3:00-4:00"].ToString(), dr["4:00-5:00"].ToString(), dr["5:00-6:00"].ToString(), dr["6:00-7:00"].ToString(), dr["TOTAL"].ToString());
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
                //remove duplicate records
                //tang ina ang hirap hahaha
                string removeduplicatecells = grid_daily_logs.Rows[0].Cells[0].Value.ToString();       
                for (int i=1;i<grid_daily_logs.Rows.Count;i++)
                {
                    if (grid_daily_logs.Rows[i].Cells[0].Value.ToString() == removeduplicatecells)
                    {
                        grid_daily_logs.Rows[i].Cells[0].Value = string.Empty;
                    }
                    else
                    {
                        removeduplicatecells = grid_daily_logs.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void load_monthly_logs_records()
        {
            string _yyyy_value = dtpicker_sort_by_date_monthly_logs_yyyy.Text;
            //------------pampabilis daw ng pagload ng data---------------------------------------///
            //grid_daily_logs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //// or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            //// set it to false if not needed
            //grid_daily_logs.RowHeadersVisible = false;

            //--------------------------------------------------------------------------------------//


            //  string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            //  dtpicker_sort_by_date_daily_logs.Text = DateTime.Now.ToString("MM/dd/yyyy");
            grid_monthly_logs.Rows.Clear();
            try
            {
                grid_monthly_logs.Rows.Clear();
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_MONTHLY_LOGS_SELECT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@mm", _mm_value);
                cm.Parameters.AddWithValue("@yyyy",_yyyy_value );
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    grid_monthly_logs.Rows.Add(dr["dept_name"].ToString().ToUpper(), dr["course_name"].ToString().ToUpper(), dr["1"].ToString(), dr["2"].ToString(), dr["3"].ToString(), dr["4"].ToString(), dr["5"].ToString(), dr["6"].ToString(), dr["7"].ToString(), dr["8"].ToString(), dr["9"].ToString(), dr["10"].ToString(), dr["11"].ToString(), dr["12"].ToString(), dr["13"].ToString(), dr["14"].ToString(), dr["15"].ToString(), dr["16"].ToString(), dr["17"].ToString(), dr["18"].ToString(), dr["19"].ToString(), dr["20"].ToString(), dr["21"].ToString(), dr["22"].ToString(), dr["23"].ToString(), dr["24"].ToString(), dr["25"].ToString(), dr["26"].ToString(), dr["27"].ToString(), dr["28"].ToString(), dr["29"].ToString(), dr["30"].ToString(), dr["31"].ToString(), dr["TOTAL"].ToString());
                }
                dr.Close();
                cm.Parameters.Clear();
                cn.Close();
                //remove duplicate records
                //tang ina ang hirap hahaha
                string removeduplicatecells = grid_monthly_logs.Rows[0].Cells[0].Value.ToString();
                for (int i = 1; i < grid_monthly_logs.Rows.Count; i++)
                {
                    if (grid_monthly_logs.Rows[i].Cells[0].Value.ToString() == removeduplicatecells)
                    {
                        grid_monthly_logs.Rows[i].Cells[0].Value = string.Empty;
                    }
                    else
                    {
                        removeduplicatecells = grid_monthly_logs.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void load_annual_logs_records()
        {
            //------------pampabilis daw ng pagload ng data---------------------------------------///
            //grid_daily_logs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //// or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            //// set it to false if not needed
            //grid_daily_logs.RowHeadersVisible = false;

            //--------------------------------------------------------------------------------------//


           // string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");
           // dtpicker_sort_by_date_daily_logs.Text = DateTime.Now.ToString("MM/dd/yyyy");
            grid_annual_logs.Rows.Clear();
            try
            {
                grid_annual_logs.Rows.Clear();
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_ANNUAL_LOGS_SELECT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("yyyy", dtpicker_sort_by_date_annual_logs_yyyy.Text);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    grid_annual_logs.Rows.Add(dr["dept_name"].ToString().ToUpper(), dr["course_name"].ToString().ToUpper(), dr["January"].ToString(), dr["February"].ToString(), dr["March"].ToString(), dr["April"].ToString(), dr["May"].ToString(), dr["June"].ToString(), dr["July"].ToString(), dr["August"].ToString(), dr["September"].ToString(), dr["October"].ToString(), dr["November"].ToString(), dr["December"].ToString(), dr["TOTAL"].ToString());
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
                //remove duplicate records
                //tang ina ang hirap hahaha
                string removeduplicatecells = grid_annual_logs.Rows[0].Cells[0].Value.ToString();
                for (int i = 1; i < grid_annual_logs.Rows.Count; i++)
                {
                    if (grid_annual_logs.Rows[i].Cells[0].Value.ToString() == removeduplicatecells)
                    {
                        grid_annual_logs.Rows[i].Cells[0].Value = string.Empty;
                    }
                    else
                    {
                        removeduplicatecells = grid_annual_logs.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void select_logs_records(string _terminal)
        {        
            try
            {
           
                cn.Open();
                cm = new SqlCommand("select * from tbl_current_session where PC_name='" + _terminal + "'", cn); 
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    Handler_Logout hd_lg = new Handler_Logout();
                    hd_lg.POST_Logout_id = dr["log_id"].ToString();
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
        private void dtpicker_sort_by_date_ValueChanged_1(object sender, EventArgs e)
        {
            grid_student.Rows.Clear();
            try
            {
                grid_logs.Rows.Clear();
                int i = 0;
                cn.Open();
                cm = new SqlCommand("Select * from tbl_session_logs  where  cast ([login] as date) = '" + dtpicker_sort_by_date.Text + "'  ORDER BY log_id DESC", cn);
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
                    string _login = dt_login.ToString("hh:mm"), _logout = dt_logout;
                    grid_logs.Rows.Add(i, dr["UID"].ToString(), _login, _logout, dr["session"].ToString(), dr["terminal"].ToString(), dr["purpose"].ToString());
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

        private void grid_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string image_id;

            string colName = grid_student.Columns[e.ColumnIndex].Name;
            if (colName == "stud_colEdit")
            {

                form_manage_users f1 = new form_manage_users(this);
                f1.button_save_student.Text = "UPDATE";
                f1.lbl_student_details.Text = "UPDATE USER DETAILS";
                f1.txt_RFID_UID.Text= grid_student.Rows[e.RowIndex].Cells[2].Value.ToString();
                f1.txt_stud_id_no.Text = grid_student.Rows[e.RowIndex].Cells[3].Value.ToString();
                f1.txt_firstname.Text = grid_student.Rows[e.RowIndex].Cells[4].Value.ToString();
                f1.txt_lastname.Text = grid_student.Rows[e.RowIndex].Cells[5].Value.ToString();
                f1.cbo_dept.Text = grid_student.Rows[e.RowIndex].Cells[6].Value.ToString();
                f1.cbo_course.Text = grid_student.Rows[e.RowIndex].Cells[7].Value.ToString();
                f1.cbo_usertype.Text= grid_student.Rows[e.RowIndex].Cells[8].Value.ToString();
                image_id = grid_student.Rows[e.RowIndex].Cells[1].Value.ToString();
                //f1.lbl_imagepath_handler.Text= grid_student.Rows[e.RowIndex].Cells[9].Value.ToString();
                //f1.lbl_id_handler.Text = grid_student.Rows[e.RowIndex].Cells[1].Value.ToString();


                //set the id_handler 
                //reference in the Handler class
                User user_handler  = new User();
                user_handler.ID_handler = grid_student.Rows[e.RowIndex].Cells[1].Value.ToString();

                //set the image_handler 
                user_handler.Image_handler = grid_student.Rows[e.RowIndex].Cells[9].Value.ToString();

                //set the UID_handler 
                user_handler.UID_handler = grid_student.Rows[e.RowIndex].Cells[2].Value.ToString();
                try
                {
                    cn.Open();
                    // cm = new SqlCommand("SELECT [imagepath] From  tbl_student", cn);
                   
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT * From  tbl_users where user_id=" + image_id + "", cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    string paths = Application.StartupPath;
                    f1.picbox_student.Image = Image.FromFile(paths + dt.Rows[0]["imagepath"].ToString());
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                f1.ShowDialog();
               
            }
            else if (colName == "stud_colDelete")
            {
                
            
                if (MessageBox.Show("Delete this record?", _title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM tbl_users where user_id like '" + grid_student.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    //delete image in the folder
                    string paths = Application.StartupPath;
                    string image_file = grid_student.Rows[e.RowIndex].Cells[9].Value.ToString();                   
                    try
                    {
                    System.IO.File.Delete(paths + image_file);
                    }
                    catch
                    {
                        //wala lang error nito ay garbage cc usedby another process 
                        //do nothing 
                    }
                    MessageBox.Show("Record has been successfully deleted.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    load_student_records();
                }
            }


            //VIEW USER PROFILES AND LOG HISTORY
            else if ((colName == "UID") || (colName == "Student_ID") || (colName == "Firstname") || (colName == "Lastname") || (colName == "counter_data_student"))
            {
                form_User_Sessions f1 = new form_User_Sessions();
                User_Sessions Usr_sssn = new User_Sessions();
                Usr_sssn.RFID_UID= grid_student.Rows[e.RowIndex].Cells[2].Value.ToString();
                f1.ShowDialog();
               
            }
        }
      
        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_search_student_OnValueChanged(object sender, EventArgs e)
        {
            //code for smart search
            try
            {
                grid_student.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("Select * from tbl_users where  CONCAT([UID], [stud_id_no],[firstname], [lastname],[dept_name], [course_name], [usertype_name])  like'%" + txt_search_student.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    grid_student.Rows.Add(i, dr["user_id"].ToString(), dr["UID"].ToString(), dr["stud_id_no"].ToString(), dr["firstname"].ToString(), dr["lastname"].ToString(), dr["dept_name"].ToString(), dr["course_name"].ToString(), dr["usertype_name"].ToString(), dr["imagepath"].ToString());
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
        //-------------------------------------------------------------------------------------------------------------------//
        //COMPUTER TERMINALS
        private Label terminal;
        private PictureBox pic;   
        private void btn_add_terminals_Click(object sender, EventArgs e)
        {
            string _UID = null;
            
            Terminal_handler cout = new Terminal_handler();
            //get the total numbers of PC 
            count_PC();
           
            if (MessageBox.Show("Do you want to add Terminal?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //Check if PC reach maximum 
                if (cout.Max_PC == int.Parse(cout.Count_PC))
                {
                    MessageBox.Show("You have reach the maximum Terminal that can be use", _title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string pc_default_name = "PC-";
                    //  MessageBox.Show( pc_default_name + (int.Parse(cout.Count_PC)+1));
                    Int32 counter = int.Parse(cout.Count_PC);
                    //Increment by the current value
                    counter = counter + 1;
                    string counter_out = "";
                    //If single digit add zero before the number DB_Handlers.AddToCurrentSession
                    if (Convert.ToInt32(counter) < 10)
                    {
                        counter_out = ("0" + counter);
                    }
                    else
                    {
                        counter_out = counter.ToString();
                    }
                    try
                    {
                        cn.Open();
                        cm.Connection = cn;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SP_STATUS_INSERT";
                        cm.Parameters.AddWithValue("@PC_name", pc_default_name + counter_out);
                        cm.Parameters.AddWithValue("@PC_status", "OFF");
                        cm.ExecuteNonQuery();
                        cn.Close();
                        cm.Parameters.Clear();
                        MessageBox.Show("Successfully Added New Terminal!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string _terminal = pc_default_name + counter_out;
                        DB_Handlers.AddToCurrentSession(_terminal);
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    GetData_PC();
                }
            }
            else
            {
                return;
            }
        }
        public void GetData_PC()
        {                     
                flpnl_terminals.Controls.Clear();
            //      flpnl_terminals.Controls
            cn.Close();
                cn.Open();
                cm = new SqlCommand("Select * from tbl_PC", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    //  terminal =  new Label();
                    // terminal.Text = dr["Pc_id"].ToString();
                    pic = new PictureBox();
                    pic.Width = 100;
                    pic.Height = 100;
                    pic.BackgroundImageLayout = ImageLayout.Stretch;
                    pic.Tag = dr["PC_name"].ToString();
                    string terminal_status;
                    terminal_status = dr["PC_status"].ToString();
                    string b = dr["PC_id"].ToString();
                
                switch (terminal_status)
                       {
                    case "IDLE":
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Idle;                     
                        break;
                    case "OFF":
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Time_Off;
                    
                        break;
                    case "TIMEOUT":
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Timeout;        
                        break;
                        //edit_icon in the resources
                    case "LIMITED":
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Limited;                    
                        break;
                        //edit icon in the resources
                    case "UNLIMITED":
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Unlimited;
                        break;
                    default:
                        pic.BackgroundImage = Properties.Resources.Icon_Terminal_Time_Off;
                        break;
                }
                

                flpnl_terminals.Controls.Add(pic);
              

                //Terminal name display in array
                terminal = new Label();
                    terminal.Text = dr["PC_name"].ToString();
                    terminal.BackColor = Color.Transparent;

                    terminal.TextAlign = ContentAlignment.BottomCenter;
                    terminal.Dock = DockStyle.Bottom;
                    
                //terminal.Margin = new Padding(0,0,10,0);
                    terminal.Tag = dr["PC_name"].ToString();

                    //  terminal.Click += (sender, e) => Onclick(this,e, terminal.Tag.ToString());
                    pic.Click += new EventHandler(Onclick);
                    pic.Margin = new Padding(20, 0, 10, 10);
                    pic.Controls.Add(terminal);
                    // this.Controls.Add(pic);
                    pic.Cursor = Cursors.Hand;

            }
                dr.Close();
                cn.Close();         
        }
       
        public void count_PC()
        {
            try
            {
                Terminal_handler cout = new Terminal_handler();
                cn.Open();
                cm = new SqlCommand("SELECT COUNT(DISTINCT PC_name) FROM tbl_PC", cn);
                Int32 count = Convert.ToInt32(cm.ExecuteScalar());
                cout.Count_PC = Convert.ToString(count.ToString());
                cn.Close();
                //MessageBox.Show(cout);
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //    public void Onclick(object sender , EventArgs e, String Tag)
        public void Onclick(object sender, EventArgs e)
           {
         
            form_Terminal_Control frmterminal = new form_Terminal_Control();

            String tag = ((PictureBox)sender).Tag.ToString();
            try
            {              
                cn.Open();
                cm = new SqlCommand("Select * from tbl_PC where PC_name like '"+tag+"'", cn);
                dr = cm.ExecuteReader();            
                {
                    while (dr.Read())
                 
                    command_lbl_terminal_name.Text = dr["PC_name"].ToString();             
                }              
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            string _currentstatus = null;
            //disable buttons varies in pc status
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_PC where PC_name like '" + tag + "'", cn);
                dr = cm.ExecuteReader();
                {
                    while (dr.Read())

                        _currentstatus = dr["PC_status"].ToString();
                    switch (_currentstatus)
                    {
                        case "IDLE":
                            btn_terminal_control_logout.Enabled = false;
                            btn_terminal_control_add_time.Enabled = true;
                            btn_terminal_control_restart.Enabled = true;
                            btn_terminal_control_shutdown.Enabled = true;
                            break;
                        case "OFF":
                            btn_terminal_control_logout.Enabled = false;
                            btn_terminal_control_add_time.Enabled = false;
                            btn_terminal_control_restart.Enabled = false;
                            btn_terminal_control_shutdown.Enabled = false;

                            break;
                        case "TIMEOUT":
                            btn_terminal_control_logout.Enabled = true;
                            btn_terminal_control_add_time.Enabled = false;
                            btn_terminal_control_restart.Enabled = true;
                            btn_terminal_control_shutdown.Enabled = true;

                            break;
                        //edit_icon in the resources
                        case "LIMITED":
                            btn_terminal_control_logout.Enabled = true;
                            btn_terminal_control_add_time.Enabled = false;
                            btn_terminal_control_restart.Enabled = true;
                            btn_terminal_control_shutdown.Enabled = true;

                            break;
                        //edit icon in the resources
                        case "UNLIMITED":
                            btn_terminal_control_logout.Enabled = true;
                            btn_terminal_control_add_time.Enabled = false;
                            btn_terminal_control_restart.Enabled = true;
                            btn_terminal_control_shutdown.Enabled = true;
                            break;
                        default:
                            btn_terminal_control_logout.Enabled = false;
                            btn_terminal_control_add_time.Enabled = false;
                            btn_terminal_control_restart.Enabled = false;
                            btn_terminal_control_shutdown.Enabled = false;
                            break;
                    }
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            //refirect to form commands
            tabcontrol_terminal.SelectTab(tab_command);
            //retrieve images on the commands
            GetControlImages();
        }
        //--------------------------------------------------------------------------------------------------------//
        //Server Connection
        public void updateUI(String message)
        {
            string _timenow = DateTime.Now.ToString("HH:mm:ss");
            string _datenow = DateTime.Now.ToString("yyyy-MM-dd");
            string _datetimenow = DateTime.Now.ToString();
            string _logs = null;
            string _time_logs = null;
            cn.Close();
            //clear the previous log 
            //iinvoke natin kasi magccross thread
            //try
            //{
            //    this.Invoke((MethodInvoker)delegate // To Write the Received data
            //    {

            //        txt_server_logs.Clear();
            //    });
            //}
            //catch
            //{
            //    //bypass lang
            //}
           
            //update the txt_server_logs

            //update the logs in database
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_SERVER_LOGS_INSERT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@date_record",_datetimenow);
                cm.Parameters.AddWithValue("@log_specification",message);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {            
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();
            try
            {
                //current day lang na logs  iddisplay ninya 
                cn.Open();
                cm = new SqlCommand("select * from tbl_server_logs where date_record>='"+_datenow+ "' order by date_record", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    DateTime dateTime = DateTime.Parse(dr["date_record"].ToString());
                    _time_logs = dateTime.ToString("HH:mm:ss");
                    _logs = dr["log_specification"].ToString();
                    
                    //  MessageBox.Show(dr["log_specification"].ToString());
                   
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception )
            {
               
                // may error pag kaka establish pa alng ng connection tas biglang close    
            }
            this.Invoke((MethodInvoker)delegate // To Write the Received data
            {

                txt_server_logs.AppendText(_timenow+ "-> " + message + Environment.NewLine);
            });

        }
        public void onLoadupdateUI()
        {
            string _timenow = DateTime.Now.ToString("HH:mm:ss");
            string _datenow = DateTime.Now.ToString("yyyy-MM-dd");
            string _datetimenow = DateTime.Now.ToString();
            string _logs = null;
            string _time_logs = null;
            cn.Close();
          //  clear the previous log
         //   iinvoke natin kasi magccross thread
            try
            {
                this.Invoke((MethodInvoker)delegate // To Write the Received data
                {

                    txt_server_logs.Clear();
                });
            }
            catch
            {
                //bypass lang
            }

        //    update the txt_server_logs

          ///  update the logs in database
           
            try
            {
                //current day lang na logs  iddisplay ninya 
                cn.Open();
                cm = new SqlCommand("select * from tbl_server_logs where date_record>='" + _datenow + "' order by date_record", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    DateTime dateTime = DateTime.Parse(dr["date_record"].ToString());
                    _time_logs = dateTime.ToString("HH:mm:ss");
                    _logs = dr["log_specification"].ToString();

                    //  MessageBox.Show(dr["log_specification"].ToString());
                    this.Invoke((MethodInvoker)delegate // To Write the Received data
                    {

                        txt_server_logs.AppendText(_time_logs + "-> " + _logs + Environment.NewLine);
                    });
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception )
            {

                // may error pag kaka establish pa alng ng connection tas biglang close    
            }        
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if
                      (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public async void startServer()
        {
            try
            {
                Int32 port = 5000;
                IPAddress localAddr = IPAddress.Parse(GetLocalIPAddress());
                // TcpListener server = new TcpListener(port);
                listener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), port);
                listener.Start();
                updateUI("Server Started at " + listener.LocalEndpoint);
                updateUI("Waiting for Clients");
                try
                {
                    int counter = 0;
                    while (true)
                    {
                        counter++;
                        //client = await listener.AcceptTcpClientAsync();
                        client = await Task.Run(() => listener.AcceptTcpClientAsync(), cancellation.Token);

                        /* get username */
                        byte[] name = new byte[50];
                        NetworkStream stre = client.GetStream(); //Gets The Stream of The Connection
                        stre.Read(name, 0, name.Length); //Receives Data 
                        String username = Encoding.ASCII.GetString(name); // Converts Bytes Received to String
                        username = username.Substring(0, username.IndexOf("$"));

                        /* add to dictionary, listbox and send userList  */
                        clientList.Add(username, client);
                        listBox1.Items.Add(username);

                        //lagyan ng condition 
                        //GetCurrentPCStatus GC = new GetCurrentPCStatus();
                        //DB_Handlers.GetCurrentStatusPC(username);
                        //MessageBox.Show(GC.Current_pc_stat_pc_session);
                        
                        //if (GC.Current_pc_stat_pc_session== "LIMITED" || GC.Current_pc_stat_pc_session == "UNLIMITED" || GC.Current_pc_stat_pc_session == "TIMEOUT")
                        //{
                        //    //do nothin retain the current status
                        //    //pang reconnect kasi pag namatay si client
                        //    updateUI("Client Reconnected: " + username);
                        //}
                        //else 
                        //{
                            //updateUI("Client Connected: " + username + " - " + client.Client.RemoteEndPoint);
                            updateUI("Client Connected: " + username);
                            //update terminal_status
                            string terminal_name = username;
                            string terminal_stat = "IDLE";
                            update_terminal_status_idle(terminal_name, terminal_stat);

                        //}
                        //  announce(username + " Joined ", username, false);

                        await Task.Delay(1000).ContinueWith(t => sendUsersList());
                        var c = new Thread(() => ServerReceive(client, username));
                        c.Start();
                    }
                }
                catch(Exception)
                {
                    //MessageBox.Show(er.Message);
                    listener.Stop();
                }
        }
            catch (Exception ex)
            {
                if (ex.Message== "The requested address is not valid in its context")
                {
                    MessageBox.Show("The Ip Address is not valid in its context", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
}
        }
        //-----------Update Status Terminal to IDLE---------------------//
        public void update_terminal_status_idle(string terminal_name,string terminal_status)
        {        
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_STATUS_UPDATE";
                cm.Parameters.AddWithValue("@PC_name", terminal_name);
                cm.Parameters.AddWithValue("@PC_status", terminal_status);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GetData_PC();
            //--------------------------------------------------//
        }
        public void announce(string msg, string uName, bool flag)
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    if (flag)
                    {
                        //broadcastBytes = Encoding.ASCII.GetBytes("gChat|*|" + uName + " says : " + msg);

                        chat.Add("gChat");
                        chat.Add(uName + " says : " + msg);
                        broadcastBytes = ObjectToByteArray(chat);
                    }
                    else
                    {
                        //broadcastBytes = Encoding.ASCII.GetBytes("gChat|*|" + msg);

                        chat.Add("gChat");
                        chat.Add(msg);
                        broadcastBytes = ObjectToByteArray(chat);

                    }
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            }
            catch 
            {

            }
        }  //end broadcast function

        //check if connection is still alive 
        //baka iloop ko ito ng timer para di magcross threads

        public void KeepAlive()
        {
            try
            {
                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;

                    chat.Add("gChat");
                    chat.Add("COMMAND|CHECKSTATUS|");
                    broadcastBytes = ObjectToByteArray(chat);
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                    chat.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"");
            }
        }  //end broadcast function
        public Object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        
        public void ServerReceive(TcpClient clientn, String username)
        {
            
            byte[] data = new byte[1000];
            
            while (true)
            {
                try
                {

                    NetworkStream stream = clientn.GetStream(); //Gets The Stream of The Connection
                    stream.Read(data, 0, data.Length); //Receives Data 
                    List<string> parts = (List<string>)ByteArrayToObject(data);

                    switch (parts[0])
                    {
                        case "gChat":

                            string[] receiveTextSplit =parts[1].Split('|');
                         
                                if (receiveTextSplit[0] == "COMMAND")
                                {
                                    //receiveTextSplit[1]=logout
                                    //receiveTextSplit[2]=terminal name
                                    //receiveTextSplit[3]=terminal status
                                    //receiveTextSplit[4]=UID
                                    //receiveTextSplit[5]=remaining time
                                    if (receiveTextSplit[1] == "LOGOUT")
                                    {
                                     
                                        string terminal_name = receiveTextSplit[2];
                                        string terminal_status = "IDLE";
                                        update_terminal_status_logout(terminal_name, terminal_status);
                                        updateUI(terminal_name + " - " + "LOGOUT");
                                        if (receiveTextSplit[3] == "LIMITED")
                                        {
                                            DB_Handlers.UpdateSubtractRemainingTime(receiveTextSplit[4], receiveTextSplit[5]);
                                                                                  
                                        }
                                        select_logs_records(receiveTextSplit[2]);                                      
                                        DateTime _logout = DateTime.Now;
                                        Handler_Logout hd_lg = new Handler_Logout();
                                        int _log_id = int.Parse(hd_lg.POST_Logout_id); 
                                        DB_Handlers.UpdateToSessionLogs(_log_id, _logout);
                                        //      DB_Handlers.UpdateToCurrentSession();
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            tabcontrol_terminal.SelectTab(tab_pc);
                                        });
                                        cn.Close();                               
                                    }
                                else if (receiveTextSplit[1] == "TIMEOUT")
                                {
                                    string terminal_name = receiveTextSplit[2];
                                    string terminal_status = "TIMEOUT";
                                    update_terminal_status_logout(terminal_name, terminal_status);
                                    updateUI(terminal_name + " - " + "SESSION ABOUT TO END");
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        tabcontrol_terminal.SelectTab(tab_pc);
                                    });
                                    cn.Close();
                                }
                                break;

                            }
                            else
                            {
                                this.Invoke((MethodInvoker)delegate // To Write the Received data
                                {
                                    txt_server_logs.Text += DateTime.Now.ToString("HH:mm:ss") + "-> " + username + ": " + parts[1] + Environment.NewLine;
                                    //    string cmd = parts[1];        

                                });
                             //   announce(parts[1], username, true);
                                break;

                            }
                        case "pChat":
                            privateChat(parts);
                            break;
                    }
                    parts.Clear();
                }
                catch (Exception ex)
                {
               //    MessageBox.Show(ex.Message);
                    updateUI("Client Disconnected: " + username);
            //        announce("Client Disconnected: " + username + "$", username, false);
                    //update to terminal status to off
                    string terminal_name = username;
                    string terminal_status = "OFF";
                    update_terminal_status_off(terminal_name, terminal_status);
                    clientList.Remove(username);
                    //------------------------------------------------------//

                    this.Invoke((MethodInvoker)delegate
                    {
                        listBox1.Items.Remove(username);
                    });
                    sendUsersList();
                    break;
                }
            }
        }
        public void update_terminal_status_off(string terminal_name,string terminal_status)
        {
            //---------------------update status terminal status to OFF--------------//
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_STATUS_UPDATE";
                cm.Parameters.AddWithValue("@PC_name", terminal_name);
                cm.Parameters.AddWithValue("@PC_status",terminal_status);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Invoke((MethodInvoker)delegate
            {
                GetData_PC();
            });

        }

        public void sendUsersList()
        {
            try
            {
                byte[] userList = new byte[1024];
                string[] clist = listBox1.Items.OfType<string>().ToArray();
                List<string> users = new List<string>();

                users.Add("userList");
                foreach (String name in clist)
                {
                    users.Add(name);
                }
                userList = ObjectToByteArray(users);

                foreach (var Item in clientList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    broadcastStream.Write(userList, 0, userList.Length);
                    broadcastStream.Flush();
                    users.Clear();
                }
            }
            catch 
            {
            }
        }

        private void privateChat(List<string> text)
        {
            try
            {           
                byte[] byData = ObjectToByteArray(text);

                TcpClient workerSocket = null;
                workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == text[1]).Value; //find the client by username in dictionary

                NetworkStream stm = workerSocket.GetStream();
                stm.Write(byData, 0, byData.Length);
                stm.Flush();
            }
            catch
            {
            }
        }
    

        private void flpnl_terminals_Paint(object sender, PaintEventArgs e)
        {

        }

      //--------------------------------------------------------------------------//
      //SETTINGS
        private void button_settings_Click(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_settings);
            lbl_pages.Text = "Settings";
            cbo_settings_time_limit.SelectedIndex = 1;
            current_time_limit();

            network_settings_txtbox_ipadd.Text = GetLocalIPAddress();
            network_settings_txtbox_port.Text = "5000";

            database_settings_txt_server_name.Text=System.Net.Dns.GetHostName().ToUpper()+ @"\SQLEXPRESS";
            database_settings_combobox_database_selection.SelectedIndex = 0;
        }

        private void settings_tabpage_time_limit_Click(object sender, EventArgs e)
        {
           
        }

        private void settings_tabpage_network_Click(object sender, EventArgs e)
        {
       
        }
        public void current_time_limit()
        {
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_TIME_LIMIT_CURRENT_LIMIT_SELECT";
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txt_settings_time_limit_current_limit.Text= (dr["time_limit_name"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void button_settings_time_limit_save_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All time credit will reset! Are you sure you want to proceed?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string _timelimit = cbo_settings_time_limit.Text;
                int _time_limit_val = 0;
                int _time_limit_id = 1;
                switch (_timelimit)
                {
                    case "4 hours":
                        _time_limit_val = 240;
                        break;
                    case "2 hours":
                        _time_limit_val = 120;
                        break;
                    case "1 hour":
                        _time_limit_val = 60;
                        break;
                    case "30 mins":
                        _time_limit_val = 30;
                        break;
                    case "15 mins":
                        _time_limit_val = 15;
                        break;
                }

                //UPDATE TIME_REMAINING
                try
                {
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_TIME_LIMIT_UPDATE";
                    cm.Parameters.AddWithValue("@time_limit", _time_limit_val);
                    cm.Parameters.AddWithValue("@time_limit_name", _timelimit);
                    cm.Parameters.AddWithValue("@time_limit_id", _time_limit_id);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    cm.Parameters.Clear();
                    //UPDATE ALL TIME_REMAINING IN USERS
                    
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_SETTINGS_TIME_REMAINING_UPDATE";
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@time_remaining", _time_limit_val);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Successfully Updated Time Limit!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cm.Parameters.Clear();
                    current_time_limit();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            flpnl_terminals.Visible = false;
        }
        private void settings_tabcontrol_handler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lbl_close_terminal_command_Click(object sender, EventArgs e)
        {
            tabcontrol_terminal.SelectTab(tab_pc);
        }

        public void GetControlImages()
        {
            //Get the Image from the resource
            btn_terminal_control_add_time.Image = Properties.Resources.icon_terminal_control_add_time;
            btn_terminal_control_logout.Image = Properties.Resources.icon_terminal_control_logout_user;
            btn_terminal_control_restart.Image = Properties.Resources.icon_terminal_control_restart;
            btn_terminal_control_shutdown.Image = Properties.Resources.icon_terminal_control_shutdown;
        }

        private void btn_terminal_control_add_time_Click(object sender, EventArgs e)
        {
            tabcontrol_terminal.SelectTab(tab_add_time);
            pnl_add_time.Size = new Size(680
                , 360
                );
            txt_add_time_terminal_name.Text = command_lbl_terminal_name.Text;
                }

        private void lbl_close_terminal_add_time_Click(object sender, EventArgs e)
        {
            tabcontrol_terminal.SelectTab(tab_pc);
            clear_login_user_credentials(); 
            
        }



        //----------ADD TIME-------------------------------///
     
        private void Reader_Status()
        {
            NFCReader nfc = new NFCReader();
            try
            {
                nfc.Connect();
               lbl_reader_status.Text = "Connected";
            }
            catch
            {
                lbl_reader_status.Text = "Not Connected";
                try
                {
                    establishContext();
                    SelectDevice();
                }
                catch
                {
                    //return;
                }
            }
        }  
        //---------------------------------------------------------------------------------------------//
        //RFID Codes
        public void SelectDevice()
        {
            try
            {
                List<string> availableReaders = this.ListReaders();
                this.RdrState = new Card.SCARD_READERSTATE();
                readername = availableReaders[0].ToString();//selecting first device
                                                            //MessageBox.Show(readername);
                this.RdrState.RdrName = readername;
            }
            catch
            {
                //return;
                //basta wala itong gagawin
            }
        }

        private void timer_reader_status_Tick_1(object sender, EventArgs e)
        {
            Reader_Status();
        }

        private void timer_reader_card_Tick_1(object sender, EventArgs e)
        {
            if (lbl_reader_status.Text == "Connected")
            {
                try
                {
                    NFC.Connect();
                    if (connectCard())
                    {
                        string cardUID = getcardUID();
                        txt_RFID_UID.Text = cardUID; //displaying on text block
                        _flag_reader_remove = true;
                    }
                }
                catch
                {
                    if (_flag_reader_remove)
                    {
                        _flag_reader_remove = false;
                        MessageBox.Show("Reader has been removed!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //clear user credentials when reader is remove
                        clear_login_user_credentials();


                    }
                }
            }
            else
            {
                txt_RFID_UID.Clear();
            }
        }
        private void clear_login_user_credentials()
        {
            txt_RFID_UID.Clear();
            txt_usertype.Clear();
            txt_dept.Clear();
            txt_course.Clear();
            txt_usertype.Clear();
            txt_add_time_time_remaining.Clear();
            txt_stud_id_no.Clear();
            picbox_student.Image = Resources.Icon_ManageUsers_Ref;
            txt_add_time_purpose.Clear();
            radio_add_time_limited.Checked = true;
            lbl_error_msg_add_time.Visible = false;
        }
        private void txt_RFID_UID_TextChanged_1(object sender, EventArgs e)
        {
            //63000000 code is an error exception built in the library/sdk of ACR/rfid 
            string error = "63000000";
            if (txt_RFID_UID.Text == error)
            {
                clear_login_user_credentials();
            }
            get_user_details();
        }

        public List<string> ListReaders()
        {
            int ReaderCount = 0;
            List<string> AvailableReaderList = new List<string>();

            //Make sure a context has been established before 
            //retrieving the list of smartcard readers.
            retCode = Card.SCardListReaders(hContext, null, null, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //   MessageBox.Show(Card.GetScardErrMsg(retCode));
                connActive = false;
            }
            byte[] ReadersList = new byte[ReaderCount];

            //Get the list of reader present again but this time add sReaderGroup, retData as 2nd & 3rd parameter respectively.
            retCode = Card.SCardListReaders(hContext, null, ReadersList, ref ReaderCount);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                // MessageBox.Show(Card.GetScardErrMsg(retCode));
            }
            string rName = "";
            int indx = 0;
            if (ReaderCount > 0)
            {
                // Convert reader buffer to string
                while (ReadersList[indx] != 0)
                {

                    while (ReadersList[indx] != 0)
                    {
                        rName = rName + (char)ReadersList[indx];
                        indx = indx + 1;
                    }

                    //Add reader name to list
                    AvailableReaderList.Add(rName);
                    rName = "";
                    indx = indx + 1;
                }
            }
            return AvailableReaderList;
        }
        private void button_login_cancel_Click(object sender, EventArgs e)
        {
            tabcontrol_terminal.SelectTab(tab_pc);
            clear_login_user_credentials();
        }

        private void btn_terminal_control_restart_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("Are you sure you want to restart " + command_lbl_terminal_name.Text, _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                try
                {
                    String clientName = command_lbl_terminal_name.Text;
                    String command = "COMMAND|RESTART|";
                    chat.Clear();
                    chat.Add("gChat");
                    chat.Add(command);

                    byte[] byData = ObjectToByteArray(chat);
                    TcpClient workerSocket = null;
                    workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == clientName).Value;
                    //  TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

                    NetworkStream stm = client.GetStream();
                    stm.Write(byData, 0, byData.Length);
                    stm.Flush();
                }
                catch
                {
                    MessageBox.Show(txt_add_time_terminal_name.Text + " has been disconnected or suddenly shutdown", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btn_terminal_control_shutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to shutdown " + command_lbl_terminal_name.Text, _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    String clientName = command_lbl_terminal_name.Text;
                    String command = "COMMAND|SHUTDOWN|";
                    chat.Clear();
                    chat.Add("gChat");
                    chat.Add(command);

                    byte[] byData = ObjectToByteArray(chat);
                    TcpClient workerSocket = null;
                    workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == clientName).Value;
                    //  TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

                    NetworkStream stm = client.GetStream();
                    stm.Write(byData, 0, byData.Length);
                    stm.Flush();
                }
                catch
                {
                    MessageBox.Show(txt_add_time_terminal_name.Text + " has been disconnected or suddenly shutdown", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_terminal_control_logout_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to logout " + command_lbl_terminal_name.Text, _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                try
                {
                    String clientName = command_lbl_terminal_name.Text;
                    String command = "COMMAND|LOGOUT|";
                    chat.Clear();
                    chat.Add("gChat");
                    chat.Add(command);

                    byte[] byData = ObjectToByteArray(chat);
                    TcpClient workerSocket = null;
                    workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == clientName).Value;
                    //  TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

                    NetworkStream stm = client.GetStream();
                    stm.Write(byData, 0, byData.Length);
                    stm.Flush();
                }
                catch
                {
                    MessageBox.Show(txt_add_time_terminal_name.Text + " has been disconnected or suddenly shutdown", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void button_login_user_Click_1(object sender, EventArgs e)
        {
            String terminal_name = command_lbl_terminal_name.Text;
            String _userUID = txt_RFID_UID.Text;
            String _purpose = txt_add_time_purpose.Text;
            DateTime _dateTime = DateTime.Now;
            String _userName = txt_lastname.Text;
            Handler_Logout hd_lg = new Handler_Logout();
            //if user is not yet register
            if (lbl_error_msg_add_time.Visible == true)
            {
                if (MessageBox.Show("User is not yet register! Add user?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    form_manage_users form_mng_usr = new form_manage_users(this);
                    form_mng_usr.ShowDialog();
                    clear_login_user_credentials();
                    return;
                }
                else
                {
                    return;
                }
               
            }
            if ((txt_RFID_UID.Text == String.Empty) ||  (txt_firstname.Text == String.Empty) || (txt_lastname.Text == String.Empty)|| (txt_add_time_terminal_name.Text == String.Empty) || (txt_add_time_purpose.Text == String.Empty))

            {
                MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_add_time_purpose.Focus();
                return;
            }
            else
            {
                if (radio_add_time_limited.Checked == true)
                {
                    int time_remaining = Convert.ToInt32(txt_remaining_time_left.Text);
                    //If users remaining time is zero then it will ask the server if it will use unlimited session
                    if (time_remaining == 0)
                    {
                        if (MessageBox.Show("User already use his time credit! Move to Unlimited Session?", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            radio_add_time_unlimited.Checked = true;
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    //If users have remaining time then login 
                    try
                    {
                        string _sessiontype = "LIMITED";
                        String command = "COMMAND|ADDTIME|LIMITED|" + time_remaining + "|"+_userUID + "|";
                        //txt1->issue a command 
                        //txt2->type of command
                        //txt3->type of session
                        //txt4->remaining time of the user
                        //txt5->RFID tag number of the user                 
                        chat.Clear();
                        chat.Add("gChat");
                        chat.Add(command);

                        byte[] byData = ObjectToByteArray(chat);
                        TcpClient workerSocket = null;
                        workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == terminal_name).Value;
                        //  TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

                        NetworkStream stm = client.GetStream();
                        stm.Write(byData, 0, byData.Length);
                        stm.Flush();
                        MessageBox.Show("User successfully login to " + terminal_name, _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //update the status of the client
                        string terminal_status = "LIMITED";
                        update_terminal_status_timein(terminal_name,terminal_status);
                        updateUI("Session started: "+ terminal_name +" - "+ terminal_status);
                        DB_Handlers.AddToSessionLogs(_userUID, _dateTime, _purpose, terminal_name, _sessiontype);
                        DB_Handlers.Select_log_id(_userUID, _dateTime);                
                        int _log_out_id = int.Parse(hd_lg.PRE_Logout_id);
                        DB_Handlers.UpdateToCurrentSession(_userUID, _log_out_id, terminal_name, _sessiontype);
                        tabcontrol_terminal.SelectTab(tab_pc);
                        clear_login_user_credentials();
                        chat.Clear();
                    }
                    catch
                    {
                        MessageBox.Show(txt_add_time_terminal_name.Text + " has been disconnected or suddenly shutdown", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else if (radio_add_time_unlimited.Checked == true)
                {
                    string _sessiontype = "UNLIMITED";
                    
                    try
                    {                       
                        String command = "COMMAND|ADDTIME|UNLIMITED|" + _userUID + "|";
                        chat.Clear();
                        chat.Add("gChat");
                        chat.Add(command);

                        byte[] byData = ObjectToByteArray(chat);
                        TcpClient workerSocket = null;
                        workerSocket = (TcpClient)clientList.FirstOrDefault(x => x.Key == terminal_name).Value;
                        //  TcpClient client = new TcpClient(("127.0.0.1"),int.Parse(txt_TCP_add_time.Text));

                        NetworkStream stm = client.GetStream();
                        stm.Write(byData, 0, byData.Length);
                        stm.Flush();
                        MessageBox.Show("User successfully login to "+terminal_name, _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //method para maupdate kung naging unlimited na
                        string terminal_status = "UNLIMITED";
                        update_terminal_status_timein(terminal_name, terminal_status);
                        updateUI("Session started: " + terminal_name + " - " + terminal_status);
                        tabcontrol_terminal.SelectTab(tab_pc);
                        DB_Handlers.AddToSessionLogs(_userUID, _dateTime,_purpose,terminal_name,_sessiontype);
                        DB_Handlers.Select_log_id(_userUID, _dateTime);                     
                        int _log_out_id = int.Parse(hd_lg.PRE_Logout_id);
                        DB_Handlers.UpdateToCurrentSession(_userUID,_log_out_id, terminal_name, _sessiontype);
                        clear_login_user_credentials();
                        chat.Clear();
                        this.Invoke((MethodInvoker)delegate
                        {
                            GetData_PC();
                        });
                    }
                    catch
                    {
                        MessageBox.Show(txt_add_time_terminal_name.Text + " has been disconnected or suddenly shutdown", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

 
        }

        private void txt_server_logs_TextChanged(object sender, EventArgs e)
        {
            txt_server_logs.SelectionStart = txt_server_logs.TextLength;
            txt_server_logs.ScrollToCaret();
        }

        public void update_terminal_status_timein(string terminal_name,string terminal_status)
        {
                //---------------------update status--------------//
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_STATUS_UPDATE";
                cm.Parameters.AddWithValue("@PC_name", terminal_name);
                cm.Parameters.AddWithValue("@PC_status", terminal_status);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //invoke para iwas cross threads 
            this.Invoke((MethodInvoker)delegate
            {
                GetData_PC();
            });
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //applKeepAlive();
        }

        public void update_terminal_status_logout(string terminal_name, string terminal_status)
        {
            //---------------------update status--------------//
            cn.Close();
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_STATUS_UPDATE";
                cm.Parameters.AddWithValue("@PC_name", terminal_name);
                cm.Parameters.AddWithValue("@PC_status", terminal_status);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //invoke para iwas cross threads 
            this.Invoke((MethodInvoker)delegate
            {
                GetData_PC();
            });
            cn.Close();
        }

        private void grid_logs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = grid_logs.Columns[e.ColumnIndex].Name;
            //VIEW USER PROFILES AND LOG HISTORY
            if ((colName == "logs_UID") || (colName == "logs_login") || (colName == "logs_logout") || (colName == "logs_session") || (colName == "logs_terminal") || (colName == "logs_purpose"))
            {
                form_User_Sessions f1 = new form_User_Sessions();
                User_Sessions Usr_sssn = new User_Sessions();
                Usr_sssn.RFID_UID = grid_logs.Rows[e.RowIndex].Cells[1].Value.ToString();
                f1.ShowDialog();

            }
        }

        private void dtpicker_sort_by_date_daily_logs_ValueChanged(object sender, EventArgs e)
        {
            //------------pampabilis daw ng pagload ng data---------------------------------------///
            grid_daily_logs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            // or even better, use .DisableResizing. Most time consuming enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            // set it to false if not needed
            grid_daily_logs.RowHeadersVisible = false;

            //--------------------------------------------------------------------------------------//
            string _currentdate = DateTime.Now.ToString("MM/dd/yyyy");

            grid_daily_logs.Rows.Clear();
            try
            {
                grid_daily_logs.Rows.Clear();
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_DAILY_LOGS_SELECT";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@current_Date", dtpicker_sort_by_date_daily_logs.Text);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    grid_daily_logs.Rows.Add(dr["dept_name"].ToString(), dr["course_name"].ToString(), dr["7:00-8:00"].ToString(), dr["8:00-9:00"].ToString(), dr["9:00-10:00"].ToString(), dr["10:00-11:00"].ToString(), dr["11:00-12:00"].ToString(), dr["12:00-1:00"].ToString(), dr["1:00-2:00"].ToString(), dr["2:00-3:00"].ToString(), dr["3:00-4:00"].ToString(), dr["4:00-5:00"].ToString(), dr["5:00-6:00"].ToString(), dr["6:00-7:00"].ToString(), dr["TOTAL"].ToString());
                }
                dr.Close();
                cn.Close();
                cm.Parameters.Clear();
                //kapag may duplicate na data sa department gagawin whitespace lang
                string removeduplicatecells = grid_daily_logs.Rows[0].Cells[0].Value.ToString();
                for (int i = 1; i < grid_daily_logs.Rows.Count; i++)
                {
                    if (grid_daily_logs.Rows[i].Cells[0].Value.ToString() == removeduplicatecells)
                    {
                        grid_daily_logs.Rows[i].Cells[0].Value = string.Empty;
                    }
                    else
                    {
                        removeduplicatecells = grid_daily_logs.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void database_settings_button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("SELECT * FROM sys.databases d WHERE d.database_id>4", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    database_settings_combobox_database_selection.Items.Add ((dr[0].ToString()));
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database_settings_txt_server_name.Enabled = false;
            database_settings_button_connect.Enabled = false;
            database_settings_button_disconnect.Enabled = true;
            database_settings_combobox_database_selection.Enabled = true;
        }

        private void database_settings_button_disconnect_Click(object sender, EventArgs e)
        {
            database_settings_txt_server_name.Enabled = true;
            database_settings_button_connect.Enabled = true;
            database_settings_button_disconnect.Enabled = false;
            database_settings_combobox_database_selection.Items.Clear();
            database_settings_combobox_database_selection.Items.Add("Please Select...");
            database_settings_combobox_database_selection.SelectedIndex = 0;
            database_settings_combobox_database_selection.Enabled = false;
            database_settings_txt_backup_path.Clear();
            database_settings_txt_backup_path.Enabled = false;
            database_settings_button_browse_backup.Enabled = false;
            database_settings_button_backup.Enabled = false;
            database_settings_txt_restore_path.Clear();
            database_settings_txt_restore_path.Enabled = false;
            database_settings_button_browse_restore.Enabled = false;
            database_settings_button_restore.Enabled = false;
            database_settings_button_connect.Focus();


        }

        private void database_settings_combobox_database_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (database_settings_combobox_database_selection.SelectedIndex != 0)
            {
                database_settings_txt_backup_path.Enabled = true;
                database_settings_button_browse_backup.Enabled = true;
                database_settings_txt_restore_path.Enabled = true;
                database_settings_button_browse_restore.Enabled = true;
            }
            else
            {
                database_settings_txt_backup_path.Enabled = false;
                database_settings_button_backup.Enabled = false;
                database_settings_button_browse_backup.Enabled = false;
                database_settings_txt_restore_path.Enabled = false;
                database_settings_button_restore.Enabled = false;
                database_settings_button_browse_restore.Enabled = false;
                database_settings_txt_restore_path.Clear();
                database_settings_txt_backup_path.Clear();
            }
            database_settings_txt_restore_path.Clear();
            database_settings_txt_backup_path.Clear();


        }

        private void database_settings_txt_backup_path_TextChanged(object sender, EventArgs e)
        {
            if (database_settings_txt_backup_path.Text.Trim() != string.Empty)
            {
                database_settings_button_backup.Enabled = true;
            }
            else
            {
                database_settings_button_backup.Enabled = false;
            }
        }

        private void database_settings_txt_restore_path_TextChanged(object sender, EventArgs e)
        {
            if (database_settings_txt_restore_path.Text.Trim() != string.Empty)
            {
                database_settings_button_restore.Enabled = true;
            }
            else
            {
                database_settings_button_restore.Enabled = false;
            }
        }

        private void database_settings_button_browse_backup_Click(object sender, EventArgs e)
        {
            if (database_settings_browse_folder_dialog_backup.ShowDialog() == DialogResult.OK)
            {
                database_settings_txt_backup_path.Text = database_settings_browse_folder_dialog_backup.SelectedPath;
            }
        }

        private void database_settings_button_backup_Click(object sender, EventArgs e)
        {
            //string _db_name = database_settings_combobox_database_selection.Text;
            //string _path_name = database_settings_txt_backup_path.Text;
            //MessageBox.Show(_path_name);
            try
            {
        
                cn.Open();
                cm.Connection = cn;
                cm = new SqlCommand("BACKUP DATABASE " + database_settings_combobox_database_selection.Text + " TO DISK='" + database_settings_txt_backup_path.Text.Trim() + "\\" + database_settings_combobox_database_selection.Text + "-" + DateTime.Now.ToString("dddd,dd MMMM yyyy HH-mm-tt") + ".bak'", cn);
                cm.ExecuteNonQuery();
                cm.Parameters.Clear();
                cn.Close();
                database_settings_txt_backup_path.Clear();
                MessageBox.Show("Database successfully backup", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    
        }

        private void database_settings_button_browse_restore_Click(object sender, EventArgs e)
        {
            if (database_settings_txt_backup_path.Text != @"C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup")
                database_settings_browse_file_dialog_restore.InitialDirectory = database_settings_txt_backup_path.Text;
            database_settings_browse_file_dialog_restore.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)| *.*";
            database_settings_browse_file_dialog_restore.FilterIndex = 0;
            if (database_settings_browse_file_dialog_restore.ShowDialog() == DialogResult.OK)
            {
                database_settings_txt_restore_path.Text = database_settings_browse_file_dialog_restore.FileName;
            }
        }

        private void database_settings_button_restore_Click(object sender, EventArgs e)
        {      
            try
            {        
                cn.Open();
                cm.Connection = cn;

                cm = new SqlCommand("ALTER DATABASE " + database_settings_combobox_database_selection.Text +" SET SINGLE_USER WITH ROLLBACK IMMEDIATE", cn);
                cm.ExecuteNonQuery();
                
                cm = new SqlCommand("USE MASTER RESTORE DATABASE " + database_settings_combobox_database_selection.Text + " FROM DISK='" + database_settings_txt_restore_path.Text.Trim() + "'WITH REPLACE;", cn);
                cm.ExecuteNonQuery();

                cm = new SqlCommand("ALTER DATABASE " + database_settings_combobox_database_selection.Text + " SET MULTI_USER", cn);
                cm.ExecuteNonQuery();


                cn.Close();
                database_settings_txt_restore_path.Clear();
                MessageBox.Show("Database successfully backup", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    
        }

        private void logs_daily_button_print_Click(object sender, EventArgs e)
        {

            //     DGVPrinter printer = new DGVPrinter();
            //     printer.Title = "Report";//Header
            //     printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
            //     printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //     printer.PageNumbers = true;
            //     printer.PageNumberInHeader = false;
            //     printer.PorportionalColumns = false;
            //     printer.HeaderCellAlignment = StringAlignment.Near;
            ////     printer.Footer = "Total Sales : " + totalprice.Text;//Footer
            //     printer.FooterSpacing = 15;
            //     //Print landscape mode
            //     printer.printDocument.DefaultPageSettings.Landscape = true;
            //     printer.PrintDataGridView(grid_daily_logs);

           form_daily_reports_fields f1=new form_daily_reports_fields();
            Daily_Report_Fields handler = new Daily_Report_Fields();
            handler.Daily_report_field_date = dtpicker_sort_by_date_daily_logs.Text;
            f1.ShowDialog();
        }
        int _mm_value = 0;
        private void dtpicker_sort_by_date_monthly_logs_mm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _mm = dtpicker_sort_by_date_monthly_logs_mm.Text;
           
            if (_mm== "January")
            {
                _mm_value = 1;
            }
            else if (_mm == "February")
            {
                _mm_value = 2;
            }
           else if (_mm == "March")
            {
                _mm_value = 3;
            }
           else if (_mm == "April")
            {
                _mm_value = 4;
            }
          else if (_mm == "May")
            {
                _mm_value = 5;
            }
           else if (_mm == "June")
            {
                _mm_value = 6;
            }
           else if (_mm == "July")
            {
                _mm_value = 7;
            }
          else  if (_mm == "August")
            {
                _mm_value = 8;
            }
           else if (_mm == "September")
            {
                _mm_value = 9;
            }
           else if (_mm == "October")
            {
                _mm_value = 10;
            }
          else  if (_mm == "November")
            {
                _mm_value = 11;
            }
           else if (_mm == "December")
            {
                _mm_value = 12;
            }


          load_monthly_logs_records();
        }

        private void dtpicker_sort_by_date_monthly_logs_yyyy_SelectedIndexChanged(object sender, EventArgs e)
        {

            load_monthly_logs_records();
        }

        private void dtpicker_sort_by_date_annual_logs_yyyy_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_annual_logs_records();
        }

        private void logs_monthly_button_print_Click(object sender, EventArgs e)
        {
            form_monthly_reports_fields f1 = new form_monthly_reports_fields();
            Monthly_Report_Fields handlers = new Monthly_Report_Fields();
            handlers.Monthly_report_field_month = dtpicker_sort_by_date_monthly_logs_mm.Text;
            handlers.Monthly_report_field_year = dtpicker_sort_by_date_monthly_logs_yyyy.Text;
         

            f1.ShowDialog();
        }

        private void logs_annual_button_print_Click(object sender, EventArgs e)
        {
            form_annual_reports_fields f1 = new form_annual_reports_fields();
            Annual_Report_Fields handler = new Annual_Report_Fields();
            handler.Annual_report_field_year =dtpicker_sort_by_date_annual_logs_yyyy.Text;
            f1.ShowDialog();
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void txt_settings_time_limit_current_limit_TextChanged(object sender, EventArgs e)
        {

        }

        private void account_settings_button_save_Click(object sender, EventArgs e)
        {
            if ((account_settings_txt_current_password.Text == String.Empty) || (account_settings_txt_new_password.Text == String.Empty) || (account_settings_txt_confirm_password.Text == String.Empty))
            {
                MessageBox.Show("Required Missing Field!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                account_clearall();
            }
            else if (DB_Handlers.IsCurrentPass(account_settings_txt_current_password.Text))
            {
                MessageBox.Show("Current password is not correct", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                account_settings_txt_current_password.Text = "";
                account_settings_txt_current_password.Focus();
            }
            else if (account_settings_txt_new_password.Text != account_settings_txt_confirm_password.Text)
            {
                MessageBox.Show("Password doesn't match!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                account_settings_txt_confirm_password.Text = "";
                account_settings_txt_confirm_password.Focus();
            }
            else
            {
                string _adm_user = "admin";
                string _adm_password = account_settings_txt_new_password.Text;
                DB_Handlers.AccountChangePass(_adm_user, _adm_password);
                account_clearall();
            }
        }
        private void account_clearall()
        {
            account_settings_txt_confirm_password.Text = "";
            account_settings_txt_current_password.Text = "";
            account_settings_txt_new_password.Text = "";
        }


        internal void establishContext()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //  MessageBox.Show("Check your device and please restart again", "Reader not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("basta may error");

                connActive = false;
                return;
            }
        }
        public bool connectCard()
        {
            connActive = true;
            retCode = Card.SCardConnect(hContext, readername, Card.SCARD_SHARE_SHARED,
                      Card.SCARD_PROTOCOL_T0 | Card.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //    MessageBox.Show(Card.GetScardErrMsg(retCode), "Card not available", MessageBoxButton.OK, MessageBoxImage.Error);
                connActive = false;
                return false;
            }
            return true;
        }
        private string getcardUID()//only for mifare 1k cards
        {
            string cardUID = "";
            byte[] receivedUID = new byte[256];
            Card.SCARD_IO_REQUEST request = new Card.SCARD_IO_REQUEST();
            request.dwProtocol = Card.SCARD_PROTOCOL_T1;
            request.cbPciLength = System.Runtime.InteropServices.Marshal.SizeOf(typeof(Card.SCARD_IO_REQUEST));
            byte[] sendBytes = new byte[] { 0xFF, 0xCA, 0x00, 0x00, 0x04 }; //get UID command      for Mifare cards
            int outBytes = receivedUID.Length;
            int status = Card.SCardTransmit(hCard, ref request, ref sendBytes[0], sendBytes.Length, ref request, ref receivedUID[0], ref outBytes);

            if (status != Card.SCARD_S_SUCCESS)
            {
                cardUID = "Error";
            }
            else
            {
                cardUID = BitConverter.ToString(receivedUID.Take(4).ToArray()).Replace("-", string.Empty).ToUpper();
            }
            return cardUID;
        }
        public void devices()
        {
            List<string> availableReaders = this.ListReaders();
            this.RdrState = new Card.SCARD_READERSTATE();
            readername = availableReaders[0].ToString();//selecting first device

            this.RdrState.RdrName = readername;
            //   MessageBox.Show("Show Device :");
        }
        public void get_user_details()
        {
            //UPDATE TIME_REMAINING
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_ADD_TIME_USERS_DETAILS_SELECT";
                cm.Parameters.AddWithValue("@UID", txt_RFID_UID.Text);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    txt_usertype.Text = (dr["usertype_name"].ToString());
                    txt_stud_id_no.Text = (dr["stud_id_no"].ToString());
                    txt_firstname.Text = (dr["firstname"].ToString());
                    txt_lastname.Text = (dr["lastname"].ToString());
                    txt_dept.Text = (dr["dept_name"].ToString());
                    txt_course.Text = (dr["course_name"].ToString());
                    txt_remaining_time_left.Text= (dr["time_remaining"].ToString());
                    string _time_rmn= (dr["time_remaining"].ToString());
                    ConvertTimeFormat(_time_rmn);

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

           // if user is not yet register prompt error handler
            if (txt_RFID_UID.Text != "" && txt_usertype.Text == string.Empty)
            {
                lbl_error_msg_add_time.Visible = true;
           
            }
            else
            {
                lbl_error_msg_add_time.Visible = false;
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
                get_minute =time;
                get_second = 60;
            }
            
            if (get_minute < 10)
            {
                txt_add_time_time_remaining.Text = "0" + get_hour.ToString() + ":0" + get_minute.ToString();
            }
            else{
                txt_add_time_time_remaining.Text = "0" + get_hour.ToString() + ":" + get_minute.ToString();

            }
        }
    }
}





