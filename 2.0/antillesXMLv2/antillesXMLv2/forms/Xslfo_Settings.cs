using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace antillesXMLv2
{
    public partial class Xslfo_Settings : Form
    {
        public Xslfo_Settings()
        {
            InitializeComponent();
            
            switch (Properties.Settings.Default.FoFormatierer)
            {
                case "renderx":
                    label_formatter.Text = "Path to RenderX Commandline Executeable:";
                    textBox_formatter.Text = Properties.Settings.Default.RenderXLocation;
                    break;
                case "antennahouse":
                    label_formatter.Text = "Path to AntennaHouse Commandline Executeable:";
                    textBox_formatter.Text = Properties.Settings.Default.AntennahouseLocation;
                    break;

                case "fop":
                    textBox_formatter.Visible = false;
                    button_change.Visible = false;
                    break;
            }
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.FoFormatierer)
            {
                case "renderx":
                    try
                    {

                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {

                            textBox_formatter.Text = open.SelectedPath;
                            Properties.Settings.Default.RenderXLocation = open.SelectedPath;
                            Properties.Settings.Default.RenderXLocation += "\\xep.bat";
                            Properties.Settings.Default.Save();

                        }
                    }
                    catch (Exception)
                    {
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }
                    break;

                case "antennahouse":
                    bool exitsflag = false;
                    string filename = "";
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.AntennahouseLocation = open.SelectedPath;                         
                            filename = Properties.Settings.Default.AntennahouseLocation + "\\XSLCmd.exe";
                            textBox_formatter.Text = open.SelectedPath;

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
                        textBox_formatter.Text = "empty";
                    }               
            
                    Properties.Settings.Default.Save();
                    break;

                case "fop":                    
                    break;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
