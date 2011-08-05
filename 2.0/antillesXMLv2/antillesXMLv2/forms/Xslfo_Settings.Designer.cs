namespace antillesXMLv2
{
    partial class Xslfo_Settings
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
            this.textBox_formatter = new System.Windows.Forms.TextBox();
            this.button_change = new System.Windows.Forms.Button();
            this.label_formatter = new System.Windows.Forms.Label();
            this.label_path = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_formatter
            // 
            this.textBox_formatter.Location = new System.Drawing.Point(12, 59);
            this.textBox_formatter.Name = "textBox_formatter";
            this.textBox_formatter.Size = new System.Drawing.Size(279, 20);
            this.textBox_formatter.TabIndex = 0;
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(309, 58);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 1;
            this.button_change.Text = "change";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // label_formatter
            // 
            this.label_formatter.AutoSize = true;
            this.label_formatter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_formatter.Location = new System.Drawing.Point(23, 22);
            this.label_formatter.Name = "label_formatter";
            this.label_formatter.Size = new System.Drawing.Size(0, 13);
            this.label_formatter.TabIndex = 2;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_path.Location = new System.Drawing.Point(17, 22);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(0, 13);
            this.label_path.TabIndex = 3;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(309, 99);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "ok";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // Xslfo_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 148);
            this.ControlBox = false;
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.label_formatter);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.textBox_formatter);
            this.Name = "Xslfo_Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_formatter;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Label label_formatter;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.Button button_ok;
    }
}