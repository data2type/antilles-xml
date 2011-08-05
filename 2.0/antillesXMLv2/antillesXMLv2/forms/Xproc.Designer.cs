namespace antillesXMLv2
{
    partial class Xproc
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
            this.tabPage = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback = new System.Windows.Forms.PictureBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.button_inputFolder = new System.Windows.Forms.Button();
            this.button_engage = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 412);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.pictureBox_feedback);
            this.tabPage.Controls.Add(this.comboBox);
            this.tabPage.Controls.Add(this.button_inputFolder);
            this.tabPage.Controls.Add(this.button_engage);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(476, 386);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Single";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // pictureBox_feedback
            // 
            this.pictureBox_feedback.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback.Location = new System.Drawing.Point(322, 146);
            this.pictureBox_feedback.Name = "pictureBox_feedback";
            this.pictureBox_feedback.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback.TabIndex = 34;
            this.pictureBox_feedback.TabStop = false;
            this.pictureBox_feedback.Visible = false;
            // 
            // comboBox
            // 
            this.comboBox.DropDownWidth = 550;
            this.comboBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(34, 59);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(320, 21);
            this.comboBox.TabIndex = 33;
            this.comboBox.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // button_inputFolder
            // 
            this.button_inputFolder.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_inputFolder.Location = new System.Drawing.Point(371, 43);
            this.button_inputFolder.Name = "button_inputFolder";
            this.button_inputFolder.Size = new System.Drawing.Size(75, 50);
            this.button_inputFolder.TabIndex = 18;
            this.button_inputFolder.UseVisualStyleBackColor = true;
            this.button_inputFolder.Click += new System.EventHandler(this.button_inputFolder_Click);
            // 
            // button_engage
            // 
            this.button_engage.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_engage.Location = new System.Drawing.Point(371, 137);
            this.button_engage.Name = "button_engage";
            this.button_engage.Size = new System.Drawing.Size(75, 50);
            this.button_engage.TabIndex = 19;
            this.button_engage.UseVisualStyleBackColor = true;
            this.button_engage.Click += new System.EventHandler(this.button_engage_Click);
            // 
            // Xproc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Xproc";
            this.ShowIcon = false;
            this.Text = "XProc Transformations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Xproc_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.Button button_inputFolder;
        private System.Windows.Forms.Button button_engage;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.PictureBox pictureBox_feedback;
    }
}