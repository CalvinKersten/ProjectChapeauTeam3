namespace ChapeauUI
{
    partial class Form1
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
            this.pnlOrderOverview = new System.Windows.Forms.Panel();
            this.pnlOrderHome = new System.Windows.Forms.Panel();
            this.pnlOrderNav = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlOrderOverview.SuspendLayout();
            this.pnlOrderHome.SuspendLayout();
            this.pnlOrderNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrderOverview
            // 
            this.pnlOrderOverview.Controls.Add(this.pnlOrderHome);
            this.pnlOrderOverview.Controls.Add(this.pnlOrderNav);
            this.pnlOrderOverview.Location = new System.Drawing.Point(-3, 1);
            this.pnlOrderOverview.Name = "pnlOrderOverview";
            this.pnlOrderOverview.Size = new System.Drawing.Size(401, 695);
            this.pnlOrderOverview.TabIndex = 0;
            // 
            // pnlOrderHome
            // 
            this.pnlOrderHome.Controls.Add(this.pictureBox1);
            this.pnlOrderHome.Controls.Add(this.label1);
            this.pnlOrderHome.Location = new System.Drawing.Point(3, 0);
            this.pnlOrderHome.Name = "pnlOrderHome";
            this.pnlOrderHome.Size = new System.Drawing.Size(398, 73);
            this.pnlOrderHome.TabIndex = 2;
            // 
            // pnlOrderNav
            // 
            this.pnlOrderNav.Controls.Add(this.button1);
            this.pnlOrderNav.Controls.Add(this.button2);
            this.pnlOrderNav.Controls.Add(this.button3);
            this.pnlOrderNav.Location = new System.Drawing.Point(3, 74);
            this.pnlOrderNav.Name = "pnlOrderNav";
            this.pnlOrderNav.Size = new System.Drawing.Size(398, 70);
            this.pnlOrderNav.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 68);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(264, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 68);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChapeauUI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(159, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table #";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(398, 697);
            this.Controls.Add(this.pnlOrderOverview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlOrderOverview.ResumeLayout(false);
            this.pnlOrderHome.ResumeLayout(false);
            this.pnlOrderHome.PerformLayout();
            this.pnlOrderNav.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlOrderOverview;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel pnlOrderNav;
        private Panel pnlOrderHome;
    }
}