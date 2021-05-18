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
    public partial class form_manage_users : Form
    {
        //Databae variables handlers
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        DB_conn dbcon = new DB_conn();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        form_Dashboard _dashboard;
        string _title = "COMPUTER USAGE LIMITER SYSTEM";
        
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

        // instance for brwosing im
        OpenFileDialog opf = new OpenFileDialog();
        //instance for opening handler class
        User user_handler = new User();
        //flag for handling the ripple of messagebox
        bool _flag = true;
        bool _flag_reader_remove = true;
        public form_manage_users(form_Dashboard _dashboard)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.GetConnection());
            this._dashboard = _dashboard;
            load_dept_data();
            load_course_records();
            load_usertype_data();
            Reader_Status();
            SelectDevice();
            establishContext();
            current_time_limit_val();
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
            timer_reader_status.Stop();
            timer_reader_card.Stop();
        }
       

        private void button_browse_student_Click(object sender, EventArgs e)
        {
            // chose the images type
            opf.InitialDirectory = "C:\\";
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            opf.FilterIndex = 1;
            if (opf.ShowDialog() == DialogResult.OK)
            {
                // get the image returned by OpenFileDialog 
                picbox_student.Image = Image.FromFile(opf.FileName);

            }
        }

        private void form_manage_student_Load(object sender, EventArgs e)
        {

        }
        public void load_dept_data()
        {
            try
            {
                cbo_dept.Items.Clear();
                cn.Open();
                cm = new SqlCommand("SELECT [dept_name] From  tbl_department", cn);
                cm.ExecuteNonQuery();
                da = new SqlDataAdapter(cm);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    cbo_dept.Items.Add(dr["dept_name"].ToString());
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
            cbo_course.Enabled = true;
            cbo_course.SelectedIndex = -1;
            cbo_course.Items.Clear();
            try
            {
                cn.Open();
                string q = "Select dept_id from tbl_department where dept_name='" + cbo_dept.SelectedItem + "'";
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
                    cbo_course.Items.Add(dr["course_name"].ToString());
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
                }
            }
        }
        private void button_save_Click(object sender, EventArgs e)
        {
            if (cbo_usertype.Text == "student")
            {
                if (txt_stud_id_no.Text == String.Empty || cbo_dept.Text == String.Empty || cbo_course.Text == String.Empty)
                {
                    MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if ((txt_RFID_UID.Text == String.Empty) || (txt_firstname.Text == String.Empty) || (txt_lastname.Text == String.Empty))
            {
               MessageBox.Show("Required Missing Field", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;           
            }
            else
            {
                if (button_save_student.Text == "SAVE")
                {
                    add_record();
                }
                else if (button_save_student.Text=="UPDATE")
                {
                    update_record();                   
                }              
            }
        }
        //variable to handle the riffle of timer 
        //pag wala to mayat maya yung popup ng msgbox
       
        private void timer_reader_status_Tick(object sender, EventArgs e)
        {
            cn.Close();
            if (button_save_student.Text == "SAVE")
            {
                try
                {
                    cn.Open();
                    cm = new SqlCommand("Select UID from tbl_users where UID='" + txt_RFID_UID.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (_flag)
                        {
                            _flag = false;
                            MessageBox.Show("UID already exist", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_RFID_UID.Clear();
                        }
                        cn.Close();
                    }
                    else
                    {
                        Reader_Status();
                        _flag = true;
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (button_save_student.Text == "UPDATE")
            {
                User user_handler = new User();

                if (user_handler.UID_handler != txt_RFID_UID.Text)
                    {
                    try
                    {
                        cn.Open();
                        cm = new SqlCommand("Select UID from tbl_users where UID='" + txt_RFID_UID.Text + "'", cn);
                        dr = cm.ExecuteReader();
                        if (dr.HasRows)
                        {
                            if (_flag)
                            {
                                _flag = false;
                                MessageBox.Show("UID already exist", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_RFID_UID.Clear();
                            }
                            cn.Close();
                        }
                        else
                        {
                            Reader_Status();
                            _flag = true;
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
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void timer_reader_card_Tick(object sender, EventArgs e)
        {


            //------------------------------------------------------------------//
            //read
            //if (lbl_reader_status.Text == "Connected")
            //{
            //    try
            //    {

            //        NFC.Connect();
            //        NFC.GetCardUID();
            //        string a = NFC.GetCardUID();
            //        txt_RFID_UID.Text = a;
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Reader has been removed!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}

            //-----------------------------------------------------------------//
            //read-write
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
                        txt_RFID_UID.Clear();
                    }                   
                }
            }
            else
            {
                txt_RFID_UID.Clear();
            }
        }
        private void txt_RFID_UID_TextChanged(object sender, EventArgs e)
        {
            string error = "63000000";
            if (txt_RFID_UID.Text == error)
            {
                txt_RFID_UID.Clear();
            }
        }
        private void txt_RFID_UID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public void Clear_All()
        {
            txt_stud_id_no.Clear();
            txt_RFID_UID.Clear();
            txt_firstname.Clear();
            txt_lastname.Clear();
            cbo_dept.SelectedIndex = -1;
            cbo_course.SelectedIndex = -1;
            cbo_usertype.SelectedIndex = 0;
            txt_RFID_UID.Focus();
            picbox_student.Image = Properties.Resources.Icon_ManageUsers_Ref;
        }
        public void load_usertype_data()
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("Select usertype_name from tbl_usertype ", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    cbo_usertype.Items.Add(dr["usertype_name"].ToString());
                }
                dr.Close();
                cn.Close();
                //combobox set to default population
                cbo_usertype.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      
        public void check_existing_stud_ID()
        {
            cn.Close();
            try
            {
                cn.Open();
                cm = new SqlCommand("Select stud_id_no from tbl_users where stud_id_no='" + txt_stud_id_no.Text + "'", cn);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Student ID already exist", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cn.Close();
                    txt_stud_id_no.Clear();
                    txt_stud_id_no.Focus();
                }
                else
                {
                    if (button_save_student.Text == "SAVE")
                    {
                        add_record();
                    }
                    if (button_save_student.Text == "UPDATE")
                    {

                        update_record();
                    }

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void add_record()
        {
            //connection state close upon loop in methods
            cn.Close();
            //unique name
            string unique_name = DateTime.Now.ToString("yyyy_MM_dd_mm_ss");
            string CorrectFileName = unique_name + System.IO.Path.GetFileName(opf.FileName);
            //C:\Users\Alpuerto\Documents\GitHub\Computer-Usage-Limiter-System\CULS-SERVER\CULS-SERVER\bin\Debug
            string image_path = "\\Images\\" + CorrectFileName;

            //Check if user browse an image
            if (CorrectFileName == unique_name)
            {
                MessageBox.Show("Select Image!", _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button_browse_student.Focus();
            }
            else
            {
                try
                {
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_USERS_INSERT";
                    cm.Parameters.AddWithValue("@UID", txt_RFID_UID.Text);
                    cm.Parameters.AddWithValue("@stud_id_no", txt_stud_id_no.Text);
                    cm.Parameters.AddWithValue("@firstname", txt_firstname.Text);
                    cm.Parameters.AddWithValue("@lastname", txt_lastname.Text);
                    cm.Parameters.AddWithValue("@dept_name", cbo_dept.Text);
                    cm.Parameters.AddWithValue("@course_name", cbo_course.Text);
                    cm.Parameters.AddWithValue("@usertype_name", cbo_usertype.Text);
                    cm.Parameters.AddWithValue("@imagepath", image_path);
                    cm.Parameters.AddWithValue("@time_remaining", user_handler.Time_limit_handler);
                    string paths = Application.StartupPath;
                    System.IO.File.Copy(opf.FileName, paths + "\\Images\\" + CorrectFileName);
                    string i = paths + "\\Images\\" + CorrectFileName;
                    
                    cm.ExecuteNonQuery();
                    cn.Close();
             
                    timer_reader_card.Stop();
                    timer_reader_status.Stop();
                    MessageBox.Show("Successfully Added New User!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_All();
                    _dashboard.load_student_records();
                    this.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        public void update_record()
        {
            //connection state close upon loop in methods
            cn.Close();
            //unique name
            string unique_name = DateTime.Now.ToString("yyyy_MM_dd_mm_ss");
            string CorrectFileName = unique_name + System.IO.Path.GetFileName(opf.FileName);
            //C:\Users\Alpuerto\Documents\GitHub\Computer-Usage-Limiter-System\CULS-SERVER\CULS-SERVER\bin\Debug

            string image_path = "\\Images\\" + CorrectFileName;
            if (image_path == "\\Images\\" + unique_name)
            {
                //get the id_handler in dashboard
                //see the handler class                           
                try
                {

                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_USERS_UPDATE";
                    cm.Parameters.AddWithValue("@user_id", user_handler.ID_handler);
                    cm.Parameters.AddWithValue("@UID", txt_RFID_UID.Text);
                    cm.Parameters.AddWithValue("@stud_id_no", txt_stud_id_no.Text);
                    cm.Parameters.AddWithValue("@firstname", txt_firstname.Text);
                    cm.Parameters.AddWithValue("@lastname", txt_lastname.Text);
                    cm.Parameters.AddWithValue("@dept_name", cbo_dept.Text);
                    cm.Parameters.AddWithValue("@course_name", cbo_course.Text);
                    cm.Parameters.AddWithValue("@usertype_name", cbo_usertype.Text);
                    cm.Parameters.AddWithValue("@imagepath", user_handler.Image_handler);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Successfully Update New User!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_All();
                    _dashboard.load_student_records();
                    this.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {                
                //delete previous image and replace new image
                User user_handler = new User();
                string i = user_handler.Image_handler;
                string paths2 = Application.StartupPath;
                var image = Image.FromFile(paths2 + i);
                image.Dispose();

                try
                {
                    cn.Open();
                    cm.Connection = cn;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SP_USERS_UPDATE";                    
                    cm.Parameters.AddWithValue("@user_id", user_handler.ID_handler);
                    cm.Parameters.AddWithValue("@UID", txt_RFID_UID.Text);
                    cm.Parameters.AddWithValue("@stud_id_no", txt_stud_id_no.Text);
                    cm.Parameters.AddWithValue("@firstname", txt_firstname.Text);
                    cm.Parameters.AddWithValue("@lastname", txt_lastname.Text);
                    cm.Parameters.AddWithValue("@dept_name", cbo_dept.Text);
                    cm.Parameters.AddWithValue("@course_name", cbo_course.Text);
                    cm.Parameters.AddWithValue("@usertype_name", cbo_usertype.Text);
                    cm.Parameters.AddWithValue("@imagepath", image_path);

                    //copy image to the folder
                    string paths = Application.StartupPath;
                    System.IO.File.Copy(opf.FileName, paths + "\\Images\\" + CorrectFileName);
                    cm.ExecuteNonQuery();
                 
                    cn.Close();
                    MessageBox.Show("Successfully Update New User!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear_All();
                    _dashboard.load_student_records();

                    this.Close();

                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //bypass the use by another process (kapag nag open ng file) error
                //delete prev image
                GC.Collect();
                GC.WaitForPendingFinalizers();
                try
                {
                    System.IO.File.Delete(paths2 + i);

                }
                catch (Exception)
                {
                //    MessageBox.Show(ex.Message, "update");
                }
            }
        }

        private void cbo_usertype_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Usertype uType = new Usertype();
            //Enable/Disable specific fields when usertype selected
           if (cbo_usertype.Text==uType.student) {
                cbo_dept.Enabled = true;
                cbo_course.Enabled = true;
                txt_stud_id_no.Enabled = true;
            }
           if (cbo_usertype.Text == uType.employee)
            {
                cbo_dept.Enabled = false;
                cbo_course.Enabled = false;
                txt_stud_id_no.Enabled = false;
                disable_fields();
            }
           if (cbo_usertype.Text == uType.alumni)
            {
                cbo_dept.Enabled = false;
                cbo_course.Enabled = false;
                txt_stud_id_no.Enabled = false;
                disable_fields();
            }
            if (cbo_usertype.Text == uType.visitor)
            {
                cbo_dept.Enabled = false;
                cbo_course.Enabled = false;
                txt_stud_id_no.Enabled = false;
                disable_fields();
            }
        }
        public void disable_fields()
        {
            cbo_dept.SelectedIndex = -1;
            cbo_course.SelectedIndex = -1;
            txt_stud_id_no.Clear();

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

            //Get the list of reader present again but this time add sReaderGroup, retData as 2rd & 3rd parameter respectively.
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
        internal void establishContext()
        {
            retCode = Card.SCardEstablishContext(Card.SCARD_SCOPE_SYSTEM, 0, 0, ref hContext);
            if (retCode != Card.SCARD_S_SUCCESS)
            {
                //  MessageBox.Show("Check your device and please restart again", "Reader not connected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("basta may error");

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
        public void current_time_limit_val()
        {        
            try
            {
                cn.Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "SP_CURRENT_LIMIT_SELECT";
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                   user_handler.Time_limit_handler = (dr["time_limit"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}