namespace antillesXMLv2
{
    partial class Csv2Xml
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Single = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback = new System.Windows.Forms.PictureBox();
            this.comboBox_target = new System.Windows.Forms.ComboBox();
            this.comboBox_input = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.button_target = new System.Windows.Forms.Button();
            this.button_engage = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.Single.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Single);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 412);
            this.tabControl.TabIndex = 1;
            // 
            // Single
            // 
            this.Single.Controls.Add(this.pictureBox_feedback);
            this.Single.Controls.Add(this.comboBox_target);
            this.Single.Controls.Add(this.comboBox_input);
            this.Single.Controls.Add(this.label1);
            this.Single.Controls.Add(this.comboBox);
            this.Single.Controls.Add(this.button_target);
            this.Single.Controls.Add(this.button_engage);
            this.Single.Controls.Add(this.button_input);
            this.Single.Location = new System.Drawing.Point(4, 22);
            this.Single.Name = "Single";
            this.Single.Padding = new System.Windows.Forms.Padding(3);
            this.Single.Size = new System.Drawing.Size(476, 386);
            this.Single.TabIndex = 0;
            this.Single.Text = "Single";
            this.Single.UseVisualStyleBackColor = true;
            // 
            // pictureBox_feedback
            // 
            this.pictureBox_feedback.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback.Location = new System.Drawing.Point(322, 302);
            this.pictureBox_feedback.Name = "pictureBox_feedback";
            this.pictureBox_feedback.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback.TabIndex = 40;
            this.pictureBox_feedback.TabStop = false;
            this.pictureBox_feedback.Visible = false;
            // 
            // comboBox_target
            // 
            this.comboBox_target.DropDownWidth = 550;
            this.comboBox_target.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_target.FormattingEnabled = true;
            this.comboBox_target.Location = new System.Drawing.Point(34, 139);
            this.comboBox_target.Name = "comboBox_target";
            this.comboBox_target.Size = new System.Drawing.Size(320, 21);
            this.comboBox_target.TabIndex = 35;
            this.comboBox_target.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_input
            // 
            this.comboBox_input.DropDownWidth = 550;
            this.comboBox_input.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_input.FormattingEnabled = true;
            this.comboBox_input.Location = new System.Drawing.Point(34, 59);
            this.comboBox_input.Name = "comboBox_input";
            this.comboBox_input.Size = new System.Drawing.Size(320, 21);
            this.comboBox_input.TabIndex = 34;
            this.comboBox_input.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Choose Seperator";
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            ";",
            ","});
            this.comboBox.Location = new System.Drawing.Point(31, 190);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(47, 21);
            this.comboBox.TabIndex = 15;
            this.comboBox.Text = ";";
            // 
            // button_target
            // 
            this.button_target.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_target.Location = new System.Drawing.Point(371, 120);
            this.button_target.Name = "button_target";
            this.button_target.Size = new System.Drawing.Size(75, 50);
            this.button_target.TabIndex = 13;
            this.button_target.UseVisualStyleBackColor = true;
            this.button_target.Click += new System.EventHandler(this.button_target_Click);
            // 
            // button_engage
            // 
            this.button_engage.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_engage.Location = new System.Drawing.Point(371, 293);
            this.button_engage.Name = "button_engage";
            this.button_engage.Size = new System.Drawing.Size(75, 50);
            this.button_engage.TabIndex = 11;
            this.button_engage.UseVisualStyleBackColor = true;
            this.button_engage.Click += new System.EventHandler(this.button_engage_Click);
            // 
            // button_input
            // 
            this.button_input.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_input.Location = new System.Drawing.Point(371, 43);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(75, 50);
            this.button_input.TabIndex = 9;
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // Csv2Xml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Csv2Xml";
            this.ShowIcon = false;
            this.Text = "CSV 2 XML";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cals2Html_FormClosing);
            this.Load += new System.EventHandler(this.Cals2Html_Load);
            this.tabControl.ResumeLayout(false);
            this.Single.ResumeLayout(false);
            this.Single.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Single;
        private System.Windows.Forms.Button button_target;
        private System.Windows.Forms.Button button_engage;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.ComboBox comboBox_target;
        private System.Windows.Forms.ComboBox comboBox_input;
        private System.Windows.Forms.PictureBox pictureBox_feedback;
    }
}