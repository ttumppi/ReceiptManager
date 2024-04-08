namespace Kuittisovellus
{
    partial class MainListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ReceiptListView = new ListView();
            DeleteButton = new Button();
            SuspendLayout();
            // 
            // ReceiptListView
            // 
            ReceiptListView.Location = new Point(3, 54);
            ReceiptListView.Name = "ReceiptListView";
            ReceiptListView.Size = new Size(1284, 480);
            ReceiptListView.TabIndex = 10;
            ReceiptListView.UseCompatibleStateImageBehavior = false;
            ReceiptListView.ColumnClick += ColumnClick;
            ReceiptListView.ItemActivate += ReceiptListView_ItemActivate;
            ReceiptListView.ItemSelectionChanged += ReceiptListView_ItemSelectionChanged;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(3, 12);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // MainListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DeleteButton);
            Controls.Add(ReceiptListView);
            Name = "MainListView";
            Size = new Size(1300, 600);
            ResumeLayout(false);
        }

        #endregion

        private ListView ReceiptListView;
        private Button DeleteButton;
    }
}
