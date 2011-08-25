using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace antillesXMLv2
{
    public partial class Xslfo : Form
    {
        public Xslfo()
        {
            InitializeComponent();

            // Define Tooltips
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button_input, "Enter an XML Input File");
            tooltip.SetToolTip(button_inputFolder, "Enter a folder for XML Input");

            tooltip.SetToolTip(button_target, "Enter a Target File");
            tooltip.SetToolTip(button_outputFolder, "Enter a folder where the Output is written");

            tooltip.SetToolTip(button_outputStylesheet, "Enter a Stylesheet");
            tooltip.SetToolTip(button_stylesheet, "Enter a Stylesheet");

            tooltip.SetToolTip(button_engage_folder, "Start the Transformation");
            tooltip.SetToolTip(button_engage_singlefo, "Start the Transformation");

                               

            // schauen welcher formater zuletzt gewählt wurde
            // um dann den radio button im xsl-fo tab entsprechend
            // einzustellen
            switch (Properties.Settings.Default.FoFormatierer)
            {
                case "fop":
                    radioButton_fop.Checked = true;
                    button_settings.Visible = false;
                    break;
                case "antennahouse":
                    radioButton_antennahouse.Checked = true;
                    button_settings.Visible = true;
                    break;
                case "renderx":
                    radioButton_renderx.Checked = true;
                    button_settings.Visible = true;
                    break;
            }

        }

        public void setTextboxRange()
        {
            for (int i = 0; i < tabControl_xslfo.TabPages.Count; i++)
            {
                foreach (Control ctl in tabControl_xslfo.TabPages[i].Controls)
                {
                    if (ctl is ComboBox)
                    {
                        AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
                        colValues.AddRange(Program.Config.history);
                        (ctl as ComboBox).AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        (ctl as ComboBox).AutoCompleteSource = AutoCompleteSource.CustomSource;
                        (ctl as ComboBox).AutoCompleteCustomSource = colValues;
                        (ctl as ComboBox).Items.AddRange(Program.Config.history);
                    }
                }
            }
        }

        private void radioButton_antennahouse_CheckedChanged(object sender, EventArgs e)
        {
           
            Properties.Settings.Default.FoFormatierer = "antennahouse";
            button_settings.Visible = true;
            if (Properties.Settings.Default.AntennahouseLocation == "leer")
            {
                DialogResult result = MessageBox.Show("Please enter the Working Directory for Antenna House", "Enter Folder", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return; }
                else
                {
                    bool exitsflag = false;
                    string filename = "";
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.AntennahouseLocation = open.SelectedPath;                         
                            filename = Properties.Settings.Default.AntennahouseLocation + "\\XSLCmd.exe";

                            if (File.Exists(filename))
                            {
                                Properties.Settings.Default.AntennahouseLocation += "\\XSLCmd.exe";
                                exitsflag = true;
                            }
                            else 
                            {

                                filename = Properties.Settings.Default.AntennahouseLocation + "\\AHFCmd.exe";
                                if (File.Exists(filename))
                                {
                                    Properties.Settings.Default.AntennahouseLocation += "\\AHFCmd.exe";
                                    exitsflag = true;
                                }
                            
                            }                          

                        }
                    }
                    catch (Exception)
                    {
                       
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }

                    if (exitsflag)
                    {
                        Properties.Settings.Default.FoFormatierer = "antennahouse";
                    }
                    else
                    {
                        MessageBox.Show("Can´t find File XSLCmd.exe or AHFCmd.exe ", "File not found", MessageBoxButtons.OK);
                        Properties.Settings.Default.AntennahouseLocation = "empty";
                    }
                }
            }
            Properties.Settings.Default.Save();
        }
        

        private void radioButton_renderx_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.FoFormatierer = "renderx";
            button_settings.Visible = true;
            if (Properties.Settings.Default.RenderXLocation == "leer")
            {

                DialogResult result = MessageBox.Show("Please enter the Working Directory for RenderX", "Enter Folder", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return; }
                else
                {
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.RenderXLocation = open.SelectedPath;
                            Properties.Settings.Default.RenderXLocation += "\\xep.bat";
                        }
                    }
                    catch (Exception)
                    {
                      
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }

                    if (File.Exists(Properties.Settings.Default.RenderXLocation))
                    {
                        Properties.Settings.Default.FoFormatierer = "renderx";
                    }
                    else
                    {
                        MessageBox.Show("Cant find File xep.bat", "File not found", MessageBoxButtons.OK);
                        Properties.Settings.Default.RenderXLocation = "leer";
                    }
                }
            }
            Properties.Settings.Default.Save();

        }

        private void radioButton_fop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FoFormatierer = "fop";
            button_settings.Visible = false;
            Properties.Settings.Default.Save();
        }

        private void checkBox_steps_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_steps.Checked == true)
            {
                Properties.Settings.Default.KeepFoFiles = true;
            }
            else
            {
                Properties.Settings.Default.KeepFoFiles = false;
            }

            Properties.Settings.Default.Save();
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_input.Text = open.FileName;
                    Program.Config.input = open.FileName;

                    //vorschlag für result
                    comboBox_target.Text = Program.Config.input + "_result.pdf";

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_stylesheet_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xsl files (*.xsl)|*.xsl|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox_stylesheet.Text = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    Program.Config.stylesheet = open.FileName;
                    Program.Config.parameter_neuesfile = true;
                    Program.Config.parameterIsSet = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_target_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox_target.Text = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    Program.Config.target = open.FileName;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_engage_Click(object sender, EventArgs e)
        {

            //load screen
            Program.plsW.Show();
            Program.plsW.Update();
            Program.plsW.BringToFront();

            // take textboxes as final entry
            if (Program.Config.input != comboBox_input.Text) Program.Config.input = @comboBox_input.Text;
            if (Program.Config.stylesheet != comboBox_stylesheet.Text) Program.Config.stylesheet = @comboBox_stylesheet.Text;
            if (Program.Config.target != comboBox_target.Text) Program.Config.target = @comboBox_target.Text;
             

            // simple error check
            if (Program.Config.input == null
                || Program.Config.stylesheet == null
                || Program.Config.target == null
                || Program.Config.input == ""
                || Program.Config.stylesheet == ""
                || Program.Config.target == ""
                ) { Program.plsW.Hide(); return; }

       
            // do your work
            string[] fofile = { "" };
            // 1. Schritt: Transformieren zu FO
            string inputfile = Program.Config.input;
            string xsltfile = Program.Config.stylesheet;
            string fofiletarget = Program.Config.input + ".fo";

            transformer transform = new transformer();
            fofile[0] = transform.starteProzessor(inputfile, xsltfile, fofiletarget);

            // 2. Schritt: FO Stylesheet in den entsprechenden Formatierer schicken
            xslformater fo = new xslformater();
            fo.formatiere(fofile, false, Properties.Settings.Default.FoFormatierer);

            if (Program.Config.success)
            {
                this.pictureBox_feedback.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback.Visible = false;

            // quit waitscreen
            Program.plsW.Hide();

            // garbage collector
            GC.Collect(1);

        }      

        private void button_inputFolder_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.SelectedPath);
                    Properties.Settings.Default.Save();
                    comboBox_inputFolder.Text = open.SelectedPath;
                    Program.Config.input = open.SelectedPath;

                }
            }
            catch (Exception)
            {

            }
        }

        private void button_outputStylesheet_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xsl files (*.xsl)|*.xsl|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox_stylesheetFolder.Text = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    Program.Config.stylesheet = open.FileName;
                    Program.Config.parameter_neuesfile = true;
                    Program.Config.parameterIsSet = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_outputFolder_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    Properties.Settings.Default.Historie.Add(open.SelectedPath);
                    Properties.Settings.Default.Save();
                    comboBox_targetFolder.Text = open.SelectedPath;
                    Program.Config.target = open.SelectedPath;

                }
            }
            catch (Exception)
            {

            }
        }

        private void button_engage_folder_Click(object sender, EventArgs e)
        {
            //load screen
            Program.plsW.Show();
            Program.plsW.Update();
            Program.plsW.BringToFront();

            // take textboxes as final entry
            if (Program.Config.input != comboBox_inputFolder.Text) Program.Config.input = @comboBox_inputFolder.Text;
            if (Program.Config.stylesheet != comboBox_stylesheetFolder.Text) Program.Config.stylesheet = @comboBox_stylesheetFolder.Text;
            if (Program.Config.target != comboBox_targetFolder.Text) Program.Config.target = @comboBox_targetFolder.Text;
                   

            // simple error check
            if (Program.Config.input == null
                || Program.Config.stylesheet == null
                || Program.Config.target == null
                || Program.Config.input == ""
                || Program.Config.stylesheet == ""
                || Program.Config.target == ""
                ) { Program.plsW.Hide(); return; }
            
              
            
            // do your work
            // Der Quell und der Zielordner sind hier identisch, da die *.fo files neben die
            // xml quellfiles gelegt werden. 
            string[] quellfolderfiles = null;

            //prepare folder
            try
            {
                // init array
                string[] files2;

                List<string> filezList = new List<string>();
                DirectoryInfo directory = new DirectoryInfo(Program.Config.input);
                FileInfo[] filez = directory.GetFiles();

                for (int i = 0; i < filez.Length; i++)
                {
                    if (filez[i].Attributes != (FileAttributes.Hidden | FileAttributes.Archive) || (filez[i].Extension == "xml"))
                    {

                        filezList.Add(filez[i].FullName);

                    }
                }

                files2 = new string[filezList.Count];

                for (int i = 0; i < filezList.Count(); i++)
                {
                    files2[i] = filezList[i];
                }

                quellfolderfiles = files2;

            }
            catch (Exception ex)
            {

                Program.results.loadText_log(ex.Message);
                Program.plsW.Hide();
                return;

            }   

            string zielfolder = Program.Config.target;
            string xsltfile = Program.Config.stylesheet;
            // 1. Schritt: Transformieren zu FO
            transformer transform = new transformer();
            transform.starteProzessor(quellfolderfiles, zielfolder, xsltfile, ".fo");

            string[] fofiles = null;

            //prepare folder
            try
            {
                // init array
                string[] files2;

                List<string> filezList = new List<string>();
                DirectoryInfo directory = new DirectoryInfo(zielfolder);
                FileInfo[] filez = directory.GetFiles();

                for (int i = 0; i < filez.Length; i++)
                {
                    if (filez[i].Attributes != (FileAttributes.Hidden | FileAttributes.Archive) || (filez[i].Extension == "xml"))
                    {

                        filezList.Add(filez[i].FullName);

                    }
                }

                files2 = new string[filezList.Count];

                for (int i = 0; i < filezList.Count(); i++)
                {
                    files2[i] = filezList[i];
                }

                fofiles = files2;

            }
            catch (Exception ex)
            {

                Program.results.loadText_log(ex.Message);
                Program.plsW.Hide();
                return;

            }   

            // 2. Schritt: FO Stylesheet in den entsprechenden Formatierer schicken
            xslformater fo = new xslformater();
            fo.formatiere(fofiles, true, Properties.Settings.Default.FoFormatierer);

            if (Program.Config.success)
            {
                this.pictureBox_feedback2.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback2.Visible = false;

            // garbage collector
            Program.plsW.Hide(); 
            GC.Collect(1);
        }

        private void radioButton_antennahouse_CheckedChanged_1(object sender, EventArgs e)
        {
            // nothing
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            Xslfo_Settings settings = new Xslfo_Settings();
            settings.Show();
        }

        private void Xslfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Program.WINDOW_STATE = true;
            Program.results.state = false;
            Program.results.Hide();
            Program.mainframe.formSwitcher();
            Program.wizard.Show();
        }

        private void disableFeedback(object sender, EventArgs e)
        {

            for (int i = 0; i < tabControl_xslfo.TabPages.Count; i++)
            {
                foreach (Control ctl in tabControl_xslfo.TabPages[i].Controls)
                {
                    if (ctl is PictureBox)
                    {
                        Program.Config.success = false;
                        ctl.Visible = false;
                    }
                }

            }
        }
    }
}
