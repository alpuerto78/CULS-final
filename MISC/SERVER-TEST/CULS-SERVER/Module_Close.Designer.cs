namespace CULS_SERVER
{
    partial class Module_Close
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_header = new System.Windows.Forms.Panel();
            this.panel_body = new System.Windows.Forms.Panel();
            this.button_cancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button_okay = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(250, 38);
            this.panel_header.TabIndex = 0;
            // 
            // panel_body
            // 
            this.panel_body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.panel_body.Controls.Add(this.button_cancel);
            this.panel_body.Controls.Add(this.label1);
            this.panel_body.Controls.Add(this.button_okay);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 38);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(250, 162);
            this.panel_body.TabIndex = 1;
            // 
            // button_cancel
            // 
            this.button_cancel.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.button_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.button_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_cancel.BorderRadius = 5;
            this.button_cancel.ButtonText = "Cancel";
            this.button_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_cancel.DisabledColor = System.Drawing.Color.Gray;
            this.button_cancel.Iconcolor = System.Drawing.Color.Transparent;
            this.button_cancel.Iconimage = null;
            this.button_cancel.Iconimage_right = null;
            this.button_cancel.Iconimage_right_Selected = null;
            this.button_cancel.Iconimage_Selected = null;
            this.button_cancel.IconMarginLeft = 0;
            this.button_cancel.IconMarginRight = 0;
            this.button_cancel.IconRightVisible = true;
            this.button_cancel.IconRightZoom = 0D;
            this.button_cancel.IconVisible = true;
            this.button_cancel.IconZoom = 90D;
            this.button_cancel.IsTab = false;
            this.button_cancel.Location = new System.Drawing.Point(188, 120);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.button_cancel.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(130)))));
            this.button_cancel.OnHoverTextColor = System.Drawing.Color.White;
            this.button_cancel.selected = false;
            this.button_cancel.Size = new System.Drawing.Size(50, 30);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_cancel.Textcolor = System.Drawing.Color.White;
            this.button_cancel.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you sure you want to exit CULS?";
            // 
            // button_okay
            // 
            this.button_okay.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.button_okay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.button_okay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_okay.BorderRadius = 5;
            this.button_okay.ButtonText = "Okay";
            this.button_okay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_okay.DisabledColor = System.Drawing.Color.Gray;
            this.button_okay.Iconcolor = System.Drawing.Color.Transparent;
            this.button_okay.Iconimage = null;
            this.button_okay.Iconimage_right = null;
            this.button_okay.Iconimage_right_Selected = null;
            this.button_okay.Iconimage_Selected = null;
            this.button_okay.IconMarginLeft = 0;
            this.button_okay.IconMarginRight = 0;
            this.button_okay.IconRightVisible = true;
            this.button_okay.IconRightZoom = 0D;
            this.button_okay.IconVisible = true;
            this.button_okay.IconZoom = 90D;
            this.button_okay.IsTab = false;
            this.button_okay.Location = new System.Drawing.Point(132, 120);
            this.button_okay.Name = "button_okay";
            this.button_okay.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.button_okay.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(130)))));
            this.button_okay.OnHoverTextColor = System.Drawing.Color.White;
            this.button_okay.selected = false;
            this.button_okay.Size = new System.Drawing.Size(50, 30);
            this.button_okay.TabIndex = 0;
            this.button_okay.Text = "Okay";
            this.button_okay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button_okay.Textcolor = System.Drawing.Color.White;
            this.button_okay.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_okay.Click += new System.EventHandler(this.button_okay_Click);
            // 
            // Module_Close
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Module_Close";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module_Close";
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel_body;
        private Bunifu.Framework.UI.BunifuFlatButton button_okay;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton button_cancel;
    }
}