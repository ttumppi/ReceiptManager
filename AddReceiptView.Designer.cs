namespace Kuittisovellus
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SelectImageButton = new Button();
            AddButton = new Button();
            Cost_input = new TextBox();
            Date_input = new TextBox();
            Expiration_date_input = new TextBox();
            Purchase_input = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            SendImageWithAppButton = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(626, 416);
            label6.Name = "label6";
            label6.Size = new Size(350, 20);
            label6.TabIndex = 32;
            label6.Text = "Optional : Set Image with mobile app or from files. ";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(363, 561);
            label5.Name = "label5";
            label5.Size = new Size(834, 13);
            label5.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(738, 84);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 30;
            label4.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(738, 347);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 29;
            label3.Text = "XXXXX€";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 265);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 28;
            label2.Text = "XX/XX/XXXX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 179);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 27;
            label1.Text = "XX/XX/XXXX";
            // 
            // SelectImageButton
            // 
            SelectImageButton.Location = new Point(874, 456);
            SelectImageButton.Margin = new Padding(3, 4, 3, 4);
            SelectImageButton.Name = "SelectImageButton";
            SelectImageButton.Size = new Size(223, 49);
            SelectImageButton.TabIndex = 26;
            SelectImageButton.Text = "Select image from files";
            SelectImageButton.UseVisualStyleBackColor = true;
            SelectImageButton.Click += SelectImageButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(637, 592);
            AddButton.Margin = new Padding(3, 4, 3, 4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(351, 60);
            AddButton.TabIndex = 25;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // Cost_input
            // 
            Cost_input.Location = new Point(509, 371);
            Cost_input.Margin = new Padding(3, 4, 3, 4);
            Cost_input.Name = "Cost_input";
            Cost_input.Size = new Size(634, 27);
            Cost_input.TabIndex = 24;
            // 
            // Date_input
            // 
            Date_input.Location = new Point(509, 289);
            Date_input.Margin = new Padding(3, 4, 3, 4);
            Date_input.Name = "Date_input";
            Date_input.Size = new Size(634, 27);
            Date_input.TabIndex = 23;
            // 
            // Expiration_date_input
            // 
            Expiration_date_input.Location = new Point(509, 207);
            Expiration_date_input.Margin = new Padding(3, 4, 3, 4);
            Expiration_date_input.Name = "Expiration_date_input";
            Expiration_date_input.Size = new Size(634, 27);
            Expiration_date_input.TabIndex = 22;
            // 
            // Purchase_input
            // 
            Purchase_input.Location = new Point(509, 117);
            Purchase_input.Margin = new Padding(3, 4, 3, 4);
            Purchase_input.Name = "Purchase_input";
            Purchase_input.Size = new Size(634, 27);
            Purchase_input.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(447, 371);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(49, 27);
            textBox4.TabIndex = 20;
            textBox4.Text = "Cost";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(391, 289);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(110, 27);
            textBox3.TabIndex = 19;
            textBox3.Text = "Purchase Date";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(391, 207);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(110, 27);
            textBox2.TabIndex = 18;
            textBox2.Text = "Expiration Date";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(430, 117);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(71, 27);
            textBox1.TabIndex = 17;
            textBox1.Text = "Purchase";
            // 
            // SendImageWithAppButton
            // 
            SendImageWithAppButton.Location = new Point(547, 456);
            SendImageWithAppButton.Margin = new Padding(3, 4, 3, 4);
            SendImageWithAppButton.Name = "SendImageWithAppButton";
            SendImageWithAppButton.Size = new Size(223, 49);
            SendImageWithAppButton.TabIndex = 33;
            SendImageWithAppButton.Text = "Send Image with app";
            SendImageWithAppButton.UseVisualStyleBackColor = true;
            SendImageWithAppButton.Click += SendImageWithAppButton_Click;
            // 
            // AddReceiptView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SendImageWithAppButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SelectImageButton);
            Controls.Add(AddButton);
            Controls.Add(Cost_input);
            Controls.Add(Date_input);
            Controls.Add(Expiration_date_input);
            Controls.Add(Purchase_input);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddReceiptView";
            Size = new Size(1518, 803);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SelectImageButton;
        private Button AddButton;
        private TextBox Cost_input;
        private TextBox Date_input;
        private TextBox Expiration_date_input;
        private TextBox Purchase_input;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button SendImageWithAppButton;
    }
}
