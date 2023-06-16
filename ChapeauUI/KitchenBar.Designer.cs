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
            Blanklabel = new Label();
            label4 = new Label();
            label = new Label();
            PreparationBtn = new Button();
            PreaparedBtn = new Button();
            ServedBtn = new Button();
            label1 = new Label();
            listViewOrderId = new ListView();
            lblOrderStatusFirst = new Label();
            lblOS = new Label();
            KitchenPanel = new Panel();
            btnCompletedOrders = new Button();
            lblSelectedFirst = new Label();
            lblSelected = new Label();
            btnRunningOrders = new Button();
            panelRunningOrders = new Panel();
            btnOverviewFromRunning = new Button();
            ListViewRunningOrders = new ListView();
            panelCompletedOrders = new Panel();
            btnOverviewFromCompleted = new Button();
            listViewCompletedOrders = new ListView();
            panelLogin = new Panel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            labelpass = new Label();
            labelUser = new Label();
            label2 = new Label();
            KitchenPanel.SuspendLayout();
            panelRunningOrders.SuspendLayout();
            panelCompletedOrders.SuspendLayout();
            panelLogin.SuspendLayout();
            SuspendLayout();
            // 
            // MaraLabel
            // 
            MaraLabel.AutoSize = true;
            MaraLabel.BackColor = Color.Orange;
            MaraLabel.Location = new Point(1228, 65);
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
            KitchenLabel.Location = new Point(63, 113);
            KitchenLabel.Name = "KitchenLabel";
            KitchenLabel.Size = new Size(1217, 63);
            KitchenLabel.TabIndex = 1;
            KitchenLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Blanklabel
            // 
            Blanklabel.BackColor = SystemColors.ButtonHighlight;
            Blanklabel.BorderStyle = BorderStyle.FixedSingle;
            Blanklabel.Location = new Point(63, 176);
            Blanklabel.Name = "Blanklabel";
            Blanklabel.Size = new Size(1217, 70);
            Blanklabel.TabIndex = 2;
            // 
            // label4
            // 
            label4.BackColor = Color.Orange;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(743, 246);
            label4.Name = "label4";
            label4.Size = new Size(537, 34);
            label4.TabIndex = 7;
            label4.Text = "      Change Order Status";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label
            // 
            label.BackColor = SystemColors.ButtonHighlight;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Location = new Point(743, 280);
            label.Name = "label";
            label.Size = new Size(537, 55);
            label.TabIndex = 8;
            // 
            // PreparationBtn
            // 
            PreparationBtn.BackColor = SystemColors.ButtonHighlight;
            PreparationBtn.FlatStyle = FlatStyle.Popup;
            PreparationBtn.Location = new Point(765, 288);
            PreparationBtn.Name = "PreparationBtn";
            PreparationBtn.Size = new Size(141, 39);
            PreparationBtn.TabIndex = 10;
            PreparationBtn.Text = "in preparation";
            PreparationBtn.UseVisualStyleBackColor = false;
            PreparationBtn.Click += PreparationBtn_Click;
            // 
            // PreaparedBtn
            // 
            PreaparedBtn.BackColor = Color.Orange;
            PreaparedBtn.FlatStyle = FlatStyle.Popup;
            PreaparedBtn.Location = new Point(946, 288);
            PreaparedBtn.Name = "PreaparedBtn";
            PreaparedBtn.Size = new Size(127, 39);
            PreaparedBtn.TabIndex = 11;
            PreaparedBtn.Text = "Prepared";
            PreaparedBtn.UseVisualStyleBackColor = false;
            PreaparedBtn.Click += PreaparedBtn_Click;
            // 
            // ServedBtn
            // 
            ServedBtn.BackColor = Color.LimeGreen;
            ServedBtn.FlatStyle = FlatStyle.Popup;
            ServedBtn.Location = new Point(1129, 288);
            ServedBtn.Name = "ServedBtn";
            ServedBtn.Size = new Size(135, 39);
            ServedBtn.TabIndex = 12;
            ServedBtn.Text = "Served";
            ServedBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Orange;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(743, 335);
            label1.Name = "label1";
            label1.Size = new Size(537, 34);
            label1.TabIndex = 16;
            label1.Text = "      Change Order Status";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // listViewOrderId
            // 
            listViewOrderId.BorderStyle = BorderStyle.FixedSingle;
            listViewOrderId.FullRowSelect = true;
            listViewOrderId.GridLines = true;
            listViewOrderId.Location = new Point(63, 246);
            listViewOrderId.MultiSelect = false;
            listViewOrderId.Name = "listViewOrderId";
            listViewOrderId.OwnerDraw = true;
            listViewOrderId.Size = new Size(681, 195);
            listViewOrderId.TabIndex = 17;
            listViewOrderId.UseCompatibleStateImageBehavior = false;
            listViewOrderId.View = View.Details;
            listViewOrderId.DrawColumnHeader += lvorder;
            listViewOrderId.DrawSubItem += lvorder;
            listViewOrderId.SelectedIndexChanged += ViewSelectedOrderId;
            // 
            // lblOrderStatusFirst
            // 
            lblOrderStatusFirst.BackColor = SystemColors.ButtonHighlight;
            lblOrderStatusFirst.BorderStyle = BorderStyle.FixedSingle;
            lblOrderStatusFirst.Location = new Point(1004, 404);
            lblOrderStatusFirst.Name = "lblOrderStatusFirst";
            lblOrderStatusFirst.Size = new Size(276, 37);
            lblOrderStatusFirst.TabIndex = 18;
            lblOrderStatusFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOS
            // 
            lblOS.BackColor = SystemColors.ButtonHighlight;
            lblOS.BorderStyle = BorderStyle.FixedSingle;
            lblOS.Location = new Point(1004, 369);
            lblOS.Name = "lblOS";
            lblOS.Size = new Size(276, 35);
            lblOS.TabIndex = 19;
            lblOS.Text = "Order Status";
            lblOS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KitchenPanel
            // 
            KitchenPanel.Controls.Add(btnCompletedOrders);
            KitchenPanel.Controls.Add(lblSelectedFirst);
            KitchenPanel.Controls.Add(lblSelected);
            KitchenPanel.Controls.Add(btnRunningOrders);
            KitchenPanel.Controls.Add(lblOS);
            KitchenPanel.Controls.Add(lblOrderStatusFirst);
            KitchenPanel.Controls.Add(listViewOrderId);
            KitchenPanel.Controls.Add(label1);
            KitchenPanel.Controls.Add(ServedBtn);
            KitchenPanel.Controls.Add(PreaparedBtn);
            KitchenPanel.Controls.Add(PreparationBtn);
            KitchenPanel.Controls.Add(label);
            KitchenPanel.Controls.Add(label4);
            KitchenPanel.Controls.Add(Blanklabel);
            KitchenPanel.Controls.Add(KitchenLabel);
            KitchenPanel.Controls.Add(MaraLabel);
            KitchenPanel.Location = new Point(0, 0);
            KitchenPanel.Margin = new Padding(0);
            KitchenPanel.Name = "KitchenPanel";
            KitchenPanel.Size = new Size(1331, 670);
            KitchenPanel.TabIndex = 0;
            // 
            // btnCompletedOrders
            // 
            btnCompletedOrders.BackColor = Color.Orange;
            btnCompletedOrders.FlatStyle = FlatStyle.Popup;
            btnCompletedOrders.Location = new Point(743, 530);
            btnCompletedOrders.Name = "btnCompletedOrders";
            btnCompletedOrders.Size = new Size(443, 39);
            btnCompletedOrders.TabIndex = 24;
            btnCompletedOrders.Text = "Completed Orders";
            btnCompletedOrders.UseVisualStyleBackColor = false;
            btnCompletedOrders.Click += btnCompletedOrders_Click;
            // 
            // lblSelectedFirst
            // 
            lblSelectedFirst.BackColor = SystemColors.ButtonHighlight;
            lblSelectedFirst.BorderStyle = BorderStyle.FixedSingle;
            lblSelectedFirst.Location = new Point(743, 404);
            lblSelectedFirst.Name = "lblSelectedFirst";
            lblSelectedFirst.Size = new Size(265, 37);
            lblSelectedFirst.TabIndex = 23;
            lblSelectedFirst.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSelected
            // 
            lblSelected.BackColor = SystemColors.ButtonHighlight;
            lblSelected.BorderStyle = BorderStyle.FixedSingle;
            lblSelected.Location = new Point(743, 369);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(265, 35);
            lblSelected.TabIndex = 22;
            lblSelected.Text = "Selected order ID";
            lblSelected.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRunningOrders
            // 
            btnRunningOrders.BackColor = Color.Orange;
            btnRunningOrders.FlatStyle = FlatStyle.Popup;
            btnRunningOrders.Location = new Point(150, 530);
            btnRunningOrders.Name = "btnRunningOrders";
            btnRunningOrders.Size = new Size(443, 39);
            btnRunningOrders.TabIndex = 21;
            btnRunningOrders.Text = "Running Orders";
            btnRunningOrders.UseVisualStyleBackColor = false;
            btnRunningOrders.Click += btnRunningOrders_Click;
            // 
            // panelRunningOrders
            // 
            panelRunningOrders.Controls.Add(btnOverviewFromRunning);
            panelRunningOrders.Controls.Add(ListViewRunningOrders);
            panelRunningOrders.Location = new Point(0, 0);
            panelRunningOrders.Name = "panelRunningOrders";
            panelRunningOrders.Size = new Size(1310, 652);
            panelRunningOrders.TabIndex = 25;
            // 
            // btnOverviewFromRunning
            // 
            btnOverviewFromRunning.BackColor = Color.Orange;
            btnOverviewFromRunning.FlatStyle = FlatStyle.Popup;
            btnOverviewFromRunning.Location = new Point(433, 582);
            btnOverviewFromRunning.Name = "btnOverviewFromRunning";
            btnOverviewFromRunning.Size = new Size(443, 39);
            btnOverviewFromRunning.TabIndex = 26;
            btnOverviewFromRunning.Text = "Order Overview";
            btnOverviewFromRunning.UseVisualStyleBackColor = false;
            btnOverviewFromRunning.Click += btnOverviewFromRunning_Click;
            // 
            // ListViewRunningOrders
            // 
            ListViewRunningOrders.GridLines = true;
            ListViewRunningOrders.Location = new Point(50, 100);
            ListViewRunningOrders.Name = "ListViewRunningOrders";
            ListViewRunningOrders.Size = new Size(1151, 400);
            ListViewRunningOrders.TabIndex = 0;
            ListViewRunningOrders.UseCompatibleStateImageBehavior = false;
            ListViewRunningOrders.View = View.Details;
            // 
            // panelCompletedOrders
            // 
            panelCompletedOrders.Controls.Add(btnOverviewFromCompleted);
            panelCompletedOrders.Controls.Add(listViewCompletedOrders);
            panelCompletedOrders.Location = new Point(0, 0);
            panelCompletedOrders.Name = "panelCompletedOrders";
            panelCompletedOrders.Size = new Size(1333, 679);
            panelCompletedOrders.TabIndex = 1;
            // 
            // btnOverviewFromCompleted
            // 
            btnOverviewFromCompleted.BackColor = Color.Orange;
            btnOverviewFromCompleted.FlatStyle = FlatStyle.Popup;
            btnOverviewFromCompleted.Location = new Point(433, 582);
            btnOverviewFromCompleted.Name = "btnOverviewFromCompleted";
            btnOverviewFromCompleted.Size = new Size(443, 39);
            btnOverviewFromCompleted.TabIndex = 25;
            btnOverviewFromCompleted.Text = "Order Overview";
            btnOverviewFromCompleted.UseVisualStyleBackColor = false;
            btnOverviewFromCompleted.Click += btnOverviewFromCompleted_Click;
            // 
            // listViewCompletedOrders
            // 
            listViewCompletedOrders.GridLines = true;
            listViewCompletedOrders.Location = new Point(50, 100);
            listViewCompletedOrders.Name = "listViewCompletedOrders";
            listViewCompletedOrders.Size = new Size(1151, 400);
            listViewCompletedOrders.TabIndex = 0;
            listViewCompletedOrders.UseCompatibleStateImageBehavior = false;
            listViewCompletedOrders.View = View.Details;
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
            panelLogin.Size = new Size(1286, 623);
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
            btnLogin.Click += btnLogin_Click;
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
            labelUser.Text = "USERNAME: ";
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
            ClientSize = new Size(1345, 676);
            Controls.Add(panelLogin);
            Controls.Add(KitchenPanel);
            Controls.Add(panelCompletedOrders);
            Controls.Add(panelRunningOrders);
            Name = "KitchenBar";
            Text = "KitchenBar";
            KitchenPanel.ResumeLayout(false);
            KitchenPanel.PerformLayout();
            panelRunningOrders.ResumeLayout(false);
            panelCompletedOrders.ResumeLayout(false);
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label MaraLabel;
        private Label KitchenLabel;
        private Label Blanklabel;
        private Label label4;
        private Label label;
        private Button PreparationBtn;
        private Button PreaparedBtn;
        private Button ServedBtn;
        private Label label1;
        private ListView listViewOrderId;
        private Label lblOrderStatusFirst;
        private Label lblOS;
        private Panel KitchenPanel;
        private Button btnRunningOrders;
        private Label lblSelectedFirst;
        private Label lblSelected;
        private Button btnCompletedOrders;
        private Panel panelRunningOrders;
        private Panel panelCompletedOrders;
        private ListView listViewCompletedOrders;
        private ListView ListViewRunningOrders;
        private Button btnOverviewFromRunning;
        private Button btnOverviewFromCompleted;
        private Panel panelLogin;
        private Label labelUser;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label labelpass;
        private Label label2;
        private Button btnLogin;
    }
}
