namespace ReceiptManager
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
            EditButton = new Button();
            SuspendLayout();
            // 
            // ReceiptListView
            // 
            ReceiptListView.Location = new Point(3, 72);
            ReceiptListView.Margin = new Padding(3, 4, 3, 4);
            ReceiptListView.Name = "ReceiptListView";
            ReceiptListView.Size = new Size(1467, 639);
            ReceiptListView.TabIndex = 10;
            ReceiptListView.UseCompatibleStateImageBehavior = false;
            ReceiptListView.ColumnClick += ColumnClick;
            ReceiptListView.ItemActivate += ReceiptListView_ItemActivate;
            ReceiptListView.ItemSelectionChanged += ReceiptListView_ItemSelectionChanged;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(3, 16);
            DeleteButton.Margin = new Padding(3, 4, 3, 4);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(86, 31);
            DeleteButton.TabIndex = 11;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // EditButton
            // 
            EditButton.Enabled = false;
            EditButton.Location = new Point(95, 16);
            EditButton.Margin = new Padding(3, 4, 3, 4);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(86, 31);
            EditButton.TabIndex = 12;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // MainListView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(EditButton);
            Controls.Add(DeleteButton);
            Controls.Add(ReceiptListView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainListView";
            Size = new Size(1486, 800);
            ResumeLayout(false);
        }

        #endregion

        private ListView ReceiptListView;
        private Button DeleteButton;
        private Button EditButton;
    }
}
