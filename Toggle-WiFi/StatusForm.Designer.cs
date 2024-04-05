namespace Toggle_WiFi
{
    partial class StatusForm
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
            TextOut = new Label();
            SuspendLayout();
            // 
            // TextOut
            // 
            TextOut.AutoSize = true;
            TextOut.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            TextOut.Location = new Point(0, 0);
            TextOut.Margin = new Padding(3);
            TextOut.Name = "TextOut";
            TextOut.Size = new Size(327, 25);
            TextOut.TabIndex = 0;
            TextOut.Text = "Switiching From Wi-Fi to Ethernet...";
            TextOut.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatusForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(334, 41);
            ControlBox = false;
            Controls.Add(TextOut);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StatusForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wi-Fi Toggle";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label TextOut;
    }
}