
namespace CULS_Client
{
    partial class form_update_credential
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_update_credential));
            this.txt_current_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lbl_course_add = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_minimized = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_new_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_confirm_password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.button_ipAD_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_current_password
            // 
            this.txt_current_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_current_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_current_password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_current_password.ForeColor = System.Drawing.Color.Silver;
            this.txt_current_password.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_current_password.HintText = "Current Password";
            this.txt_current_password.isPassword = false;
            this.txt_current_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_current_password.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_current_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_current_password.LineThickness = 3;
            this.txt_current_password.Location = new System.Drawing.Point(47, 63);
            this.txt_current_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_current_password.Name = "txt_current_password";
            this.txt_current_password.Size = new System.Drawing.Size(200, 25);
            this.txt_current_password.TabIndex = 1;
            this.txt_current_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lbl_course_add
            // 
            this.lbl_course_add.AutoSize = true;
            this.lbl_course_add.Depth = 0;
            this.lbl_course_add.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_course_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_course_add.Location = new System.Drawing.Point(12, 22);
            this.lbl_course_add.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_course_add.Name = "lbl_course_add";
            this.lbl_course_add.Size = new System.Drawing.Size(168, 19);
            this.lbl_course_add.TabIndex = 35;
            this.lbl_course_add.Text = "UPDATE CREDENTIALS";
            // 
            // lbl_minimized
            // 
            this.lbl_minimized.AutoSize = true;
            this.lbl_minimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_minimized.Location = new System.Drawing.Point(272, 22);
            this.lbl_minimized.Name = "lbl_minimized";
            this.lbl_minimized.Size = new System.Drawing.Size(15, 13);
            this.lbl_minimized.TabIndex = 34;
            this.lbl_minimized.Text = "--";
            this.lbl_minimized.Click += new System.EventHandler(this.lbl_minimized_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 10);
            this.panel1.TabIndex = 33;
            // 
            // txt_new_password
            // 
            this.txt_new_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_new_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_new_password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new_password.ForeColor = System.Drawing.Color.Silver;
            this.txt_new_password.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_new_password.HintText = "New Password";
            this.txt_new_password.isPassword = false;
            this.txt_new_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_new_password.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_new_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_new_password.LineThickness = 3;
            this.txt_new_password.Location = new System.Drawing.Point(47, 100);
            this.txt_new_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_new_password.Name = "txt_new_password";
            this.txt_new_password.Size = new System.Drawing.Size(200, 25);
            this.txt_new_password.TabIndex = 2;
            this.txt_new_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_confirm_password
            // 
            this.txt_confirm_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_confirm_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_confirm_password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirm_password.ForeColor = System.Drawing.Color.Silver;
            this.txt_confirm_password.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_confirm_password.HintText = "Confirm Password";
            this.txt_confirm_password.isPassword = false;
            this.txt_confirm_password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_confirm_password.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txt_confirm_password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.txt_confirm_password.LineThickness = 3;
            this.txt_confirm_password.Location = new System.Drawing.Point(47, 138);
            this.txt_confirm_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_confirm_password.Name = "txt_confirm_password";
            this.txt_confirm_password.Size = new System.Drawing.Size(200, 25);
            this.txt_confirm_password.TabIndex = 3;
            this.txt_confirm_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Arial", 8F);
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cancel.Location = new System.Drawing.Point(151, 186);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(64, 25);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "CANCEL";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // button_ipAD_save
            // 
            this.button_ipAD_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button_ipAD_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ipAD_save.Font = new System.Drawing.Font("Arial", 8F);
            this.button_ipAD_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_ipAD_save.Location = new System.Drawing.Point(221, 186);
            this.button_ipAD_save.Name = "button_ipAD_save";
            this.button_ipAD_save.Size = new System.Drawing.Size(67, 25);
            this.button_ipAD_save.TabIndex = 4;
            this.button_ipAD_save.Text = "SAVE";
            this.button_ipAD_save.UseVisualStyleBackColor = false;
            this.button_ipAD_save.Click += new System.EventHandler(this.button_ipAD_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(10, 35);
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
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "_____________________________________________";
            // 
            // form_update_credential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_current_password);
            this.Controls.Add(this.txt_new_password);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_confirm_password);
            this.Controls.Add(this.lbl_course_add);
            this.Controls.Add(this.button_ipAD_save);
            this.Controls.Add(this.lbl_minimized);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_update_credential";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS CLIENT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_current_password;
        public MaterialSkin.Controls.MaterialLabel lbl_course_add;
        private System.Windows.Forms.Label lbl_minimized;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_new_password;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_confirm_password;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button button_ipAD_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}