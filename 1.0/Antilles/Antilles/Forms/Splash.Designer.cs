namespace Antilles
{
    partial class Splash
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
            this.label_splash = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_splash
            // 
            this.label_splash.AutoSize = true;
            this.label_splash.BackColor = System.Drawing.Color.Transparent;
            this.label_splash.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_splash.Location = new System.Drawing.Point(302, 146);
            this.label_splash.Name = "label_splash";
            this.label_splash.Size = new System.Drawing.Size(29, 13);
            this.label_splash.TabIndex = 0;
            this.label_splash.Text = "...init";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Antilles.Properties.Resources.splash;
            this.ClientSize = new System.Drawing.Size(398, 168);
            this.ControlBox = false;
            this.Controls.Add(this.label_splash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Splash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_splash;

    }
}