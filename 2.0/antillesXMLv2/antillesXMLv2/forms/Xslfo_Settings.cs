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
    public partial class Xslfo_Settings : Form
    {
        public Xslfo_Settings()
        {
            InitializeComponent();
            
            switch (Properties.Settings.Default.FoFormatierer)
            {
                case "renderx":
                    label_formatter.Text = " RenderX Working Directory:";
                    textBox_formatter.Text = Properties.Settings.Default.RenderXLocation;
                    break;
                case "antennahouse":
                    label_formatter.Text =  "Antenna House Working Directory:";
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
                    try
                    {

                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {

                            textBox_formatter.Text = open.SelectedPath;
                            Properties.Settings.Default.AntennahouseLocation = open.SelectedPath;
                            Properties.Settings.Default.AntennahouseLocation += "\\XSLCmd.exe";
                            Properties.Settings.Default.Save();

                        }
                    }
                    catch (Exception)
                    {
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }
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
