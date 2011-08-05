namespace Antilles
{
    partial class WordML
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
            this.button_wordclose = new System.Windows.Forms.Button();
            this.button_wordausführen = new System.Windows.Forms.Button();
            this.button_wordspeichern = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_wordclose
            // 
            this.button_wordclose.Location = new System.Drawing.Point(408, 491);
            this.button_wordclose.Name = "button_wordclose";
            this.button_wordclose.Size = new System.Drawing.Size(75, 23);
            this.button_wordclose.TabIndex = 1;
            this.button_wordclose.Text = "close";
            this.button_wordclose.UseVisualStyleBackColor = true;
            this.button_wordclose.Click += new System.EventHandler(this.button_wordclose_Click);
            // 
            // button_wordausführen
            // 
            this.button_wordausführen.Location = new System.Drawing.Point(568, 491);
            this.button_wordausführen.Name = "button_wordausführen";
            this.button_wordausführen.Size = new System.Drawing.Size(75, 23);
            this.button_wordausführen.TabIndex = 2;
            this.button_wordausführen.Text = "ausführen";
            this.button_wordausführen.UseVisualStyleBackColor = true;
            this.button_wordausführen.Click += new System.EventHandler(this.button_wordausführen_Click);
            // 
            // button_wordspeichern
            // 
            this.button_wordspeichern.Location = new System.Drawing.Point(487, 491);
            this.button_wordspeichern.Name = "button_wordspeichern";
            this.button_wordspeichern.Size = new System.Drawing.Size(75, 23);
            this.button_wordspeichern.TabIndex = 3;
            this.button_wordspeichern.Text = "save";
            this.button_wordspeichern.UseVisualStyleBackColor = true;
            this.button_wordspeichern.Click += new System.EventHandler(this.button_wordspeichern_Click);
            // 
            // WordML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(669, 526);
            this.ControlBox = false;
            this.Controls.Add(this.button_wordspeichern);
            this.Controls.Add(this.button_wordausführen);
            this.Controls.Add(this.button_wordclose);
            this.Name = "WordML";
            this.Text = "WordML Feature (BETA)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_wordclose;
        private System.Windows.Forms.Button button_wordausführen;
        private System.Windows.Forms.Button button_wordspeichern;
    }
}