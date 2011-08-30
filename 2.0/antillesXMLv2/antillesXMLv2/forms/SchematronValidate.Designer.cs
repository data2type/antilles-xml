namespace antillesXMLv2
{
    partial class SchematronValidate
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
            this.comboBox_stylesheet = new System.Windows.Forms.ComboBox();
            this.comboBox_input = new System.Windows.Forms.ComboBox();
            this.button_engage = new System.Windows.Forms.Button();
            this.button_stylesheet = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.Folder = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback2 = new System.Windows.Forms.PictureBox();
            this.comboBox_stylesheetFolder = new System.Windows.Forms.ComboBox();
            this.comboBox_inputFolder = new System.Windows.Forms.ComboBox();
            this.button_folderenage = new System.Windows.Forms.Button();
            this.button_outputStylesheet = new System.Windows.Forms.Button();
            this.button_inputFolder = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.Single.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).BeginInit();
            this.Folder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Single);
            this.tabControl.Controls.Add(this.Folder);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 412);
            this.tabControl.TabIndex = 0;
            // 
            // Single
            // 
            this.Single.Controls.Add(this.pictureBox_feedback);
            this.Single.Controls.Add(this.comboBox_stylesheet);
            this.Single.Controls.Add(this.comboBox_input);
            this.Single.Controls.Add(this.button_engage);
            this.Single.Controls.Add(this.button_stylesheet);
            this.Single.Controls.Add(this.button_input);
            this.Single.Location = new System.Drawing.Point(4, 22);
            this.Single.Name = "Single";
            this.Single.Padding = new System.Windows.Forms.Padding(3);
            this.Single.Size = new System.Drawing.Size(476, 386);
            this.Single.TabIndex = 0;
            this.Single.Text = "Single";
            this.Single.UseVisualStyleBackColor = true;
            this.Single.Click += new System.EventHandler(this.Single_Click);
            // 
            // pictureBox_feedback
            // 
            this.pictureBox_feedback.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback.Location = new System.Drawing.Point(322, 302);
            this.pictureBox_feedback.Name = "pictureBox_feedback";
            this.pictureBox_feedback.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback.TabIndex = 37;
            this.pictureBox_feedback.TabStop = false;
            this.pictureBox_feedback.Visible = false;
            // 
            // comboBox_stylesheet
            // 
            this.comboBox_stylesheet.DropDownWidth = 550;
            this.comboBox_stylesheet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_stylesheet.FormattingEnabled = true;
            this.comboBox_stylesheet.Location = new System.Drawing.Point(34, 139);
            this.comboBox_stylesheet.Name = "comboBox_stylesheet";
            this.comboBox_stylesheet.Size = new System.Drawing.Size(320, 21);
            this.comboBox_stylesheet.TabIndex = 33;
            this.comboBox_stylesheet.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_input
            // 
            this.comboBox_input.DropDownWidth = 550;
            this.comboBox_input.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_input.FormattingEnabled = true;
            this.comboBox_input.Location = new System.Drawing.Point(34, 59);
            this.comboBox_input.Name = "comboBox_input";
            this.comboBox_input.Size = new System.Drawing.Size(320, 21);
            this.comboBox_input.TabIndex = 32;
            this.comboBox_input.TextChanged += new System.EventHandler(this.disableFeedback);
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
            // button_stylesheet
            // 
            this.button_stylesheet.Image = global::antillesXMLv2.Properties.Resources.stylesheet;
            this.button_stylesheet.Location = new System.Drawing.Point(371, 123);
            this.button_stylesheet.Name = "button_stylesheet";
            this.button_stylesheet.Size = new System.Drawing.Size(75, 50);
            this.button_stylesheet.TabIndex = 10;
            this.button_stylesheet.UseVisualStyleBackColor = true;
            this.button_stylesheet.Click += new System.EventHandler(this.button_output_Click);
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
            // Folder
            // 
            this.Folder.Controls.Add(this.pictureBox_feedback2);
            this.Folder.Controls.Add(this.comboBox_stylesheetFolder);
            this.Folder.Controls.Add(this.comboBox_inputFolder);
            this.Folder.Controls.Add(this.button_folderenage);
            this.Folder.Controls.Add(this.button_outputStylesheet);
            this.Folder.Controls.Add(this.button_inputFolder);
            this.Folder.Location = new System.Drawing.Point(4, 22);
            this.Folder.Name = "Folder";
            this.Folder.Padding = new System.Windows.Forms.Padding(3);
            this.Folder.Size = new System.Drawing.Size(476, 386);
            this.Folder.TabIndex = 1;
            this.Folder.Text = "Folder";
            this.Folder.UseVisualStyleBackColor = true;
            // 
            // pictureBox_feedback2
            // 
            this.pictureBox_feedback2.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback2.Location = new System.Drawing.Point(322, 302);
            this.pictureBox_feedback2.Name = "pictureBox_feedback2";
            this.pictureBox_feedback2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback2.TabIndex = 38;
            this.pictureBox_feedback2.TabStop = false;
            this.pictureBox_feedback2.Visible = false;
            // 
            // comboBox_stylesheetFolder
            // 
            this.comboBox_stylesheetFolder.DropDownWidth = 550;
            this.comboBox_stylesheetFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_stylesheetFolder.FormattingEnabled = true;
            this.comboBox_stylesheetFolder.Location = new System.Drawing.Point(34, 139);
            this.comboBox_stylesheetFolder.Name = "comboBox_stylesheetFolder";
            this.comboBox_stylesheetFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_stylesheetFolder.TabIndex = 33;
            this.comboBox_stylesheetFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_inputFolder
            // 
            this.comboBox_inputFolder.DropDownWidth = 550;
            this.comboBox_inputFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_inputFolder.FormattingEnabled = true;
            this.comboBox_inputFolder.Location = new System.Drawing.Point(34, 59);
            this.comboBox_inputFolder.Name = "comboBox_inputFolder";
            this.comboBox_inputFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_inputFolder.TabIndex = 32;
            this.comboBox_inputFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // button_folderenage
            // 
            this.button_folderenage.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_folderenage.Location = new System.Drawing.Point(371, 293);
            this.button_folderenage.Name = "button_folderenage";
            this.button_folderenage.Size = new System.Drawing.Size(75, 50);
            this.button_folderenage.TabIndex = 11;
            this.button_folderenage.UseVisualStyleBackColor = true;
            this.button_folderenage.Click += new System.EventHandler(this.button_folderenage_Click);
            // 
            // button_outputStylesheet
            // 
            this.button_outputStylesheet.Image = global::antillesXMLv2.Properties.Resources.stylesheet;
            this.button_outputStylesheet.Location = new System.Drawing.Point(371, 123);
            this.button_outputStylesheet.Name = "button_outputStylesheet";
            this.button_outputStylesheet.Size = new System.Drawing.Size(75, 50);
            this.button_outputStylesheet.TabIndex = 10;
            this.button_outputStylesheet.UseVisualStyleBackColor = true;
            this.button_outputStylesheet.Click += new System.EventHandler(this.button_outputStylesheet_Click);
            // 
            // button_inputFolder
            // 
            this.button_inputFolder.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_inputFolder.Location = new System.Drawing.Point(371, 43);
            this.button_inputFolder.Name = "button_inputFolder";
            this.button_inputFolder.Size = new System.Drawing.Size(75, 50);
            this.button_inputFolder.TabIndex = 9;
            this.button_inputFolder.UseVisualStyleBackColor = true;
            this.button_inputFolder.Click += new System.EventHandler(this.button_inputFolder_Click);
            // 
            // SchematronValidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "SchematronValidate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Schematron Validation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchematronValidate_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.Single.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).EndInit();
            this.Folder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Single;
        private System.Windows.Forms.TabPage Folder;
        private System.Windows.Forms.Button button_folderenage;
        private System.Windows.Forms.Button button_outputStylesheet;
        private System.Windows.Forms.Button button_inputFolder;
        private System.Windows.Forms.Button button_engage;
        private System.Windows.Forms.Button button_stylesheet;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.ComboBox comboBox_stylesheet;
        private System.Windows.Forms.ComboBox comboBox_input;
        private System.Windows.Forms.ComboBox comboBox_stylesheetFolder;
        private System.Windows.Forms.ComboBox comboBox_inputFolder;
        private System.Windows.Forms.PictureBox pictureBox_feedback;
        private System.Windows.Forms.PictureBox pictureBox_feedback2;
    }
}