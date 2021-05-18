
namespace CULS_SERVER
{
    partial class form_manage_student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_manage_student));
            this.combobox_display_dept = new System.Windows.Forms.ComboBox();
            this.button_browse_student = new System.Windows.Forms.Button();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_course_add = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_RFID_UID = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.combobox_display_course = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_reader_status = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_dept_handler = new System.Windows.Forms.Label();
            this.timer_reader_status = new System.Windows.Forms.Timer(this.components);
            this.timer_reader_card = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // combobox_display_dept
            // 
            this.combobox_display_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_display_dept.FormattingEnabled = true;
            this.combobox_display_dept.Location = new System.Drawing.Point(16, 271);
            this.combobox_display_dept.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.combobox_display_dept.Name = "combobox_display_dept";
            this.combobox_display_dept.Size = new System.Drawing.Size(150, 21);
            this.combobox_display_dept.TabIndex = 6;
            this.combobox_display_dept.SelectedIndexChanged += new System.EventHandler(this.combobox_display_dept_SelectedIndexChanged);
            // 
            // button_browse_student
            // 
            this.button_browse_student.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_browse_student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_browse_student.Font = new System.Drawing.Font("Arial", 8F);
            this.button_browse_student.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_browse_student.Location = new System.Drawing.Point(53, 163);
            this.button_browse_student.Name = "button_browse_student";
            this.button_browse_student.Size = new System.Drawing.Size(96, 25);
            this.button_browse_student.TabIndex = 3;
            this.button_browse_student.Text = "BROWSE";
            this.button_browse_student.UseVisualStyleBackColor = false;
            this.button_browse_student.Click += new System.EventHandler(this.button_browse_student_Click);
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(323, 28);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 29;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // lbl_course_add
            // 
            this.lbl_course_add.AutoSize = true;
            this.lbl_course_add.Depth = 0;
            this.lbl_course_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_course_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_course_add.Location = new System.Drawing.Point(12, 24);
            this.lbl_course_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_course_add.Name = "lbl_course_add";
            this.lbl_course_add.Size = new System.Drawing.Size(173, 19);
            this.lbl_course_add.TabIndex = 28;
            this.lbl_course_add.Text = "ADD STUDENT DETAILS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 10);
            this.panel1.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(13, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "_____________________________________________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 58);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // txt_RFID_UID
            // 
            this.txt_RFID_UID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_RFID_UID.Location = new System.Drawing.Point(188, 91);
            this.txt_RFID_UID.MaxLength = 15;
            this.txt_RFID_UID.Name = "txt_RFID_UID";
            this.txt_RFID_UID.Size = new System.Drawing.Size(150, 20);
            this.txt_RFID_UID.TabIndex = 1;
            this.txt_RFID_UID.TextChanged += new System.EventHandler(this.txt_RFID_UID_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.Location = new System.Drawing.Point(188, 134);
            this.textBox2.MaxLength = 15;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 44;
            this.label6.Text = "RFID *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(185, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "Student ID *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 254);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 49;
            this.label1.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "Firstname";
            // 
            // textBox4
            // 
            this.textBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox4.Location = new System.Drawing.Point(16, 228);
            this.textBox4.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.textBox4.MaxLength = 15;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(188, 254);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 53;
            this.label8.Text = "Course";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 211);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 14);
            this.label9.TabIndex = 52;
            this.label9.Text = "Lastname";
            // 
            // textBox6
            // 
            this.textBox6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox6.Location = new System.Drawing.Point(188, 228);
            this.textBox6.Margin = new System.Windows.Forms.Padding(15, 3, 3, 15);
            this.textBox6.MaxLength = 15;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(150, 20);
            this.textBox6.TabIndex = 5;
            // 
            // combobox_display_course
            // 
            this.combobox_display_course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_display_course.Enabled = false;
            this.combobox_display_course.FormattingEnabled = true;
            this.combobox_display_course.Location = new System.Drawing.Point(188, 271);
            this.combobox_display_course.Name = "combobox_display_course";
            this.combobox_display_course.Size = new System.Drawing.Size(150, 21);
            this.combobox_display_course.TabIndex = 7;
            this.combobox_display_course.SelectedIndexChanged += new System.EventHandler(this.combobox_display_course_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(13, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "_____________________________________________________";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(13, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(325, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "_____________________________________________________";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Arial", 8F);
            this.button_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_save.Location = new System.Drawing.Point(263, 315);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 25);
            this.button_save.TabIndex = 57;
            this.button_save.Text = "SAVE";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel2.Controls.Add(this.lbl_reader_status);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 343);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 20);
            this.panel2.TabIndex = 58;
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
            // lbl_dept_handler
            // 
            this.lbl_dept_handler.AutoSize = true;
            this.lbl_dept_handler.Location = new System.Drawing.Point(62, 315);
            this.lbl_dept_handler.Name = "lbl_dept_handler";
            this.lbl_dept_handler.Size = new System.Drawing.Size(13, 13);
            this.lbl_dept_handler.TabIndex = 59;
            this.lbl_dept_handler.Text = "0";
            this.lbl_dept_handler.Click += new System.EventHandler(this.lbl_dept_handler_Click);
            // 
            // timer_reader_status
            // 
            this.timer_reader_status.Enabled = true;
            this.timer_reader_status.Tick += new System.EventHandler(this.timer_reader_status_Tick);
            // 
            // timer_reader_card
            // 
            this.timer_reader_card.Enabled = true;
            this.timer_reader_card.Tick += new System.EventHandler(this.timer_reader_card_Tick);
            // 
            // form_manage_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 363);
            this.Controls.Add(this.lbl_dept_handler);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combobox_display_course);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_browse_student);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txt_RFID_UID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.combobox_display_dept);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_course_add);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_manage_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_manage_student";
            this.Load += new System.EventHandler(this.form_manage_student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ComboBox combobox_display_dept;
        public System.Windows.Forms.Button button_browse_student;
        private System.Windows.Forms.Label label_close;
        public MaterialSkin.Controls.MaterialLabel lbl_course_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txt_RFID_UID;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.ComboBox combobox_display_course;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_reader_status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_dept_handler;
        private System.Windows.Forms.Timer timer_reader_status;
        private System.Windows.Forms.Timer timer_reader_card;
    }
}