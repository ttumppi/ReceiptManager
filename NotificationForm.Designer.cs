namespace ReceiptManager
{
    partial class NotificationForm
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
            NotificationText = new Label();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // NotificationText
            // 
            NotificationText.AutoSize = true;
            NotificationText.Location = new Point(142, 100);
            NotificationText.Name = "NotificationText";
            NotificationText.Size = new Size(91, 15);
            NotificationText.TabIndex = 0;
            NotificationText.Text = "NotificationText";
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(142, 177);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(75, 23);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 231);
            Controls.Add(CancelButton);
            Controls.Add(NotificationText);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NotificationForm";
            Text = "Notification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NotificationText;
        private Button CancelButton;
    }
}