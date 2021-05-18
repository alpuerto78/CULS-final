
namespace CULS_SERVER
{
    partial class form_Preload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Preload));
            this.stretch = new System.Windows.Forms.Timer(this.components);
            this.transition_color = new Bunifu.Framework.UI.BunifuColorTransition(this.components);
            this.timer_color_transition = new System.Windows.Forms.Timer(this.components);
            this.progbar_pre_load = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stretch
            // 
            this.stretch.Enabled = true;
            this.stretch.Interval = 25;
            this.stretch.Tick += new System.EventHandler(this.stretch_Tick);
            // 
            // transition_color
            // 
            this.transition_color.Color1 = System.Drawing.Color.LimeGreen;
            this.transition_color.Color2 = System.Drawing.Color.White;
            this.transition_color.ProgessValue = 0;
            // 
            // timer_color_transition
            // 
            this.timer_color_transition.Enabled = true;
            this.timer_color_transition.Interval = 50;
            // 
            // progbar_pre_load
            // 
            this.progbar_pre_load.animated = true;
            this.progbar_pre_load.animationIterval = 1;
            this.progbar_pre_load.animationSpeed = 1;
            this.progbar_pre_load.BackColor = System.Drawing.Color.Transparent;
            this.progbar_pre_load.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progbar_pre_load.BackgroundImage")));
            this.progbar_pre_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progbar_pre_load.ForeColor = System.Drawing.Color.SeaGreen;
            this.progbar_pre_load.LabelVisible = false;
            this.progbar_pre_load.LineProgressThickness = 5;
            this.progbar_pre_load.LineThickness = 5;
            this.progbar_pre_load.Location = new System.Drawing.Point(9, 22);
            this.progbar_pre_load.Margin = new System.Windows.Forms.Padding(0);
            this.progbar_pre_load.MaxValue = 100;
            this.progbar_pre_load.Name = "progbar_pre_load";
            this.progbar_pre_load.ProgressBackColor = System.Drawing.Color.Transparent;
            this.progbar_pre_load.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.progbar_pre_load.Size = new System.Drawing.Size(50, 50);
            this.progbar_pre_load.TabIndex = 3;
            this.progbar_pre_load.Value = 20;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(176)))), ((int)(((byte)(154)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Chocolate;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 10);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.label1.Location = new System.Drawing.Point(71, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Loading...";
            // 
            // form_Preload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 79);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progbar_pre_load);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_Preload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CULS SERVER";
            this.Load += new System.EventHandler(this.form_Preload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer stretch;
        private Bunifu.Framework.UI.BunifuColorTransition transition_color;
        private System.Windows.Forms.Timer timer_color_transition;
        private Bunifu.Framework.UI.BunifuCircleProgressbar progbar_pre_load;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}