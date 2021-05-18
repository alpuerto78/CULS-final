using CULS_SERVER.Properties;
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
    public partial class Dashboard : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        ClassDB dbcon = new ClassDB();   
        SqlDataAdapter da = new SqlDataAdapter();

        string title = "Computer usage Limiter System";
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        private bool Collapse;
        public Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());

           
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

        private void label1_Click(object sender, EventArgs e)

        {
            Module_Close f1 = new Module_Close();
            f1.Show();
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_current_time.Text = DateTime.Now.ToLongTimeString();
            timer_clock.Start();
        }

        private void label_current_date_Click(object sender, EventArgs e)
        {

        }
        private void bunifuFlatButton2_Click_2(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_Computer_Terminal);
            lbl_pages.Text = "Computer Terminal";
        }

        private void bunifuFlatButton6_Click_2(object sender, EventArgs e)
        {
            lbl_pages.Text = "Manage User/Search User";
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            tabcontrol_multipage_handler.SelectTab(tab_Dashboard);
            lbl_pages.Text = "Dashboard";
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
                panel_report.Height += 20;
                if (panel_report.Size == panel_report.MaximumSize)
                {
                    collapse_report.Stop();
                    Collapse = false;
                }
            }
            else
            {
                button_report.Iconimage_right = Resources.Icon_DropDown_Maximize_Portable;
                panel_report.Height -= 20;
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
            if (MessageBox.Show("Are you sure you want to logout?", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Login f1 = new Login();
                this.Hide();
                f1.ShowDialog();
            }
            else
            {
                //retain lang 
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

        }

        private void button_edit_user_Click(object sender, EventArgs e)
        {
            lbl_pages.Text = "Manage User/Edit User";
        }

        private void button_daily_report_Click(object sender, EventArgs e)
        {
            lbl_pages.Text = "Manage User/Daily Report";
        }

        private void button_Monthly_report_Click(object sender, EventArgs e)
        {
            lbl_pages.Text = "Manage User/Monthly Report";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_close_MouseHover(object sender, EventArgs e)
        {
            lbl_close.BackColor = Color.FromArgb(255, 106, 112, 117);
        }

        private void lbl_close_MouseLeave(object sender, EventArgs e)
        {
            lbl_close.BackColor = Color.FromArgb(255, 67, 71, 74);
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
            f1.Show();
        }

        private void grid_dept_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
           
            string colName = grid_dept.Columns[e.ColumnIndex].Name;
            if (colName == "dept_colEdit")
            {
                form_department_add f1 = new form_department_add(this);

             
             
                f1.lbl_dept_value.Text= grid_dept.Rows[e.RowIndex].Cells[1].Value.ToString();
                f1.textbox_department.Text = grid_dept.Rows[e.RowIndex].Cells[2].Value.ToString();
                f1.textbox_dept_description.Text = grid_dept.Rows[e.RowIndex].Cells[3].Value.ToString();
                f1.button_save.Text = "UPDATE";
                f1.lbl_dept_add.Text = "UPDATE DEPARTMENT";

                f1.Show();
            }
            else if (colName == "dept_colDelete")
            {

                if (MessageBox.Show("Delete this record?", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM tbl_department where dept_name like '" + grid_dept.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Record has been successfully deleted.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    load_dept_records();

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

                cm = new SqlCommand("SELECT * FROM  tbl_department", cn);
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

        }

        private void button_courses_add_Click(object sender, EventArgs e)
        {

            form_course_add f1 = new form_course_add(this);
            f1.button_course_save.Text = "SAVE";
            f1.lbl_course_add.Text = "ADD COURSES";
            f1.Show();
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
                    f1.Show();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (colName == "course_colDelete")
            {

                if (MessageBox.Show("Delete this record?", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM tbl_course where course_id like '" + grid_courses.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                   
                    MessageBox.Show("Record has been successfully deleted.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                cm = new SqlCommand("SELECT * FROM  tbl_course", cn);
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



            string department_id;


            try
            {
                cn.Open();
                string q = "Select dept_id from tbl_department where dept_name='" + combo_sort_category_dept.SelectedItem + "'";
                cm = new SqlCommand(q, cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lbl_dept_handler.Text= dr[0].ToString();
                    //textbox_dept_description.Text = dr[0].ToString();



                }
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

            try
            {
                grid_courses.Rows.Clear();
                int i = 0;
                cn.Open();

                cm = new SqlCommand("Select * from tbl_course where course_name like'" + txt_search_course.Text + "%'", cn);
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
    }

    
    }    

