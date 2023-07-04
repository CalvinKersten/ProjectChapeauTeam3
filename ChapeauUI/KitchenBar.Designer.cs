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
            MaraLabel = new Label();
            KitchenLabel = new Label();
            lblOrderStatus = new Label();
            label4 = new Label();
            label = new Label();
            PreaparedBtn = new Button();
            listViewOrder = new ListView();
            KitchenPanel = new Panel();
            btnOrderOverview = new Button();
            btnPreparing = new Button();
            btnRefresh = new Button();
            btnRunningOrders = new Button();
            btnCompletedOrders = new Button();
            panelLogin = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            labelpass = new Label();
            labelUser = new Label();
            label2 = new Label();
            KitchenPanel.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // MaraLabel
            // 
            MaraLabel.AutoSize = true;
            MaraLabel.BackColor = Color.Orange;
            MaraLabel.Location = new Point(1228, 39);
            MaraLabel.Name = "MaraLabel";
            MaraLabel.Size = new Size(52, 25);
            MaraLabel.TabIndex = 0;
            MaraLabel.Text = "Mara";
            // 
            // KitchenLabel
            // 
            KitchenLabel.BackColor = Color.Orange;
            KitchenLabel.BorderStyle = BorderStyle.FixedSingle;
            KitchenLabel.Font = new Font("Cambria", 16F, FontStyle.Bold, GraphicsUnit.Point);
            KitchenLabel.Location = new Point(63, 90);
            KitchenLabel.Name = "KitchenLabel";
            KitchenLabel.Size = new Size(1217, 63);
            KitchenLabel.TabIndex = 1;
            KitchenLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.BackColor = SystemColors.ButtonHighlight;
            lblOrderStatus.BorderStyle = BorderStyle.FixedSingle;
            lblOrderStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrderStatus.Location = new Point(63, 153);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(1217, 68);
            lblOrderStatus.TabIndex = 2;
            lblOrderStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Orange;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(1064, 217);
            label4.Name = "label4";
            label4.Size = new Size(216, 98);
            label4.TabIndex = 7;
            label4.Text = "      Change Order Status";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label
            // 
            label.BackColor = SystemColors.ButtonHighlight;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Location = new Point(1064, 315);
            label.Name = "label";
            label.Size = new Size(216, 217);
            label.TabIndex = 8;
            // 
            // PreaparedBtn
            // 
            PreaparedBtn.BackColor = Color.Orange;
            PreaparedBtn.FlatStyle = FlatStyle.Popup;
            PreaparedBtn.Location = new Point(1116, 347);
            PreaparedBtn.Name = "PreaparedBtn";
            PreaparedBtn.Size = new Size(127, 39);
            PreaparedBtn.TabIndex = 11;
            PreaparedBtn.Text = "Completed";
            PreaparedBtn.UseVisualStyleBackColor = false;
            PreaparedBtn.Click += PreaparedBtn_Click;
            // 
            // listViewOrder
            // 
            listViewOrder.BorderStyle = BorderStyle.FixedSingle;
            listViewOrder.FullRowSelect = true;
            listViewOrder.GridLines = true;
            listViewOrder.Location = new Point(63, 217);
            listViewOrder.Name = "listViewOrder";
            listViewOrder.OwnerDraw = true;
            listViewOrder.Size = new Size(1015, 373);
            listViewOrder.TabIndex = 17;
            listViewOrder.UseCompatibleStateImageBehavior = false;
            listViewOrder.View = View.Details;
            listViewOrder.DrawColumnHeader += lvorder;
            listViewOrder.DrawSubItem += lvorder;
            // 
            // KitchenPanel
            // 
            KitchenPanel.Controls.Add(btnOrderOverview);
            KitchenPanel.Controls.Add(btnPreparing);
            KitchenPanel.Controls.Add(btnRefresh);
            KitchenPanel.Controls.Add(btnRunningOrders);
            KitchenPanel.Controls.Add(btnCompletedOrders);
            KitchenPanel.Controls.Add(listViewOrder);
            KitchenPanel.Controls.Add(PreaparedBtn);
            KitchenPanel.Controls.Add(label4);
            KitchenPanel.Controls.Add(label);
            KitchenPanel.Controls.Add(lblOrderStatus);
            KitchenPanel.Controls.Add(KitchenLabel);
            KitchenPanel.Controls.Add(MaraLabel);
            KitchenPanel.Location = new Point(0, 0);
            KitchenPanel.Margin = new Padding(0);
            KitchenPanel.Name = "KitchenPanel";
            KitchenPanel.Size = new Size(1342, 670);
            KitchenPanel.TabIndex = 0;
            // 
            // btnOrderOverview
            // 
            btnOrderOverview.BackColor = Color.Orange;
            btnOrderOverview.FlatStyle = FlatStyle.Popup;
            btnOrderOverview.Location = new Point(135, 607);
            btnOrderOverview.Name = "btnOrderOverview";
            btnOrderOverview.Size = new Size(394, 39);
            btnOrderOverview.TabIndex = 30;
            btnOrderOverview.Text = "Order Overview";
            btnOrderOverview.UseVisualStyleBackColor = false;
            btnOrderOverview.Click += btnOrderOverview_Click;
            // 
            // btnPreparing
            // 
            btnPreparing.BackColor = Color.Orange;
            btnPreparing.FlatStyle = FlatStyle.Popup;
            btnPreparing.Location = new Point(1116, 440);
            btnPreparing.Name = "btnPreparing";
            btnPreparing.Size = new Size(127, 39);
            btnPreparing.TabIndex = 29;
            btnPreparing.Text = "Preparing";
            btnPreparing.UseVisualStyleBackColor = false;
            btnPreparing.Click += btnPreparing_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Location = new Point(1078, 529);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(202, 61);
            btnRefresh.TabIndex = 28;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRunningOrders
            // 
            btnRunningOrders.BackColor = Color.Orange;
            btnRunningOrders.FlatStyle = FlatStyle.Popup;
            btnRunningOrders.Location = new Point(660, 607);
            btnRunningOrders.Name = "btnRunningOrders";
            btnRunningOrders.Size = new Size(394, 39);
            btnRunningOrders.TabIndex = 27;
            btnRunningOrders.Text = "Running Orders";
            btnRunningOrders.UseVisualStyleBackColor = false;
            btnRunningOrders.Click += btnRunningOrders_Click;
            // 
            // btnCompletedOrders
            // 
            btnCompletedOrders.BackColor = Color.Orange;
            btnCompletedOrders.FlatStyle = FlatStyle.Popup;
            btnCompletedOrders.Location = new Point(660, 607);
            btnCompletedOrders.Name = "btnCompletedOrders";
            btnCompletedOrders.Size = new Size(394, 39);
            btnCompletedOrders.TabIndex = 24;
            btnCompletedOrders.Text = "Completed Orders";
            btnCompletedOrders.UseVisualStyleBackColor = false;
            btnCompletedOrders.Click += btnCompletedOrders_Click;
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(txtPassword);
            panelLogin.Controls.Add(txtUsername);
            panelLogin.Controls.Add(labelpass);
            panelLogin.Controls.Add(labelUser);
            panelLogin.Controls.Add(label2);
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(1286, 670);
            panelLogin.TabIndex = 25;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.MediumSeaGreen;
            btnLogin.Location = new Point(498, 421);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LogIn";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(582, 331);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(210, 31);
            txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(582, 271);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(210, 31);
            txtUsername.TabIndex = 3;
            // 
            // labelpass
            // 
            labelpass.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelpass.Location = new Point(363, 330);
            labelpass.Name = "labelpass";
            labelpass.Size = new Size(146, 38);
            labelpass.TabIndex = 1;
            labelpass.Text = "PASSWORD:";
            // 
            // labelUser
            // 
            labelUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            labelUser.Location = new Point(363, 271);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(146, 38);
            labelUser.TabIndex = 0;
            labelUser.Text = "USER ID:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(247, 121);
            label2.Name = "label2";
            label2.Size = new Size(740, 452);
            label2.TabIndex = 2;
            // 
            // KitchenBar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 676);
            Controls.Add(panelLogin);
            Controls.Add(KitchenPanel);
            Name = "KitchenBar";
            Text = "KitchenBar";
            KitchenPanel.ResumeLayout(false);
            KitchenPanel.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label MaraLabel;
        private Label KitchenLabel;
        private Label lblOrderStatus;
        private Label label4;
        private Label label;
        private Button PreaparedBtn;
        private ListView listViewOrder;
        private Panel KitchenPanel;
        private Button btnCompletedOrders;
        private Panel panelLogin;
        private Label labelUser;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label labelpass;
        private Label label2;
        private Button btnLogin;
        private Button btnRunningOrders;
        private Button btnRefresh;
        private Button btnPreparing;
        private Button btnOrderOverview;
    }
}
