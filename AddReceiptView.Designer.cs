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
            panel1 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 6);
            label6.Name = "label6";
            label6.Size = new Size(350, 20);
            label6.TabIndex = 32;
            label6.Text = "Optional : Set Image with mobile app or from files. ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 159);
            label2.Name = "label2";
            label2.Size = new Size(151, 20);
            label2.TabIndex = 28;
            label2.Text = "Format : dd/mm/yyyy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(179, 84);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 27;
            label1.Text = "Format : dd/mm/yyyy";
            // 
            // SelectImageButton
            // 
            SelectImageButton.Location = new Point(73, 124);
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
            AddButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            AddButton.Location = new Point(502, 291);
            AddButton.Margin = new Padding(3, 4, 3, 4);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(192, 56);
            AddButton.TabIndex = 25;
            AddButton.Text = "Finish";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // Cost_input
            // 
            Cost_input.Location = new Point(151, 237);
            Cost_input.Margin = new Padding(3, 4, 3, 4);
            Cost_input.Name = "Cost_input";
            Cost_input.Size = new Size(213, 27);
            Cost_input.TabIndex = 24;
            // 
            // Date_input
            // 
            Date_input.Location = new Point(151, 192);
            Date_input.Margin = new Padding(3, 4, 3, 4);
            Date_input.Name = "Date_input";
            Date_input.Size = new Size(213, 27);
            Date_input.TabIndex = 23;
            // 
            // Expiration_date_input
            // 
            Expiration_date_input.Location = new Point(151, 118);
            Expiration_date_input.Margin = new Padding(3, 4, 3, 4);
            Expiration_date_input.Name = "Expiration_date_input";
            Expiration_date_input.Size = new Size(213, 27);
            Expiration_date_input.TabIndex = 22;
            // 
            // Purchase_input
            // 
            Purchase_input.Location = new Point(151, 44);
            Purchase_input.Margin = new Padding(3, 4, 3, 4);
            Purchase_input.Name = "Purchase_input";
            Purchase_input.Size = new Size(213, 27);
            Purchase_input.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(68, 237);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(49, 27);
            textBox4.TabIndex = 20;
            textBox4.Text = "Cost";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(7, 192);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(110, 27);
            textBox3.TabIndex = 19;
            textBox3.Text = "Purchase Date";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 118);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(110, 27);
            textBox2.TabIndex = 18;
            textBox2.Text = "Expiration Date";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 44);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(107, 27);
            textBox1.TabIndex = 17;
            textBox1.Text = "Purchase name";
            // 
            // SendImageWithAppButton
            // 
            SendImageWithAppButton.Location = new Point(73, 56);
            SendImageWithAppButton.Margin = new Padding(3, 4, 3, 4);
            SendImageWithAppButton.Name = "SendImageWithAppButton";
            SendImageWithAppButton.Size = new Size(223, 49);
            SendImageWithAppButton.TabIndex = 33;
            SendImageWithAppButton.Text = "Send Image with app";
            SendImageWithAppButton.UseVisualStyleBackColor = true;
            SendImageWithAppButton.Click += SendImageWithAppButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(AddButton);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(207, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(940, 383);
            panel1.TabIndex = 34;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, -1);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 35;
            label3.Text = "Receipt Information";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(SendImageWithAppButton);
            panel2.Controls.Add(SelectImageButton);
            panel2.Location = new Point(502, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(389, 210);
            panel2.TabIndex = 36;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(Expiration_date_input);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(Date_input);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(Cost_input);
            panel3.Controls.Add(Purchase_input);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(30, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(407, 304);
            panel3.TabIndex = 35;
            // 
            // AddReceiptView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddReceiptView";
            Size = new Size(1518, 803);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
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
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
    }
}
