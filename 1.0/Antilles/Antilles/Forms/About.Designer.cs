namespace Antilles
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label_about = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.textBox_abouttxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.Location = new System.Drawing.Point(22, 21);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(62, 13);
            this.label_about.TabIndex = 0;
            this.label_about.Text = "AntillesXML";
            // 
            // button_close
            // 
            this.button_close.Image = global::Antilles.Properties.Resources.closecross;
            this.button_close.Location = new System.Drawing.Point(234, 157);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(37, 25);
            this.button_close.TabIndex = 1;
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // textBox_abouttxt
            // 
            this.textBox_abouttxt.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_abouttxt.Location = new System.Drawing.Point(25, 37);
            this.textBox_abouttxt.Multiline = true;
            this.textBox_abouttxt.Name = "textBox_abouttxt";
            this.textBox_abouttxt.ReadOnly = true;
            this.textBox_abouttxt.Size = new System.Drawing.Size(446, 114);
            this.textBox_abouttxt.TabIndex = 2;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 194);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_abouttxt);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.label_about);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_about;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.TextBox textBox_abouttxt;
    }
}