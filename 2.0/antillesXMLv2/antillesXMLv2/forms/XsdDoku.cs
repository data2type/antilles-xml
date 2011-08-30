using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Diagnostics;
using System.Threading;
using System.Reflection;  

namespace antillesXMLv2
{
    public partial class XsdDoku : Form
    {
        public XsdDoku()
        {
            InitializeComponent();

            // Checkboxen prüfen ob html im browser direkt angezeigt wird
            // heisst hier schematron obwohl es sich um schema dreht
            // denkfehler ... 
            switch (Properties.Settings.Default.Schematronberichtbrowser)
            {

                case true:
                    checkBox.CheckState = CheckState.Checked;
                    break;

                case false:
                    checkBox.CheckState = CheckState.Unchecked;
                    break;

            }

            // Define Tooltips
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button_input, "Enter an XSD Input File");           

            tooltip.SetToolTip(button_target, "Enter a Target");
            
            tooltip.SetToolTip(button_engage, "Create Docu");

       
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
                open.Filter = "xsd files (*.xsd)|*.xsd|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_input.Text = open.FileName;
                    Program.Config.input = open.FileName;
                    Program.Config.parameterIsSet = false;

                    //vorschlag für result
                    comboBox_target.Text = Program.Config.input + "_result.html";

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
                open.Filter = "html files (*.html)|*.html|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_target.Text = open.FileName;
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
            if (Program.Config.target != comboBox_target.Text) Program.Config.target = @comboBox_target.Text;


            // simple error check
            if (Program.Config.input == null
                || Program.Config.target == null
                || Program.Config.target == ""
                || Program.Config.input == ""
                ) { Program.plsW.Hide(); return; }

          
            string fileName = Path.Combine(Application.StartupPath, "lib\\xs3p\\");
            string xs3pschema = fileName + "xs3p.xsl";

            Program.transform.starteProzessor(Program.Config.input, xs3pschema, Program.Config.target);
            
            // Im Browser anzeigen?
            try
            {
                if (Properties.Settings.Default.Schematronberichtbrowser) Process.Start(Program.Config.target);
            }
            catch (Exception)
            {

              //  setLogTxt(ex.Message);

            }

            if (Program.Config.success)
            {
                this.pictureBox_feedback.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback.Visible = false;

            Program.plsW.Hide();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                checkBox.Checked = true;
                Properties.Settings.Default.Schematronberichtbrowser = true;
            }
            else
            {
                Properties.Settings.Default.Schematronberichtbrowser = false;
                checkBox.Checked = false;
            }
            Properties.Settings.Default.Save();
        }

        private void SyntaxHighlighting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.QUIT)
            {
                e.Cancel = true;
                Program.WINDOW_STATE = true;
                Program.mainframe.results.state = false;
                Program.mainframe.results.Hide();
                Program.mainframe.formSwitcher();
                Program.mainframe.wizard.Show();
            }
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
