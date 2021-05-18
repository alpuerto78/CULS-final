namespace CULS_SERVER
{
    partial class form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Login));
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
            resources.ApplyResources(this.button_show_pass, "button_show_pass");
            this.button_show_pass.ImageActive = null;
            this.button_show_pass.Name = "button_show_pass";
            this.button_show_pass.TabStop = false;
            this.button_show_pass.Zoom = 10;
            this.button_show_pass.Click += new System.EventHandler(this.button_show_pass_Click_1);
            // 
            // btn_signin
            // 
            this.btn_signin.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(100)))));
            this.btn_signin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            resources.ApplyResources(this.btn_signin, "btn_signin");
            this.btn_signin.BorderRadius = 5;
            this.btn_signin.ButtonText = "SIGN IN";
            this.btn_signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signin.DisabledColor = System.Drawing.Color.Gray;
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
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.btn_signin.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(130)))));
            this.btn_signin.OnHoverTextColor = System.Drawing.Color.Azure;
            this.btn_signin.selected = false;
            this.btn_signin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_signin.Textcolor = System.Drawing.Color.WhiteSmoke;
            this.btn_signin.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signin.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.txt_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txt_password, "txt_password");
            this.txt_password.ForeColor = System.Drawing.Color.Silver;
            this.txt_password.HintForeColor = System.Drawing.Color.Empty;
            this.txt_password.HintText = "";
            this.txt_password.isPassword = false;
            this.txt_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_password.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_password.LineThickness = 3;
            this.txt_password.Name = "txt_password";
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
            resources.ApplyResources(this.bunifuImageButton2, "bunifuImageButton2");
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.bunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.bunifuImageButton3, "bunifuImageButton3");
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 10;
            this.bunifuImageButton3.Click += new System.EventHandler(this.bunifuImageButton3_Click);
            // 
            // lbl_Close
            // 
            resources.ApplyResources(this.lbl_Close, "lbl_Close");
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Click += new System.EventHandler(this.label1_Click);
            this.lbl_Close.MouseLeave += new System.EventHandler(this.lbl_Close_MouseLeave);
            this.lbl_Close.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.panel_login);
            this.panel1.Controls.Add(this.lbl_Close);
            this.panel1.Name = "panel1";
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
            resources.ApplyResources(this.panel_login, "panel_login");
            this.panel_login.Name = "panel_login";
            // 
            // label_alert
            // 
            resources.ApplyResources(this.label_alert, "label_alert");
            this.label_alert.ForeColor = System.Drawing.Color.DarkGray;
            this.label_alert.Name = "label_alert";
            this.label_alert.Click += new System.EventHandler(this.label_alert_Click);
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.txt_username, "txt_username");
            this.txt_username.ForeColor = System.Drawing.Color.Silver;
            this.txt_username.HintForeColor = System.Drawing.Color.Empty;
            this.txt_username.HintText = "";
            this.txt_username.isPassword = false;
            this.txt_username.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_username.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_username.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_username.LineThickness = 3;
            this.txt_username.Name = "txt_username";
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
            resources.ApplyResources(this.button_hide_pass, "button_hide_pass");
            this.button_hide_pass.ImageActive = null;
            this.button_hide_pass.Name = "button_hide_pass";
            this.button_hide_pass.TabStop = false;
            this.button_hide_pass.Zoom = 10;
            this.button_hide_pass.Click += new System.EventHandler(this.button_hide_pass_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 10;
            this.bunifuElipse2.TargetControl = this.panel_login;
            // 
            // form_Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "form_Login";
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