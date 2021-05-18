
namespace CULS_SERVER
{
    partial class form_User_Sessions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_User_Sessions));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_stud_id_no = new System.Windows.Forms.TextBox();
            this.txt_RFID_UID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picbox_student = new System.Windows.Forms.PictureBox();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_student_details = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dept = new System.Windows.Forms.TextBox();
            this.txt_course = new System.Windows.Forms.TextBox();
            this.txt_usertype = new System.Windows.Forms.TextBox();
            this.txt_remaining_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grid_user_sessions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logs_login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logs_logout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logs_session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logs_terminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logs_purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_user_sessions)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(185, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 14);
            this.label11.TabIndex = 86;
            this.label11.Text = "Usertype";
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Font = new System.Drawing.Font("Arial", 8F);
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_cancel.Location = new System.Drawing.Point(605, 448);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 25);
            this.button_cancel.TabIndex = 83;
            this.button_cancel.Text = "CANCEL";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(525, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 80;
            this.label8.Text = "Course";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(355, 101);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 79;
            this.label9.Text = "Lastname";
            // 
            // txt_lastname
            // 
            this.txt_lastname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_lastname.Enabled = false;
            this.txt_lastname.Location = new System.Drawing.Point(358, 118);
            this.txt_lastname.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.txt_lastname.MaxLength = 15;
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.ReadOnly = true;
            this.txt_lastname.Size = new System.Drawing.Size(150, 20);
            this.txt_lastname.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 77;
            this.label3.Text = "Firstname";
            // 
            // txt_firstname
            // 
            this.txt_firstname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_firstname.Enabled = false;
            this.txt_firstname.Location = new System.Drawing.Point(358, 77);
            this.txt_firstname.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_firstname.MaxLength = 15;
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.ReadOnly = true;
            this.txt_firstname.Size = new System.Drawing.Size(150, 20);
            this.txt_firstname.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 14);
            this.label6.TabIndex = 75;
            this.label6.Text = "RFID ";
            // 
            // txt_stud_id_no
            // 
            this.txt_stud_id_no.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_stud_id_no.Enabled = false;
            this.txt_stud_id_no.Location = new System.Drawing.Point(188, 161);
            this.txt_stud_id_no.MaxLength = 15;
            this.txt_stud_id_no.Name = "txt_stud_id_no";
            this.txt_stud_id_no.ReadOnly = true;
            this.txt_stud_id_no.Size = new System.Drawing.Size(150, 20);
            this.txt_stud_id_no.TabIndex = 64;
            // 
            // txt_RFID_UID
            // 
            this.txt_RFID_UID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_RFID_UID.Enabled = false;
            this.txt_RFID_UID.Location = new System.Drawing.Point(188, 118);
            this.txt_RFID_UID.MaxLength = 15;
            this.txt_RFID_UID.Name = "txt_RFID_UID";
            this.txt_RFID_UID.ReadOnly = true;
            this.txt_RFID_UID.Size = new System.Drawing.Size(150, 20);
            this.txt_RFID_UID.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 78;
            this.label1.Text = "Department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(185, 144);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 76;
            this.label7.Text = "Student ID ";
            // 
            // picbox_student
            // 
            this.picbox_student.BackColor = System.Drawing.Color.Gainsboro;
            this.picbox_student.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_student.Image = global::CULS_SERVER.Properties.Resources.Icon_ManageUsers_Ref;
            this.picbox_student.InitialImage = ((System.Drawing.Image)(resources.GetObject("picbox_student.InitialImage")));
            this.picbox_student.Location = new System.Drawing.Point(43, 76);
            this.picbox_student.Margin = new System.Windows.Forms.Padding(2);
            this.picbox_student.Name = "picbox_student";
            this.picbox_student.Size = new System.Drawing.Size(106, 105);
            this.picbox_student.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_student.TabIndex = 74;
            this.picbox_student.TabStop = false;
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(665, 28);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 72;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // lbl_student_details
            // 
            this.lbl_student_details.AutoSize = true;
            this.lbl_student_details.Depth = 0;
            this.lbl_student_details.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_student_details.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_student_details.Location = new System.Drawing.Point(12, 24);
            this.lbl_student_details.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_student_details.Name = "lbl_student_details";
            this.lbl_student_details.Size = new System.Drawing.Size(107, 19);
            this.lbl_student_details.TabIndex = 71;
            this.lbl_student_details.Text = "USER PROFILE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 10);
            this.panel1.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(667, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "_________________________________________________________________________________" +
    "_____________________________";
            // 
            // txt_dept
            // 
            this.txt_dept.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dept.Enabled = false;
            this.txt_dept.Location = new System.Drawing.Point(528, 77);
            this.txt_dept.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_dept.MaxLength = 15;
            this.txt_dept.Name = "txt_dept";
            this.txt_dept.ReadOnly = true;
            this.txt_dept.Size = new System.Drawing.Size(150, 20);
            this.txt_dept.TabIndex = 88;
            // 
            // txt_course
            // 
            this.txt_course.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_course.Enabled = false;
            this.txt_course.Location = new System.Drawing.Point(528, 118);
            this.txt_course.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_course.MaxLength = 15;
            this.txt_course.Name = "txt_course";
            this.txt_course.ReadOnly = true;
            this.txt_course.Size = new System.Drawing.Size(150, 20);
            this.txt_course.TabIndex = 89;
            // 
            // txt_usertype
            // 
            this.txt_usertype.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_usertype.Enabled = false;
            this.txt_usertype.Location = new System.Drawing.Point(188, 77);
            this.txt_usertype.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_usertype.MaxLength = 15;
            this.txt_usertype.Name = "txt_usertype";
            this.txt_usertype.ReadOnly = true;
            this.txt_usertype.Size = new System.Drawing.Size(150, 20);
            this.txt_usertype.TabIndex = 90;
            // 
            // txt_remaining_time
            // 
            this.txt_remaining_time.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_remaining_time.Enabled = false;
            this.txt_remaining_time.Location = new System.Drawing.Point(358, 161);
            this.txt_remaining_time.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_remaining_time.MaxLength = 15;
            this.txt_remaining_time.Name = "txt_remaining_time";
            this.txt_remaining_time.ReadOnly = true;
            this.txt_remaining_time.Size = new System.Drawing.Size(150, 20);
            this.txt_remaining_time.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(355, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 14);
            this.label2.TabIndex = 96;
            this.label2.Text = "Remaining Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(9, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(667, 13);
            this.label5.TabIndex = 97;
            this.label5.Text = "_________________________________________________________________________________" +
    "_____________________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Location = new System.Drawing.Point(12, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(667, 13);
            this.label10.TabIndex = 98;
            this.label10.Text = "_________________________________________________________________________________" +
    "_____________________________";
            // 
            // grid_user_sessions
            // 
            this.grid_user_sessions.AllowUserToAddRows = false;
            this.grid_user_sessions.AllowUserToResizeColumns = false;
            this.grid_user_sessions.AllowUserToResizeRows = false;
            this.grid_user_sessions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.grid_user_sessions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_user_sessions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grid_user_sessions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_user_sessions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_user_sessions.ColumnHeadersHeight = 30;
            this.grid_user_sessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid_user_sessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.Date,
            this.logs_login,
            this.logs_logout,
            this.logs_session,
            this.logs_terminal,
            this.logs_purpose});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_user_sessions.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_user_sessions.EnableHeadersVisualStyles = false;
            this.grid_user_sessions.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.grid_user_sessions.Location = new System.Drawing.Point(15, 205);
            this.grid_user_sessions.Margin = new System.Windows.Forms.Padding(0);
            this.grid_user_sessions.Name = "grid_user_sessions";
            this.grid_user_sessions.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_user_sessions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_user_sessions.RowHeadersVisible = false;
            this.grid_user_sessions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_user_sessions.Size = new System.Drawing.Size(661, 227);
            this.grid_user_sessions.TabIndex = 99;
            this.grid_user_sessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_user_sessions_CellContentClick);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.HeaderText = "#";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 37;
            // 
            // Date
            // 
            this.Date.HeaderText = "DATE";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // logs_login
            // 
            this.logs_login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.logs_login.HeaderText = "LOGIN";
            this.logs_login.Name = "logs_login";
            this.logs_login.ReadOnly = true;
            this.logs_login.Width = 63;
            // 
            // logs_logout
            // 
            this.logs_logout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.logs_logout.HeaderText = "LOGOUT";
            this.logs_logout.Name = "logs_logout";
            this.logs_logout.ReadOnly = true;
            this.logs_logout.Width = 75;
            // 
            // logs_session
            // 
            this.logs_session.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.logs_session.HeaderText = "SESSION";
            this.logs_session.Name = "logs_session";
            this.logs_session.ReadOnly = true;
            this.logs_session.Width = 77;
            // 
            // logs_terminal
            // 
            this.logs_terminal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.logs_terminal.HeaderText = "TERMINAL";
            this.logs_terminal.Name = "logs_terminal";
            this.logs_terminal.ReadOnly = true;
            this.logs_terminal.Width = 85;
            // 
            // logs_purpose
            // 
            this.logs_purpose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.logs_purpose.HeaderText = "PURPOSE";
            this.logs_purpose.Name = "logs_purpose";
            this.logs_purpose.ReadOnly = true;
            // 
            // form_User_Sessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 475);
            this.Controls.Add(this.grid_user_sessions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_remaining_time);
            this.Controls.Add(this.txt_usertype);
            this.Controls.Add(this.txt_course);
            this.Controls.Add(this.txt_dept);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_lastname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_firstname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_stud_id_no);
            this.Controls.Add(this.txt_RFID_UID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picbox_student);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_student_details);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_User_Sessions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_User_Sessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_user_sessions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_stud_id_no;
        public System.Windows.Forms.TextBox txt_RFID_UID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox picbox_student;
        private System.Windows.Forms.Label label_close;
        public MaterialSkin.Controls.MaterialLabel lbl_student_details;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_dept;
        public System.Windows.Forms.TextBox txt_course;
        public System.Windows.Forms.TextBox txt_usertype;
        public System.Windows.Forms.TextBox txt_remaining_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DataGridView grid_user_sessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn logs_login;
        private System.Windows.Forms.DataGridViewTextBoxColumn logs_logout;
        private System.Windows.Forms.DataGridViewTextBoxColumn logs_session;
        private System.Windows.Forms.DataGridViewTextBoxColumn logs_terminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn logs_purpose;
    }
}