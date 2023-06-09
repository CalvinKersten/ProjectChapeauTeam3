namespace ChapeauUI
{
    partial class KitchenBar
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
            DashboardPanel = new Panel();
            SuspendLayout();
            // 
            // DashboardPanel
            // 
            DashboardPanel.Location = new Point(12, 12);
            DashboardPanel.Name = "DashboardPanel";
            DashboardPanel.Size = new Size(1230, 765);
            DashboardPanel.TabIndex = 0;
            // 
            // KitchenBar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 789);
            Controls.Add(DashboardPanel);
            Name = "KitchenBar";
            Text = "KitchenBar";
            ResumeLayout(false);
        }

        #endregion

        private Panel DashboardPanel;
    }
}