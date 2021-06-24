
namespace CULS_Client
{
    partial class form_PostLockscreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_PostLockscreen));
            this.picturebox_slideshow = new System.Windows.Forms.PictureBox();
            this.timer_get_time = new System.Windows.Forms.Timer(this.components);
            this.timer_shuffle_image = new System.Windows.Forms.Timer(this.components);
            this.label_pc_no = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_slideshow)).BeginInit();
            this.SuspendLayout();
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
            this.picturebox_slideshow.TabIndex = 3;
            this.picturebox_slideshow.TabStop = false;
            this.picturebox_slideshow.Click += new System.EventHandler(this.picturebox_slideshow_Click);
            // 
            // timer_get_time
            // 
            this.timer_get_time.Enabled = true;
            this.timer_get_time.Interval = 1000;
            this.timer_get_time.Tick += new System.EventHandler(this.timer_get_time_Tick);
            // 
            // timer_shuffle_image
            // 
            this.timer_shuffle_image.Enabled = true;
            this.timer_shuffle_image.Interval = 5000;
            this.timer_shuffle_image.Tick += new System.EventHandler(this.timer_shuffle_image_Tick);
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
            this.label_pc_no.TabIndex = 4;
            this.label_pc_no.Text = "PC-01";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this.label_pc_no;
            // 
            // form_PostLockscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_pc_no);
            this.Controls.Add(this.picturebox_slideshow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_PostLockscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS CLIENT";
            this.Load += new System.EventHandler(this.form_PostLockscreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_slideshow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox_slideshow;
        private System.Windows.Forms.Timer timer_get_time;
        private System.Windows.Forms.Timer timer_shuffle_image;
        private System.Windows.Forms.Label label_pc_no;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}