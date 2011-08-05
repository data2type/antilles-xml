﻿using System;
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
    public partial class XsdValidate_xsd : Form
    {
        public XsdValidate_xsd()
        {
            InitializeComponent();

            // Define Tooltips
            ToolTip tooltip = new ToolTip();

            tooltip.SetToolTip(button_input, "Enter an XML Input File");
            tooltip.SetToolTip(button_inputFolder, "Enter a folder for XML Input");
           
            tooltip.SetToolTip(button_outputStylesheet, "Enter a XML Schema File");
            tooltip.SetToolTip(button_stylesheet, "Enter a XML Schema File");

            tooltip.SetToolTip(button_folderenage, "Start the Transformation");
            tooltip.SetToolTip(button_engage, "Start the Transformation");
            
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
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_input.Text = open.FileName;                   
                    Program.Config.input = open.FileName;
                    
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        private void button_output_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "xsd files (*.xsd)|*.xsd|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    comboBox_stylesheet.Text = open.FileName;
                    Program.Config.stylesheet = open.FileName;
                    Program.Config.parameter_neuesfile = true;
                    Program.Config.parameterIsSet = false;
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

            // get log
            Program.results.state = true;
            Program.results.tabControl.SelectedTab = Program.results.tabPage_log;
            Program.results.Show();

            // simple error check
            if ((Program.Config.input == null || Program.Config.input == "")
                && (Program.Config.stylesheet == null || Program.Config.stylesheet == "")
                ) { Program.plsW.Hide(); return; }

            // take textboxes as final entry
            if (Program.Config.input != comboBox_input.Text) Program.Config.input = @comboBox_input.Text;
            if (Program.Config.stylesheet != comboBox_stylesheet.Text) Program.Config.stylesheet = @comboBox_stylesheet.Text;

            if (Program.Config.stylesheet == "") Program.Config.stylesheet = null;

            // work           
            Program.validate.ValidiereXMLFile(Program.Config.input, ValidationType.Schema, Program.Config.stylesheet);

            if (Program.Config.success)
            {
                this.pictureBox_feedback.Visible = true;
                Program.Config.success = false;
            }
            else this.pictureBox_feedback.Visible = false;

            // quit waitscreen thread
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
                open.Filter = "xsd files (*.xsd)|*.xsd|All files (*.*)|*.*";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    comboBox_stylesheetFolder.Text = open.FileName;
                    Properties.Settings.Default.Historie.Add(open.FileName);
                    Properties.Settings.Default.Save();
                    Program.Config.stylesheet = open.FileName;
                    Program.Config.parameter_neuesfile = true;
                    Program.Config.parameterIsSet = false;
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

            // get log
            Program.results.state = true;
            Program.results.tabControl.SelectedTab = Program.results.tabPage_log;
            Program.results.Show();

            // take textboxes as final entry
            if (Program.Config.input != comboBox_inputFolder.Text) Program.Config.input = @comboBox_inputFolder.Text;
            if (Program.Config.stylesheet != comboBox_stylesheetFolder.Text) Program.Config.stylesheet = @comboBox_stylesheetFolder.Text;
           
            // simple error check
            if ((Program.Config.input == null || Program.Config.input == "")
                && (Program.Config.stylesheet == null || Program.Config.stylesheet == "")
                ) { Program.plsW.Hide(); return; }

            if (Program.Config.stylesheet == "") Program.Config.stylesheet = null;

            // init array
            string[] files = null;

            // take textboxes as final entry
            if (Program.Config.input != comboBox_inputFolder.Text) Program.Config.input = @comboBox_inputFolder.Text;
            if (Program.Config.stylesheet != comboBox_stylesheetFolder.Text) Program.Config.stylesheet = @comboBox_stylesheetFolder.Text;


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

           
            Program.validate.ValidiereXMLFile(files, ValidationType.Schema, Program.Config.stylesheet, "null");

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

        private void textBox_stylesheet_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {

                FileInfo fi = new FileInfo(filename);
                if (fi.Exists)
                {

                   comboBox_stylesheet.Text = fi.FullName;
                   Program.Config.stylesheet = fi.FullName;
                   Program.Config.parameter_neuesfile = true;

                }

            }

        }

       

        private void textBox_inputFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string filename in fileNames)
            {
                DirectoryInfo di = new DirectoryInfo(filename);                
                if (di.Exists)
                {

                   comboBox_inputFolder.Text = di.FullName;

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

                  comboBox_stylesheetFolder.Text = fi.FullName;
                  Program.Config.stylesheet = fi.FullName;
                  Program.Config.parameter_neuesfile = true;

                }

            }
        }

        private void XsdValidate_xsd_FormClosing(object sender, FormClosingEventArgs e)
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
