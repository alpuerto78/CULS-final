namespace CULS_SERVER
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.button_show_pass = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_signin = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txt_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.label_alert = new System.Windows.Forms.Label();
            this.txt_username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.button_hide_pass = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.button_show_pass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_hide_pass)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // button_show_pass
            // 
            this.button_show_pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.button_show_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_show_pass.Image = ((System.Drawing.Image)(resources.GetObject("button_show_pass.Image")));
            this.button_show_pass.ImageActive = null;
            this.button_show_pass.Location = new System.Drawing.Point(182, 80);
            this.button_show_pass.Name = "button_show_pass";
            this.button_show_pass.Size = new System.Drawing.Size(15, 15);
            this.button_show_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.button_show_pass.TabIndex = 3;
            this.button_show_pass.TabStop = false;
            this.button_show_pass.Zoom = 10;
            this.button_show_pass.Click += new System.EventHandler(this.button_show_pass_Click_1);
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
            this.btn_signin.Location = new System.Drawing.Point(28, 118);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.btn_signin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(130)))));
            this.btn_signin.OnHoverTextColor = System.Drawing.Color.Azure;
            this.btn_signin.selected = false;
            this.btn_signin.Size = new System.Drawing.Size(173, 30);
            this.btn_signin.TabIndex = 3;
            this.btn_signin.Text = "SIGN IN";
            this.btn_signin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_signin.Textcolor = System.Drawing.Color.WhiteSmoke;
            this.btn_signin.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signin.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
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
            this.txt_password.Location = new System.Drawing.Point(48, 75);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(153, 25);
            this.txt_password.TabIndex = 2;
            this.txt_password.Text = "Password";
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_password.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox2_OnValueChanged);
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            this.txt_password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_password_MouseClick);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(27, 39);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(21, 21);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 9;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.bunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.Image")));
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Location = new System.Drawing.Point(27, 79);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(21, 21);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton3.TabIndex = 10;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 10;
            this.bunifuImageButton3.Click += new System.EventHandler(this.bunifuImageButton3_Click);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Close.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_Close.Location = new System.Drawing.Point(474, 9);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(17, 16);
            this.lbl_Close.TabIndex = 11;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.label1_Click);
            this.lbl_Close.MouseLeave += new System.EventHandler(this.lbl_Close_MouseLeave);
            this.lbl_Close.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel_login);
            this.panel1.Controls.Add(this.lbl_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 331);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.panel_login.Controls.Add(this.label_alert);
            this.panel_login.Controls.Add(this.btn_signin);
            this.panel_login.Controls.Add(this.txt_username);
            this.panel_login.Controls.Add(this.button_hide_pass);
            this.panel_login.Controls.Add(this.button_show_pass);
            this.panel_login.Controls.Add(this.bunifuImageButton3);
            this.panel_login.Controls.Add(this.bunifuImageButton2);
            this.panel_login.Controls.Add(this.txt_password);
            this.panel_login.Location = new System.Drawing.Point(246, 120);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(226, 169);
            this.panel_login.TabIndex = 12;
            // 
            // label_alert
            // 
            this.label_alert.AutoSize = true;
            this.label_alert.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_alert.ForeColor = System.Drawing.Color.DarkGray;
            this.label_alert.Location = new System.Drawing.Point(25, 15);
            this.label_alert.Name = "label_alert";
            this.label_alert.Size = new System.Drawing.Size(97, 14);
            this.label_alert.TabIndex = 13;
            this.label_alert.Text = "*Fill out credentials";
            this.label_alert.Click += new System.EventHandler(this.label_alert_Click);
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
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
            this.txt_username.Location = new System.Drawing.Point(48, 38);
            this.txt_username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(153, 22);
            this.txt_username.TabIndex = 1;
            this.txt_username.Text = "Username";
            this.txt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_username.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox1_OnValueChanged);
            this.txt_username.Click += new System.EventHandler(this.txt_username_Click);
            this.txt_username.Enter += new System.EventHandler(this.txt_username_Enter);
            this.txt_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername_KeyPress);
            this.txt_username.Leave += new System.EventHandler(this.txt_username_Leave);
            this.txt_username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_username_MouseClick);
            // 
            // button_hide_pass
            // 
            this.button_hide_pass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.button_hide_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_hide_pass.Image = ((System.Drawing.Image)(resources.GetObject("button_hide_pass.Image")));
            this.button_hide_pass.ImageActive = null;
            this.button_hide_pass.Location = new System.Drawing.Point(182, 80);
            this.button_hide_pass.Name = "button_hide_pass";
            this.button_hide_pass.Size = new System.Drawing.Size(15, 15);
            this.button_hide_pass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.button_hide_pass.TabIndex = 6;
            this.button_hide_pass.TabStop = false;
            this.button_hide_pass.Zoom = 10;
            this.button_hide_pass.Click += new System.EventHandler(this.button_hide_pass_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.panel_login;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(500, 331);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.button_show_pass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button_hide_pass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuImageButton button_show_pass;
        private Bunifu.Framework.UI.BunifuFlatButton btn_signin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_password;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Label lbl_Close;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton button_hide_pass;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_username;
        private System.Windows.Forms.Panel panel_login;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.Label label_alert;
    }
}