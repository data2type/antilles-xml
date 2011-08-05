namespace Antilles
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.button_close = new System.Windows.Forms.Button();
            this.webBrowser_help = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.Image = global::Antilles.Properties.Resources.closecross;
            this.button_close.Location = new System.Drawing.Point(381, 539);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(37, 25);
            this.button_close.TabIndex = 0;
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // webBrowser_help
            // 
            this.webBrowser_help.Location = new System.Drawing.Point(12, 12);
            this.webBrowser_help.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_help.Name = "webBrowser_help";
            this.webBrowser_help.Size = new System.Drawing.Size(820, 521);
            this.webBrowser_help.TabIndex = 2;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 576);
            this.ControlBox = false;
            this.Controls.Add(this.webBrowser_help);
            this.Controls.Add(this.button_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.WebBrowser webBrowser_help;
    }
}