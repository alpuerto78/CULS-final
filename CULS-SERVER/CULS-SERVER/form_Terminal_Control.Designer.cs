
namespace CULS_SERVER
{
    partial class form_Terminal_Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Terminal_Control));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_close = new System.Windows.Forms.Label();
            this.lbl_terminal_name = new MaterialSkin.Controls.MaterialLabel();
            this.btn_terminal_control_add_time = new System.Windows.Forms.Button();
            this.btn_terminal_control_logout = new System.Windows.Forms.Button();
            this.btn_terminal_control_restart = new System.Windows.Forms.Button();
            this.btn_terminal_control_shutdown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 10);
            this.panel1.TabIndex = 0;
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_close.Location = new System.Drawing.Point(275, 16);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(15, 13);
            this.label_close.TabIndex = 18;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // lbl_terminal_name
            // 
            this.lbl_terminal_name.Depth = 0;
            this.lbl_terminal_name.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_terminal_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_terminal_name.Location = new System.Drawing.Point(125, 17);
            this.lbl_terminal_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_terminal_name.Name = "lbl_terminal_name";
            this.lbl_terminal_name.Size = new System.Drawing.Size(50, 19);
            this.lbl_terminal_name.TabIndex = 17;
            this.lbl_terminal_name.Text = "PC-00";
            this.lbl_terminal_name.Click += new System.EventHandler(this.lbl_terminal_name_Click);
            // 
            // btn_terminal_control_add_time
            // 
            this.btn_terminal_control_add_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminal_control_add_time.Location = new System.Drawing.Point(33, 57);
            this.btn_terminal_control_add_time.Name = "btn_terminal_control_add_time";
            this.btn_terminal_control_add_time.Size = new System.Drawing.Size(100, 100);
            this.btn_terminal_control_add_time.TabIndex = 19;
            this.btn_terminal_control_add_time.Text = "ADD TIME";
            this.btn_terminal_control_add_time.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_terminal_control_add_time.UseVisualStyleBackColor = true;
            this.btn_terminal_control_add_time.Click += new System.EventHandler(this.btn_terminal_control_add_time_Click);
            // 
            // btn_terminal_control_logout
            // 
            this.btn_terminal_control_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminal_control_logout.Location = new System.Drawing.Point(161, 57);
            this.btn_terminal_control_logout.Name = "btn_terminal_control_logout";
            this.btn_terminal_control_logout.Size = new System.Drawing.Size(100, 100);
            this.btn_terminal_control_logout.TabIndex = 20;
            this.btn_terminal_control_logout.Text = "LOGOUT";
            this.btn_terminal_control_logout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_terminal_control_logout.UseVisualStyleBackColor = true;
            this.btn_terminal_control_logout.Click += new System.EventHandler(this.btn_terminal_control_logout_Click);
            // 
            // btn_terminal_control_restart
            // 
            this.btn_terminal_control_restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminal_control_restart.Location = new System.Drawing.Point(33, 174);
            this.btn_terminal_control_restart.Name = "btn_terminal_control_restart";
            this.btn_terminal_control_restart.Size = new System.Drawing.Size(100, 100);
            this.btn_terminal_control_restart.TabIndex = 21;
            this.btn_terminal_control_restart.Text = "RESTART";
            this.btn_terminal_control_restart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_terminal_control_restart.UseVisualStyleBackColor = true;
            this.btn_terminal_control_restart.Click += new System.EventHandler(this.btn_terminal_control_restart_Click);
            // 
            // btn_terminal_control_shutdown
            // 
            this.btn_terminal_control_shutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_terminal_control_shutdown.Location = new System.Drawing.Point(161, 174);
            this.btn_terminal_control_shutdown.Name = "btn_terminal_control_shutdown";
            this.btn_terminal_control_shutdown.Size = new System.Drawing.Size(100, 100);
            this.btn_terminal_control_shutdown.TabIndex = 22;
            this.btn_terminal_control_shutdown.Text = "SHUTDOWN";
            this.btn_terminal_control_shutdown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_terminal_control_shutdown.UseVisualStyleBackColor = true;
            this.btn_terminal_control_shutdown.Click += new System.EventHandler(this.btn_terminal_control_shutdown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 255);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // form_Terminal_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 304);
            this.Controls.Add(this.btn_terminal_control_shutdown);
            this.Controls.Add(this.btn_terminal_control_restart);
            this.Controls.Add(this.btn_terminal_control_logout);
            this.Controls.Add(this.btn_terminal_control_add_time);
            this.Controls.Add(this.label_close);
            this.Controls.Add(this.lbl_terminal_name);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_Terminal_Control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_Terminal_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_close;
        public MaterialSkin.Controls.MaterialLabel lbl_terminal_name;
        private System.Windows.Forms.Button btn_terminal_control_add_time;
        private System.Windows.Forms.Button btn_terminal_control_logout;
        private System.Windows.Forms.Button btn_terminal_control_restart;
        private System.Windows.Forms.Button btn_terminal_control_shutdown;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}