namespace CULS_Client
{
    partial class form_Lockscreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Lockscreen));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.picturebox_slideshow = new System.Windows.Forms.PictureBox();
            this.timer_shuffle = new System.Windows.Forms.Timer(this.components);
            this.label_pc_no = new System.Windows.Forms.Label();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_configure = new System.Windows.Forms.Panel();
            this.btn_signin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txt_username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button_hide_pass = new Bunifu.Framework.UI.BunifuImageButton();
            this.button_show_pass = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.txt_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lbl_course_add = new MaterialSkin.Controls.MaterialLabel();
            this.label_close = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_load_server = new System.Windows.Forms.Timer(this.components);
            this.timer_get_time = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer_keepAlive = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_slideshow)).BeginInit();
            this.panel_configure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_hide_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_show_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // picturebox_slideshow
            // 
            this.picturebox_slideshow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picturebox_slideshow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturebox_slideshow.Image = ((System.Drawing.Image)(resources.GetObject("picturebox_slideshow.Image")));
            this.picturebox_slideshow.InitialImage = null;
            this.picturebox_slideshow.Location = new System.Drawing.Point(0, 0);
            this.picturebox_slideshow.Name = "picturebox_slideshow";
            this.picturebox_slideshow.Size = new System.Drawing.Size(800, 450);
            this.picturebox_slideshow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_slideshow.TabIndex = 2;
            this.picturebox_slideshow.TabStop = false;
            this.picturebox_slideshow.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer_shuffle
            // 
            this.timer_shuffle.Enabled = true;
            this.timer_shuffle.Interval = 5000;
            this.timer_shuffle.Tick += new System.EventHandler(this.timer_shuffle_Tick);
            // 
            // label_pc_no
            // 
            this.label_pc_no.AutoSize = true;
            this.label_pc_no.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label_pc_no.Font = new System.Drawing.Font("Calibri", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pc_no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.label_pc_no.Location = new System.Drawing.Point(27, 25);
            this.label_pc_no.Name = "label_pc_no";
            this.label_pc_no.Size = new System.Drawing.Size(279, 117);
            this.label_pc_no.TabIndex = 3;
            this.label_pc_no.Text = "PC-01";
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.label_pc_no;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 5;
            this.bunifuElipse3.TargetControl = this.panel_configure;
            // 
            // panel_configure
            // 
            this.panel_configure.Controls.Add(this.label1);
            this.panel_configure.Controls.Add(this.btn_signin);
            this.panel_configure.Controls.Add(this.txt_username);
            this.panel_configure.Controls.Add(this.button_hide_pass);
            this.panel_configure.Controls.Add(this.button_show_pass);
            this.panel_configure.Controls.Add(this.bunifuImageButton3);
            this.panel_configure.Controls.Add(this.bunifuImageButton2);
            this.panel_configure.Controls.Add(this.txt_password);
            this.panel_configure.Controls.Add(this.lbl_course_add);
            this.panel_configure.Controls.Add(this.label_close);
            this.panel_configure.Controls.Add(this.panel1);
            this.panel_configure.Controls.Add(this.label4);
            this.panel_configure.Location = new System.Drawing.Point(25, 160);
            this.panel_configure.Name = "panel_configure";
            this.panel_configure.Size = new System.Drawing.Size(297, 200);
            this.panel_configure.TabIndex = 4;
            this.panel_configure.Visible = false;
            this.panel_configure.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_configure_Paint);
            // 
            // btn_signin
            // 
            this.btn_signin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(100)))));
            this.btn_signin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.btn_signin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_signin.BorderRadius = 5;
            this.btn_signin.ButtonText = "SIGN IN";
            this.btn_signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signin.DisabledColor = System.Drawing.Color.Gray;
            this.btn_signin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signin.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_signin.Iconimage = null;
            this.btn_signin.Iconimage_right = null;
            this.btn_signin.Iconimage_right_Selected = null;
            this.btn_signin.Iconimage_Selected = null;
            this.btn_signin.IconMarginLeft = 0;
            this.btn_signin.IconMarginRight = 0;
            this.btn_signin.IconRightVisible = true;
            this.btn_signin.IconRightZoom = 0D;
            this.btn_signin.IconVisible = true;
            this.btn_signin.IconZoom = 0D;
            this.btn_signin.IsTab = false;
            this.btn_signin.Location = new System.Drawing.Point(62, 158);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.btn_signin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(130)))));
            this.btn_signin.OnHoverTextColor = System.Drawing.Color.Azure;
            this.btn_signin.selected = false;
            this.btn_signin.Size = new System.Drawing.Size(173, 30);
            this.btn_signin.TabIndex = 27;
            this.btn_signin.Text = "SIGN IN";
            this.btn_signin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_signin.Textcolor = System.Drawing.Color.WhiteSmoke;
            this.btn_signin.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.SystemColors.Control;
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.Silver;
            this.txt_username.HintForeColor = System.Drawing.Color.Empty;
            this.txt_username.HintText = "";
            this.txt_username.isPassword = false;
            this.txt_username.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_username.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_username.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_username.LineThickness = 3;
            this.txt_username.Location = new System.Drawing.Point(81, 67);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(153, 22);
            this.txt_username.TabIndex = 25;
            this.txt_username.Text = "Username";
            this.txt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_username.Click += new System.EventHandler(this.txt_username_Click);
            this.txt_username.Enter += new System.EventHandler(this.txt_username_Enter);
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_username_KeyPress);
            this.txt_username.Leave += new System.EventHandler(this.txt_username_Leave);
            this.txt_username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_username_MouseClick);
            // 
            // button_hide_pass
            // 
            this.button_hide_pass.BackColor = System.Drawing.SystemColors.Control;
            this.button_hide_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_hide_pass.Image = ((System.Drawing.Image)(resources.GetObject("button_hide_pass.Image")));
            this.button_hide_pass.ImageActive = null;
            this.button_hide_pass.Location = new System.Drawing.Point(215, 109);
            this.button_hide_pass.Name = "button_hide_pass";
            this.button_hide_pass.Size = new System.Drawing.Size(15, 15);
            this.button_hide_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.button_hide_pass.TabIndex = 29;
            this.button_hide_pass.TabStop = false;
            this.button_hide_pass.Zoom = 10;
            this.button_hide_pass.Click += new System.EventHandler(this.button_hide_pass_Click_2);
            // 
            // button_show_pass
            // 
            this.button_show_pass.BackColor = System.Drawing.SystemColors.Control;
            this.button_show_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_pass.Image = ((System.Drawing.Image)(resources.GetObject("button_show_pass.Image")));
            this.button_show_pass.ImageActive = null;
            this.button_show_pass.Location = new System.Drawing.Point(215, 109);
            this.button_show_pass.Name = "button_show_pass";
            this.button_show_pass.Size = new System.Drawing.Size(15, 15);
            this.button_show_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.button_show_pass.TabIndex = 28;
            this.button_show_pass.TabStop = false;
            this.button_show_pass.Zoom = 10;
            this.button_show_pass.Click += new System.EventHandler(this.button_show_pass_Click);
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.Image")));
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Location = new System.Drawing.Point(60, 108);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(21, 21);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton3.TabIndex = 31;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 10;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.SystemColors.Control;
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(60, 68);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(21, 21);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 30;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.SystemColors.Control;
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Silver;
            this.txt_password.HintForeColor = System.Drawing.Color.Empty;
            this.txt_password.HintText = "";
            this.txt_password.isPassword = false;
            this.txt_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_password.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_password.LineThickness = 3;
            this.txt_password.Location = new System.Drawing.Point(81, 104);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(153, 25);
            this.txt_password.TabIndex = 26;
            this.txt_password.Text = "Password";
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_password.OnValueChanged += new System.EventHandler(this.txt_password_OnValueChanged);
            this.txt_password.Click += new System.EventHandler(this.txt_password_Click);
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            this.txt_password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_password_MouseClick);
            // 
            // lbl_course_add
            // 
            this.lbl_course_add.AutoSize = true;
            this.lbl_course_add.Depth = 0;
            this.lbl_course_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_course_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_course_add.Location = new System.Drawing.Point(13, 25);
            this.lbl_course_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_course_add.Name = "lbl_course_add";
            this.lbl_course_add.Size = new System.Drawing.Size(126, 19);
            this.lbl_course_add.TabIndex = 19;
            this.lbl_course_add.Text = "ADMINISTRATOR";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(266, 26);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 18;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            this.label_close.MouseLeave += new System.EventHandler(this.label_close_MouseLeave);
            this.label_close.MouseHover += new System.EventHandler(this.label_close_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 10);
            this.panel1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChatToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 26);
            // 
            // privateChatToolStripMenuItem
            // 
            this.privateChatToolStripMenuItem.Name = "privateChatToolStripMenuItem";
            this.privateChatToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.privateChatToolStripMenuItem.Text = "Private Chat";
            // 
            // timer_load_server
            // 
            this.timer_load_server.Enabled = true;
            this.timer_load_server.Interval = 1000;
            // 
            // timer_get_time
            // 
            this.timer_get_time.Enabled = true;
            this.timer_get_time.Interval = 1000;
            this.timer_get_time.Tick += new System.EventHandler(this.timer_get_time_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(435, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "check status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer_keepAlive
            // 
            this.timer_keepAlive.Enabled = true;
            this.timer_keepAlive.Interval = 1000;
            this.timer_keepAlive.Tick += new System.EventHandler(this.timer_keepAlive_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(552, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "close connection";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(435, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(8, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "_____________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(8, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "_____________________________________________";
            // 
            // form_Lockscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel_configure);
            this.Controls.Add(this.label_pc_no);
            this.Controls.Add(this.picturebox_slideshow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_Lockscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS CLIENT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_slideshow)).EndInit();
            this.panel_configure.ResumeLayout(false);
            this.panel_configure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_hide_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_show_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox picturebox_slideshow;
        private System.Windows.Forms.Timer timer_shuffle;
        private System.Windows.Forms.Label label_pc_no;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.Panel panel_configure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_close;
        private Bunifu.Framework.UI.BunifuFlatButton btn_signin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_username;
        private Bunifu.Framework.UI.BunifuImageButton button_hide_pass;
        private Bunifu.Framework.UI.BunifuImageButton button_show_pass;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_password;
        public MaterialSkin.Controls.MaterialLabel lbl_course_add;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem privateChatToolStripMenuItem;
        private System.Windows.Forms.Timer timer_load_server;
        private System.Windows.Forms.Timer timer_get_time;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_keepAlive;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

