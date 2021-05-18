
namespace CULS_SERVER
{
    partial class form_daily_reports_fields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_daily_reports_fields));
            this.report_daily_txt_area_field = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_daily_report_field_view = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_course_add = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.report_daily_txt_date_field = new System.Windows.Forms.TextBox();
            this.report_daily_txt_prepared_field = new System.Windows.Forms.TextBox();
            this.report_daily_txt_noted_field = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // report_daily_txt_area_field
            // 
            this.report_daily_txt_area_field.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.report_daily_txt_area_field.Location = new System.Drawing.Point(84, 85);
            this.report_daily_txt_area_field.MaxLength = 20;
            this.report_daily_txt_area_field.Name = "report_daily_txt_area_field";
            this.report_daily_txt_area_field.Size = new System.Drawing.Size(200, 20);
            this.report_daily_txt_area_field.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 14);
            this.label3.TabIndex = 47;
            this.label3.Text = "Area:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "Prepared By:";
            // 
            // button_daily_report_field_view
            // 
            this.button_daily_report_field_view.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_daily_report_field_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_daily_report_field_view.Font = new System.Drawing.Font("Arial", 8F);
            this.button_daily_report_field_view.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_daily_report_field_view.Location = new System.Drawing.Point(227, 179);
            this.button_daily_report_field_view.Name = "button_daily_report_field_view";
            this.button_daily_report_field_view.Size = new System.Drawing.Size(57, 25);
            this.button_daily_report_field_view.TabIndex = 4;
            this.button_daily_report_field_view.Text = "VIEW";
            this.button_daily_report_field_view.UseVisualStyleBackColor = false;
            this.button_daily_report_field_view.Click += new System.EventHandler(this.button_course_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 45;
            this.label1.Text = "Date:";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(271, 19);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 5;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // lbl_course_add
            // 
            this.lbl_course_add.AutoSize = true;
            this.lbl_course_add.Depth = 0;
            this.lbl_course_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_course_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_course_add.Location = new System.Drawing.Point(8, 16);
            this.lbl_course_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_course_add.Name = "lbl_course_add";
            this.lbl_course_add.Size = new System.Drawing.Size(109, 19);
            this.lbl_course_add.TabIndex = 43;
            this.lbl_course_add.Text = "DAILY REPORT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 10);
            this.panel1.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(11, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "_____________________________________________";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(7, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(277, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "_____________________________________________";
            // 
            // report_daily_txt_date_field
            // 
            this.report_daily_txt_date_field.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.report_daily_txt_date_field.Location = new System.Drawing.Point(84, 57);
            this.report_daily_txt_date_field.MaxLength = 20;
            this.report_daily_txt_date_field.Name = "report_daily_txt_date_field";
            this.report_daily_txt_date_field.ReadOnly = true;
            this.report_daily_txt_date_field.Size = new System.Drawing.Size(200, 20);
            this.report_daily_txt_date_field.TabIndex = 52;
            // 
            // report_daily_txt_prepared_field
            // 
            this.report_daily_txt_prepared_field.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.report_daily_txt_prepared_field.Location = new System.Drawing.Point(84, 114);
            this.report_daily_txt_prepared_field.MaxLength = 50;
            this.report_daily_txt_prepared_field.Name = "report_daily_txt_prepared_field";
            this.report_daily_txt_prepared_field.Size = new System.Drawing.Size(200, 20);
            this.report_daily_txt_prepared_field.TabIndex = 2;
            // 
            // report_daily_txt_noted_field
            // 
            this.report_daily_txt_noted_field.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.report_daily_txt_noted_field.Location = new System.Drawing.Point(84, 146);
            this.report_daily_txt_noted_field.MaxLength = 50;
            this.report_daily_txt_noted_field.Name = "report_daily_txt_noted_field";
            this.report_daily_txt_noted_field.Size = new System.Drawing.Size(200, 20);
            this.report_daily_txt_noted_field.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 55;
            this.label6.Text = "Noted By:";
            // 
            // form_daily_reports_fields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 210);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.report_daily_txt_noted_field);
            this.Controls.Add(this.report_daily_txt_prepared_field);
            this.Controls.Add(this.report_daily_txt_date_field);
            this.Controls.Add(this.report_daily_txt_area_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_daily_report_field_view);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_course_add);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_daily_reports_fields";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_daily_reports_fields_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox report_daily_txt_area_field;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_daily_report_field_view;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_close;
        public MaterialSkin.Controls.MaterialLabel lbl_course_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox report_daily_txt_date_field;
        public System.Windows.Forms.TextBox report_daily_txt_prepared_field;
        public System.Windows.Forms.TextBox report_daily_txt_noted_field;
        private System.Windows.Forms.Label label6;
    }
}