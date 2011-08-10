using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace antillesXMLv2
{
    public partial class Mainframe : Form
    {
        public Mainframe()
        {
            InitializeComponent();          

            int breite = this.Size.Width;
            double placeLeft = (2 * breite) / 100;
            double placeRight = (75 * breite) / 100;

            Program.wizard.TopLevel = false;
            this.Controls.Add(Program.wizard);            
            Program.wizard.Top = 90;
            Program.wizard.Left = (breite / 2) - 200;
            Program.wizard.Show();            

            
            Program.xslt.TopLevel = false;
            this.Controls.Add(Program.xslt);
            Program.xslt.Top = 50;
            Program.xslt.Left = Convert.ToInt32(placeLeft);

            Program.results.TopLevel = false;
            this.Controls.Add(Program.results);
            Program.results.Top = 50;
            Program.results.Left = Convert.ToInt32(placeRight);

            Program.xslfo.TopLevel = false;
            this.Controls.Add(Program.xslfo);
            Program.xslfo.Top = 50;
            Program.xslfo.Left = Convert.ToInt32(placeLeft);

            Program.xsddoku.TopLevel = false;
            this.Controls.Add(Program.xsddoku);
            Program.xsddoku.Top = 50;
            Program.xsddoku.Left = Convert.ToInt32(placeLeft);

            Program.help.TopLevel = false;
            this.Controls.Add(Program.help);
            Program.help.Top = 50;
            Program.help.Left = Convert.ToInt32(placeLeft);           

            Program.reportBug.TopLevel = false;
            this.Controls.Add(Program.reportBug);
            Program.reportBug.Top = 50;
            Program.reportBug.Left = Convert.ToInt32(placeLeft);
            
            Program.word.TopLevel = false;
            this.Controls.Add(Program.word);
            Program.word.Top = 50;
            Program.word.Left = Convert.ToInt32(placeLeft);

            Program.syntaxhighlighting.TopLevel = false;
            this.Controls.Add(Program.syntaxhighlighting);
            Program.syntaxhighlighting.Top = 50;
            Program.syntaxhighlighting.Left = Convert.ToInt32(placeLeft);

            Program.xproc.TopLevel = false;
            this.Controls.Add(Program.xproc);
            Program.xproc.Top = 50;
            Program.xproc.Left = Convert.ToInt32(placeLeft);

            Program.dtd.TopLevel = false;
            this.Controls.Add(Program.dtd);
            Program.dtd.Top = 50;
            Program.dtd.Left = Convert.ToInt32(placeLeft);

            Program.schematronvalidate.TopLevel = false;
            this.Controls.Add(Program.schematronvalidate);
            Program.schematronvalidate.Top = 50;
            Program.schematronvalidate.Left = Convert.ToInt32(placeLeft);

            Program.about.TopLevel = false;
            this.Controls.Add(Program.about);
            Program.about.Top = 30;
            Program.about.Left = Convert.ToInt32(placeLeft);

            Program.xsd.TopLevel = false;
            this.Controls.Add(Program.xsd);
            Program.xsd.Top = 50;
            Program.xsd.Left = Convert.ToInt32(placeLeft);

            Program.hotfoldForm.TopLevel = false;
            this.Controls.Add(Program.hotfoldForm);
            Program.hotfoldForm.Top = 50;
            Program.hotfoldForm.Left = Convert.ToInt32(placeLeft);

            Program.csv2xml.TopLevel = false;
            this.Controls.Add(Program.csv2xml);
            Program.csv2xml.Top = 50;
            Program.csv2xml.Left = Convert.ToInt32(placeLeft);

            Program.checkupdate.TopLevel = false;
            this.Controls.Add(Program.checkupdate);
            Program.checkupdate.Top = 50;
            Program.checkupdate.Left = Convert.ToInt32(placeLeft);

            Program.eigenschaften.TopLevel = false;
            this.Controls.Add(Program.eigenschaften);
            Program.eigenschaften.Top = 50;
            Program.eigenschaften.Left = Convert.ToInt32(placeLeft); 

           
            
          
        }

        // class to hide the forms if WINDOW_STATE is true
        public void formSwitcher() {

            if (Program.WINDOW_STATE) {

                if (this.Controls.Contains(Program.splash)) 
                { Program.splash.Close(); }

                if (Program.Config.hotfolder)
                {

                    try
                    {

                        Program.hotfold.FSW_Stop();
                        Program.Config.hotfolder = false;

                    }
                    catch (Exception)
                    {

                        Program.results.loadText_log("Hotfolder was still active!");
                        return;
                    }

                }
                
                Program.xslt.Hide();
                // Program.help.Hide();
                // Program.reportBug.Hide();
                Program.checkupdate.Hide();
                //  Program.about.Hide();
                Program.syntaxhighlighting.Hide();
                Program.csv2xml.Hide();
                Program.hotfoldForm.Hide();
                Program.word.Hide();
                Program.xsd.Hide();
                // Program.eigenschaften.Hide();
                Program.xslfo.Hide();
                Program.dtd.Hide();
                Program.wizard.Hide();
                Program.xproc.Hide();
                Program.xsddoku.Hide();
                Program.schematronvalidate.Hide();
                Program.WINDOW_STATE = false;

                checkJava();
                checkWorkfolder();
            }
                
        }

        // Arbeitsverzeichnis setzen
        private void checkWorkfolder()
        {

            if (Properties.Settings.Default.antilles_arbeitsordner == "unset")
            {
                try
                {
                    Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                }
                catch (Exception)
                {
                    // unwahrscheinlich das es hier abstürzt
                }
            }
            else
            {
                try
                {
                    Environment.CurrentDirectory = Properties.Settings.Default.antilles_arbeitsordner;
                }
                catch (Exception)
                {

                    Environment.CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                }

            }


        }
        // Checkt ob Java installiert ist. Falls nicht, wird ein Fehler ausgegeben.
        private void checkJava() 
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey subKey = rk.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment");

                string currentVerion = subKey.GetValue("CurrentVersion").ToString();

               // Program.results.loadText_log(currentVerion);
            }
            catch (Exception) {

                Program.results.loadText_log("It seems that you don´t have Java installed on your System. Some Features only work with a propper installed Java Runtime Enviroment. For futher Details please visit our Website at: http://www.data2type.de in the antillesXML Help Section.");
                
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xSLTTransformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.xslt.Show();

            Program.results.Show();
            Program.results.state = true;

        }

        private void xSLFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.xslfo.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void xSLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.results.tabControl.SelectedTab = Program.results.tabPage_log;
        }

        private void resultWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Program.results.tabControl.SelectedTab = Program.results.tabPage_results;
           
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.results.state == false) {

                Program.results.Show();
                Program.results.state = true;
            
            }
            else if (Program.results.state == true) {


                Program.results.Hide();
                Program.results.state = false;
            
            }
        }

        private void xProcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.xproc.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void dTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.dtd.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void xMLSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.xsd.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void schematronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.schematronvalidate.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Config.hotfolder) 
            {

                try
                {

                    Program.hotfold.FSW_Stop();
                    Program.Config.hotfolder = true;

                }
                catch (Exception) 
                {

                    Program.results.loadText_log("Hotfolder was still active!");
                    return;
                }
            
            }

            Application.Exit();
        }

        private void wordToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.word.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void calsToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.csv2xml.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void xMLSyntaxhighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.syntaxhighlighting.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void hotfolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.hotfoldForm.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void aboutAntillesXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Program.WINDOW_STATE = true;
         //   formSwitcher();
            Program.about.Show();
            Program.about.BringToFront();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.WINDOW_STATE = true;
          //  formSwitcher();
            Program.eigenschaften.Show();
            Program.eigenschaften.BringToFront();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.checkupdate.Show();
        }

        private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.WINDOW_STATE = true;
           // formSwitcher();
            Program.help.Show();
            Program.help.BringToFront();
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  Program.WINDOW_STATE = true;
          //  formSwitcher();
            Program.reportBug.Show();
            Program.reportBug.BringToFront();
        }

        private void Mainframe_Resize(object sender, EventArgs e)
        {
            // Minimize to Tray (in den Options anklickbar machen)
            /*
            if (WindowState == FormWindowState.Minimized) this.Hide();

            if (WindowState == FormWindowState.Minimized)
            {
                Hide();

                notifyIcon1.BalloonTipTitle = "antillesXML is now Minimized";
                notifyIcon1.BalloonTipText = "Your application has been minimized to the taskbar.";
                notifyIcon1.ShowBalloonTip(3000);
            }
              */
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void xSDDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            Program.xsddoku.Show();

            Program.results.Show();
            Program.results.state = true;
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            Program.results.state = false;
            Program.results.Hide();
            Program.mainframe.formSwitcher();
            Program.wizard.Show();
        }

        private void toolStripStatusLabel_TextChanged(object sender, EventArgs e)
        {
            Timer time = new Timer();
            time.Interval = 15000;
            time.Tick += new EventHandler(ChangeStatus);
            time.Start();
           
        }

        void ChangeStatus(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Ready";
        }

        private void Mainframe_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Program.Config.hotfolder)
            {

                try
                {

                    Program.hotfold.FSW_Stop();                    
                    Program.Config.hotfolder = false;

                }
                catch (Exception)
                {

                    Program.results.loadText_log("Hotfolder was still active!");
                    return;
                }

            }

         //   e.Cancel = true;
            Application.Exit();
        }
    }
}
