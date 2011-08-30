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

        private int childCount = 0;
        // Create the Windows Forms
        public Xslt xslt = new Xslt();
        public Results results = new Results();
        public Wizard wizard = new Wizard();
        public Xslfo xslfo = new Xslfo();
        public XsdDoku xsddoku = new XsdDoku();
        public Help help = new Help();
        public ReportBug reportBug = new ReportBug();
        public Word2Gen word = new Word2Gen();
        public SyntaxHighlighting syntaxhighlighting = new SyntaxHighlighting();
        public Xproc xproc = new Xproc();
        public XsdValidate dtd = new XsdValidate();
        public SchematronValidate schematronvalidate = new SchematronValidate();
        public About about = new About();
        public XsdValidate_xsd xsd = new XsdValidate_xsd();
        public Hotfolder hotfoldForm = new Hotfolder();
        public Csv2Xml csv2xml = new Csv2Xml();
        public CheckUpdate checkupdate = new CheckUpdate();
        public Eigenschaften eigenschaften = new Eigenschaften();

        public Mainframe()
        {
           
            InitializeComponent();

            int breite = this.Size.Width;
            double placeLeft = (2 * breite) / 100;
            double placeRight = (75 * breite) / 100;

            //xslt
            xslt.MdiParent = this;
            xslt.setTextboxRange();
            xslt.Top = 50;
            xslt.Left = Convert.ToInt32(placeLeft);
            childCount++;

            //results
            results.MdiParent = this;          
            results.Top = 50;
            results.Left = Convert.ToInt32(placeRight);
            childCount++;

            //wizard
            wizard.MdiParent = this;        
            childCount++;
            wizard.Show();  
            
            //xslfo
            xslfo.MdiParent = this;           
            xslfo.Top = 50;
            xslfo.Left = Convert.ToInt32(placeLeft);
            xslfo.setTextboxRange();
            childCount++;

            //xsd doku
            xsddoku.MdiParent = this;            
            xsddoku.Top = 50;
            xsddoku.Left = Convert.ToInt32(placeLeft);
            xsddoku.setTextboxRange();
            childCount++;

            //help
            help.MdiParent = this;            
            help.Top = 50;
            help.Left = Convert.ToInt32(placeLeft);
            childCount++;

            // report bug
            reportBug.MdiParent = this;            
            reportBug.Top = 50;
            reportBug.Left = Convert.ToInt32(placeLeft);
            childCount++;
            
            //word2xml
            word.MdiParent = this;           
            word.Top = 50;
            word.Left = Convert.ToInt32(placeLeft);
            word.setTextboxRange();
            childCount++;

            //syntaxhighlighting
            syntaxhighlighting.MdiParent = this;           
            syntaxhighlighting.Top = 50;
            syntaxhighlighting.Left = Convert.ToInt32(placeLeft);
            syntaxhighlighting.setTextboxRange();
            childCount++;

            //xproc
            xproc.MdiParent = this;           
            xproc.Top = 50;
            xproc.Left = Convert.ToInt32(placeLeft);
            xproc.setTextboxRange();
            childCount++;

            //dtd
            dtd.MdiParent = this;
            dtd.Top = 50;
            dtd.Left = Convert.ToInt32(placeLeft);
            dtd.setTextboxRange();
            childCount++;

            //schematronValidate
            schematronvalidate.MdiParent = this;
            schematronvalidate.Top = 50;
            schematronvalidate.Left = Convert.ToInt32(placeLeft);
            schematronvalidate.setTextboxRange();
            childCount++;

            //about
            about.MdiParent = this;            
            about.Top = 30;
            about.Left = Convert.ToInt32(placeLeft);
            childCount++;

            //xsd
            xsd.MdiParent = this;
            xsd.Top = 50;
            xsd.Left = Convert.ToInt32(placeLeft);
            xsd.setTextboxRange();       
            childCount++;

            // Hotfolder
            hotfoldForm.MdiParent = this;
            hotfoldForm.Top = 50;
            hotfoldForm.Left = Convert.ToInt32(placeLeft);
            hotfoldForm.setTextboxRange();
            childCount++;

            //csv2xml
            csv2xml.MdiParent = this;
            csv2xml.Top = 50;
            csv2xml.Left = Convert.ToInt32(placeLeft);
            csv2xml.setTextboxRange();
            childCount++;

            //check for update
            checkupdate.MdiParent = this;
            checkupdate.Top = 50;
            checkupdate.Left = Convert.ToInt32(placeLeft);
            childCount++;

            //eigenschaften
            eigenschaften.MdiParent = this;        
            eigenschaften.Top = 50;
            eigenschaften.Left = Convert.ToInt32(placeLeft);
            childCount++;
           
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

                        results.loadText_log("Hotfolder was still active!");
                        return;
                    }

                }
                
                xslt.Hide();               
                checkupdate.Hide();              
                syntaxhighlighting.Hide();
                csv2xml.Hide();
                hotfoldForm.Hide();
                word.Hide();
                xsd.Hide();               
                xslfo.Hide();
                dtd.Hide();
                wizard.Hide();
                xproc.Hide();
                xsddoku.Hide();
                schematronvalidate.Hide();
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

               // Program.mainframe.results.loadText_log(currentVerion);
            }
            catch (Exception) {

                results.loadText_log("It seems that you don´t have Java installed on your System. Some Features only work with a propper installed Java Runtime Enviroment. For futher Details please visit our Website at: http://www.data2type.de in the antillesXML Help Section.");
                
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xSLTTransformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            xslt.Show();

            results.Show();
            results.state = true;

        }

        private void xSLFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            xslfo.Show();

            results.Show();
            results.state = true;
        }

        private void xSLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            results.tabControl.SelectedTab = results.tabPage_log;
        }

        private void resultWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

            results.tabControl.SelectedTab = results.tabPage_results;
           
        }

        private void outputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (results.state == false) {

                results.Show();
                results.state = true;
            
            }
            else if (results.state == true) {


                results.Hide();
                results.state = false;
            
            }
        }

        private void xProcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            xproc.Show();

            results.Show();
            results.state = true;
        }

        private void dTDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            dtd.Show();

            results.Show();
            results.state = true;
        }

        private void xMLSchemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            xsd.Show();

            results.Show();
            results.state = true;
        }

        private void schematronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            schematronvalidate.Show();

            results.Show();
            results.state = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.QUIT = true;

            if (Program.Config.hotfolder) 
            {

                try
                {

                    Program.hotfold.FSW_Stop();
                    Program.Config.hotfolder = true;

                }
                catch (Exception) 
                {

                    results.loadText_log("Hotfolder was still active!");
                    return;
                }
            
            }

            Application.Exit();
        }

        private void wordToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            word.Show();

            results.Show();
            results.state = true;
        }

        private void calsToHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            csv2xml.Show();

            results.Show();
            results.state = true;
        }

        private void xMLSyntaxhighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            syntaxhighlighting.Show();

            results.Show();
            results.state = true;
        }

        private void hotfolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            hotfoldForm.Show();

            results.Show();
            results.state = true;
        }

        private void aboutAntillesXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            about.Show();
            about.BringToFront();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            eigenschaften.Show();
            eigenschaften.BringToFront();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            formSwitcher();
            checkupdate.Show();
        }

        private void onlineHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            help.Show();
            help.BringToFront();
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            reportBug.Show();
            reportBug.BringToFront();
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
            xsddoku.Show();

            results.Show();
            results.state = true;
        }

        private void wizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.WINDOW_STATE = true;
            results.state = false;
            results.Hide();
            Program.mainframe.formSwitcher();
            Program.mainframe.wizard.Show();
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

            Program.QUIT = true;

            if (Program.Config.hotfolder)
            {

                try
                {

                    Program.hotfold.FSW_Stop();                    
                    Program.Config.hotfolder = false;

                }
                catch (Exception)
                {

                    results.loadText_log("Hotfolder was still active!");
                    return;
                }

            }

         //   e.Cancel = true;
            Application.Exit();
        }
    }
}
