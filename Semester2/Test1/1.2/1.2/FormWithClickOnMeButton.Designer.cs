namespace _1._2
{
    public partial class FormWithClickOnMeButton
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
            this.clickOnMeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clickOnMeButton
            // 
            this.clickOnMeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clickOnMeButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.clickOnMeButton.Font = new System.Drawing.Font("Calibri", 9F);
            this.clickOnMeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clickOnMeButton.Location = new System.Drawing.Point(336, 198);
            this.clickOnMeButton.MaximumSize = new System.Drawing.Size(75, 50);
            this.clickOnMeButton.MinimumSize = new System.Drawing.Size(75, 50);
            this.clickOnMeButton.Name = "clickOnMeButton";
            this.clickOnMeButton.Size = new System.Drawing.Size(75, 50);
            this.clickOnMeButton.TabIndex = 0;
            this.clickOnMeButton.Text = "Click on me!";
            this.clickOnMeButton.UseVisualStyleBackColor = false;
            this.clickOnMeButton.Click += new System.EventHandler(this.ClickOnMeButton_Click);
            this.clickOnMeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ClickOnMeButton_MouseMove);
            // 
            // FormWithClickOnMeButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 453);
            this.Controls.Add(this.clickOnMeButton);
            this.MaximumSize = new System.Drawing.Size(820, 500);
            this.MinimumSize = new System.Drawing.Size(820, 500);
            this.Name = "FormWithClickOnMeButton";
            this.Text = "FormWithClickOnMeButton";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clickOnMeButton;
    }
}

