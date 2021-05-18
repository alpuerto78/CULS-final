
namespace CULS_SERVER
{
    partial class form_course_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_course_add));
            this.txt_course_descript = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_course_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_course_add = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_course_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combobox_display_dept = new System.Windows.Forms.ComboBox();
            this.lbl_course_value = new System.Windows.Forms.Label();
            this.lbl_dept_value = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_course_descript
            // 
            this.txt_course_descript.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_course_descript.Location = new System.Drawing.Point(84, 128);
            this.txt_course_descript.MaxLength = 100;
            this.txt_course_descript.Multiline = true;
            this.txt_course_descript.Name = "txt_course_descript";
            this.txt_course_descript.Size = new System.Drawing.Size(200, 37);
            this.txt_course_descript.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Description";
            // 
            // button_course_save
            // 
            this.button_course_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_course_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_course_save.Font = new System.Drawing.Font("Arial", 8F);
            this.button_course_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_course_save.Location = new System.Drawing.Point(227, 183);
            this.button_course_save.Name = "button_course_save";
            this.button_course_save.Size = new System.Drawing.Size(57, 25);
            this.button_course_save.TabIndex = 4;
            this.button_course_save.Text = "SAVE";
            this.button_course_save.UseVisualStyleBackColor = false;
            this.button_course_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Department";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(271, 33);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 16;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // lbl_course_add
            // 
            this.lbl_course_add.AutoSize = true;
            this.lbl_course_add.Depth = 0;
            this.lbl_course_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_course_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_course_add.Location = new System.Drawing.Point(8, 30);
            this.lbl_course_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_course_add.Name = "lbl_course_add";
            this.lbl_course_add.Size = new System.Drawing.Size(109, 19);
            this.lbl_course_add.TabIndex = 13;
            this.lbl_course_add.Text = "ADD COURSES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 10);
            this.panel1.TabIndex = 11;
            // 
            // txt_course_name
            // 
            this.txt_course_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_course_name.Location = new System.Drawing.Point(84, 99);
            this.txt_course_name.MaxLength = 20;
            this.txt_course_name.Name = "txt_course_name";
            this.txt_course_name.Size = new System.Drawing.Size(200, 20);
            this.txt_course_name.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "Courses";
            // 
            // combobox_display_dept
            // 
            this.combobox_display_dept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_display_dept.FormattingEnabled = true;
            this.combobox_display_dept.Location = new System.Drawing.Point(84, 70);
            this.combobox_display_dept.Name = "combobox_display_dept";
            this.combobox_display_dept.Size = new System.Drawing.Size(200, 21);
            this.combobox_display_dept.TabIndex = 1;
            this.combobox_display_dept.SelectedIndexChanged += new System.EventHandler(this.combobox_display_dept_SelectedIndexChanged);
            // 
            // lbl_course_value
            // 
            this.lbl_course_value.AutoSize = true;
            this.lbl_course_value.Location = new System.Drawing.Point(81, 182);
            this.lbl_course_value.Name = "lbl_course_value";
            this.lbl_course_value.Size = new System.Drawing.Size(87, 13);
            this.lbl_course_value.TabIndex = 21;
            this.lbl_course_value.Text = "lbl_course_value";
            this.lbl_course_value.Visible = false;
            // 
            // lbl_dept_value
            // 
            this.lbl_dept_value.AutoSize = true;
            this.lbl_dept_value.Location = new System.Drawing.Point(82, 203);
            this.lbl_dept_value.Name = "lbl_dept_value";
            this.lbl_dept_value.Size = new System.Drawing.Size(76, 13);
            this.lbl_dept_value.TabIndex = 22;
            this.lbl_dept_value.Text = "lbl_dept_value";
            this.lbl_dept_value.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(11, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "_____________________________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "_____________________________________________";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // form_course_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 225);
            this.Controls.Add(this.lbl_dept_value);
            this.Controls.Add(this.lbl_course_value);
            this.Controls.Add(this.combobox_display_dept);
            this.Controls.Add(this.txt_course_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_course_descript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_course_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_course_add);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_course_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_course_add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txt_course_descript;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_course_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txt_course_name;
        private System.Windows.Forms.Label label3;
        public MaterialSkin.Controls.MaterialLabel lbl_course_add;
        public System.Windows.Forms.ComboBox combobox_display_dept;
        public System.Windows.Forms.Label lbl_course_value;
        public System.Windows.Forms.Label lbl_dept_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}