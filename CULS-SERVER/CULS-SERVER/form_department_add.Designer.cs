
namespace CULS_SERVER
{
    partial class form_department_add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_department_add));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_dept_add = new MaterialSkin.Controls.MaterialLabel();
            this.label_close = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_department = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_dept_description = new System.Windows.Forms.TextBox();
            this.lbl_dept_value = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 10);
            this.panel1.TabIndex = 0;
            // 
            // lbl_dept_add
            // 
            this.lbl_dept_add.AutoSize = true;
            this.lbl_dept_add.Depth = 0;
            this.lbl_dept_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_dept_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_dept_add.Location = new System.Drawing.Point(8, 26);
            this.lbl_dept_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_dept_add.Name = "lbl_dept_add";
            this.lbl_dept_add.Size = new System.Drawing.Size(141, 19);
            this.lbl_dept_add.TabIndex = 1;
            this.lbl_dept_add.Text = "ADD DEPARTMENT";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(233, 26);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 6;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Department";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textbox_department
            // 
            this.textbox_department.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_department.Location = new System.Drawing.Point(80, 67);
            this.textbox_department.MaxLength = 15;
            this.textbox_department.Name = "textbox_department";
            this.textbox_department.Size = new System.Drawing.Size(168, 20);
            this.textbox_department.TabIndex = 1;
            this.textbox_department.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Arial", 8F);
            this.button_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_save.Location = new System.Drawing.Point(191, 152);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(57, 25);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "SAVE";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            this.button_save.MouseEnter += new System.EventHandler(this.button_save_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description";
            // 
            // textbox_dept_description
            // 
            this.textbox_dept_description.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textbox_dept_description.Location = new System.Drawing.Point(80, 93);
            this.textbox_dept_description.MaxLength = 100;
            this.textbox_dept_description.Multiline = true;
            this.textbox_dept_description.Name = "textbox_dept_description";
            this.textbox_dept_description.Size = new System.Drawing.Size(168, 37);
            this.textbox_dept_description.TabIndex = 2;
            // 
            // lbl_dept_value
            // 
            this.lbl_dept_value.AutoSize = true;
            this.lbl_dept_value.Location = new System.Drawing.Point(62, 149);
            this.lbl_dept_value.Name = "lbl_dept_value";
            this.lbl_dept_value.Size = new System.Drawing.Size(35, 13);
            this.lbl_dept_value.TabIndex = 11;
            this.lbl_dept_value.Text = "label3";
            this.lbl_dept_value.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(9, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "_______________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "_______________________________________";
            // 
            // form_department_add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 184);
            this.Controls.Add(this.lbl_dept_value);
            this.Controls.Add(this.textbox_dept_description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.textbox_department);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_dept_add);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_department_add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_department_add_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_department_add_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_save;
        public System.Windows.Forms.TextBox textbox_department;
        public System.Windows.Forms.TextBox textbox_dept_description;
        public MaterialSkin.Controls.MaterialLabel lbl_dept_add;
        public System.Windows.Forms.Label lbl_dept_value;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}