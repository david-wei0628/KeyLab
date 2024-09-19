namespace KeyLab
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.labelCountdown = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCountdown
            // 
            this.labelCountdown.AutoSize = true;
            this.labelCountdown.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelCountdown.Location = new System.Drawing.Point(75, 205);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(81, 29);
            this.labelCountdown.TabIndex = 0;
            this.labelCountdown.Text = "label1";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(560, 248);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "button1";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelCountdown);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Label labelCountdown;
        private System.Windows.Forms.Button buttonStart;
    }
}