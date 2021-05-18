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

namespace CULS_SERVER
{
    public partial class form_department_add : Form
    {
   
        
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DB_conn dbcon = new DB_conn();
        form_Dashboard _dashboard;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        public form_department_add(form_Dashboard _dashboard)
        {
            InitializeComponent();
           
            cn = new SqlConnection(dbcon.GetConnection());
            this._dashboard = _dashboard;
          //  test if database is connected
            // cn.Open();
           //  MessageBox.Show("Connected");
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
        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void form_department_add_Load(object sender, EventArgs e)
        {

        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void form_department_add_MouseMove(object sender, MouseEventArgs e)
        {
           
            
        }
        public void Clearall()
        {
            textbox_department.Clear();
            textbox_dept_description.Clear();
            textbox_department.Focus();
        }
        private void button_save_Click(object sender, EventArgs e)
        {
        //ADD Records
            if (button_save.Text == "SAVE")
            {
                try
                {
                    if ((textbox_department.Text == String.Empty) || (textbox_dept_description.Text == String.Empty))

                    {
                        MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_DEPT_INSERT";
                    cm.Parameters.AddWithValue("@dept_name", textbox_department.Text);
                    cm.Parameters.AddWithValue("@dept_description", textbox_dept_description.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Successfully Added New Department!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dashboard.load_dept_records();
                    Clearall();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            //UPDATE records
            if (button_save.Text == "UPDATE")
            {
                
                try
                {
                    if ((textbox_department.Text == String.Empty) || (textbox_dept_description.Text == String.Empty))

                    {
                        MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_DEPT_UPDATE";                
                    cm.Parameters.AddWithValue("@dept_name", textbox_department.Text);
                    cm.Parameters.AddWithValue("@dept_description", textbox_dept_description.Text);
                    cm.Parameters.AddWithValue("@dept_id",lbl_dept_value.Text);

                    cm.ExecuteNonQuery();
                    cn.Close();
                    this.Close();
                    MessageBox.Show("Successfully Updated New Department!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //display updated datagrid
                    _dashboard.load_dept_records();
                    Clearall();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
           
        private void button_save_MouseEnter(object sender, EventArgs e)
        {
            button_save.BackColor = Color.FromArgb(67, 71, 74);
        }

        private void lbl_dept_id_call_Click(object sender, EventArgs e)
        {

        }
    }
}
