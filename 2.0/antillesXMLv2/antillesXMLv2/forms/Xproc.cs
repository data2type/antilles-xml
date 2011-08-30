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
    public partial class Xproc : Form
    {
        public Xproc()
        {
            InitializeComponent();
            // Define Tooltips
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(button_inputFolder, "Enter a XProc File as Input");
            tooltip.SetToolTip(button_engage, "Start the Pipeline");
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


                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Text = open.FileName;
                    Program.Config.input = open.FileName;

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
            if (Program.Config.input != comboBox.Text) Program.Config.input = comboBox.Text;


            // simple error check
            if (Program.Config.input == null
                || Program.Config.input == ""
                ) { Program.plsW.Hide(); return; }

            
            // load pleasewait screen
            Thread showWaitScreen = new Thread(show);
            showWaitScreen.IsBackground = true;
            showWaitScreen.Start();

            // work
            xproc xproc = new xproc();
            xproc.doxproc(Program.Config.input, true);

            // quit waitscreen thread
            showWaitScreen.Abort();

            if (Program.Config.success)
            {
                this.pictureBox_feedback.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback.Visible = false;

            // garbage collector
            Program.plsW.Hide();
            GC.Collect(1);

        }

        private void show(Object process)
        {
            PleaseWait plsW = new PleaseWait();
            plsW.Show();
            plsW.Update();
            plsW.BringToFront();
        }

        private void button_inputFolder_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xpl files (*.xpl)|*.xpl|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Text = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();

                    Program.Config.input = open.FileName;
                    Program.Config.parameterIsSet = false;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }

        }

        //obsolet
        private void button_engageFolder_Click(object sender, EventArgs e)
        {
            //load screen
            Program.plsW.Show();
            Program.plsW.Update();
            Program.plsW.BringToFront();

            // take textboxes as final entry
            if (Program.Config.input != comboBox.Text) Program.Config.input = comboBox.Text;

            // simple error check
            if (Program.Config.input == null
                || Program.Config.input == ""
                ) { Program.plsW.Hide(); return; }

           

            // load pleasewait screen
            Thread showWaitScreen = new Thread(show);
            showWaitScreen.IsBackground = true;
            showWaitScreen.Start();

            // work
            xproc xproc = new xproc();
            xproc.doxproc(Program.Config.input, false);

            // quit waitscreen thread
            showWaitScreen.Abort();

            // garbage collector
            Program.plsW.Hide();
            GC.Collect(1);
        }

        private void Xproc_FormClosing(object sender, FormClosingEventArgs e)
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
