namespace CULS_Client
{
    partial class form_Timer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Timer));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_logout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbl_second = new System.Windows.Forms.Label();
            this.lbl_minute = new System.Windows.Forms.Label();
            this.lbl_hour = new System.Windows.Forms.Label();
            this.lbl_end_time = new System.Windows.Forms.Label();
            this.lbl_start_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_remaining_time = new System.Windows.Forms.Label();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.client_timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_time_catcher = new System.Windows.Forms.Label();
            this.lbl_minimize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(76, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(74, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Time Remaining:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button_logout);
            this.panel1.Controls.Add(this.lbl_second);
            this.panel1.Controls.Add(this.lbl_minute);
            this.panel1.Controls.Add(this.lbl_hour);
            this.panel1.Controls.Add(this.lbl_end_time);
            this.panel1.Controls.Add(this.lbl_start_time);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(8, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 208);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_logout
            // 
            this.button_logout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(143)))));
            this.button_logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(143)))));
            this.button_logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_logout.BorderRadius = 5;
            this.button_logout.ButtonText = "End Session";
            this.button_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_logout.DisabledColor = System.Drawing.Color.Gray;
            this.button_logout.Iconcolor = System.Drawing.Color.Transparent;
            this.button_logout.Iconimage = null;
            this.button_logout.Iconimage_right = null;
            this.button_logout.Iconimage_right_Selected = null;
            this.button_logout.Iconimage_Selected = null;
            this.button_logout.IconMarginLeft = 0;
            this.button_logout.IconMarginRight = 0;
            this.button_logout.IconRightVisible = true;
            this.button_logout.IconRightZoom = 0D;
            this.button_logout.IconVisible = true;
            this.button_logout.IconZoom = 90D;
            this.button_logout.IsTab = false;
            this.button_logout.Location = new System.Drawing.Point(49, 165);
            this.button_logout.Margin = new System.Windows.Forms.Padding(4);
            this.button_logout.Name = "button_logout";
            this.button_logout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(85)))), ((int)(((byte)(143)))));
            this.button_logout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(154)))), ((int)(((byte)(213)))));
            this.button_logout.OnHoverTextColor = System.Drawing.Color.WhiteSmoke;
            this.button_logout.selected = false;
            this.button_logout.Size = new System.Drawing.Size(100, 25);
            this.button_logout.TabIndex = 14;
            this.button_logout.Text = "End Session";
            this.button_logout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_logout.Textcolor = System.Drawing.Color.WhiteSmoke;
            this.button_logout.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // lbl_second
            // 
            this.lbl_second.AutoSize = true;
            this.lbl_second.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_second.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_second.Location = new System.Drawing.Point(116, 53);
            this.lbl_second.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_second.Name = "lbl_second";
            this.lbl_second.Size = new System.Drawing.Size(30, 24);
            this.lbl_second.TabIndex = 13;
            this.lbl_second.Text = "00";
            // 
            // lbl_minute
            // 
            this.lbl_minute.AutoSize = true;
            this.lbl_minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minute.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_minute.Location = new System.Drawing.Point(84, 53);
            this.lbl_minute.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_minute.Name = "lbl_minute";
            this.lbl_minute.Size = new System.Drawing.Size(30, 24);
            this.lbl_minute.TabIndex = 11;
            this.lbl_minute.Text = "00";
            this.lbl_minute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_hour
            // 
            this.lbl_hour.AutoSize = true;
            this.lbl_hour.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hour.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_hour.Location = new System.Drawing.Point(51, 53);
            this.lbl_hour.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_hour.Name = "lbl_hour";
            this.lbl_hour.Size = new System.Drawing.Size(30, 24);
            this.lbl_hour.TabIndex = 9;
            this.lbl_hour.Text = "00";
            this.lbl_hour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_end_time
            // 
            this.lbl_end_time.AutoSize = true;
            this.lbl_end_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_end_time.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_end_time.Location = new System.Drawing.Point(102, 126);
            this.lbl_end_time.Name = "lbl_end_time";
            this.lbl_end_time.Size = new System.Drawing.Size(47, 13);
            this.lbl_end_time.TabIndex = 6;
            this.lbl_end_time.Text = "8:32 PM";
            // 
            // lbl_start_time
            // 
            this.lbl_start_time.AutoSize = true;
            this.lbl_start_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_start_time.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_start_time.Location = new System.Drawing.Point(102, 104);
            this.lbl_start_time.Name = "lbl_start_time";
            this.lbl_start_time.Size = new System.Drawing.Size(47, 13);
            this.lbl_start_time.TabIndex = 5;
            this.lbl_start_time.Text = "8:00 PM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(42, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(39, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Time:";
            // 
            // lbl_remaining_time
            // 
            this.lbl_remaining_time.AutoSize = true;
            this.lbl_remaining_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remaining_time.ForeColor = System.Drawing.Color.White;
            this.lbl_remaining_time.Location = new System.Drawing.Point(39, 9);
            this.lbl_remaining_time.Name = "lbl_remaining_time";
            this.lbl_remaining_time.Size = new System.Drawing.Size(13, 13);
            this.lbl_remaining_time.TabIndex = 8;
            this.lbl_remaining_time.Text = "1";
            this.lbl_remaining_time.Visible = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this;
            // 
            // client_timer
            // 
            this.client_timer.Interval = 1000;
            this.client_timer.Tick += new System.EventHandler(this.client_timer_Tick);
            // 
            // lbl_time_catcher
            // 
            this.lbl_time_catcher.AutoSize = true;
            this.lbl_time_catcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time_catcher.ForeColor = System.Drawing.Color.Black;
            this.lbl_time_catcher.Location = new System.Drawing.Point(39, 36);
            this.lbl_time_catcher.Name = "lbl_time_catcher";
            this.lbl_time_catcher.Size = new System.Drawing.Size(13, 13);
            this.lbl_time_catcher.TabIndex = 9;
            this.lbl_time_catcher.Text = "5";
            this.lbl_time_catcher.Visible = false;
            // 
            // lbl_minimize
            // 
            this.lbl_minimize.AutoSize = true;
            this.lbl_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minimize.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_minimize.Location = new System.Drawing.Point(187, 2);
            this.lbl_minimize.Name = "lbl_minimize";
            this.lbl_minimize.Size = new System.Drawing.Size(21, 20);
            this.lbl_minimize.TabIndex = 10;
            this.lbl_minimize.Text = "--";
            this.lbl_minimize.Click += new System.EventHandler(this.lbl_minimize_Click);
            // 
            // form_Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(220, 287);
            this.Controls.Add(this.lbl_minimize);
            this.Controls.Add(this.lbl_time_catcher);
            this.Controls.Add(this.lbl_remaining_time);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_Timer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS CLIENT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIsClosing);
            this.Load += new System.EventHandler(this.Timer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_end_time;
        private System.Windows.Forms.Label lbl_start_time;
        private System.Windows.Forms.Timer client_timer;
        private System.Windows.Forms.Label lbl_minute;
        private System.Windows.Forms.Label lbl_hour;
        private System.Windows.Forms.Label lbl_time_catcher;
        private System.Windows.Forms.Label lbl_minimize;
        private System.Windows.Forms.Label lbl_second;
        private Bunifu.Framework.UI.BunifuFlatButton button_logout;
        public System.Windows.Forms.Label lbl_remaining_time;
    }
}