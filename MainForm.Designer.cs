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
            ViewImageButton.Location = new Point(311, 1);
            ViewImageButton.Margin = new Padding(3, 4, 3, 4);
            ViewImageButton.Name = "ViewImageButton";
            ViewImageButton.Size = new Size(104, 47);
            ViewImageButton.TabIndex = 20;
            ViewImageButton.Text = "View Image";
            ViewImageButton.UseVisualStyleBackColor = true;
            ViewImageButton.Click += ViewImageButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1499, 751);
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
        }

        #endregion
        private Button ReceiptsTabButton;
        private Button AddReceiptTabButton;
        private Button ViewLogTabButton;
        private Button ViewImageButton;
    }
}