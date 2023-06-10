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
            this.DrinksNavButton = new ChapeauUI.ButtonStyle();
            this.DinnerNavButton = new ChapeauUI.ButtonStyle();
            this.LunchNavButton = new ChapeauUI.ButtonStyle();
            this.labelStyle1 = new ChapeauUI.LabelStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStyle1 = new ChapeauUI.ButtonStyle();
            this.LVOrderOverview = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.pnlOrderOverview.SuspendLayout();
            this.pnlOrderHome.SuspendLayout();
            this.pnlOrderNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrderOverview
            // 
            this.pnlOrderOverview.Controls.Add(this.pnlOrderHome);
            this.pnlOrderOverview.Controls.Add(this.label4);
            this.pnlOrderOverview.Controls.Add(this.label3);
            this.pnlOrderOverview.Controls.Add(this.label2);
            this.pnlOrderOverview.Controls.Add(this.buttonStyle1);
            this.pnlOrderOverview.Controls.Add(this.LVOrderOverview);
            this.pnlOrderOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderOverview.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderOverview.Name = "pnlOrderOverview";
            this.pnlOrderOverview.Size = new System.Drawing.Size(398, 697);
            this.pnlOrderOverview.TabIndex = 0;
            // 
            // pnlOrderHome
            // 
            this.pnlOrderHome.Controls.Add(this.pnlOrderNav);
            this.pnlOrderHome.Controls.Add(this.labelStyle1);
            this.pnlOrderHome.Controls.Add(this.pictureBox1);
            this.pnlOrderHome.Controls.Add(this.label1);
            this.pnlOrderHome.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderHome.Name = "pnlOrderHome";
            this.pnlOrderHome.Size = new System.Drawing.Size(395, 149);
            this.pnlOrderHome.TabIndex = 2;
            // 
            // pnlOrderNav
            // 
            this.pnlOrderNav.Controls.Add(this.DrinksNavButton);
            this.pnlOrderNav.Controls.Add(this.DinnerNavButton);
            this.pnlOrderNav.Controls.Add(this.LunchNavButton);
            this.pnlOrderNav.Location = new System.Drawing.Point(0, 79);
            this.pnlOrderNav.Name = "pnlOrderNav";
            this.pnlOrderNav.Size = new System.Drawing.Size(398, 70);
            this.pnlOrderNav.TabIndex = 2;
            // 
            // DrinksNavButton
            // 
            this.DrinksNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DrinksNavButton.FlatAppearance.BorderSize = 0;
            this.DrinksNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrinksNavButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrinksNavButton.Location = new System.Drawing.Point(285, 7);
            this.DrinksNavButton.Name = "DrinksNavButton";
            this.DrinksNavButton.Size = new System.Drawing.Size(98, 56);
            this.DrinksNavButton.TabIndex = 2;
            this.DrinksNavButton.Text = "Drinks";
            this.DrinksNavButton.UseVisualStyleBackColor = false;
            // 
            // DinnerNavButton
            // 
            this.DinnerNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DinnerNavButton.FlatAppearance.BorderSize = 0;
            this.DinnerNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DinnerNavButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DinnerNavButton.Location = new System.Drawing.Point(146, 7);
            this.DinnerNavButton.Name = "DinnerNavButton";
            this.DinnerNavButton.Size = new System.Drawing.Size(98, 56);
            this.DinnerNavButton.TabIndex = 1;
            this.DinnerNavButton.Text = "Dinner";
            this.DinnerNavButton.UseVisualStyleBackColor = false;
            // 
            // LunchNavButton
            // 
            this.LunchNavButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LunchNavButton.FlatAppearance.BorderSize = 0;
            this.LunchNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LunchNavButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LunchNavButton.Location = new System.Drawing.Point(11, 7);
            this.LunchNavButton.Name = "LunchNavButton";
            this.LunchNavButton.Size = new System.Drawing.Size(98, 56);
            this.LunchNavButton.TabIndex = 0;
            this.LunchNavButton.Text = "Lunch";
            this.LunchNavButton.UseVisualStyleBackColor = false;
            // 
            // labelStyle1
            // 
            this.labelStyle1.AutoSize = true;
            this.labelStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelStyle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelStyle1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStyle1.Location = new System.Drawing.Point(288, 20);
            this.labelStyle1.Name = "labelStyle1";
            this.labelStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.labelStyle1.Size = new System.Drawing.Size(89, 42);
            this.labelStyle1.TabIndex = 0;
            this.labelStyle1.Text = "Calvin";
            this.labelStyle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChapeauUI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Verdana Pro Light", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(140, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(203, 582);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "VAT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(273, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "_ _ _,-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Verdana", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(174, 531);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total:";
            // 
            // buttonStyle1
            // 
            this.buttonStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonStyle1.FlatAppearance.BorderSize = 0;
            this.buttonStyle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStyle1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStyle1.Location = new System.Drawing.Point(235, 628);
            this.buttonStyle1.Name = "buttonStyle1";
            this.buttonStyle1.Size = new System.Drawing.Size(151, 56);
            this.buttonStyle1.TabIndex = 3;
            this.buttonStyle1.Text = "Pay";
            this.buttonStyle1.UseVisualStyleBackColor = false;
            // 
            // LVOrderOverview
            // 
            this.LVOrderOverview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LVOrderOverview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LVOrderOverview.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LVOrderOverview.Location = new System.Drawing.Point(14, 166);
            this.LVOrderOverview.MultiSelect = false;
            this.LVOrderOverview.Name = "LVOrderOverview";
            this.LVOrderOverview.Size = new System.Drawing.Size(372, 362);
            this.LVOrderOverview.TabIndex = 0;
            this.LVOrderOverview.UseCompatibleStateImageBehavior = false;
            this.LVOrderOverview.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "no.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "price";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.pnlOrderOverview.PerformLayout();
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
        private Panel pnlOrderNav;
        private Panel pnlOrderHome;
        private ButtonStyle LunchNavButton;
        private ButtonStyle DrinksNavButton;
        private ButtonStyle DinnerNavButton;
        private LabelStyle labelStyle1;
        private ListView LVOrderOverview;
        private ColumnHeader ColumnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label4;
        private Label label3;
        private Label label2;
        private ButtonStyle buttonStyle1;
    }
}