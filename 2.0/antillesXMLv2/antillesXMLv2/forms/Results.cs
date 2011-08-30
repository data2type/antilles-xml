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
    public partial class Results : Form
    {
        public bool state = false;

        public Results()
        {
            InitializeComponent();          

        }

        public void loadText_log(string input)
        {
            this.richTextBox_log.AppendText("\r\n");
            this.richTextBox_log.SelectionFont = this.richTextBox_log.Font;
            this.richTextBox_log.AppendText(input);  

        }

        public void loadText_results(string input)
        {

            this.richTextBox_results.AppendText("\r\n");
            this.richTextBox_results.SelectionFont = this.richTextBox_log.Font;
            this.richTextBox_results.AppendText(input);  

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox_results.Clear();
        }

        private void Results_Click(object sender, EventArgs e)
        {
            Program.mainframe.results.Activate();
        }

        private void Results_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!Program.QUIT)
            {
                e.Cancel = true;
                state = false;
                this.Hide();
            }
           
        }

        private void Results_MouseDown(object sender, MouseEventArgs e)
        {
            this.Activate();
        }

        private void Results_Move(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "TXT file (*.txt)|*.txt";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {

                    string fileName = open.FileName;
                    richTextBox_log.SaveFile(fileName);


                }
            }
            catch (Exception) { }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "TXT file (*.txt)|*.txt";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {

                    string fileName = open.FileName;
                    richTextBox_results.SaveFile(fileName);


                }
            }
            catch (Exception) { }
        }
    }
}
