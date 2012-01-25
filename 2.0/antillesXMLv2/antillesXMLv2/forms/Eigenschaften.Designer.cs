namespace antillesXMLv2
{
    partial class Eigenschaften
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eigenschaften));
            this.txt_Kommandozeilenoptionen = new System.Windows.Forms.Label();
            this.radioButton_Whitespace_ALL = new System.Windows.Forms.RadioButton();
            this.radioButton_Whitespace_Ignore = new System.Windows.Forms.RadioButton();
            this.radioButton_Whitespace_Nothing = new System.Windows.Forms.RadioButton();
            this.desc_sall = new System.Windows.Forms.Label();
            this.desc_signorable = new System.Windows.Forms.Label();
            this.desc_snone = new System.Windows.Forms.Label();
            this.desc_linkedtree = new System.Windows.Forms.Label();
            this.desc_tinytree = new System.Windows.Forms.Label();
            this.desc_w0 = new System.Windows.Forms.Label();
            this.desc_w1 = new System.Windows.Forms.Label();
            this.radioButton_linkedtree = new System.Windows.Forms.RadioButton();
            this.radioButton_TinyTree = new System.Windows.Forms.RadioButton();
            this.groupBox_Whitespace = new System.Windows.Forms.GroupBox();
            this.groupBox_datenstruktur = new System.Windows.Forms.GroupBox();
            this.desc_w2 = new System.Windows.Forms.Label();
            this.groupBox_recoverpolicy = new System.Windows.Forms.GroupBox();
            this.radioButton_w2 = new System.Windows.Forms.RadioButton();
            this.radioButton_w1 = new System.Windows.Forms.RadioButton();
            this.radioButton_w0 = new System.Windows.Forms.RadioButton();
            this.checkBox_VersionWarning = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_xml11 = new System.Windows.Forms.CheckBox();
            this.checkBox_traceextfunctions = new System.Windows.Forms.CheckBox();
            this.checkBox_explain = new System.Windows.Forms.CheckBox();
            this.checkBox_timing = new System.Windows.Forms.CheckBox();
            this.checkBox_linenumber = new System.Windows.Forms.CheckBox();
            this.desc_novw = new System.Windows.Forms.Label();
            this.desc_linenumber = new System.Windows.Forms.Label();
            this.desc_timing = new System.Windows.Forms.Label();
            this.desc_explain = new System.Windows.Forms.Label();
            this.desc_traceextfunct = new System.Windows.Forms.Label();
            this.desc_xmlver = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.groupBox_Whitespace.SuspendLayout();
            this.groupBox_datenstruktur.SuspendLayout();
            this.groupBox_recoverpolicy.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Kommandozeilenoptionen
            // 
            this.txt_Kommandozeilenoptionen.AutoSize = true;
            this.txt_Kommandozeilenoptionen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Kommandozeilenoptionen.Location = new System.Drawing.Point(18, 10);
            this.txt_Kommandozeilenoptionen.Name = "txt_Kommandozeilenoptionen";
            this.txt_Kommandozeilenoptionen.Size = new System.Drawing.Size(90, 13);
            this.txt_Kommandozeilenoptionen.TabIndex = 0;
            this.txt_Kommandozeilenoptionen.Text = "Saxon Options";
            // 
            // radioButton_Whitespace_ALL
            // 
            this.radioButton_Whitespace_ALL.AutoSize = true;
            this.radioButton_Whitespace_ALL.Location = new System.Drawing.Point(18, 20);
            this.radioButton_Whitespace_ALL.Name = "radioButton_Whitespace_ALL";
            this.radioButton_Whitespace_ALL.Size = new System.Drawing.Size(141, 17);
            this.radioButton_Whitespace_ALL.TabIndex = 1;
            this.radioButton_Whitespace_ALL.Text = "Remove Whitespace";
            this.radioButton_Whitespace_ALL.UseVisualStyleBackColor = true;
            this.radioButton_Whitespace_ALL.Click += new System.EventHandler(this.radioButton_Whitespace_ALL_CheckedChanged);
            // 
            // radioButton_Whitespace_Ignore
            // 
            this.radioButton_Whitespace_Ignore.AutoSize = true;
            this.radioButton_Whitespace_Ignore.Location = new System.Drawing.Point(18, 40);
            this.radioButton_Whitespace_Ignore.Name = "radioButton_Whitespace_Ignore";
            this.radioButton_Whitespace_Ignore.Size = new System.Drawing.Size(198, 17);
            this.radioButton_Whitespace_Ignore.TabIndex = 2;
            this.radioButton_Whitespace_Ignore.Text = "Remove ignorable Whitespace";
            this.radioButton_Whitespace_Ignore.UseVisualStyleBackColor = true;
            this.radioButton_Whitespace_Ignore.Click += new System.EventHandler(this.radioButton_Whitespace_Ignore_CheckedChanged);
            // 
            // radioButton_Whitespace_Nothing
            // 
            this.radioButton_Whitespace_Nothing.AutoSize = true;
            this.radioButton_Whitespace_Nothing.Location = new System.Drawing.Point(18, 60);
            this.radioButton_Whitespace_Nothing.Name = "radioButton_Whitespace_Nothing";
            this.radioButton_Whitespace_Nothing.Size = new System.Drawing.Size(229, 17);
            this.radioButton_Whitespace_Nothing.TabIndex = 3;
            this.radioButton_Whitespace_Nothing.Text = "Don´t remove Whitespace (default)";
            this.radioButton_Whitespace_Nothing.UseVisualStyleBackColor = true;
            this.radioButton_Whitespace_Nothing.Click += new System.EventHandler(this.radioButton_Whitespace_Nothing_CheckedChanged);
            // 
            // desc_sall
            // 
            this.desc_sall.AutoSize = true;
            this.desc_sall.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_sall.Location = new System.Drawing.Point(18, 48);
            this.desc_sall.Name = "desc_sall";
            this.desc_sall.Size = new System.Drawing.Size(31, 13);
            this.desc_sall.TabIndex = 5;
            this.desc_sall.Text = "-sall";
            // 
            // desc_signorable
            // 
            this.desc_signorable.AutoSize = true;
            this.desc_signorable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_signorable.Location = new System.Drawing.Point(18, 68);
            this.desc_signorable.Name = "desc_signorable";
            this.desc_signorable.Size = new System.Drawing.Size(71, 13);
            this.desc_signorable.TabIndex = 6;
            this.desc_signorable.Text = "-signorable";
            // 
            // desc_snone
            // 
            this.desc_snone.AutoSize = true;
            this.desc_snone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_snone.Location = new System.Drawing.Point(18, 88);
            this.desc_snone.Name = "desc_snone";
            this.desc_snone.Size = new System.Drawing.Size(46, 13);
            this.desc_snone.TabIndex = 7;
            this.desc_snone.Text = "-snone";
            // 
            // desc_linkedtree
            // 
            this.desc_linkedtree.AutoSize = true;
            this.desc_linkedtree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_linkedtree.Location = new System.Drawing.Point(18, 138);
            this.desc_linkedtree.Name = "desc_linkedtree";
            this.desc_linkedtree.Size = new System.Drawing.Size(25, 13);
            this.desc_linkedtree.TabIndex = 8;
            this.desc_linkedtree.Text = "-ds";
            // 
            // desc_tinytree
            // 
            this.desc_tinytree.AutoSize = true;
            this.desc_tinytree.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_tinytree.Location = new System.Drawing.Point(18, 158);
            this.desc_tinytree.Name = "desc_tinytree";
            this.desc_tinytree.Size = new System.Drawing.Size(23, 13);
            this.desc_tinytree.TabIndex = 9;
            this.desc_tinytree.Text = "-dt";
            this.desc_tinytree.Click += new System.EventHandler(this.desc_tinytree_Click);
            // 
            // desc_w0
            // 
            this.desc_w0.AutoSize = true;
            this.desc_w0.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_w0.Location = new System.Drawing.Point(18, 210);
            this.desc_w0.Name = "desc_w0";
            this.desc_w0.Size = new System.Drawing.Size(28, 13);
            this.desc_w0.TabIndex = 10;
            this.desc_w0.Text = "-w0";
            this.desc_w0.Click += new System.EventHandler(this.label3_Click);
            // 
            // desc_w1
            // 
            this.desc_w1.AutoSize = true;
            this.desc_w1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_w1.Location = new System.Drawing.Point(18, 230);
            this.desc_w1.Name = "desc_w1";
            this.desc_w1.Size = new System.Drawing.Size(28, 13);
            this.desc_w1.TabIndex = 11;
            this.desc_w1.Text = "-w1";
            this.desc_w1.Click += new System.EventHandler(this.label4_Click);
            // 
            // radioButton_linkedtree
            // 
            this.radioButton_linkedtree.AutoSize = true;
            this.radioButton_linkedtree.Location = new System.Drawing.Point(18, 20);
            this.radioButton_linkedtree.Name = "radioButton_linkedtree";
            this.radioButton_linkedtree.Size = new System.Drawing.Size(142, 17);
            this.radioButton_linkedtree.TabIndex = 12;
            this.radioButton_linkedtree.Text = "Linkedtree Structure";
            this.radioButton_linkedtree.UseVisualStyleBackColor = true;
            this.radioButton_linkedtree.Click += new System.EventHandler(this.radioButton_linkedtree_CheckedChanged);
            // 
            // radioButton_TinyTree
            // 
            this.radioButton_TinyTree.AutoSize = true;
            this.radioButton_TinyTree.CausesValidation = false;
            this.radioButton_TinyTree.Location = new System.Drawing.Point(18, 40);
            this.radioButton_TinyTree.Name = "radioButton_TinyTree";
            this.radioButton_TinyTree.Size = new System.Drawing.Size(182, 17);
            this.radioButton_TinyTree.TabIndex = 13;
            this.radioButton_TinyTree.Text = "Tinytree Structure (default)";
            this.radioButton_TinyTree.UseVisualStyleBackColor = true;
            this.radioButton_TinyTree.Click += new System.EventHandler(this.radioButton_TinyTree_CheckedChanged);
            // 
            // groupBox_Whitespace
            // 
            this.groupBox_Whitespace.Controls.Add(this.radioButton_Whitespace_Ignore);
            this.groupBox_Whitespace.Controls.Add(this.radioButton_Whitespace_ALL);
            this.groupBox_Whitespace.Controls.Add(this.radioButton_Whitespace_Nothing);
            this.groupBox_Whitespace.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Whitespace.Location = new System.Drawing.Point(100, 25);
            this.groupBox_Whitespace.Name = "groupBox_Whitespace";
            this.groupBox_Whitespace.Size = new System.Drawing.Size(316, 89);
            this.groupBox_Whitespace.TabIndex = 14;
            this.groupBox_Whitespace.TabStop = false;
            // 
            // groupBox_datenstruktur
            // 
            this.groupBox_datenstruktur.Controls.Add(this.radioButton_linkedtree);
            this.groupBox_datenstruktur.Controls.Add(this.radioButton_TinyTree);
            this.groupBox_datenstruktur.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_datenstruktur.Location = new System.Drawing.Point(100, 115);
            this.groupBox_datenstruktur.Name = "groupBox_datenstruktur";
            this.groupBox_datenstruktur.Size = new System.Drawing.Size(316, 70);
            this.groupBox_datenstruktur.TabIndex = 15;
            this.groupBox_datenstruktur.TabStop = false;
            // 
            // desc_w2
            // 
            this.desc_w2.AutoSize = true;
            this.desc_w2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_w2.Location = new System.Drawing.Point(18, 250);
            this.desc_w2.Name = "desc_w2";
            this.desc_w2.Size = new System.Drawing.Size(28, 13);
            this.desc_w2.TabIndex = 16;
            this.desc_w2.Text = "-w2";
            // 
            // groupBox_recoverpolicy
            // 
            this.groupBox_recoverpolicy.Controls.Add(this.radioButton_w2);
            this.groupBox_recoverpolicy.Controls.Add(this.radioButton_w1);
            this.groupBox_recoverpolicy.Controls.Add(this.radioButton_w0);
            this.groupBox_recoverpolicy.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_recoverpolicy.Location = new System.Drawing.Point(100, 187);
            this.groupBox_recoverpolicy.Name = "groupBox_recoverpolicy";
            this.groupBox_recoverpolicy.Size = new System.Drawing.Size(316, 89);
            this.groupBox_recoverpolicy.TabIndex = 17;
            this.groupBox_recoverpolicy.TabStop = false;
            // 
            // radioButton_w2
            // 
            this.radioButton_w2.AutoSize = true;
            this.radioButton_w2.Location = new System.Drawing.Point(18, 60);
            this.radioButton_w2.Name = "radioButton_w2";
            this.radioButton_w2.Size = new System.Drawing.Size(111, 17);
            this.radioButton_w2.TabIndex = 2;
            this.radioButton_w2.Text = "Do not recover";
            this.radioButton_w2.UseVisualStyleBackColor = true;
            this.radioButton_w2.Click += new System.EventHandler(this.radioButton_w2_CheckedChanged);
            // 
            // radioButton_w1
            // 
            this.radioButton_w1.AutoSize = true;
            this.radioButton_w1.Location = new System.Drawing.Point(18, 40);
            this.radioButton_w1.Name = "radioButton_w1";
            this.radioButton_w1.Size = new System.Drawing.Size(209, 17);
            this.radioButton_w1.TabIndex = 1;
            this.radioButton_w1.Text = "Recover with Warnings (default)";
            this.radioButton_w1.UseVisualStyleBackColor = true;
            this.radioButton_w1.Click += new System.EventHandler(this.radioButton_w1_CheckedChanged);
            // 
            // radioButton_w0
            // 
            this.radioButton_w0.AutoSize = true;
            this.radioButton_w0.Location = new System.Drawing.Point(18, 20);
            this.radioButton_w0.Name = "radioButton_w0";
            this.radioButton_w0.Size = new System.Drawing.Size(118, 17);
            this.radioButton_w0.TabIndex = 0;
            this.radioButton_w0.Text = "Recover Silently";
            this.radioButton_w0.UseVisualStyleBackColor = true;
            this.radioButton_w0.Click += new System.EventHandler(this.radioButton_w0_CheckedChanged);
            // 
            // checkBox_VersionWarning
            // 
            this.checkBox_VersionWarning.AutoSize = true;
            this.checkBox_VersionWarning.Location = new System.Drawing.Point(18, 20);
            this.checkBox_VersionWarning.Name = "checkBox_VersionWarning";
            this.checkBox_VersionWarning.Size = new System.Drawing.Size(160, 17);
            this.checkBox_VersionWarning.TabIndex = 18;
            this.checkBox_VersionWarning.Text = "XSLT-Version Warnings";
            this.checkBox_VersionWarning.UseVisualStyleBackColor = true;
            this.checkBox_VersionWarning.CheckedChanged += new System.EventHandler(this.checkBox_VersionWarning_CheckedChanged);
            this.checkBox_VersionWarning.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_xml11);
            this.groupBox1.Controls.Add(this.checkBox_traceextfunctions);
            this.groupBox1.Controls.Add(this.checkBox_explain);
            this.groupBox1.Controls.Add(this.checkBox_timing);
            this.groupBox1.Controls.Add(this.checkBox_linenumber);
            this.groupBox1.Controls.Add(this.checkBox_VersionWarning);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(100, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 155);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // checkBox_xml11
            // 
            this.checkBox_xml11.AutoSize = true;
            this.checkBox_xml11.Location = new System.Drawing.Point(18, 120);
            this.checkBox_xml11.Name = "checkBox_xml11";
            this.checkBox_xml11.Size = new System.Drawing.Size(75, 17);
            this.checkBox_xml11.TabIndex = 23;
            this.checkBox_xml11.Text = "XML 1.1 ";
            this.checkBox_xml11.UseVisualStyleBackColor = true;
            this.checkBox_xml11.Click += new System.EventHandler(this.checkBox_xml11_Click);
            // 
            // checkBox_traceextfunctions
            // 
            this.checkBox_traceextfunctions.AutoSize = true;
            this.checkBox_traceextfunctions.Location = new System.Drawing.Point(18, 100);
            this.checkBox_traceextfunctions.Name = "checkBox_traceextfunctions";
            this.checkBox_traceextfunctions.Size = new System.Drawing.Size(166, 17);
            this.checkBox_traceextfunctions.TabIndex = 22;
            this.checkBox_traceextfunctions.Text = "Trace external Functions";
            this.checkBox_traceextfunctions.UseVisualStyleBackColor = true;
            this.checkBox_traceextfunctions.CheckedChanged += new System.EventHandler(this.checkBox_traceextfunctions_CheckedChanged);
            this.checkBox_traceextfunctions.Click += new System.EventHandler(this.checkBox_traceextfunctions_Click);
            // 
            // checkBox_explain
            // 
            this.checkBox_explain.AutoSize = true;
            this.checkBox_explain.Location = new System.Drawing.Point(18, 80);
            this.checkBox_explain.Name = "checkBox_explain";
            this.checkBox_explain.Size = new System.Drawing.Size(175, 17);
            this.checkBox_explain.TabIndex = 21;
            this.checkBox_explain.Text = "Trace Optimiser Decicions";
            this.checkBox_explain.UseVisualStyleBackColor = true;
            this.checkBox_explain.CheckedChanged += new System.EventHandler(this.checkBox_explain_CheckedChanged);
            this.checkBox_explain.Click += new System.EventHandler(this.checkBox_explain_Click);
            // 
            // checkBox_timing
            // 
            this.checkBox_timing.AutoSize = true;
            this.checkBox_timing.Location = new System.Drawing.Point(18, 60);
            this.checkBox_timing.Name = "checkBox_timing";
            this.checkBox_timing.Size = new System.Drawing.Size(213, 17);
            this.checkBox_timing.TabIndex = 20;
            this.checkBox_timing.Text = "Show Version and Runtime Infos";
            this.checkBox_timing.UseVisualStyleBackColor = true;
            this.checkBox_timing.Click += new System.EventHandler(this.checkBox_timing_Click);
            // 
            // checkBox_linenumber
            // 
            this.checkBox_linenumber.AutoSize = true;
            this.checkBox_linenumber.Location = new System.Drawing.Point(18, 40);
            this.checkBox_linenumber.Name = "checkBox_linenumber";
            this.checkBox_linenumber.Size = new System.Drawing.Size(148, 17);
            this.checkBox_linenumber.TabIndex = 19;
            this.checkBox_linenumber.Text = "Keep Line Numbering";
            this.checkBox_linenumber.UseVisualStyleBackColor = true;
            this.checkBox_linenumber.Click += new System.EventHandler(this.checkBox_linenumber_Click);
            // 
            // desc_novw
            // 
            this.desc_novw.AutoSize = true;
            this.desc_novw.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_novw.Location = new System.Drawing.Point(18, 300);
            this.desc_novw.Name = "desc_novw";
            this.desc_novw.Size = new System.Drawing.Size(42, 13);
            this.desc_novw.TabIndex = 20;
            this.desc_novw.Text = "-novw";
            // 
            // desc_linenumber
            // 
            this.desc_linenumber.AutoSize = true;
            this.desc_linenumber.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_linenumber.Location = new System.Drawing.Point(18, 320);
            this.desc_linenumber.Name = "desc_linenumber";
            this.desc_linenumber.Size = new System.Drawing.Size(15, 13);
            this.desc_linenumber.TabIndex = 21;
            this.desc_linenumber.Text = "-l";
            // 
            // desc_timing
            // 
            this.desc_timing.AutoSize = true;
            this.desc_timing.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_timing.Location = new System.Drawing.Point(18, 340);
            this.desc_timing.Name = "desc_timing";
            this.desc_timing.Size = new System.Drawing.Size(16, 13);
            this.desc_timing.TabIndex = 22;
            this.desc_timing.Text = "-t";
            // 
            // desc_explain
            // 
            this.desc_explain.AutoSize = true;
            this.desc_explain.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_explain.Location = new System.Drawing.Point(18, 360);
            this.desc_explain.Name = "desc_explain";
            this.desc_explain.Size = new System.Drawing.Size(53, 13);
            this.desc_explain.TabIndex = 23;
            this.desc_explain.Text = "-explain";
            // 
            // desc_traceextfunct
            // 
            this.desc_traceextfunct.AutoSize = true;
            this.desc_traceextfunct.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_traceextfunct.Location = new System.Drawing.Point(18, 380);
            this.desc_traceextfunct.Name = "desc_traceextfunct";
            this.desc_traceextfunct.Size = new System.Drawing.Size(24, 13);
            this.desc_traceextfunct.TabIndex = 24;
            this.desc_traceextfunct.Text = "-TJ";
            // 
            // desc_xmlver
            // 
            this.desc_xmlver.AutoSize = true;
            this.desc_xmlver.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc_xmlver.Location = new System.Drawing.Point(18, 400);
            this.desc_xmlver.Name = "desc_xmlver";
            this.desc_xmlver.Size = new System.Drawing.Size(30, 13);
            this.desc_xmlver.TabIndex = 25;
            this.desc_xmlver.Text = "-1.1";
            // 
            // button_close
            // 
            this.button_close.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_close.Location = new System.Drawing.Point(18, 450);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(81, 25);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // Eigenschaften
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 502);
            this.Controls.Add(this.desc_xmlver);
            this.Controls.Add(this.desc_traceextfunct);
            this.Controls.Add(this.desc_explain);
            this.Controls.Add(this.desc_timing);
            this.Controls.Add(this.desc_linenumber);
            this.Controls.Add(this.desc_novw);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_recoverpolicy);
            this.Controls.Add(this.desc_w2);
            this.Controls.Add(this.groupBox_datenstruktur);
            this.Controls.Add(this.groupBox_Whitespace);
            this.Controls.Add(this.desc_w1);
            this.Controls.Add(this.desc_w0);
            this.Controls.Add(this.desc_tinytree);
            this.Controls.Add(this.desc_linkedtree);
            this.Controls.Add(this.desc_snone);
            this.Controls.Add(this.desc_signorable);
            this.Controls.Add(this.desc_sall);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.txt_Kommandozeilenoptionen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 540);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 540);
            this.Name = "Eigenschaften";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Eigenschaften_FormClosing);
            this.groupBox_Whitespace.ResumeLayout(false);
            this.groupBox_Whitespace.PerformLayout();
            this.groupBox_datenstruktur.ResumeLayout(false);
            this.groupBox_datenstruktur.PerformLayout();
            this.groupBox_recoverpolicy.ResumeLayout(false);
            this.groupBox_recoverpolicy.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_Kommandozeilenoptionen;
        private System.Windows.Forms.RadioButton radioButton_Whitespace_ALL;
        private System.Windows.Forms.RadioButton radioButton_Whitespace_Ignore;
        private System.Windows.Forms.RadioButton radioButton_Whitespace_Nothing;
        private System.Windows.Forms.Label desc_sall;
        private System.Windows.Forms.Label desc_signorable;
        private System.Windows.Forms.Label desc_snone;
        private System.Windows.Forms.Label desc_linkedtree;
        private System.Windows.Forms.Label desc_tinytree;
        private System.Windows.Forms.Label desc_w0;
        private System.Windows.Forms.Label desc_w1;
        private System.Windows.Forms.RadioButton radioButton_linkedtree;
        private System.Windows.Forms.RadioButton radioButton_TinyTree;
        private System.Windows.Forms.GroupBox groupBox_Whitespace;
        private System.Windows.Forms.GroupBox groupBox_datenstruktur;
        private System.Windows.Forms.Label desc_w2;
        private System.Windows.Forms.GroupBox groupBox_recoverpolicy;
        private System.Windows.Forms.RadioButton radioButton_w2;
        private System.Windows.Forms.RadioButton radioButton_w1;
        private System.Windows.Forms.RadioButton radioButton_w0;
        private System.Windows.Forms.CheckBox checkBox_VersionWarning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label desc_novw;
        private System.Windows.Forms.CheckBox checkBox_xml11;
        private System.Windows.Forms.CheckBox checkBox_traceextfunctions;
        private System.Windows.Forms.CheckBox checkBox_explain;
        private System.Windows.Forms.CheckBox checkBox_timing;
        private System.Windows.Forms.CheckBox checkBox_linenumber;
        private System.Windows.Forms.Label desc_linenumber;
        private System.Windows.Forms.Label desc_timing;
        private System.Windows.Forms.Label desc_explain;
        private System.Windows.Forms.Label desc_traceextfunct;
        private System.Windows.Forms.Label desc_xmlver;
        private System.Windows.Forms.Button button_close;
    }
}