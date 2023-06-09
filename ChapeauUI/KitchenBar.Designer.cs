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
            KitchenPanel = new Panel();
            listViewOrder = new ListView();
            ServedBtn = new Button();
            PreaparedBtn = new Button();
            PreparationBtn = new Button();
            label = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            OrderIdlabel = new Label();
            Blanklabel = new Label();
            KitchenLabel = new Label();
            MaraLabel = new Label();
            KitchenPanel.SuspendLayout();
            SuspendLayout();
            // 
            // KitchenPanel
            // 
            KitchenPanel.Controls.Add(listViewOrder);
            KitchenPanel.Controls.Add(ServedBtn);
            KitchenPanel.Controls.Add(PreaparedBtn);
            KitchenPanel.Controls.Add(PreparationBtn);
            KitchenPanel.Controls.Add(label);
            KitchenPanel.Controls.Add(label4);
            KitchenPanel.Controls.Add(label3);
            KitchenPanel.Controls.Add(label2);
            KitchenPanel.Controls.Add(label1);
            KitchenPanel.Controls.Add(OrderIdlabel);
            KitchenPanel.Controls.Add(Blanklabel);
            KitchenPanel.Controls.Add(KitchenLabel);
            KitchenPanel.Controls.Add(MaraLabel);
            KitchenPanel.Location = new Point(5, 3);
            KitchenPanel.Name = "KitchenPanel";
            KitchenPanel.Size = new Size(1182, 670);
            KitchenPanel.TabIndex = 0;
            // 
            // listViewOrder
            // 
            listViewOrder.Location = new Point(83, 297);
            listViewOrder.Name = "listViewOrder";
            listViewOrder.Size = new Size(531, 217);
            listViewOrder.TabIndex = 13;
            listViewOrder.UseCompatibleStateImageBehavior = false;
            listViewOrder.View = View.Details;
            // 
            // ServedBtn
            // 
            ServedBtn.BackColor = Color.LimeGreen;
            ServedBtn.FlatStyle = FlatStyle.Popup;
            ServedBtn.Location = new Point(953, 301);
            ServedBtn.Name = "ServedBtn";
            ServedBtn.Size = new Size(112, 34);
            ServedBtn.TabIndex = 12;
            ServedBtn.Text = "Served";
            ServedBtn.UseVisualStyleBackColor = false;
            // 
            // PreaparedBtn
            // 
            PreaparedBtn.BackColor = Color.SandyBrown;
            PreaparedBtn.FlatStyle = FlatStyle.Popup;
            PreaparedBtn.Location = new Point(816, 301);
            PreaparedBtn.Name = "PreaparedBtn";
            PreaparedBtn.Size = new Size(112, 34);
            PreaparedBtn.TabIndex = 11;
            PreaparedBtn.Text = "Prepared";
            PreaparedBtn.UseVisualStyleBackColor = false;
            // 
            // PreparationBtn
            // 
            PreparationBtn.BackColor = SystemColors.ButtonHighlight;
            PreparationBtn.FlatStyle = FlatStyle.Popup;
            PreparationBtn.Location = new Point(633, 300);
            PreparationBtn.Name = "PreparationBtn";
            PreparationBtn.Size = new Size(141, 35);
            PreparationBtn.TabIndex = 10;
            PreparationBtn.Text = "in preparation";
            PreparationBtn.UseVisualStyleBackColor = false;
            // 
            // label
            // 
            label.BackColor = SystemColors.ButtonHighlight;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Location = new Point(613, 297);
            label.Name = "label";
            label.Size = new Size(482, 51);
            label.TabIndex = 8;
            // 
            // label4
            // 
            label4.BackColor = Color.SandyBrown;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(613, 246);
            label4.Name = "label4";
            label4.Size = new Size(482, 51);
            label4.TabIndex = 7;
            label4.Text = "      Change Order Status";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.SandyBrown;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.ImageAlign = ContentAlignment.TopLeft;
            label3.Location = new Point(464, 246);
            label3.Name = "label3";
            label3.Size = new Size(150, 51);
            label3.TabIndex = 6;
            label3.Text = "      Description";
            // 
            // label2
            // 
            label2.BackColor = Color.SandyBrown;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.ImageAlign = ContentAlignment.TopLeft;
            label2.Location = new Point(346, 246);
            label2.Name = "label2";
            label2.Size = new Size(125, 51);
            label2.TabIndex = 5;
            label2.Text = "      Count";
            // 
            // label1
            // 
            label1.BackColor = Color.SandyBrown;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(193, 246);
            label1.Name = "label1";
            label1.Size = new Size(156, 51);
            label1.TabIndex = 4;
            label1.Text = "    Order number";
            // 
            // OrderIdlabel
            // 
            OrderIdlabel.BackColor = Color.SandyBrown;
            OrderIdlabel.BorderStyle = BorderStyle.FixedSingle;
            OrderIdlabel.ImageAlign = ContentAlignment.TopLeft;
            OrderIdlabel.Location = new Point(83, 246);
            OrderIdlabel.Name = "OrderIdlabel";
            OrderIdlabel.Size = new Size(113, 51);
            OrderIdlabel.TabIndex = 3;
            OrderIdlabel.Text = "    Order Id";
            // 
            // Blanklabel
            // 
            Blanklabel.BackColor = SystemColors.ButtonHighlight;
            Blanklabel.BorderStyle = BorderStyle.FixedSingle;
            Blanklabel.Location = new Point(83, 176);
            Blanklabel.Name = "Blanklabel";
            Blanklabel.Size = new Size(1012, 70);
            Blanklabel.TabIndex = 2;
            // 
            // KitchenLabel
            // 
            KitchenLabel.BackColor = Color.SandyBrown;
            KitchenLabel.BorderStyle = BorderStyle.FixedSingle;
            KitchenLabel.Font = new Font("Cambria", 16F, FontStyle.Bold, GraphicsUnit.Point);
            KitchenLabel.Location = new Point(83, 113);
            KitchenLabel.Name = "KitchenLabel";
            KitchenLabel.Size = new Size(1012, 63);
            KitchenLabel.TabIndex = 1;
            KitchenLabel.Text = "Kitchen Orders";
            KitchenLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MaraLabel
            // 
            MaraLabel.AutoSize = true;
            MaraLabel.BackColor = Color.SandyBrown;
            MaraLabel.Location = new Point(1043, 68);
            MaraLabel.Name = "MaraLabel";
            MaraLabel.Size = new Size(52, 25);
            MaraLabel.TabIndex = 0;
            MaraLabel.Text = "Mara";
            // 
            // KitchenBar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 676);
            Controls.Add(KitchenPanel);
            Name = "KitchenBar";
            Text = "KitchenBar";
            KitchenPanel.ResumeLayout(false);
            KitchenPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel KitchenPanel;
        private Label OrderIdlabel;
        private Label Blanklabel;
        private Label KitchenLabel;
        private Label MaraLabel;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button ServedBtn;
        private Button PreaparedBtn;
        private Button PreparationBtn;
        private Label label;
        private ListView listViewOrder;
    }
}
