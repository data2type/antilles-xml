namespace Antilles
{
    partial class ParameterFenster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterFenster));
            this.button_close = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.dataGridView_parameter = new System.Windows.Forms.DataGridView();
            this.Column_parametergrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parameter_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).BeginInit();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.Image = global::Antilles.Properties.Resources.closecross;
            this.button_close.Location = new System.Drawing.Point(188, 231);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(37, 25);
            this.button_close.TabIndex = 1;
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_save
            // 
            this.button_save.Image = ((System.Drawing.Image)(resources.GetObject("button_save.Image")));
            this.button_save.Location = new System.Drawing.Point(96, 231);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(37, 25);
            this.button_save.TabIndex = 2;
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // dataGridView_parameter
            // 
            this.dataGridView_parameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_parameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_parametergrid,
            this.parameter_value});
            this.dataGridView_parameter.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_parameter.Name = "dataGridView_parameter";
            this.dataGridView_parameter.Size = new System.Drawing.Size(300, 194);
            this.dataGridView_parameter.TabIndex = 3;
            // 
            // Column_parametergrid
            // 
            this.Column_parametergrid.Frozen = true;
            this.Column_parametergrid.HeaderText = "Parameter";
            this.Column_parametergrid.Name = "Column_parametergrid";
            this.Column_parametergrid.Width = 130;
            // 
            // parameter_value
            // 
            this.parameter_value.HeaderText = "Value";
            this.parameter_value.Name = "parameter_value";
            this.parameter_value.Width = 125;
            // 
            // button_clear
            // 
            this.button_clear.Image = global::Antilles.Properties.Resources.remove;
            this.button_clear.Location = new System.Drawing.Point(142, 231);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(37, 25);
            this.button_clear.TabIndex = 4;
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // ParameterFenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 275);
            this.ControlBox = false;
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.dataGridView_parameter);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ParameterFenster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parameter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_parameter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridView dataGridView_parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_parametergrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameter_value;
        private System.Windows.Forms.Button button_clear;
    }
}