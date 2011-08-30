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
    public partial class Word2Gen : Form
    {
        public Word2Gen()
        {
            InitializeComponent();            
            // Define Tooltips
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button_input, "Enter an XML Input File");
            tooltip.SetToolTip(button_target, "Enter a Target");          
            tooltip.SetToolTip(button_engage, "Start the Word to Generic Transformation");

     
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
                open.Filter = "Word 2003 XML files (*.xml)|*.xml|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_input.Text = open.FileName;                   
                    Program.Config.input = open.FileName;
                    Program.Config.parameterIsSet = false;

                    //vorschlag für result
                    comboBox_target.Text = Program.Config.input + "_result.xml";
                    
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

                          
            // transform
            Program.word2gen.ausfuehren();

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

      

     

      /*

   
        private void textBox_input_DragEnter(object sender, DragEventArgs e)
        {
            // do nothing
        }

        private void textBox_input_DragDrop(object sender, DragEventArgs e)
        {

            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames) {

                FileInfo fi = new FileInfo(filename);
                if (fi.Exists) {

                    comboBox_input.Text = fi.FullName;
                
                }            
            
            }

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

       

        private void textBox_target_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {

                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                {

                   comboBox_target.Text = fi.FullName;
                    
                }

            }
        }
        */
        private void Word2Gen_FormClosing(object sender, FormClosingEventArgs e)
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
