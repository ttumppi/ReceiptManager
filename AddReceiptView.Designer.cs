namespace ReceiptManager
{
    partial class AddReceiptView
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
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            SelectImageButton = new Button();
            AddButton = new Button();
            CostInput = new TextBox();
            PurchaseDateInput = new TextBox();
            ExpirationDateInput = new TextBox();
            PurchaseNameInput = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SendImageWithAppButton = new Button();
            panel1 = new Panel();
            EditButton = new Button();
            panel3 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            BackButton = new Button();
            ClearImageButton = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 4);
            label6.Name = "label6";
            label6.Size = new Size(276, 15);
            label6.TabIndex = 32;
            label6.Text = "Optional : Set Image with mobile app or from files. ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 119);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 28;
            label2.Text = "Format : dd/mm/yyyy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(157, 63);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 27;
            label1.Text = "Format : dd/mm/yyyy";
            // 
            // SelectImageButton
            // 
            SelectImageButton.Location = new Point(64, 93);
            SelectImageButton.Name = "SelectImageButton";
            SelectImageButton.Size = new Size(195, 37);
            SelectImageButton.TabIndex = 26;
            SelectImageButton.Text = "Select image from files";
            SelectImageButton.UseVisualStyleBackColor = true;
            SelectImageButton.Click += SelectImageButton_Click;
            // 
            // AddButton
            // 
            AddButton.Enabled = false;
            AddButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            AddButton.Location = new Point(438, 261);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(168, 42);
            AddButton.TabIndex = 25;
            AddButton.Text = "Finish";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Visible = false;
            AddButton.Click += AddButton_Click;
            // 
            // CostInput
            // 
            CostInput.Location = new Point(132, 178);
            CostInput.Name = "CostInput";
            CostInput.Size = new Size(187, 23);
            CostInput.TabIndex = 24;
            // 
            // PurchaseDateInput
            // 
            PurchaseDateInput.Location = new Point(132, 144);
            PurchaseDateInput.Name = "PurchaseDateInput";
            PurchaseDateInput.Size = new Size(187, 23);
            PurchaseDateInput.TabIndex = 23;
            // 
            // ExpirationDateInput
            // 
            ExpirationDateInput.Location = new Point(132, 88);
            ExpirationDateInput.Name = "ExpirationDateInput";
            ExpirationDateInput.Size = new Size(187, 23);
            ExpirationDateInput.TabIndex = 22;
            // 
            // PurchaseNameInput
            // 
            PurchaseNameInput.Location = new Point(132, 33);
            PurchaseNameInput.Name = "PurchaseNameInput";
            PurchaseNameInput.Size = new Size(187, 23);
            PurchaseNameInput.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(60, 178);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(43, 23);
            textBox4.TabIndex = 20;
            textBox4.Text = "Cost";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 144);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(97, 23);
            textBox3.TabIndex = 19;
            textBox3.Text = "Purchase Date";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 88);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(97, 23);
            textBox2.TabIndex = 18;
            textBox2.Text = "Expiration Date";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(9, 33);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(94, 23);
            textBox1.TabIndex = 17;
            textBox1.Text = "Purchase name";
            // 
            // SendImageWithAppButton
            // 
            SendImageWithAppButton.Location = new Point(64, 42);
            SendImageWithAppButton.Name = "SendImageWithAppButton";
            SendImageWithAppButton.Size = new Size(195, 37);
            SendImageWithAppButton.TabIndex = 33;
            SendImageWithAppButton.Text = "Send Image with app";
            SendImageWithAppButton.UseVisualStyleBackColor = true;
            SendImageWithAppButton.Click += SendImageWithAppButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(EditButton);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(AddButton);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(181, 42);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 367);
            panel1.TabIndex = 34;
            // 
            // EditButton
            // 
            EditButton.Enabled = false;
            EditButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            EditButton.Location = new Point(612, 261);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(168, 42);
            EditButton.TabIndex = 37;
            EditButton.Text = "Finish";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Visible = false;
            EditButton.Click += EditButton_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(ExpirationDateInput);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(PurchaseDateInput);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(CostInput);
            panel3.Controls.Add(PurchaseNameInput);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(26, 18);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(356, 228);
            panel3.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, -1);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 35;
            label3.Text = "Receipt Information";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ClearImageButton);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(SendImageWithAppButton);
            panel2.Controls.Add(SelectImageButton);
            panel2.Location = new Point(439, 18);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(341, 193);
            panel2.TabIndex = 36;
            // 
            // BackButton
            // 
            BackButton.Enabled = false;
            BackButton.Location = new Point(0, 2);
            BackButton.Margin = new Padding(3, 2, 3, 2);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(78, 29);
            BackButton.TabIndex = 35;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Visible = false;
            BackButton.Click += BackButton_Click;
            // 
            // ClearImageButton
            // 
            ClearImageButton.Location = new Point(64, 136);
            ClearImageButton.Name = "ClearImageButton";
            ClearImageButton.Size = new Size(195, 37);
            ClearImageButton.TabIndex = 34;
            ClearImageButton.Text = "Clear Image";
            ClearImageButton.UseVisualStyleBackColor = true;
            ClearImageButton.Click += ClearImageButton_Click;
            // 
            // AddReceiptView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BackButton);
            Controls.Add(panel1);
            Name = "AddReceiptView";
            Size = new Size(1328, 602);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Label label2;
        private Label label1;
        private Button SelectImageButton;
        private Button AddButton;
        private TextBox CostInput;
        private TextBox PurchaseDateInput;
        private TextBox ExpirationDateInput;
        private TextBox PurchaseNameInput;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button SendImageWithAppButton;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Button BackButton;
        private Button EditButton;
        private Button ClearImageButton;
    }
}
