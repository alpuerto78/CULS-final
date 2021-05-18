
namespace CULS_SERVER
{
    partial class form_add_time
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_add_time));
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_dept_handler = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_reader_status = new System.Windows.Forms.Label();
            this.button_add_time = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_stud_id_no = new System.Windows.Forms.TextBox();
            this.txt_RFID_UID = new System.Windows.Forms.TextBox();
            this.timer_reader_status = new System.Windows.Forms.Timer(this.components);
            this.timer_reader_card = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_student_details = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.picbox_student = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_usertype = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_dept = new System.Windows.Forms.TextBox();
            this.txt_course = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_student)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(13, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 14);
            this.label10.TabIndex = 59;
            this.label10.Text = "RFID Reader  :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(183, 52);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 14);
            this.label11.TabIndex = 86;
            this.label11.Text = "Usertype";
            // 
            // lbl_dept_handler
            // 
            this.lbl_dept_handler.AutoSize = true;
            this.lbl_dept_handler.Location = new System.Drawing.Point(10, 289);
            this.lbl_dept_handler.Name = "lbl_dept_handler";
            this.lbl_dept_handler.Size = new System.Drawing.Size(13, 13);
            this.lbl_dept_handler.TabIndex = 85;
            this.lbl_dept_handler.Text = "0";
            this.lbl_dept_handler.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.lbl_reader_status);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 462);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 20);
            this.panel2.TabIndex = 84;
            // 
            // lbl_reader_status
            // 
            this.lbl_reader_status.AutoSize = true;
            this.lbl_reader_status.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reader_status.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_reader_status.Location = new System.Drawing.Point(90, 3);
            this.lbl_reader_status.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lbl_reader_status.Name = "lbl_reader_status";
            this.lbl_reader_status.Size = new System.Drawing.Size(76, 14);
            this.lbl_reader_status.TabIndex = 60;
            this.lbl_reader_status.Text = "Reader Status";
            // 
            // button_add_time
            // 
            this.button_add_time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_add_time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_time.Font = new System.Drawing.Font("Arial", 8F);
            this.button_add_time.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_add_time.Location = new System.Drawing.Point(263, 431);
            this.button_add_time.Name = "button_add_time";
            this.button_add_time.Size = new System.Drawing.Size(75, 25);
            this.button_add_time.TabIndex = 83;
            this.button_add_time.Text = "ADD TIME";
            this.button_add_time.UseVisualStyleBackColor = false;
            this.button_add_time.Click += new System.EventHandler(this.button_add_time_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(11, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "_____________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(11, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "_____________________________________________________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(186, 246);
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
            this.label9.Location = new System.Drawing.Point(186, 203);
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
            this.txt_lastname.Location = new System.Drawing.Point(186, 220);
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
            this.label3.Location = new System.Drawing.Point(11, 203);
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
            this.txt_firstname.Location = new System.Drawing.Point(14, 220);
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
            this.label6.Location = new System.Drawing.Point(183, 93);
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
            this.txt_stud_id_no.Location = new System.Drawing.Point(186, 153);
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
            this.txt_RFID_UID.Location = new System.Drawing.Point(186, 110);
            this.txt_RFID_UID.MaxLength = 15;
            this.txt_RFID_UID.Name = "txt_RFID_UID";
            this.txt_RFID_UID.ReadOnly = true;
            this.txt_RFID_UID.Size = new System.Drawing.Size(150, 20);
            this.txt_RFID_UID.TabIndex = 63;
            this.txt_RFID_UID.TextChanged += new System.EventHandler(this.txt_RFID_UID_TextChanged);
            // 
            // timer_reader_status
            // 
            this.timer_reader_status.Enabled = true;
            this.timer_reader_status.Interval = 1000;
            this.timer_reader_status.Tick += new System.EventHandler(this.timer_reader_status_Tick);
            // 
            // timer_reader_card
            // 
            this.timer_reader_card.Enabled = true;
            this.timer_reader_card.Tick += new System.EventHandler(this.timer_reader_card_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 246);
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
            this.label7.Location = new System.Drawing.Point(183, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 76;
            this.label7.Text = "Student ID ";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(321, 20);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 72;
            this.label_close.Text = "X";
            // 
            // lbl_student_details
            // 
            this.lbl_student_details.AutoSize = true;
            this.lbl_student_details.Depth = 0;
            this.lbl_student_details.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_student_details.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_student_details.Location = new System.Drawing.Point(10, 16);
            this.lbl_student_details.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_student_details.Name = "lbl_student_details";
            this.lbl_student_details.Size = new System.Drawing.Size(78, 19);
            this.lbl_student_details.TabIndex = 71;
            this.lbl_student_details.Text = "ADD TIME";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 10);
            this.panel1.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(11, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "_____________________________________________________";
            // 
            // picbox_student
            // 
            this.picbox_student.BackColor = System.Drawing.Color.Gainsboro;
            this.picbox_student.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbox_student.Image = global::CULS_SERVER.Properties.Resources.Icon_ManageUsers_Ref;
            this.picbox_student.InitialImage = ((System.Drawing.Image)(resources.GetObject("picbox_student.InitialImage")));
            this.picbox_student.Location = new System.Drawing.Point(51, 69);
            this.picbox_student.Margin = new System.Windows.Forms.Padding(2);
            this.picbox_student.Name = "picbox_student";
            this.picbox_student.Size = new System.Drawing.Size(96, 96);
            this.picbox_student.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_student.TabIndex = 74;
            this.picbox_student.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Location = new System.Drawing.Point(16, 324);
            this.textBox1.MaxLength = 250;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(322, 40);
            this.textBox1.TabIndex = 88;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 306);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 14);
            this.label12.TabIndex = 89;
            this.label12.Text = "Purpose*";
            // 
            // txt_usertype
            // 
            this.txt_usertype.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_usertype.Enabled = false;
            this.txt_usertype.Location = new System.Drawing.Point(186, 69);
            this.txt_usertype.MaxLength = 15;
            this.txt_usertype.Name = "txt_usertype";
            this.txt_usertype.ReadOnly = true;
            this.txt_usertype.Size = new System.Drawing.Size(150, 20);
            this.txt_usertype.TabIndex = 90;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(62, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 17);
            this.radioButton1.TabIndex = 91;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Limited";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(177, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 92;
            this.radioButton2.Text = "Unlimited";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label13.Location = new System.Drawing.Point(11, 415);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(325, 13);
            this.label13.TabIndex = 93;
            this.label13.Text = "_____________________________________________________";
            // 
            // txt_dept
            // 
            this.txt_dept.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dept.Enabled = false;
            this.txt_dept.Location = new System.Drawing.Point(13, 263);
            this.txt_dept.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_dept.MaxLength = 15;
            this.txt_dept.Name = "txt_dept";
            this.txt_dept.ReadOnly = true;
            this.txt_dept.Size = new System.Drawing.Size(150, 20);
            this.txt_dept.TabIndex = 94;
            // 
            // txt_course
            // 
            this.txt_course.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_course.Enabled = false;
            this.txt_course.Location = new System.Drawing.Point(186, 263);
            this.txt_course.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txt_course.MaxLength = 15;
            this.txt_course.Name = "txt_course";
            this.txt_course.ReadOnly = true;
            this.txt_course.Size = new System.Drawing.Size(150, 20);
            this.txt_course.TabIndex = 95;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 45);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Session";
            // 
            // form_add_time
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 482);
            this.Controls.Add(this.txt_course);
            this.Controls.Add(this.txt_dept);
            this.Controls.Add(this.txt_usertype);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl_dept_handler);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_add_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_add_time";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_student)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_dept_handler;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_reader_status;
        public System.Windows.Forms.Button button_add_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_stud_id_no;
        public System.Windows.Forms.TextBox txt_RFID_UID;
        private System.Windows.Forms.Timer timer_reader_status;
        private System.Windows.Forms.Timer timer_reader_card;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox picbox_student;
        private System.Windows.Forms.Label label_close;
        public MaterialSkin.Controls.MaterialLabel lbl_student_details;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txt_usertype;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txt_dept;
        public System.Windows.Forms.TextBox txt_course;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}