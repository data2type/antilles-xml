namespace antillesXMLv2
{
    partial class Xslfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xslfo));
            this.tabControl_xslfo = new System.Windows.Forms.TabControl();
            this.tabPage_xslfoSingle = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback = new System.Windows.Forms.PictureBox();
            this.comboBox_target = new System.Windows.Forms.ComboBox();
            this.comboBox_stylesheet = new System.Windows.Forms.ComboBox();
            this.comboBox_input = new System.Windows.Forms.ComboBox();
            this.button_target = new System.Windows.Forms.Button();
            this.button_engage_singlefo = new System.Windows.Forms.Button();
            this.button_stylesheet = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.tabPage_xslfoFolder = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback2 = new System.Windows.Forms.PictureBox();
            this.comboBox_targetFolder = new System.Windows.Forms.ComboBox();
            this.comboBox_stylesheetFolder = new System.Windows.Forms.ComboBox();
            this.comboBox_inputFolder = new System.Windows.Forms.ComboBox();
            this.button_outputFolder = new System.Windows.Forms.Button();
            this.button_engage_folder = new System.Windows.Forms.Button();
            this.button_outputStylesheet = new System.Windows.Forms.Button();
            this.button_inputFolder = new System.Windows.Forms.Button();
            this.tabPage_xslfoProperties = new System.Windows.Forms.TabPage();
            this.button_settings = new System.Windows.Forms.Button();
            this.checkBox_steps = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.radioButton_fop = new System.Windows.Forms.RadioButton();
            this.radioButton_renderx = new System.Windows.Forms.RadioButton();
            this.radioButton_antennahouse = new System.Windows.Forms.RadioButton();
            this.tabControl_xslfo.SuspendLayout();
            this.tabPage_xslfoSingle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).BeginInit();
            this.tabPage_xslfoFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback2)).BeginInit();
            this.tabPage_xslfoProperties.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_xslfo
            // 
            this.tabControl_xslfo.Controls.Add(this.tabPage_xslfoSingle);
            this.tabControl_xslfo.Controls.Add(this.tabPage_xslfoFolder);
            this.tabControl_xslfo.Controls.Add(this.tabPage_xslfoProperties);
            this.tabControl_xslfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_xslfo.Location = new System.Drawing.Point(0, 0);
            this.tabControl_xslfo.Name = "tabControl_xslfo";
            this.tabControl_xslfo.SelectedIndex = 0;
            this.tabControl_xslfo.Size = new System.Drawing.Size(484, 412);
            this.tabControl_xslfo.TabIndex = 0;
            // 
            // tabPage_xslfoSingle
            // 
            this.tabPage_xslfoSingle.Controls.Add(this.pictureBox_feedback);
            this.tabPage_xslfoSingle.Controls.Add(this.comboBox_target);
            this.tabPage_xslfoSingle.Controls.Add(this.comboBox_stylesheet);
            this.tabPage_xslfoSingle.Controls.Add(this.comboBox_input);
            this.tabPage_xslfoSingle.Controls.Add(this.button_target);
            this.tabPage_xslfoSingle.Controls.Add(this.button_engage_singlefo);
            this.tabPage_xslfoSingle.Controls.Add(this.button_stylesheet);
            this.tabPage_xslfoSingle.Controls.Add(this.button_input);
            this.tabPage_xslfoSingle.Location = new System.Drawing.Point(4, 22);
            this.tabPage_xslfoSingle.Name = "tabPage_xslfoSingle";
            this.tabPage_xslfoSingle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_xslfoSingle.Size = new System.Drawing.Size(476, 386);
            this.tabPage_xslfoSingle.TabIndex = 0;
            this.tabPage_xslfoSingle.Text = "Single";
            this.tabPage_xslfoSingle.UseVisualStyleBackColor = true;
            // 
            // pictureBox_feedback
            // 
            this.pictureBox_feedback.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback.Location = new System.Drawing.Point(319, 302);
            this.pictureBox_feedback.Name = "pictureBox_feedback";
            this.pictureBox_feedback.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback.TabIndex = 18;
            this.pictureBox_feedback.TabStop = false;
            this.pictureBox_feedback.Visible = false;
            // 
            // comboBox_target
            // 
            this.comboBox_target.DropDownWidth = 550;
            this.comboBox_target.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_target.FormattingEnabled = true;
            this.comboBox_target.Location = new System.Drawing.Point(31, 219);
            this.comboBox_target.Name = "comboBox_target";
            this.comboBox_target.Size = new System.Drawing.Size(320, 21);
            this.comboBox_target.TabIndex = 23;
            this.comboBox_target.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_stylesheet
            // 
            this.comboBox_stylesheet.DropDownWidth = 550;
            this.comboBox_stylesheet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_stylesheet.FormattingEnabled = true;
            this.comboBox_stylesheet.Location = new System.Drawing.Point(31, 139);
            this.comboBox_stylesheet.Name = "comboBox_stylesheet";
            this.comboBox_stylesheet.Size = new System.Drawing.Size(320, 21);
            this.comboBox_stylesheet.TabIndex = 22;
            this.comboBox_stylesheet.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_input
            // 
            this.comboBox_input.DropDownWidth = 550;
            this.comboBox_input.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_input.FormattingEnabled = true;
            this.comboBox_input.Location = new System.Drawing.Point(31, 59);
            this.comboBox_input.Name = "comboBox_input";
            this.comboBox_input.Size = new System.Drawing.Size(320, 21);
            this.comboBox_input.TabIndex = 21;
            this.comboBox_input.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // button_target
            // 
            this.button_target.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_target.Location = new System.Drawing.Point(371, 203);
            this.button_target.Name = "button_target";
            this.button_target.Size = new System.Drawing.Size(75, 50);
            this.button_target.TabIndex = 20;
            this.button_target.UseVisualStyleBackColor = true;
            this.button_target.Click += new System.EventHandler(this.button_target_Click);
            // 
            // button_engage_singlefo
            // 
            this.button_engage_singlefo.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_engage_singlefo.Location = new System.Drawing.Point(371, 293);
            this.button_engage_singlefo.Name = "button_engage_singlefo";
            this.button_engage_singlefo.Size = new System.Drawing.Size(75, 50);
            this.button_engage_singlefo.TabIndex = 18;
            this.button_engage_singlefo.UseVisualStyleBackColor = true;
            this.button_engage_singlefo.Click += new System.EventHandler(this.button_engage_Click);
            // 
            // button_stylesheet
            // 
            this.button_stylesheet.Image = global::antillesXMLv2.Properties.Resources.stylesheet;
            this.button_stylesheet.Location = new System.Drawing.Point(371, 123);
            this.button_stylesheet.Name = "button_stylesheet";
            this.button_stylesheet.Size = new System.Drawing.Size(75, 50);
            this.button_stylesheet.TabIndex = 17;
            this.button_stylesheet.UseVisualStyleBackColor = true;
            this.button_stylesheet.Click += new System.EventHandler(this.button_stylesheet_Click);
            // 
            // button_input
            // 
            this.button_input.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_input.Location = new System.Drawing.Point(371, 43);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(75, 50);
            this.button_input.TabIndex = 16;
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // tabPage_xslfoFolder
            // 
            this.tabPage_xslfoFolder.Controls.Add(this.pictureBox_feedback2);
            this.tabPage_xslfoFolder.Controls.Add(this.comboBox_targetFolder);
            this.tabPage_xslfoFolder.Controls.Add(this.comboBox_stylesheetFolder);
            this.tabPage_xslfoFolder.Controls.Add(this.comboBox_inputFolder);
            this.tabPage_xslfoFolder.Controls.Add(this.button_outputFolder);
            this.tabPage_xslfoFolder.Controls.Add(this.button_engage_folder);
            this.tabPage_xslfoFolder.Controls.Add(this.button_outputStylesheet);
            this.tabPage_xslfoFolder.Controls.Add(this.button_inputFolder);
            this.tabPage_xslfoFolder.Location = new System.Drawing.Point(4, 22);
            this.tabPage_xslfoFolder.Name = "tabPage_xslfoFolder";
            this.tabPage_xslfoFolder.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_xslfoFolder.Size = new System.Drawing.Size(476, 386);
            this.tabPage_xslfoFolder.TabIndex = 1;
            this.tabPage_xslfoFolder.Text = "Folder";
            this.tabPage_xslfoFolder.UseVisualStyleBackColor = true;
            // 
            // pictureBox_feedback2
            // 
            this.pictureBox_feedback2.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback2.Location = new System.Drawing.Point(319, 302);
            this.pictureBox_feedback2.Name = "pictureBox_feedback2";
            this.pictureBox_feedback2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback2.TabIndex = 31;
            this.pictureBox_feedback2.TabStop = false;
            this.pictureBox_feedback2.Visible = false;
            // 
            // comboBox_targetFolder
            // 
            this.comboBox_targetFolder.DropDownWidth = 550;
            this.comboBox_targetFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_targetFolder.FormattingEnabled = true;
            this.comboBox_targetFolder.Location = new System.Drawing.Point(31, 219);
            this.comboBox_targetFolder.Name = "comboBox_targetFolder";
            this.comboBox_targetFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_targetFolder.TabIndex = 30;
            this.comboBox_targetFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_stylesheetFolder
            // 
            this.comboBox_stylesheetFolder.DropDownWidth = 550;
            this.comboBox_stylesheetFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_stylesheetFolder.FormattingEnabled = true;
            this.comboBox_stylesheetFolder.Location = new System.Drawing.Point(31, 139);
            this.comboBox_stylesheetFolder.Name = "comboBox_stylesheetFolder";
            this.comboBox_stylesheetFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_stylesheetFolder.TabIndex = 29;
            this.comboBox_stylesheetFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_inputFolder
            // 
            this.comboBox_inputFolder.DropDownWidth = 550;
            this.comboBox_inputFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_inputFolder.FormattingEnabled = true;
            this.comboBox_inputFolder.Location = new System.Drawing.Point(31, 59);
            this.comboBox_inputFolder.Name = "comboBox_inputFolder";
            this.comboBox_inputFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_inputFolder.TabIndex = 28;
            this.comboBox_inputFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // button_outputFolder
            // 
            this.button_outputFolder.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_outputFolder.Location = new System.Drawing.Point(371, 203);
            this.button_outputFolder.Name = "button_outputFolder";
            this.button_outputFolder.Size = new System.Drawing.Size(75, 50);
            this.button_outputFolder.TabIndex = 27;
            this.button_outputFolder.UseVisualStyleBackColor = true;
            this.button_outputFolder.Click += new System.EventHandler(this.button_outputFolder_Click);
            // 
            // button_engage_folder
            // 
            this.button_engage_folder.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_engage_folder.Location = new System.Drawing.Point(371, 293);
            this.button_engage_folder.Name = "button_engage_folder";
            this.button_engage_folder.Size = new System.Drawing.Size(75, 50);
            this.button_engage_folder.TabIndex = 25;
            this.button_engage_folder.UseVisualStyleBackColor = true;
            this.button_engage_folder.Click += new System.EventHandler(this.button_engage_folder_Click);
            // 
            // button_outputStylesheet
            // 
            this.button_outputStylesheet.Image = global::antillesXMLv2.Properties.Resources.stylesheet;
            this.button_outputStylesheet.Location = new System.Drawing.Point(371, 123);
            this.button_outputStylesheet.Name = "button_outputStylesheet";
            this.button_outputStylesheet.Size = new System.Drawing.Size(75, 50);
            this.button_outputStylesheet.TabIndex = 24;
            this.button_outputStylesheet.UseVisualStyleBackColor = true;
            this.button_outputStylesheet.Click += new System.EventHandler(this.button_outputStylesheet_Click);
            // 
            // button_inputFolder
            // 
            this.button_inputFolder.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_inputFolder.Location = new System.Drawing.Point(371, 43);
            this.button_inputFolder.Name = "button_inputFolder";
            this.button_inputFolder.Size = new System.Drawing.Size(75, 50);
            this.button_inputFolder.TabIndex = 23;
            this.button_inputFolder.UseVisualStyleBackColor = true;
            this.button_inputFolder.Click += new System.EventHandler(this.button_inputFolder_Click);
            // 
            // tabPage_xslfoProperties
            // 
            this.tabPage_xslfoProperties.Controls.Add(this.button_settings);
            this.tabPage_xslfoProperties.Controls.Add(this.checkBox_steps);
            this.tabPage_xslfoProperties.Controls.Add(this.groupBox);
            this.tabPage_xslfoProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPage_xslfoProperties.Name = "tabPage_xslfoProperties";
            this.tabPage_xslfoProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_xslfoProperties.Size = new System.Drawing.Size(476, 386);
            this.tabPage_xslfoProperties.TabIndex = 2;
            this.tabPage_xslfoProperties.Text = "Properties";
            this.tabPage_xslfoProperties.UseVisualStyleBackColor = true;
            // 
            // button_settings
            // 
            this.button_settings.Location = new System.Drawing.Point(284, 53);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(102, 43);
            this.button_settings.TabIndex = 2;
            this.button_settings.Text = "Settings";
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Visible = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // checkBox_steps
            // 
            this.checkBox_steps.AutoSize = true;
            this.checkBox_steps.Location = new System.Drawing.Point(50, 172);
            this.checkBox_steps.Name = "checkBox_steps";
            this.checkBox_steps.Size = new System.Drawing.Size(100, 17);
            this.checkBox_steps.TabIndex = 1;
            this.checkBox_steps.Text = "Create *.fo Files";
            this.checkBox_steps.UseVisualStyleBackColor = true;
            this.checkBox_steps.CheckedChanged += new System.EventHandler(this.checkBox_steps_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButton_fop);
            this.groupBox.Controls.Add(this.radioButton_renderx);
            this.groupBox.Controls.Add(this.radioButton_antennahouse);
            this.groupBox.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(50, 42);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(210, 124);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Which Formatter?";
            // 
            // radioButton_fop
            // 
            this.radioButton_fop.AutoSize = true;
            this.radioButton_fop.Location = new System.Drawing.Point(27, 90);
            this.radioButton_fop.Name = "radioButton_fop";
            this.radioButton_fop.Size = new System.Drawing.Size(132, 20);
            this.radioButton_fop.TabIndex = 2;
            this.radioButton_fop.TabStop = true;
            this.radioButton_fop.Text = "Apache FOP 1.0";
            this.radioButton_fop.UseVisualStyleBackColor = true;
            this.radioButton_fop.Click += new System.EventHandler(this.radioButton_fop_CheckedChanged);
            // 
            // radioButton_renderx
            // 
            this.radioButton_renderx.AutoSize = true;
            this.radioButton_renderx.Location = new System.Drawing.Point(27, 56);
            this.radioButton_renderx.Name = "radioButton_renderx";
            this.radioButton_renderx.Size = new System.Drawing.Size(80, 20);
            this.radioButton_renderx.TabIndex = 1;
            this.radioButton_renderx.TabStop = true;
            this.radioButton_renderx.Text = "RenderX";
            this.radioButton_renderx.UseVisualStyleBackColor = true;
            this.radioButton_renderx.Click += new System.EventHandler(this.radioButton_renderx_CheckedChanged);
            // 
            // radioButton_antennahouse
            // 
            this.radioButton_antennahouse.AutoSize = true;
            this.radioButton_antennahouse.Location = new System.Drawing.Point(27, 22);
            this.radioButton_antennahouse.Name = "radioButton_antennahouse";
            this.radioButton_antennahouse.Size = new System.Drawing.Size(126, 20);
            this.radioButton_antennahouse.TabIndex = 0;
            this.radioButton_antennahouse.TabStop = true;
            this.radioButton_antennahouse.Text = "Antenna House";
            this.radioButton_antennahouse.UseVisualStyleBackColor = true;
            this.radioButton_antennahouse.CheckedChanged += new System.EventHandler(this.radioButton_antennahouse_CheckedChanged_1);
            this.radioButton_antennahouse.Click += new System.EventHandler(this.radioButton_antennahouse_CheckedChanged);
            // 
            // Xslfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl_xslfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Xslfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XSL-FO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Xslfo_FormClosing);
            this.tabControl_xslfo.ResumeLayout(false);
            this.tabPage_xslfoSingle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).EndInit();
            this.tabPage_xslfoFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback2)).EndInit();
            this.tabPage_xslfoProperties.ResumeLayout(false);
            this.tabPage_xslfoProperties.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_xslfo;
        private System.Windows.Forms.TabPage tabPage_xslfoSingle;
        private System.Windows.Forms.TabPage tabPage_xslfoFolder;
        private System.Windows.Forms.TabPage tabPage_xslfoProperties;
        private System.Windows.Forms.Button button_target;
        private System.Windows.Forms.Button button_engage_singlefo;
        private System.Windows.Forms.Button button_stylesheet;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Button button_outputFolder;
        private System.Windows.Forms.Button button_engage_folder;
        private System.Windows.Forms.Button button_outputStylesheet;
        private System.Windows.Forms.Button button_inputFolder;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButton_fop;
        private System.Windows.Forms.RadioButton radioButton_renderx;
        private System.Windows.Forms.RadioButton radioButton_antennahouse;
        private System.Windows.Forms.CheckBox checkBox_steps;
        private System.Windows.Forms.Button button_settings;
        private System.Windows.Forms.ComboBox comboBox_target;
        private System.Windows.Forms.ComboBox comboBox_stylesheet;
        private System.Windows.Forms.ComboBox comboBox_input;
        private System.Windows.Forms.ComboBox comboBox_targetFolder;
        private System.Windows.Forms.ComboBox comboBox_stylesheetFolder;
        private System.Windows.Forms.ComboBox comboBox_inputFolder;
        private System.Windows.Forms.PictureBox pictureBox_feedback;
        private System.Windows.Forms.PictureBox pictureBox_feedback2;
    }
}