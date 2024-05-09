using System.Diagnostics;
namespace ReceiptManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ReceiptsTabButton = new Button();
            AddReceiptTabButton = new Button();
            ViewLogTabButton = new Button();
            IPLabel = new Label();
            SearchForPhoneAppButton = new Button();
            ForStyling = new Label();
            ConnectionText = new Label();
            ConnectionStateLabel = new Label();
            SuspendLayout();
            // 
            // ReceiptsTabButton
            // 
            ReceiptsTabButton.Location = new Point(0, 0);
            ReceiptsTabButton.Margin = new Padding(3, 4, 3, 4);
            ReceiptsTabButton.Name = "ReceiptsTabButton";
            ReceiptsTabButton.Size = new Size(104, 47);
            ReceiptsTabButton.TabIndex = 17;
            ReceiptsTabButton.Text = "Receipts";
            ReceiptsTabButton.UseVisualStyleBackColor = true;
            ReceiptsTabButton.Click += ReceiptsTabButton_Click;
            // 
            // AddReceiptTabButton
            // 
            AddReceiptTabButton.Location = new Point(103, 0);
            AddReceiptTabButton.Margin = new Padding(3, 4, 3, 4);
            AddReceiptTabButton.Name = "AddReceiptTabButton";
            AddReceiptTabButton.Size = new Size(104, 47);
            AddReceiptTabButton.TabIndex = 18;
            AddReceiptTabButton.Text = "Add";
            AddReceiptTabButton.UseVisualStyleBackColor = true;
            AddReceiptTabButton.Click += AddReceiptTabButton_Click;
            // 
            // ViewLogTabButton
            // 
            ViewLogTabButton.Location = new Point(207, 0);
            ViewLogTabButton.Margin = new Padding(3, 4, 3, 4);
            ViewLogTabButton.Name = "ViewLogTabButton";
            ViewLogTabButton.Size = new Size(104, 47);
            ViewLogTabButton.TabIndex = 19;
            ViewLogTabButton.Text = "Log";
            ViewLogTabButton.UseVisualStyleBackColor = true;
            ViewLogTabButton.Click += ViewLogTabButton_Click;
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            IPLabel.Location = new Point(1293, 4);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(60, 17);
            IPLabel.TabIndex = 21;
            IPLabel.Text = "Device IP";
            // 
            // SearchForPhoneAppButton
            // 
            SearchForPhoneAppButton.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            SearchForPhoneAppButton.Location = new Point(1101, 0);
            SearchForPhoneAppButton.Margin = new Padding(3, 4, 3, 4);
            SearchForPhoneAppButton.Name = "SearchForPhoneAppButton";
            SearchForPhoneAppButton.Size = new Size(104, 47);
            SearchForPhoneAppButton.TabIndex = 22;
            SearchForPhoneAppButton.Text = "Search For Phone App";
            SearchForPhoneAppButton.UseVisualStyleBackColor = true;
            SearchForPhoneAppButton.Click += SearchForPhoneAppButton_Click;
            // 
            // ForStyling
            // 
            ForStyling.BorderStyle = BorderStyle.FixedSingle;
            ForStyling.Location = new Point(0, 46);
            ForStyling.Name = "ForStyling";
            ForStyling.Size = new Size(1499, 1);
            ForStyling.TabIndex = 23;
            // 
            // ConnectionText
            // 
            ConnectionText.AutoSize = true;
            ConnectionText.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            ConnectionText.Location = new Point(1293, 25);
            ConnectionText.Name = "ConnectionText";
            ConnectionText.Size = new Size(113, 17);
            ConnectionText.TabIndex = 24;
            ConnectionText.Text = "Connection State :";
            // 
            // ConnectionStateLabel
            // 
            ConnectionStateLabel.AutoSize = true;
            ConnectionStateLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            ConnectionStateLabel.Location = new Point(1412, 25);
            ConnectionStateLabel.Name = "ConnectionStateLabel";
            ConnectionStateLabel.Size = new Size(35, 17);
            ConnectionStateLabel.TabIndex = 25;
            ConnectionStateLabel.Text = "false";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 751);
            Controls.Add(ConnectionStateLabel);
            Controls.Add(ConnectionText);
            Controls.Add(ForStyling);
            Controls.Add(SearchForPhoneAppButton);
            Controls.Add(IPLabel);
            Controls.Add(ViewLogTabButton);
            Controls.Add(AddReceiptTabButton);
            Controls.Add(ReceiptsTabButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ReceiptsTabButton;
        private Button AddReceiptTabButton;
        private Button ViewLogTabButton;
        private Label IPLabel;
        private Button SearchForPhoneAppButton;
        private Label ForStyling;
        private Label ConnectionText;
        private Label ConnectionStateLabel;
    }
}