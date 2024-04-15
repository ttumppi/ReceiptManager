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
            SuspendLayout();
            // 
            // NotificationText
            // 
            NotificationText.AutoSize = true;
            NotificationText.Location = new Point(162, 134);
            NotificationText.Name = "NotificationText";
            NotificationText.Size = new Size(115, 20);
            NotificationText.TabIndex = 0;
            NotificationText.Text = "NotificationText";
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 308);
            Controls.Add(NotificationText);
            Name = "NotificationForm";
            Text = "Notification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NotificationText;
    }
}