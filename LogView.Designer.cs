namespace Kuittisovellus
{
    partial class LogView
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
            PanelForMessages = new Panel();
            TextElement = new Label();
            TestButton = new Button();
            PanelForMessages.SuspendLayout();
            SuspendLayout();
            // 
            // PanelForMessages
            // 
            PanelForMessages.BorderStyle = BorderStyle.Fixed3D;
            PanelForMessages.Controls.Add(TextElement);
            PanelForMessages.Location = new Point(3, 79);
            PanelForMessages.Name = "PanelForMessages";
            PanelForMessages.Size = new Size(1169, 445);
            PanelForMessages.TabIndex = 0;
            // 
            // TextElement
            // 
            TextElement.Location = new Point(3, 21);
            TextElement.Name = "TextElement";
            TextElement.Size = new Size(40, 20);
            TextElement.TabIndex = 0;
            TextElement.Text = "Logs";
            TextElement.Paint += TextElement_Paint;
            // 
            // TestButton
            // 
            TestButton.Location = new Point(3, 44);
            TestButton.Name = "TestButton";
            TestButton.Size = new Size(94, 29);
            TestButton.TabIndex = 1;
            TestButton.Text = "Test";
            TestButton.UseVisualStyleBackColor = true;
            TestButton.Visible = false;
            TestButton.Click += TestButton_Click;
            // 
            // LogView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TestButton);
            Controls.Add(PanelForMessages);
            Name = "LogView";
            Size = new Size(1175, 558);
            PanelForMessages.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelForMessages;
        private Label TextElement;
        private Button TestButton;
        private Button PaintButton;
    }
}
