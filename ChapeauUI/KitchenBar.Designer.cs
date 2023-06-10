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
            label1 = new Label();
            listViewKitchen = new ListView();
            ServedBtn = new Button();
            PreaparedBtn = new Button();
            PreparationBtn = new Button();
            label = new Label();
            label4 = new Label();
            Blanklabel = new Label();
            KitchenLabel = new Label();
            MaraLabel = new Label();
            KitchenPanel.SuspendLayout();
            SuspendLayout();
            // 
            // KitchenPanel
            // 
            KitchenPanel.Controls.Add(label1);
            KitchenPanel.Controls.Add(listViewKitchen);
            KitchenPanel.Controls.Add(ServedBtn);
            KitchenPanel.Controls.Add(PreaparedBtn);
            KitchenPanel.Controls.Add(PreparationBtn);
            KitchenPanel.Controls.Add(label);
            KitchenPanel.Controls.Add(label4);
            KitchenPanel.Controls.Add(Blanklabel);
            KitchenPanel.Controls.Add(KitchenLabel);
            KitchenPanel.Controls.Add(MaraLabel);
            KitchenPanel.Location = new Point(5, 3);
            KitchenPanel.Name = "KitchenPanel";
            KitchenPanel.Size = new Size(1182, 670);
            KitchenPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.Orange;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(623, 335);
            label1.Name = "label1";
            label1.Size = new Size(472, 34);
            label1.TabIndex = 16;
            label1.Text = "      Change Order Status";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // listViewKitchen
            // 
            listViewKitchen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            listViewKitchen.FullRowSelect = true;
            listViewKitchen.GridLines = true;
            listViewKitchen.LabelEdit = true;
            listViewKitchen.Location = new Point(63, 246);
            listViewKitchen.Margin = new Padding(6);
            listViewKitchen.Name = "listViewKitchen";
            listViewKitchen.OwnerDraw = true;
            listViewKitchen.Size = new Size(560, 316);
            listViewKitchen.TabIndex = 15;
            listViewKitchen.TileSize = new Size(2, 2);
            listViewKitchen.UseCompatibleStateImageBehavior = false;
            listViewKitchen.View = View.Details;
            listViewKitchen.DrawColumnHeader += listView_DrawColumnHeader;
            // 
            // ServedBtn
            // 
            ServedBtn.BackColor = Color.LimeGreen;
            ServedBtn.FlatStyle = FlatStyle.Popup;
            ServedBtn.Location = new Point(953, 284);
            ServedBtn.Name = "ServedBtn";
            ServedBtn.Size = new Size(112, 34);
            ServedBtn.TabIndex = 12;
            ServedBtn.Text = "Served";
            ServedBtn.UseVisualStyleBackColor = false;
            // 
            // PreaparedBtn
            // 
            PreaparedBtn.BackColor = Color.Orange;
            PreaparedBtn.FlatStyle = FlatStyle.Popup;
            PreaparedBtn.Location = new Point(804, 284);
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
            PreparationBtn.Location = new Point(632, 284);
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
            label.Location = new Point(613, 280);
            label.Name = "label";
            label.Size = new Size(482, 55);
            label.TabIndex = 8;
            // 
            // label4
            // 
            label4.BackColor = Color.Orange;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(613, 246);
            label4.Name = "label4";
            label4.Size = new Size(482, 34);
            label4.TabIndex = 7;
            label4.Text = "      Change Order Status";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // Blanklabel
            // 
            Blanklabel.BackColor = SystemColors.ButtonHighlight;
            Blanklabel.BorderStyle = BorderStyle.FixedSingle;
            Blanklabel.Location = new Point(63, 176);
            Blanklabel.Name = "Blanklabel";
            Blanklabel.Size = new Size(1032, 70);
            Blanklabel.TabIndex = 2;
            // 
            // KitchenLabel
            // 
            KitchenLabel.BackColor = Color.Orange;
            KitchenLabel.BorderStyle = BorderStyle.FixedSingle;
            KitchenLabel.Font = new Font("Cambria", 16F, FontStyle.Bold, GraphicsUnit.Point);
            KitchenLabel.Location = new Point(63, 113);
            KitchenLabel.Name = "KitchenLabel";
            KitchenLabel.Size = new Size(1032, 63);
            KitchenLabel.TabIndex = 1;
            KitchenLabel.Text = "Kitchen Orders";
            KitchenLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MaraLabel
            // 
            MaraLabel.AutoSize = true;
            MaraLabel.BackColor = Color.Orange;
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
        private Label Blanklabel;
        private Label KitchenLabel;
        private Label MaraLabel;
        private Label label4;
        private Button ServedBtn;
        private Button PreaparedBtn;
        private Button PreparationBtn;
        private Label label;
        private ListView listViewKitchen;
        private Label label1;
    }
}
