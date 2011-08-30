namespace antillesXMLv2
{
    partial class Xslt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xslt));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Single = new System.Windows.Forms.TabPage();
            this.pictureBox_feedback = new System.Windows.Forms.PictureBox();
            this.comboBox_target = new System.Windows.Forms.ComboBox();
            this.comboBox_stylesheet = new System.Windows.Forms.ComboBox();
            this.combobox_input = new System.Windows.Forms.ComboBox();
            this.button_target = new System.Windows.Forms.Button();
            this.button_engage = new System.Windows.Forms.Button();
            this.button_stylesheet = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.Folder = new System.Windows.Forms.TabPage();
            this.pictureBox_success2 = new System.Windows.Forms.PictureBox();
            this.comboBox_targetFolder = new System.Windows.Forms.ComboBox();
            this.comboBox_stylesheetFolder = new System.Windows.Forms.ComboBox();
            this.comboBox_inputFolder = new System.Windows.Forms.ComboBox();
            this.button_outputFolder = new System.Windows.Forms.Button();
            this.button_folderenage = new System.Windows.Forms.Button();
            this.button_outputStylesheet = new System.Windows.Forms.Button();
            this.button_inputFolder = new System.Windows.Forms.Button();
            this.Pipelines = new System.Windows.Forms.TabPage();
            this.pictureBox_success3 = new System.Windows.Forms.PictureBox();
            this.comboBox_targetPipe = new System.Windows.Forms.ComboBox();
            this.comboBox_inputPipe = new System.Windows.Forms.ComboBox();
            this.dataGridView_pipeline = new System.Windows.Forms.DataGridView();
            this.Stylesheets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncludeStylesheet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button_load = new System.Windows.Forms.Button();
            this.button_savePipe = new System.Windows.Forms.Button();
            this.button_enagePipe = new System.Windows.Forms.Button();
            this.button_targetPipe = new System.Windows.Forms.Button();
            this.button_inputPipe = new System.Windows.Forms.Button();
            this.Parameters = new System.Windows.Forms.TabPage();
            this.button_saveParas = new System.Windows.Forms.Button();
            this.dataGridView_parameter = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.Single.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).BeginInit();
            this.Folder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_success2)).BeginInit();
            this.Pipelines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_success3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pipeline)).BeginInit();
            this.Parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Single);
            this.tabControl.Controls.Add(this.Folder);
            this.tabControl.Controls.Add(this.Pipelines);
            this.tabControl.Controls.Add(this.Parameters);
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
            this.Single.Controls.Add(this.comboBox_target);
            this.Single.Controls.Add(this.comboBox_stylesheet);
            this.Single.Controls.Add(this.combobox_input);
            this.Single.Controls.Add(this.button_target);
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
            // 
            // pictureBox_feedback
            // 
            this.pictureBox_feedback.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_feedback.Location = new System.Drawing.Point(319, 302);
            this.pictureBox_feedback.Name = "pictureBox_feedback";
            this.pictureBox_feedback.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_feedback.TabIndex = 17;
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
            this.comboBox_target.TabIndex = 16;
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
            this.comboBox_stylesheet.TabIndex = 15;
            this.comboBox_stylesheet.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // combobox_input
            // 
            this.combobox_input.DropDownWidth = 550;
            this.combobox_input.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_input.FormattingEnabled = true;
            this.combobox_input.Location = new System.Drawing.Point(31, 59);
            this.combobox_input.Name = "combobox_input";
            this.combobox_input.Size = new System.Drawing.Size(320, 21);
            this.combobox_input.TabIndex = 0;
            this.combobox_input.SelectedIndexChanged += new System.EventHandler(this.combobox_input_SelectedIndexChanged);
            this.combobox_input.TextChanged += new System.EventHandler(this.disableFeedback);
            this.combobox_input.Click += new System.EventHandler(this.combobox_input_Click);
            this.combobox_input.Enter += new System.EventHandler(this.combobox_input_Enter);
            // 
            // button_target
            // 
            this.button_target.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_target.Location = new System.Drawing.Point(371, 203);
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
            this.Folder.Controls.Add(this.pictureBox_success2);
            this.Folder.Controls.Add(this.comboBox_targetFolder);
            this.Folder.Controls.Add(this.comboBox_stylesheetFolder);
            this.Folder.Controls.Add(this.comboBox_inputFolder);
            this.Folder.Controls.Add(this.button_outputFolder);
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
            // pictureBox_success2
            // 
            this.pictureBox_success2.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_success2.Location = new System.Drawing.Point(319, 302);
            this.pictureBox_success2.Name = "pictureBox_success2";
            this.pictureBox_success2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_success2.TabIndex = 20;
            this.pictureBox_success2.TabStop = false;
            this.pictureBox_success2.Visible = false;
            // 
            // comboBox_targetFolder
            // 
            this.comboBox_targetFolder.DropDownWidth = 550;
            this.comboBox_targetFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_targetFolder.FormattingEnabled = true;
            this.comboBox_targetFolder.Location = new System.Drawing.Point(31, 219);
            this.comboBox_targetFolder.Name = "comboBox_targetFolder";
            this.comboBox_targetFolder.Size = new System.Drawing.Size(320, 21);
            this.comboBox_targetFolder.TabIndex = 19;
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
            this.comboBox_stylesheetFolder.TabIndex = 18;
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
            this.comboBox_inputFolder.TabIndex = 17;
            this.comboBox_inputFolder.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // button_outputFolder
            // 
            this.button_outputFolder.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_outputFolder.Location = new System.Drawing.Point(371, 203);
            this.button_outputFolder.Name = "button_outputFolder";
            this.button_outputFolder.Size = new System.Drawing.Size(75, 50);
            this.button_outputFolder.TabIndex = 13;
            this.button_outputFolder.UseVisualStyleBackColor = true;
            this.button_outputFolder.Click += new System.EventHandler(this.button_outputFolder_Click);
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
            // Pipelines
            // 
            this.Pipelines.Controls.Add(this.pictureBox_success3);
            this.Pipelines.Controls.Add(this.comboBox_targetPipe);
            this.Pipelines.Controls.Add(this.comboBox_inputPipe);
            this.Pipelines.Controls.Add(this.dataGridView_pipeline);
            this.Pipelines.Controls.Add(this.button_load);
            this.Pipelines.Controls.Add(this.button_savePipe);
            this.Pipelines.Controls.Add(this.button_enagePipe);
            this.Pipelines.Controls.Add(this.button_targetPipe);
            this.Pipelines.Controls.Add(this.button_inputPipe);
            this.Pipelines.Location = new System.Drawing.Point(4, 22);
            this.Pipelines.Name = "Pipelines";
            this.Pipelines.Padding = new System.Windows.Forms.Padding(3);
            this.Pipelines.Size = new System.Drawing.Size(476, 386);
            this.Pipelines.TabIndex = 4;
            this.Pipelines.Text = "Pipeline";
            this.Pipelines.UseVisualStyleBackColor = true;
            // 
            // pictureBox_success3
            // 
            this.pictureBox_success3.Image = global::antillesXMLv2.Properties.Resources.success;
            this.pictureBox_success3.Location = new System.Drawing.Point(171, 333);
            this.pictureBox_success3.Name = "pictureBox_success3";
            this.pictureBox_success3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_success3.TabIndex = 33;
            this.pictureBox_success3.TabStop = false;
            this.pictureBox_success3.Visible = false;
            // 
            // comboBox_targetPipe
            // 
            this.comboBox_targetPipe.DropDownWidth = 550;
            this.comboBox_targetPipe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_targetPipe.FormattingEnabled = true;
            this.comboBox_targetPipe.Location = new System.Drawing.Point(31, 109);
            this.comboBox_targetPipe.Name = "comboBox_targetPipe";
            this.comboBox_targetPipe.Size = new System.Drawing.Size(334, 21);
            this.comboBox_targetPipe.TabIndex = 32;
            this.comboBox_targetPipe.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // comboBox_inputPipe
            // 
            this.comboBox_inputPipe.DropDownWidth = 550;
            this.comboBox_inputPipe.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_inputPipe.FormattingEnabled = true;
            this.comboBox_inputPipe.Location = new System.Drawing.Point(31, 39);
            this.comboBox_inputPipe.Name = "comboBox_inputPipe";
            this.comboBox_inputPipe.Size = new System.Drawing.Size(334, 21);
            this.comboBox_inputPipe.TabIndex = 31;
            this.comboBox_inputPipe.TextChanged += new System.EventHandler(this.disableFeedback);
            // 
            // dataGridView_pipeline
            // 
            this.dataGridView_pipeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_pipeline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Stylesheets,
            this.IncludeStylesheet});
            this.dataGridView_pipeline.Location = new System.Drawing.Point(31, 152);
            this.dataGridView_pipeline.Name = "dataGridView_pipeline";
            this.dataGridView_pipeline.Size = new System.Drawing.Size(415, 157);
            this.dataGridView_pipeline.TabIndex = 27;
            this.dataGridView_pipeline.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_pipeline_CellDoubleClick);
            // 
            // Stylesheets
            // 
            this.Stylesheets.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stylesheets.HeaderText = "Stylesheets";
            this.Stylesheets.Name = "Stylesheets";
            this.Stylesheets.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // IncludeStylesheet
            // 
            this.IncludeStylesheet.HeaderText = "Include Stylesheet";
            this.IncludeStylesheet.Name = "IncludeStylesheet";
            // 
            // button_load
            // 
            this.button_load.Image = global::antillesXMLv2.Properties.Resources.load;
            this.button_load.Location = new System.Drawing.Point(209, 324);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 50);
            this.button_load.TabIndex = 30;
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_savePipe
            // 
            this.button_savePipe.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_savePipe.Location = new System.Drawing.Point(290, 324);
            this.button_savePipe.Name = "button_savePipe";
            this.button_savePipe.Size = new System.Drawing.Size(75, 50);
            this.button_savePipe.TabIndex = 29;
            this.button_savePipe.UseVisualStyleBackColor = true;
            this.button_savePipe.Click += new System.EventHandler(this.button_savePipe_Click);
            // 
            // button_enagePipe
            // 
            this.button_enagePipe.Image = global::antillesXMLv2.Properties.Resources.go;
            this.button_enagePipe.Location = new System.Drawing.Point(371, 324);
            this.button_enagePipe.Name = "button_enagePipe";
            this.button_enagePipe.Size = new System.Drawing.Size(75, 50);
            this.button_enagePipe.TabIndex = 28;
            this.button_enagePipe.UseVisualStyleBackColor = true;
            this.button_enagePipe.Click += new System.EventHandler(this.button_enagePipe_Click);
            // 
            // button_targetPipe
            // 
            this.button_targetPipe.Image = global::antillesXMLv2.Properties.Resources.target;
            this.button_targetPipe.Location = new System.Drawing.Point(371, 93);
            this.button_targetPipe.Name = "button_targetPipe";
            this.button_targetPipe.Size = new System.Drawing.Size(75, 50);
            this.button_targetPipe.TabIndex = 26;
            this.button_targetPipe.UseVisualStyleBackColor = true;
            this.button_targetPipe.Click += new System.EventHandler(this.button_targetPipe_Click);
            // 
            // button_inputPipe
            // 
            this.button_inputPipe.Image = global::antillesXMLv2.Properties.Resources.file;
            this.button_inputPipe.Location = new System.Drawing.Point(371, 23);
            this.button_inputPipe.Name = "button_inputPipe";
            this.button_inputPipe.Size = new System.Drawing.Size(75, 50);
            this.button_inputPipe.TabIndex = 24;
            this.button_inputPipe.UseVisualStyleBackColor = true;
            this.button_inputPipe.Click += new System.EventHandler(this.button_inputPipe_Click);
            // 
            // Parameters
            // 
            this.Parameters.Controls.Add(this.button_saveParas);
            this.Parameters.Controls.Add(this.dataGridView_parameter);
            this.Parameters.Location = new System.Drawing.Point(4, 22);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new System.Drawing.Size(476, 386);
            this.Parameters.TabIndex = 2;
            this.Parameters.Text = "Parameters";
            this.Parameters.UseVisualStyleBackColor = true;
            this.Parameters.Enter += new System.EventHandler(this.Parameters_Enter);
            // 
            // button_saveParas
            // 
            this.button_saveParas.Image = global::antillesXMLv2.Properties.Resources.saveas;
            this.button_saveParas.Location = new System.Drawing.Point(9, 344);
            this.button_saveParas.Name = "button_saveParas";
            this.button_saveParas.Size = new System.Drawing.Size(75, 39);
            this.button_saveParas.TabIndex = 1;
            this.button_saveParas.UseVisualStyleBackColor = true;
            this.button_saveParas.Click += new System.EventHandler(this.button_saveParas_Click);
            // 
            // dataGridView_parameter
            // 
            this.dataGridView_parameter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_parameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_parameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter,
            this.Value});
            this.dataGridView_parameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_parameter.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_parameter.Name = "dataGridView_parameter";
            this.dataGridView_parameter.Size = new System.Drawing.Size(476, 338);
            this.dataGridView_parameter.TabIndex = 0;
            this.dataGridView_parameter.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_parameter_CellContentClick);
            // 
            // Parameter
            // 
            this.Parameter.HeaderText = "Parameter";
            this.Parameter.Name = "Parameter";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Xslt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Xslt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "XSLT Transformations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Xslt_FormClosing);
            this.Load += new System.EventHandler(this.Xslt_Load);
            this.tabControl.ResumeLayout(false);
            this.Single.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_feedback)).EndInit();
            this.Folder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_success2)).EndInit();
            this.Pipelines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_success3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_pipeline)).EndInit();
            this.Parameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Single;
        private System.Windows.Forms.Button button_target;
        private System.Windows.Forms.Button button_engage;
        private System.Windows.Forms.Button button_stylesheet;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.TabPage Folder;
        private System.Windows.Forms.Button button_outputFolder;
        private System.Windows.Forms.Button button_folderenage;
        private System.Windows.Forms.Button button_outputStylesheet;
        private System.Windows.Forms.Button button_inputFolder;
        private System.Windows.Forms.TabPage Parameters;
        private System.Windows.Forms.Button button_saveParas;
        private System.Windows.Forms.DataGridView dataGridView_parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TabPage Pipelines;
        private System.Windows.Forms.Button button_targetPipe;
        private System.Windows.Forms.Button button_inputPipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stylesheets;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncludeStylesheet;
        private System.Windows.Forms.Button button_enagePipe;
        public System.Windows.Forms.DataGridView dataGridView_pipeline;
        private System.Windows.Forms.Button button_savePipe;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.ComboBox combobox_input;
        private System.Windows.Forms.ComboBox comboBox_target;
        private System.Windows.Forms.ComboBox comboBox_stylesheet;
        private System.Windows.Forms.ComboBox comboBox_targetFolder;
        private System.Windows.Forms.ComboBox comboBox_stylesheetFolder;
        private System.Windows.Forms.ComboBox comboBox_inputFolder;
        private System.Windows.Forms.ComboBox comboBox_targetPipe;
        private System.Windows.Forms.ComboBox comboBox_inputPipe;
        private System.Windows.Forms.PictureBox pictureBox_feedback;
        private System.Windows.Forms.PictureBox pictureBox_success2;
        private System.Windows.Forms.PictureBox pictureBox_success3;
      //  private System.Windows.Forms.DataGridViewTextBoxColumn Value;
      //  private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
    }
}