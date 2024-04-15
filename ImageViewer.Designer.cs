namespace Kuittisovellus
{
    partial class ImageViewer
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
            PictureBox = new PictureBox();
            OKButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            ConfirmationControlsPanel = new Panel();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            ConfirmationControlsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PictureBox
            // 
            PictureBox.BorderStyle = BorderStyle.FixedSingle;
            PictureBox.Location = new Point(610, 3);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(643, 493);
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(3, 67);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(94, 29);
            OKButton.TabIndex = 1;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(151, 67);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(94, 29);
            CancelButton.TabIndex = 2;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Name = "label1";
            label1.Size = new Size(217, 20);
            label1.TabIndex = 3;
            label1.Text = "Do you want to use this image?";
            // 
            // ConfirmationControlsPanel
            // 
            ConfirmationControlsPanel.BorderStyle = BorderStyle.FixedSingle;
            ConfirmationControlsPanel.Controls.Add(OKButton);
            ConfirmationControlsPanel.Controls.Add(label1);
            ConfirmationControlsPanel.Controls.Add(CancelButton);
            ConfirmationControlsPanel.Enabled = false;
            ConfirmationControlsPanel.Location = new Point(793, 502);
            ConfirmationControlsPanel.Name = "ConfirmationControlsPanel";
            ConfirmationControlsPanel.Size = new Size(253, 103);
            ConfirmationControlsPanel.TabIndex = 4;
            ConfirmationControlsPanel.Visible = false;
            // 
            // BackButton
            // 
            BackButton.Enabled = false;
            BackButton.Location = new Point(3, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(126, 47);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Visible = false;
            BackButton.Click += BackButton_Click;
            // 
            // ImageViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BackButton);
            Controls.Add(ConfirmationControlsPanel);
            Controls.Add(PictureBox);
            Name = "ImageViewer";
            Size = new Size(1374, 622);
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ConfirmationControlsPanel.ResumeLayout(false);
            ConfirmationControlsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PictureBox;
        private Button OKButton;
        private Button CancelButton;
        private Label label1;
        private Panel ConfirmationControlsPanel;
        private Button BackButton;
    }
}
