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
    public partial class form_course_add : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        DB_conn dbcon = new DB_conn();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        form_Dashboard _dashboard;
        string department_id;
        public form_course_add(form_Dashboard _dashboard)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            this._dashboard = _dashboard;
            load_dept_data();
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
        private void button_save_Click(object sender, EventArgs e)
        {
            //ADD Records
            if (button_course_save.Text == "SAVE")
            {
                try
                {
                    if ((txt_course_name.Text == String.Empty) || (txt_course_descript.Text == String.Empty || combobox_display_dept.Text == String.Empty))

                    {
                        MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_COURSE_INSERT";
                    cm.Parameters.AddWithValue("@course_name", txt_course_name.Text);
                    cm.Parameters.AddWithValue("@course_description", txt_course_descript.Text);
                    cm.Parameters.AddWithValue("@dept_id", department_id);
                    cm.ExecuteNonQuery();
               
                    cn.Close();
                    // Show all records
                    //  _dashboard.load_course_records();
                    MessageBox.Show("Successfully Added New Course!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_course_name.Clear();
                    txt_course_descript.Clear();
                    //clear the current selection, but leave all of the items in the list
                    combobox_display_dept.SelectedIndex = -1;
                    combobox_display_dept.Focus();
                    _dashboard.load_course_records();
                    
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //Update records 
            if (button_course_save.Text == "UPDATE")
                {
                    
                try
                    {
                        if ((txt_course_name.Text == String.Empty) || (txt_course_descript.Text == String.Empty || combobox_display_dept.Text == String.Empty))

                        {
                            MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cn.Open();
                     // MessageBox.Show(department_id);
                        cm.Connection = cn;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SP_COURSE_UPDATE";
                        cm.Parameters.AddWithValue("@course_name", txt_course_name.Text);
                        cm.Parameters.AddWithValue("@course_description", txt_course_descript.Text);
                        cm.Parameters.AddWithValue("@course_id", lbl_course_value.Text);
                    cm.Parameters.AddWithValue("@dept_id", lbl_dept_value.Text);
                    cm.ExecuteNonQuery();
                        cn.Close();
                    //display updated datagrid
                    _dashboard.load_course_records();
                    this.Close();

                        MessageBox.Show("Successfully Updated New Department!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                        Clearall();
                   
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    
                }
            
        }
        //load data in the combobox_dept
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
        private void form_course_add_Load(object sender, EventArgs e)
        {

        }

        private void combobox_display_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbl_course_add.Text == "ADD COURSES")
            {
                try
                {
                    cn.Open();
                    string q = "Select dept_id from tbl_department where dept_name='" + combobox_display_dept.SelectedItem + "'";
                    cm = new SqlCommand(q, cn);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                        department_id = dr[0].ToString();

                        //textbox_dept_description.Text = dr[0].ToString();

                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lbl_course_add.Text == "UPDATE COURSE")
            {
                try
                {
                    cn.Open();
                    string q = "Select dept_id from tbl_department where dept_name='" + combobox_display_dept.SelectedItem + "'";
                    cm = new SqlCommand(q, cn);
                    dr = cm.ExecuteReader();
                    while (dr.Read())
                    {
                       lbl_dept_value.Text = dr[0].ToString();

                        //textbox_dept_description.Text = dr[0].ToString();

                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void Clearall()
        {
            combobox_display_dept.Items.Clear();
            txt_course_name.Clear();
            txt_course_descript.Clear();
            combobox_display_dept.Focus();
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

