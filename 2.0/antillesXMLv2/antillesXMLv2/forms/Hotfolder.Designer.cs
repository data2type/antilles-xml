namespace antillesXMLv2
{
    partial class Hotfolder
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
            this.hotfolder_xslt = new System.Windows.Forms.TabPage();
            this.label_hotfolder = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_target = new System.Windows.Forms.Button();
            this.button_engage = new System.Windows.Forms.Button();
            this.button_stylesheet = new System.Windows.Forms.Button();
            this.button_input = new System.Windows.Forms.Button();
            this.tabPage_parameters = new System.Windows.Forms.TabPage();
            this.button_saveParas = new System.Windows.Forms.Button();
            this.dataGridView_parameter = new System.Windows.Forms.DataGridView();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_stylesheet = new System.Windows.Forms.ComboBox();
            this.comboBox_target = new System.Windows.Forms.ComboBox();
            this.combobox_input = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.hotfolder_xslt.SuspendLayout();
            this.tabPage_parameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.hotfolder_xslt);
            this.tabControl.Controls.Add(this.tabPage_parameters);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 412);
            this.tabControl.TabIndex = 2;
            // 
            // hotfolder_xslt
            // 
            this.hotfolder_xslt.Controls.Add(this.comboBox_stylesheet);
            this.hotfolder_xslt.Controls.Add(this.comboBox_target);
            this.hotfolder_xslt.Controls.Add(this.combobox_input);
            this.hotfolder_xslt.Controls.Add(this.label_hotfolder);
            this.hotfolder_xslt.Controls.Add(this.button_stop);
            this.hotfolder_xslt.Controls.Add(this.button_target);
            this.hotfolder_xslt.Controls.Add(this.button_engage);
            this.hotfolder_xslt.Controls.Add(this.button_stylesheet);
            this.hotfolder_xslt.Controls.Add(this.button_input);
            this.hotfolder_xslt.Location = new System.Drawing.Point(4, 22);
            this.hotfolder_xslt.Name = "hotfolder_xslt";
            this.hotfolder_xslt.Padding = new System.Windows.Forms.Padding(3);
            this.hotfolder_xslt.Size = new System.Drawing.Size(476, 386);
            this.hotfolder_xslt.TabIndex = 0;
            this.hotfolder_xslt.Text = "XSLT";
            this.hotfolder_xslt.UseVisualStyleBackColor = true;
            this.hotfolder_xslt.Click += new System.EventHandler(this.hotfolder_xslt_Click);
            // 
            // label_hotfolder
            // 
            this.label_hotfolder.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_hotfolder.Location = new System.Drawing.Point(24, 275);
            this.label_hotfolder.Name = "label_hotfolder";
            this.label_hotfolder.Size = new System.Drawing.Size(219, 93);
            this.label_hotfolder.TabIndex = 22;
            this.label_hotfolder.Text = "HOTFOLDER ACTIVE";
            this.label_hotfolder.Visible = false;
            this.label_hotfolder.Click += new System.EventHandler(this.label_hotfolder_Click);
            // 
            // button_stop
            // 
            this.button_stop.Image = global::antillesXMLv2.Properties.Resources.stop;
            this.button_stop.Location = new System.Drawing.Point(371, 299);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 50);
            this.button_stop.TabIndex = 21;
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_target
            // 
            this.button_target.Image = global::antillesXMLv2.Properties.Resources.hotfolder_save1;
            this.button_target.Location = new System.Drawing.Point(371, 123);
            this.button_target.Name = "button_target";
            this.button_target.Size = new System.Drawing.Size(75, 50);
            this.button_target.TabIndex = 20;
            this.button_target.UseVisualStyleBackColor = true;
            this.button_target.Click += new System.EventHandler(this.button_target_Click);
            // 
            // button_engage
            // 
            this.button_engage.Image = global::antillesXMLv2.Properties.Resources.start;
            this.button_engage.Location = new System.Drawing.Point(276, 299);
            this.button_engage.Name = "button_engage";
            this.button_engage.Size = new System.Drawing.Size(75, 50);
            this.button_engage.TabIndex = 18;
            this.button_engage.UseVisualStyleBackColor = true;
            this.button_engage.Click += new System.EventHandler(this.button_engage_Click);
            // 
            // button_stylesheet
            // 
            this.button_stylesheet.Image = global::antillesXMLv2.Properties.Resources.stylesheet;
            this.button_stylesheet.Location = new System.Drawing.Point(371, 203);
            this.button_stylesheet.Name = "button_stylesheet";
            this.button_stylesheet.Size = new System.Drawing.Size(75, 50);
            this.button_stylesheet.TabIndex = 17;
            this.button_stylesheet.UseVisualStyleBackColor = true;
            this.button_stylesheet.Click += new System.EventHandler(this.button_stylesheet_Click);
            // 
            // button_input
            // 
            this.button_input.Image = global::antillesXMLv2.Properties.Resources.hotfolder_icn;
            this.button_input.Location = new System.Drawing.Point(371, 43);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(75, 50);
            this.button_input.TabIndex = 16;
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // tabPage_parameters
            // 
            this.tabPage_parameters.Controls.Add(this.button_saveParas);
            this.tabPage_parameters.Controls.Add(this.dataGridView_parameter);
            this.tabPage_parameters.Location = new System.Drawing.Point(4, 22);
            this.tabPage_parameters.Name = "tabPage_parameters";
            this.tabPage_parameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_parameters.Size = new System.Drawing.Size(476, 386);
            this.tabPage_parameters.TabIndex = 1;
            this.tabPage_parameters.Text = "Parameters";
            this.tabPage_parameters.UseVisualStyleBackColor = true;
            this.tabPage_parameters.Enter += new System.EventHandler(this.tabPage_parameters_Enter);
            // 
            // button_saveParas
            // 
            this.button_saveParas.Image = global::antillesXMLv2.Properties.Resources.saveas;
            this.button_saveParas.Location = new System.Drawing.Point(6, 344);
            this.button_saveParas.Name = "button_saveParas";
            this.button_saveParas.Size = new System.Drawing.Size(75, 39);
            this.button_saveParas.TabIndex = 2;
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
            this.dataGridView_parameter.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_parameter.Name = "dataGridView_parameter";
            this.dataGridView_parameter.Size = new System.Drawing.Size(470, 338);
            this.dataGridView_parameter.TabIndex = 1;
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
            // comboBox_stylesheet
            // 
            this.comboBox_stylesheet.DropDownWidth = 550;
            this.comboBox_stylesheet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_stylesheet.FormattingEnabled = true;
            this.comboBox_stylesheet.Location = new System.Drawing.Point(31, 219);
            this.comboBox_stylesheet.Name = "comboBox_stylesheet";
            this.comboBox_stylesheet.Size = new System.Drawing.Size(320, 21);
            this.comboBox_stylesheet.TabIndex = 25;
            // 
            // comboBox_target
            // 
            this.comboBox_target.DropDownWidth = 550;
            this.comboBox_target.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_target.FormattingEnabled = true;
            this.comboBox_target.Location = new System.Drawing.Point(31, 139);
            this.comboBox_target.Name = "comboBox_target";
            this.comboBox_target.Size = new System.Drawing.Size(320, 21);
            this.comboBox_target.TabIndex = 24;
            // 
            // combobox_input
            // 
            this.combobox_input.DropDownWidth = 550;
            this.combobox_input.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_input.FormattingEnabled = true;
            this.combobox_input.Location = new System.Drawing.Point(31, 59);
            this.combobox_input.Name = "combobox_input";
            this.combobox_input.Size = new System.Drawing.Size(320, 21);
            this.combobox_input.TabIndex = 23;
            // 
            // Hotfolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 412);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Hotfolder";
            this.ShowIcon = false;
            this.Text = "Hotfolder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hotfolder_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.hotfolder_xslt.ResumeLayout(false);
            this.tabPage_parameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage hotfolder_xslt;
        private System.Windows.Forms.Button button_target;
        private System.Windows.Forms.Button button_engage;
        private System.Windows.Forms.Button button_stylesheet;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Label label_hotfolder;
        private System.Windows.Forms.TabPage tabPage_parameters;
        private System.Windows.Forms.DataGridView dataGridView_parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button button_saveParas;
        private System.Windows.Forms.ComboBox comboBox_stylesheet;
        private System.Windows.Forms.ComboBox comboBox_target;
        private System.Windows.Forms.ComboBox combobox_input;
    }
}