using System.Diagnostics;
namespace Kuittisovellus
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
            ViewImageButton = new Button();
            IPLabel = new Label();
            button1 = new Button();
            ForStyling = new Label();
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
            // ViewImageButton
            // 
            ViewImageButton.Location = new Point(311, 0);
            ViewImageButton.Margin = new Padding(3, 4, 3, 4);
            ViewImageButton.Name = "ViewImageButton";
            ViewImageButton.Size = new Size(104, 47);
            ViewImageButton.TabIndex = 20;
            ViewImageButton.Text = "View Image";
            ViewImageButton.UseVisualStyleBackColor = true;
            ViewImageButton.Click += ViewImageButton_Click;
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Location = new Point(1301, 14);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(70, 20);
            IPLabel.TabIndex = 21;
            IPLabel.Text = "Device IP";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1101, 0);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(104, 47);
            button1.TabIndex = 22;
            button1.Text = "Search For Phone App";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ForStyling
            // 
            ForStyling.BorderStyle = BorderStyle.FixedSingle;
            ForStyling.Location = new Point(0, 46);
            ForStyling.Name = "ForStyling";
            ForStyling.Size = new Size(1499, 1);
            ForStyling.TabIndex = 23;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 751);
            Controls.Add(ForStyling);
            Controls.Add(button1);
            Controls.Add(IPLabel);
            Controls.Add(ViewImageButton);
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
        private Button ViewImageButton;
        private Label IPLabel;
        private Button button1;
        private Label ForStyling;
    }
}