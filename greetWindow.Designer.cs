namespace ProgremmersDictionary
{
    partial class GreetWindow
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.greetWindowtoolTip = new System.Windows.Forms.ToolTip(this.components);
            this.waitRing = new RuProgressRing.RuProgressRing();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // greetWindowtoolTip
            // 
            this.greetWindowtoolTip.IsBalloon = true;
            // 
            // waitRing
            // 
            this.waitRing.Control_Height = 80;
            this.waitRing.Indicator_Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.waitRing.Location = new System.Drawing.Point(186, 230);
            this.waitRing.Name = "waitRing";
            this.waitRing.Refresh_Rate = 100;
            this.waitRing.Size = new System.Drawing.Size(80, 80);
            this.waitRing.TabIndex = 0;
            this.waitRing.MouseHover += new System.EventHandler(this.waitRing_MouseHover);
            // 
            // GreetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.BackgroundImage = global::ProgremmersDictionary.Properties.Resources.greetTeal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(439, 466);
            this.ControlBox = false;
            this.Controls.Add(this.waitRing);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GreetWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.Load += new System.EventHandler(this.GreetWindow_Load);
            this.MouseHover += new System.EventHandler(this.GreetWindow_MouseHover);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip greetWindowtoolTip;
        private RuProgressRing.RuProgressRing waitRing;
    }
}

