namespace antillesXMLv2
{
    partial class Results
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
            this.tabPage_log = new System.Windows.Forms.TabPage();
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_results = new System.Windows.Forms.TabPage();
            this.richTextBox_results = new System.Windows.Forms.RichTextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPage_log.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage_results.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_log);
            this.tabControl.Controls.Add(this.tabPage_results);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 512);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_log
            // 
            this.tabPage_log.Controls.Add(this.richTextBox_log);
            this.tabPage_log.Controls.Add(this.menuStrip1);
            this.tabPage_log.Location = new System.Drawing.Point(4, 22);
            this.tabPage_log.Name = "tabPage_log";
            this.tabPage_log.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_log.Size = new System.Drawing.Size(476, 486);
            this.tabPage_log.TabIndex = 0;
            this.tabPage_log.Text = "Log";
            this.tabPage_log.UseVisualStyleBackColor = true;
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_log.Location = new System.Drawing.Point(3, 27);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(470, 456);
            this.richTextBox_log.TabIndex = 0;
            this.richTextBox_log.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(470, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tabPage_results
            // 
            this.tabPage_results.Controls.Add(this.richTextBox_results);
            this.tabPage_results.Controls.Add(this.menuStrip2);
            this.tabPage_results.Location = new System.Drawing.Point(4, 22);
            this.tabPage_results.Name = "tabPage_results";
            this.tabPage_results.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_results.Size = new System.Drawing.Size(476, 486);
            this.tabPage_results.TabIndex = 1;
            this.tabPage_results.Text = "Results";
            this.tabPage_results.UseVisualStyleBackColor = true;
            // 
            // richTextBox_results
            // 
            this.richTextBox_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_results.Location = new System.Drawing.Point(3, 27);
            this.richTextBox_results.Name = "richTextBox_results";
            this.richTextBox_results.Size = new System.Drawing.Size(470, 456);
            this.richTextBox_results.TabIndex = 0;
            this.richTextBox_results.Text = "";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem1,
            this.saveToolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(470, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 512);
            this.Controls.Add(this.tabControl);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Results";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Statistics";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Results_FormClosing);
            this.Click += new System.EventHandler(this.Results_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Results_MouseDown);
            this.Move += new System.EventHandler(this.Results_Move);
            this.tabControl.ResumeLayout(false);
            this.tabPage_log.ResumeLayout(false);
            this.tabPage_log.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage_results.ResumeLayout(false);
            this.tabPage_results.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.TabPage tabPage_log;
        public System.Windows.Forms.TabPage tabPage_results;
        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.RichTextBox richTextBox_results;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;


    }
}