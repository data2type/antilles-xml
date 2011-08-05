namespace Antilles
{
    partial class Infos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infos));
            this.pictureBox_startscreen = new System.Windows.Forms.PictureBox();
            this.checkBox_janein = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_startscreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_startscreen
            // 
            this.pictureBox_startscreen.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_startscreen.Name = "pictureBox_startscreen";
            this.pictureBox_startscreen.Size = new System.Drawing.Size(560, 450);
            this.pictureBox_startscreen.TabIndex = 0;
            this.pictureBox_startscreen.TabStop = false;
            this.pictureBox_startscreen.Click += new System.EventHandler(this.pictureBox_startscreen_Click);
            // 
            // checkBox_janein
            // 
            this.checkBox_janein.AutoSize = true;
            this.checkBox_janein.Checked = true;
            this.checkBox_janein.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_janein.Location = new System.Drawing.Point(12, 476);
            this.checkBox_janein.Name = "checkBox_janein";
            this.checkBox_janein.Size = new System.Drawing.Size(199, 17);
            this.checkBox_janein.TabIndex = 1;
            this.checkBox_janein.Text = "Beim Start von AntillesXML anzeigen";
            this.checkBox_janein.UseVisualStyleBackColor = true;
            this.checkBox_janein.Click += new System.EventHandler(this.checkBox_janein_Click);
            // 
            // Infos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 505);
            this.Controls.Add(this.checkBox_janein);
            this.Controls.Add(this.pictureBox_startscreen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Infos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Willkommen bei AntillesXML";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_startscreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_startscreen;
        private System.Windows.Forms.CheckBox checkBox_janein;

    }
}