using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Saxon.Api;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace antillesXMLv2
{
    public partial class Xslt : Form
    {

        public Xslt()
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

            tooltip.SetToolTip(button_folderenage, "Start the Transformation");
            tooltip.SetToolTip(button_engage, "Start the Transformation");

            tooltip.SetToolTip(button_inputPipe, "Enter an XML Input File");
            tooltip.SetToolTip(button_targetPipe, "Enter a Target File");
            tooltip.SetToolTip(button_savePipe, "Save this Pipeline");
            tooltip.SetToolTip(button_load, "Load a Pipeline from a File");
            tooltip.SetToolTip(button_enagePipe, "Start Pipeline");



            tooltip.SetToolTip(button_saveParas, "Save the Parameters");

        }

        public void setTextboxRange()
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                foreach (Control ctl in tabControl.TabPages[i].Controls)
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

        private void button_input_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    combobox_input.Text = open.FileName;
                    Program.Config.input = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();

                }
            }
            catch (Exception ex)
            {
                Program.results.loadText_log(ex.Message);
            }
        }

        private void button_output_Click(object sender, EventArgs e)
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
                open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    comboBox_target.Text = open.FileName;
                    Program.Config.target = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
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
            if (Program.Config.input != combobox_input.Text) Program.Config.input = combobox_input.Text;
            if (Program.Config.stylesheet != comboBox_stylesheet.Text) Program.Config.stylesheet = comboBox_stylesheet.Text;
            if (Program.Config.target != comboBox_target.Text) Program.Config.target = comboBox_target.Text;

            // simple error check
            if (Program.Config.input == null
                || Program.Config.stylesheet == null
                || Program.Config.target == null
                || Program.Config.input == ""
                || Program.Config.stylesheet == ""
                || Program.Config.target == ""
                ) { Program.plsW.Hide(); return; }


            // transform
            Program.transform.starteProzessor(Program.Config.input, Program.Config.stylesheet, Program.Config.target);

            if (Program.Config.success)
            {
                this.pictureBox_feedback.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback.Visible = false;

            // garbage collector
            GC.Collect(1);
            Program.plsW.Hide();

        }



        private void Single_Click(object sender, EventArgs e)
        {

        }

        private void button_inputFolder_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

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

        private void button_folderenage_Click(object sender, EventArgs e)
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

            // init array
            string[] files = null;

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

                files = files2;

            }
            catch (Exception ex)
            {

                Program.results.loadText_log(ex.Message);
                Program.plsW.Hide();
                return;

            }


            // transform
            transformer Transform = new transformer();
            Transform.starteProzessor(files, Program.Config.target, Program.Config.stylesheet, "");

            if (Program.Config.success)
            {
                this.pictureBox_success2.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_success2.Visible = false;


            //close loadscreen
            Program.plsW.Hide();

            // garbage collector
            GC.Collect(1);
        }

        private void button_outputFolder_Click(object sender, EventArgs e)
        {

            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    comboBox_targetFolder.Text = open.SelectedPath;
                    Program.Config.target = open.SelectedPath;

                }
            }
            catch (Exception)
            {

            }

        }

        /*

         * Drag n Drop Funktionen
         * 
         * 
         * 
        private void textBox_input_DragEnter(object sender, DragEventArgs e)
        {
            // do nothing
        }

        private void textBox_input_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textBox_input_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
            e.Effect = DragDropEffects.Copy;
            
            }

            else {
            
            e.Effect = DragDropEffects.None;
            
            }
        }

        private void textBox_stylesheet_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textBox_target_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textBox_inputFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {
                DirectoryInfo di = new DirectoryInfo(filename);                
                if (di.Exists)
                {

                   textBox_inputFolder.Text = di.FullName;

                }

            }
        }

        private void textBox_outputFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {
                DirectoryInfo di = new DirectoryInfo(filename);
                if (di.Exists)
                {

                   textBox_outputFolder.Text = di.FullName;

                }

            }
        }

        private void textBox2_folderStylesheet_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {

                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                {

                  textBox2_folderStylesheet.Text = fi.FullName;
                  Program.Config.stylesheet = fi.FullName;
                  Program.Config.parameter_neuesfile = true;

                }

            }
        }
         
        */
        private void Parameters_Enter(object sender, EventArgs e)
        {

            dataGridView_parameter.Rows.Clear();

            if (Program.Config.piplelineaktiv)
            {
                for (int i = 0; i < dataGridView_pipeline.RowCount; i++)
                {

                    transformer Transform = new transformer();
                    if (dataGridView_pipeline["Stylesheets", i].Value != null)
                    {
                        Transform.getParameter(dataGridView_pipeline["Stylesheets", i].Value.ToString());
                    }

                }
                Program.Config.parameter_neuesfile = false;
                Program.Config.piplelineaktiv = false;
            }

            if (Program.Config.parameterIsSet == false)
            {
                // Program.results.loadText_log("Please assign or reassign a Stylesheet.");
                return;
            }

            if (Program.Config.parameter_neuesfile)
            {
                transformer Transform = new transformer();
                Transform.getParameter(Program.Config.stylesheet);
                Program.Config.parameter_neuesfile = false;

            }

            if (Program.Config.parameters.Count > 0)
            {
                dataGridView_parameter.Rows.Add(Program.Config.parameters.Count);
                for (int i = 0; i < Program.Config.parameters.Count; i++)
                {

                    dataGridView_parameter["Parameter", i].Value = Convert.ToString(Program.Config.parameters[i].param);
                    dataGridView_parameter["Value", i].Value = Convert.ToString(Program.Config.parameters[i].value);

                }
            }
        }

        private void button_saveParas_Click(object sender, EventArgs e)
        {

            if (Program.Config.parameterIsSet == false)
            {
                Program.results.loadText_log("Parameters not saved. Please assign or reassign a Stylesheet.");
                return;
            }

            bool check = false;

            Program.Config.parameters.Clear();
            for (int i = 0; i < dataGridView_parameter.RowCount; i++)
            {
                if ((dataGridView_parameter["Parameter", i].Value != null)
                    && (dataGridView_parameter["Value", i].Value != null))
                {

                    parameter Item = new parameter();
                    Item.param = dataGridView_parameter["Parameter", i].Value.ToString();
                    Item.value = dataGridView_parameter["Value", i].Value.ToString();
                    Program.Config.parameters.Add(Item);
                    check = true;
                }
            }
            if (check) { Program.results.loadText_log("Parameters saved"); check = false; }
        }

        private void Xslt_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Program.WINDOW_STATE = true;
            Program.results.state = false;
            Program.results.Hide();
            Program.mainframe.formSwitcher();
            Program.wizard.Show();
        }

        private void Xslt_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_parameter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void xmlfile_pipe_input_Click(object sender, EventArgs e)
        {

        }

        private void button_zieldatei_Click(object sender, EventArgs e)
        {

        }

        private void xslt_btn_pipe_Click(object sender, EventArgs e)
        {

        }




        private void dataGridView_pipeline_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_pipeline_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 1) return;

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xsl files (*.xsl)|*.xsl|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    dataGridView_pipeline["Stylesheets", e.RowIndex].Value = open.FileName;

                    Program.Config.stylesheet = open.FileName;
                    Program.Config.piplelineaktiv = true;
                    Program.Config.parameterIsSet = true;



                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_xsltpipe_engage_Click(object sender, EventArgs e)
        {

        }

        private void button_enagePipe_Click(object sender, EventArgs e)
        {
            //load screen
            Program.plsW.Show();
            Program.plsW.Update();
            Program.plsW.BringToFront();

            List<string> thePipeLineList = new List<string>();
            for (int i = 0; i < dataGridView_pipeline.RowCount; i++)
            {


                if (dataGridView_pipeline["IncludeStylesheet", i].Value != null)
                {

                    thePipeLineList.Add(dataGridView_pipeline["Stylesheets", i].Value.ToString());

                }


            }
            try
            {
                string pipe = Program.Config.input;
                string tempTarget = Path.GetTempFileName();

                for (int i = 0; i < thePipeLineList.Count - 1; i++)
                {
                    pipe = Program.transform.starteProzessor(pipe, thePipeLineList[i], tempTarget);
                    tempTarget = Path.GetTempFileName();
                }

                Program.transform.starteProzessor(pipe, thePipeLineList[thePipeLineList.Count - 1], Program.Config.target);
            }

            catch (Exception) { }

            if (Program.Config.success)
            {
                this.pictureBox_success3.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_success3.Visible = false;

            // garbage collector
            GC.Collect(1);
            Program.plsW.Hide();


        }

        private void button_inputPipe_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    comboBox_inputPipe.Text = open.FileName;
                    Program.Config.input = open.FileName;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_targetPipe_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    comboBox_targetPipe.Text = open.FileName;
                    Program.Config.target = open.FileName;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_savePipe_Click(object sender, EventArgs e)
        {

            string target = "";
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    target = open.FileName;
                    List<String> Config = new List<string>();
                    Config.Add(Program.Config.input);
                    Config.Add(Program.Config.target);

                    for (int i = 0; i < dataGridView_pipeline.RowCount; i++)
                    {
                        if (dataGridView_pipeline["Stylesheets", i].Value != null)
                        {
                            Config.Add(dataGridView_pipeline["Stylesheets", i].Value.ToString());
                        }
                    }

                    XmlSerializer ser = new XmlSerializer(typeof(List<String>));
                    FileStream str = new FileStream(target, FileMode.Create);
                    ser.Serialize(str, Config);
                    str.Close();
                }
            }
            catch (Exception)
            {
                // setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt(DateTime.Now.ToString());                
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {


            string target = "";

            try
            {
                dataGridView_pipeline.Rows.Clear();
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    target = open.FileName;
                    List<String> Config = new List<string>();
                    XmlSerializer ser = new XmlSerializer(typeof(List<String>));
                    StreamReader sr = new StreamReader(target);
                    Config = (List<string>)ser.Deserialize(sr);
                    sr.Close();

                    if (Config.Count > 3)
                    {

                        dataGridView_pipeline.Rows.Add(Config.Count - 3);

                    }


                    for (int i = 0; i < Config.Count; i++)
                    {
                        if (i == 0)
                        {
                            Program.Config.input = Config[0];
                            comboBox_inputPipe.Text = Config[0];
                        }
                        else if (i == 1)
                        {
                            comboBox_targetPipe.Text = Config[1];
                            Program.Config.target = Config[1];
                        }

                        else
                        {
                            dataGridView_pipeline["Stylesheets", i - 2].Value = Config[i];
                            dataGridView_pipeline["IncludeStylesheet", i - 2].Value = true;
                            Program.Config.piplelineaktiv = true;
                        }

                    }


                }

            }

            catch (Exception)
            {
                Program.results.loadText_log("Loading failed");
            }
        }

        private void textBox_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void combobox_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void disableFeedback(object sender, EventArgs e)
        {

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                foreach (Control ctl in tabControl.TabPages[i].Controls)
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
