using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace antillesXMLv2
{
    public partial class Hotfolder : Form
    {

        private bool running = false;

        public Hotfolder()
        {
            InitializeComponent();

            // Define Tooltips
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button_input, "Enter Folder which will be the Hotfolder");
            tooltip.SetToolTip(button_target, "Enter a Folder which will be the Output Folder");           
            tooltip.SetToolTip(button_stylesheet, "Enter a Stylesheet");            
            tooltip.SetToolTip(button_engage, "Activate the Hotfolder");
            tooltip.SetToolTip(button_stop, "Deactivate the Hotfolder");
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

        private void button_target_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.SelectedPath);
                    Properties.Settings.Default.Save();
                    comboBox_target.Text = open.SelectedPath;
                    Program.Config.target = open.SelectedPath;

                }
            }
            catch (Exception)
            {

            }
        }

        private void hotfolder_xslt_Click(object sender, EventArgs e)
        {

        }

        private void button_input_Click(object sender, EventArgs e)
        {

            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.SelectedPath);
                    Properties.Settings.Default.Save();
                    combobox_input.Text = open.SelectedPath;
                    Program.Config.input = open.SelectedPath;

                }
            }
            catch (Exception)
            {

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

        private void button_engage_Click(object sender, EventArgs e)
        {

            //load screen
            Program.mainframe.menuStrip.Enabled = false;
            label_hotfolder.Visible = true;

            // take textboxes as final entry
            if (Program.Config.input != combobox_input.Text) Program.Config.input = @combobox_input.Text;
            if (Program.Config.stylesheet != comboBox_stylesheet.Text) Program.Config.stylesheet = @comboBox_stylesheet.Text;
            if (Program.Config.target != comboBox_target.Text) Program.Config.target = @comboBox_target.Text;


            // simple error check
            if (Program.Config.input == null
                || Program.Config.stylesheet == null
                || Program.Config.target == null
                || Program.Config.input == ""
                || Program.Config.stylesheet == ""
                || Program.Config.target == ""
                )
            {
                Program.plsW.Hide();
                Program.mainframe.menuStrip.Enabled = true;
                label_hotfolder.Visible = false;
                return;
            }

            Program.mainframe.results.loadText_log("Hotfolder Session started.");
                      
            // transform
            running = true;
            Program.Config.hotfolder = true;
            Program.hotfold.FSW_Init(Program.Config.input);


            // garbage collector
            GC.Collect(1);

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (running)
            {
                Program.hotfold.FSW_Stop();
                running = false;
                label_hotfolder.Visible = false;
                Program.mainframe.menuStrip.Enabled = true;
                Program.mainframe.results.loadText_log("Hotfolder Session finished.");
                Program.Config.hotfolder = false;
            }
        }

        private void label_hotfolder_Click(object sender, EventArgs e)
        {

        }

        private void Hotfolder_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!Program.QUIT)
            {
                if (Program.Config.hotfolder)
                {

                    try
                    {

                        Program.hotfold.FSW_Stop();
                        Program.mainframe.results.loadText_log("Hotfolder Session finished");
                        Program.Config.hotfolder = false;

                    }
                    catch (Exception)
                    {

                        Program.mainframe.results.loadText_log("Hotfolder still active!");

                    }

                }

                e.Cancel = true;
                Program.WINDOW_STATE = true;
                Program.mainframe.results.state = false;
                Program.mainframe.results.Hide();
                Program.mainframe.formSwitcher();
                Program.mainframe.wizard.Show();
            }
           
        }

        private void button_saveParas_Click(object sender, EventArgs e)
        {
            if (Program.Config.parameterIsSet == false)
            {
                Program.mainframe.results.loadText_log("Parameters not saved. Please assign or reassign a Stylesheet.");
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
            if (check) { Program.mainframe.results.loadText_log("Parameters saved"); check = false; }
        }

        private void tabPage_parameters_Enter(object sender, EventArgs e)
        {
            dataGridView_parameter.Rows.Clear();

            if (Program.Config.parameterIsSet == false) {

                Program.mainframe.results.loadText_log("Please assign or reassign a Stylesheet.");
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
    }

}

