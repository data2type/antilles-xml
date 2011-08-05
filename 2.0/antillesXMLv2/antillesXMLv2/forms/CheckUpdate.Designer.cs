namespace antillesXMLv2
{
    partial class CheckUpdate
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_new = new System.Windows.Forms.Label();
            this.label_ok = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "please wait";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(126, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_new
            // 
            this.label_new.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_new.Location = new System.Drawing.Point(79, 23);
            this.label_new.Name = "label_new";
            this.label_new.Size = new System.Drawing.Size(169, 57);
            this.label_new.TabIndex = 2;
            this.label_new.Text = "New Version avaiable. Please visit http://www.data2type.de for more Infos.";
            this.label_new.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_new.Visible = false;
            // 
            // label_ok
            // 
            this.label_ok.AutoSize = true;
            this.label_ok.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ok.Location = new System.Drawing.Point(96, 44);
            this.label_ok.Name = "label_ok";
            this.label_ok.Size = new System.Drawing.Size(149, 13);
            this.label_ok.TabIndex = 3;
            this.label_ok.Text = "antillesXML is up to date.";
            this.label_ok.Visible = false;
            // 
            // CheckUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 145);
            this.ControlBox = false;
            this.Controls.Add(this.label_ok);
            this.Controls.Add(this.label_new);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "CheckUpdate";
            this.Text = "Checking Update";
            this.Shown += new System.EventHandler(this.CheckUpdate_Shown);
            this.VisibleChanged += new System.EventHandler(this.CheckUpdate_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_new;
        private System.Windows.Forms.Label label_ok;
    }
}