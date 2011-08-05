// ------------------------------------------------------------------------ //
// Hauptfenster                                                             //
//                                                                          //
//                                                                          //     
// Da das Programm in Tabs aufgeteilt ist, wird hier durch Kommentare       //
// der jeweilige Abschnitt gekennzeichnet                                   //
//                                                                          //
//                                                                          //
// ------------------------------------------------------------------------ //

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


namespace Antilles
{

    public partial class Hauptfenster : Form
    {

        // ---- ALLGEMEINER BEREICH ---->

        ArrayList textboxnamelist = new ArrayList();
        xsltpipe Xsltpipe = new xsltpipe();
        public bool ordneranlegen = false;
        private static Mutex mutex_messages = new Mutex();
        // Für Threadzugriffe von "aussen" im Log
        protected delegate void LogData(string input);

        // Tooltips
        ToolTip tooltip = new ToolTip();

        private void initTooltips() 
        {
            // Einzeltransformationen
            tooltip.SetToolTip(btn_transform, "Transformation starten");
            tooltip.SetToolTip(btn_xml, "XML-Dokument festlegen");
            tooltip.SetToolTip(btn_xslt, "XSLT-Dokument festlegen");
            tooltip.SetToolTip(button_parameterxsltsingle, "Parameter öffnen");
            tooltip.SetToolTip(button_zieldatei_transformation, "Ziel festlegen");
            // Tooltips Ordnerweise Transformation
            tooltip.SetToolTip(btn_ausgang, "Ziel Ordner festlegen");
            tooltip.SetToolTip(btn_ordnertrans, "Ordnerweise Transformation starten");
            tooltip.SetToolTip(btn_ordnerdirinput, "Eingangs Ordner festlegen");            
            tooltip.SetToolTip(btn_xsltordner, "XSLT-Dokument festlegen");
            tooltip.SetToolTip(button_parameterxsltordner, "Parameter öffnen");
            // Cals2Html
            tooltip.SetToolTip(button_cals2html_engage, "Umwandlung starten");
            tooltip.SetToolTip(button_cals2html_input, "Eingangs Dokument festlegen");
            tooltip.SetToolTip(button_cals2html_stylesheet, "XSLT-Dokument festlegen");
            // Validierungen
            tooltip.SetToolTip(button_dtd, "DTD festlegen");
            tooltip.SetToolTip(button_xmlvalueordner, "Ordner festlegen");
            tooltip.SetToolTip(button_xmlschemainput, "XML Schema Dokument festlegen");
            tooltip.SetToolTip(button_xmlvalidinput, "XML-Dokument festlegen");         
            tooltip.SetToolTip(button_new, "Step hinzufügen");
            tooltip.SetToolTip(button_validiere_xmlschema, "Validierung starten");
            // XSL-FO
            tooltip.SetToolTip(button_fo_xmlfile_input, "XML-Dokument festlegen");
            tooltip.SetToolTip(button_xslfo_ziel, "Ziel festlegen");
            tooltip.SetToolTip(button_xslo_engage, "Formatierung durchführen");
            tooltip.SetToolTip(button_xsltfo_folder, "Ordner auswählen");
            tooltip.SetToolTip(button_xsltfo_stylesheet, "XSLT-Dokument auswählen");
            // Schematron
            tooltip.SetToolTip(button_schematron_engage, "Schematron ausführen");
            tooltip.SetToolTip(button_schematron_input, "Eingangs Dokument festlegen");
            tooltip.SetToolTip(button_schema_buttn, "Ordner auswählen");
            // XML darstellen                      
            tooltip.SetToolTip(button_xml_schematron_input, "XML-Dokument festlegen");
            tooltip.SetToolTip(button_xmlberichtengage, "XML Ansicht erzeugen");
            tooltip.SetToolTip(button_xmlberichtquelle, "XML-Dokument festlegen");
            tooltip.SetToolTip(button_xmlberichtziel, "Ziel festlegen");            
            // XSLT Pipeline
            tooltip.SetToolTip(button_parameterxsltpipe, "Parameter öffnen");
            tooltip.SetToolTip(button_config_load, "Pipelineaufbau laden");
            tooltip.SetToolTip(button_config_save, "Pipelineaufbau speichern");
            tooltip.SetToolTip(button_xsltpipe_engage, "Pipe ausführen");            
            tooltip.SetToolTip(button_zieldatei, "Ziel festlegen");
            tooltip.SetToolTip(xmlfile_pipe_input, "XML-Dokument festlegen");
            tooltip.SetToolTip(xslt_btn_pipe, "XSLT-Dokument festlegen");
            // Log
            tooltip.SetToolTip(button_speichern, "Log Speichern");
            tooltip.SetToolTip(button_flush, "Log leeren");
            // XProc
            tooltip.SetToolTip(button_xproc_engage, "XProc durchführen");
            tooltip.SetToolTip(button_xprocinput_file, "XPL-Dokument festlegen");
            tooltip.SetToolTip(button_xprocinput_folder, "Ordner festlegen");
            // Schemabericht erstellen
            tooltip.SetToolTip(button_xsd_bericht_engage, "Schemabericht erstellen");
            tooltip.SetToolTip(button_xsdbericht_ziel, "Ziel festlegen");
            tooltip.SetToolTip(xsd_bericht_input, "Schema-Dokument festlegen");      
            // Hotfolder
            tooltip.SetToolTip(button_hotfolder_input, "Hotfolder festlegen");
            tooltip.SetToolTip(button_hotfolder_parameter, "Parameter festlegen");
            tooltip.SetToolTip(button_hotfolder_starten, "Hotfolder aktiv schalten");
            tooltip.SetToolTip(button_hotfolder_stylesheet, "XSLT-Dokument festlegen");
            tooltip.SetToolTip(button_hotfolder_ziel, "Ziel Ordner auswählen");
            tooltip.SetToolTip(button_hotfolder_stop, "Hotfolder ausschalten");
            
        }
        

        // wichtig für den startup, da sonst fehlermeldungen entstehen könnten
        bool initradiofo = true;

        // boolsche Variable für die Verhaltenslogik des Programms
        // wird auf true gesetzt, wenn eine DTD mitgegeben wird
        private bool DTD = false;
        public bool dtdisset
        {
            get
            {
                return DTD;
            }

            set
            {
                DTD = value;
            }
        }

        // boolsche Variable für die Verhaltenslogik des Programms
        // wird auf true gesetzt, wenn ein Ordner abgearbeitet werden soll
        private bool XMLfolder = false;
        public bool xmlfolder
        {
            get
            {
                return XMLfolder;
            }

            set
            {
                XMLfolder = value;
            }
        }

        // Konstruktor der Hauptform ...
        public Hauptfenster()
        {
            InitializeComponent();


            // Arbeitsverzeichnis setzen ...
            checkWorkfolder();            
           
            // Tooltips setzen
            initTooltips();

            // schauen welcher formater zuletzt gewählt wurde
            // um dann den radio button im xsl-fo tab entsprechend
            // einzustellen
            switch (Properties.Settings.Default.FoFormatierer)
            {
                case "fop":
                    radioButton_formaterfop.Checked = true;
                    break;
                case "antennahouse":
                    radioButton_formatterantennahouse.Checked = true;
                    break;
                case "renderx":
                    radioButton_formatterxep.Checked = true;
                    break;
            }

            // schauen ob fo files behalten werden sollen oder nicht
            // je nach einstellung wird die checkbox geschaltet
            switch (Properties.Settings.Default.KeepFoFiles)
            {

                case true:
                    checkBox_keepfos.Checked = true;
                    break;

                case false:
                    checkBox_keepfos.Checked = false;
                    break;

            }

            // Checkboxen prüfen ob html im browser direkt angezeigt wird
            switch (Properties.Settings.Default.Cals2htmlberichtbrowser)
            {

                case true:
                    checkBox_cals2htmlbrowser.CheckState = CheckState.Checked;
                    break;

                case false:
                    checkBox_cals2htmlbrowser.CheckState = CheckState.Unchecked;
                    break;

            }

            // Checkboxen prüfen ob html im browser direkt angezeigt wird
            switch (Properties.Settings.Default.Schematronberichtbrowser)
            {

                case true:
                    checkBox_berichtimbrowseranzeigen.CheckState = CheckState.Checked;
                    break;

                case false:
                    checkBox_berichtimbrowseranzeigen.CheckState = CheckState.Unchecked;
                    break;

            }

            // Checkboxen prüfen ob html im browser direkt angezeigt wird (Xml darstellen)
            switch (Properties.Settings.Default.XMLdarstellenbrowser)
            {

                case true:
                    checkBox_xmlberichtbrowser.CheckState = CheckState.Checked;
                    break;

                case false:
                    checkBox_xmlberichtbrowser.CheckState = CheckState.Unchecked;
                    break;

            }

            // auf false stellen, damit die fo radiobuttons funktionieren
            // wahrscheinlich nicht mehr notwendig. bei gelegenheit testen.
            initradiofo = false;

            this.progressBar.Maximum = 200;

        }

        // Wird geladen wenn die Tabform erzeugt wird 
        private void tabControl_Enter(object sender, EventArgs e)
        {
            // Javatestresultate abfangen und eventuelle Fehler ausgeben
            switch (Program.tester.java)
            {
                case true: break;

                case false:
                    MessageBox.Show("Sie haben kein Java installiert. Einige Funktionen von AntillesXML werden nicht funktionieren. Diese werden deaktiviert. Bitte installieren sie Java und starten dann AntillesXML erneut. http://www.java.com/de/", "Achtung", MessageBoxButtons.OK);
                    tabControl.TabPages.Remove(tabPage_fo);
                    tabControl.TabPages.Remove(tabPage_xproc);
                    break;
            }

            // Internettest abfangen und Infotafel ausgeben
            switch (Program.tester.internet)
            {
                case true:
                    if (Properties.Settings.Default.antilles_willkommensbild)
                    {
                        Infos infotafel = new Infos();
                        infotafel.Show();
                    }
                    break;

                case false:                    
                    break;
            }

        }    


        // Progressbar logik
        public void raiseProgressbar()
        {
            if (InvokeRequired) 
            {
                Invoke(new MethodInvoker(raiseProgressbar));    
                return; 
            }
            
            if (this.progressBar.Value == 200)
            {
                this.progressBar.Value = 0;
            }
            if (this.progressBar.Value < 200)
            {
                this.progressBar.Value += 20;
            }
            
        }
              
        public void setProgressbarMax()
        {

            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(setProgressbarMax));
                return;
            }
            this.progressBar.Value = 200;

        }

        public void setProgressbarNull()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(setProgressbarNull));
                return;
            }
            this.progressBar.Value = 0;
            
        }

        // Hier wird eine Instanz der klasse pipetarget erzeugt
        // Sie ist relevant für die XsltPipe 
        public pipetarget thepipetarget = new pipetarget();

        // öffnet das eigenschaften fenster
        private void saxonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.eigenschaften.Show();
        }

        // öffnet die einstellungen zu antilles
        private void antillesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.antilleseigenschaften.Show();
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // hier passiert nicht
        }

        // beendet die gesamte applikation TODO: aufräumen
        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // öffnet die about box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.about.Show();
        }

        // öffnet die hilfe
        private void hilfeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.help.Show();
        }

        // Methode zum setzen ob valide oder nicht im livelog
        public void setFehlermarker(bool flag, string filename)
        {

            // bei false nicht valide. bei true valide
            if (flag)
            {
                textBox_livelog.Text = filename + " ist wellformed";
                setProgressbarNull();
            }
            else
            {
                textBox_livelog.Text = filename + " nicht wellformed";
                setProgressbarNull();
            }

        }

        // setzt den Statustext am Ende der Form
        public void setStatusTxt(string Input)
        {
            this.toolstrip_status.Text = Input;
        }

        // öffnet das Logtab
        public void goToLog() 
        {
            tabControl.SelectedTab = tabPage_log;       
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
        

        // <---- ALLGEMEINER BEREICH ----        

        // ---- XSLT TRANSFORMATION EINFACH ---->  


        private void outname_textbox_TextChanged(object sender, EventArgs e)
        {
            // hier passiert nichts
            
        }

        private void button_parameterxsltsingle_Click(object sender, EventArgs e)
        {              
            
            ParameterFenster parameterwindow = new ParameterFenster(Program.konfiguration.xsltfilepath);
            parameterwindow.Show();

        }  

        // Methode für den xml button. öffnet einen filedialog
        private void btn_xml_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    xml_textbox.Text = open.FileName;
                    Program.konfiguration.xmlfilepath = open.FileName;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlfilepath, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
            }
        }

        // Methode für den xslt button. öffnet einen filedialog
        private void btn_xslt_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    xslt_textbox.Text = open.FileName;
                    Program.konfiguration.xsltfilepath = open.FileName;
                    // checken ob xmlfile valide ist                    
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xsltfilepath, ValidationType.Schema, null);
                    }
                    // für parameter check. wenn true, neu parsen
                    Program.konfiguration.parameter_neuesfile = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        // führt die transformation aus. bzw. startet die entsprechenden
        // methoden der transformerklassen instanz optimus prime ...
        private void btn_transform_Click(object sender, EventArgs e)
        {

            setProgressbarNull();
            // Einfacher Fehlercheck
            if (Program.konfiguration.xmlfilepath == null
                || Program.konfiguration.xsltfilepath == null
                || Program.konfiguration.outfile == null) return;

            //this.setStatusTxt("Einzeldatei Transformation ...");
            Program.konfiguration.outfile = outname_textbox.Text;            
            Program.optimusprime.starteProzessor();
            goToLog();

        }

        private void button_zieldatei_transformation_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml|HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    outname_textbox.Text = open.FileName;
                    Program.konfiguration.outfile = open.FileName;
                }

            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }

        // <---- XSLT TRANSFORMATION EINFACH ----        

        // ---- XSLT TRANSFORMATION ORDNER ---->

        private void btn_ordnerdirinput_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    ordnerinput_textbox.Text = open.SelectedPath;
                    Program.konfiguration.inputpath = open.SelectedPath;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void btn_ausgang_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    ordneroutput_textbox.Text = open.SelectedPath;
                    Program.konfiguration.outputpath = open.SelectedPath;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void btn_xsltordner_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    xsltordner_textbox.Text = open.FileName;
                    Program.konfiguration.xsltfilepath = open.FileName;
                    // checken ob xmlfile valide ist                    
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xsltfilepath, ValidationType.Schema, null);
                    }
                    Program.konfiguration.parameter_neuesfile = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Es ist ein Fehler passiert ... ");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void btn_ordnertrans_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            if (Program.konfiguration.inputpath == null
                || Program.konfiguration.outputpath == null
                || Program.konfiguration.xsltfilepath == null) return;

            try
            {
                string[] files = Directory.GetFiles(Program.konfiguration.inputpath);
                Program.optimusprime.starteProzessor(files, Program.konfiguration.outputpath, Program.konfiguration.xsltfilepath, "");
                goToLog();
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_parameterxsltordner_Click(object sender, EventArgs e)
        {
            ParameterFenster parameterwindow = new ParameterFenster(Program.konfiguration.xsltfilepath);
            parameterwindow.Show();
        }   

        // <---- XSLT TRANSFORMATION ORDNER ----  


        // ---- LOGFILE BEREICH ---->

        // Einträge ins Logtextfeld entgegennehmen und ausgeben
        public void setLogTxt(string input)
        {

            if (InvokeRequired)
            {
                Invoke(new LogData(setLogTxt), new Object[] { input });             
                return;
            }

            ListViewItem item = new ListViewItem(input);   
            listView_log.Items.Add(item);
            //textBox_livelog.Text = input;
        }

        private void listView_log_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ListView).FocusedItem.Text, "Detailansicht", MessageBoxButtons.OK);
        }

        // Hier wird das log gecleart
        private void button_flush_Click(object sender, EventArgs e)
        {
            listView_log.Clear();

            ColumnHeader header = new ColumnHeader();
            header.Text = "Log Meldungen";
            header.TextAlign = HorizontalAlignment.Left;
            header.Width = 490;
            listView_log.Columns.Add(header);

        }

        // Hier wird das logfile abgespeichert. 
        private void button_speichern_Click(object sender, EventArgs e)
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
                    StreamWriter sw = null;

                    try
                    {
                        sw = new StreamWriter(fileName, false, Encoding.GetEncoding("windows-1252"));
                    }
                    catch (Exception ex)
                    {
                        setStatusTxt("Es ist ein Fehler passiert ... " + ex.Message);
                    }
                    sw.Write("<---- beginne logfile,");
                    sw.Write(" erstellt am: " + DateTime.Now.ToString());
                    sw.Write(Environment.NewLine);
                    sw.Write(Environment.NewLine);

                    for (int i = 0; i < listView_log.Items.Count; i++)
                    {
                        sw.Write(listView_log.Items[i].Text);
                        sw.Write(Environment.NewLine);
                    }
                    sw.Write(Environment.NewLine);
                    sw.Write("----- ende des logfiles ---->");
                    sw.Close();
                }

            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }

        }

        private void tabPage_log_Enter(object sender, EventArgs e)
        {
            if (Program.konfiguration.xmlHotfolder) 
            {
                textBox_livelog.Text = "...";
                return; 
            }
            textBox_livelog.Text = "...";
            toolstrip_status.Text = "Ready";
        }

        // <---- LOGFILE BEREICH ----

        // ---- VALIDIERUNGS BEREICH ---->

        private void button_xmlvalueordner_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    textBox_xmlquelle_valid.Text = open.SelectedPath;
                    Program.konfiguration.xmlFilenameValidFolder = open.SelectedPath;
                    XMLfolder = true;

                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xmlvalidinput_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xmlquelle_valid.Text = open.FileName;
                    Program.konfiguration.xmlFilenameValid = open.FileName;

                    // Prüfen ob eine DTD im xml file vorliegt. 
                    XmlDocument doc = new XmlDocument();
                    bool docflag = false;
                    doc.Load(Program.konfiguration.xmlFilenameValid);
                    try
                    {

                        string doctype = doc.DocumentType.SystemId;

                    }
                    catch (Exception)
                    {
                        // hier keine fehlerausgabe, da gewünscht
                        docflag = true;

                    }
                    if (docflag)
                    {
                        dtdisset = true;
                    }
                    else
                    {
                        dtdisset = false;
                    }
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlFilenameValid, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {

                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xmlschemainput_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSD file (*.xsd)|*.xsd";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_schemaquelle_valid.Text = open.FileName;
                    Program.konfiguration.xmlSchemaFileName = open.FileName;
                    dtdisset = false;
                    pictureBox_dtdchoosen.Visible = false;
                    pictureBox_xmlschemachoosen.Visible = true;
                    // checken ob file valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlSchemaFileName, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_dtd_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "DTD file (*.dtd)|*.dtd";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_dtd.Text = open.FileName;
                    Program.konfiguration.dtdSchemaFile = open.FileName;
                    // dtd wurde gesetzt. wichtig für validbutton, der muss das wissen
                    dtdisset = true;
                    pictureBox_dtdchoosen.Visible = true;
                    pictureBox_xmlschemachoosen.Visible = false;
                    // checken ob schema valide ist
                    // Program.validboy.ausgabeflag = false;
                    //Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlSchemaFileName, ValidationType.Schema, null, "schema");

                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_validiere_xmlschema_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner fehlercheck
            if (Program.konfiguration.xmlSchemaFileName == null
                && Program.konfiguration.dtdSchemaFile == null) return;

            if (Program.konfiguration.xmlFilenameValid == null
               && Program.konfiguration.xmlFilenameValidFolder == null) return;


            if (!dtdisset)
            {
                if (!XMLfolder)
                {
                    Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlFilenameValid, ValidationType.Schema, Program.konfiguration.xmlSchemaFileName);
                }
                else
                {

                    try
                    {

                        string[] files = Directory.GetFiles(Program.konfiguration.xmlFilenameValidFolder, "*.xml");
                        Program.validboy.ValidiereXMLFile(files, ValidationType.Schema, Program.konfiguration.xmlSchemaFileName, "null");

                    }
                    catch (Exception ex)
                    {
                        //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");

                        setLogTxt(ex.Message);
                    }

                }
            }
            else
            {
                if (!XMLfolder)
                {
                    Program.validboy.ValidiereXMLFileDtD(Program.konfiguration.xmlFilenameValid, ValidationType.DTD, Program.konfiguration.dtdSchemaFile, "null");
                    //Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlFilenameValid, ValidationType.DTD, Program.konfiguration.dtdSchemaFile, "null");
                }
                else
                {

                    try
                    {
                        string[] files = Directory.GetFiles(Program.konfiguration.xmlFilenameValidFolder, "*.xml");
                        Program.validboy.ValidiereXMLFileDtD(files, ValidationType.DTD, Program.konfiguration.dtdSchemaFile, "null");
                    }
                    catch (Exception ex)
                    {
                        // HIER BAUSTELLE! --- Geht doch?? 19.04.2010
                        // KOMISCHE EXCEPTION WENN ORDNER


                        //setLogTxt(ex.Message);
                        //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");

                        setLogTxt(ex.Message);
                    }
                }
            }
            goToLog();
        }

        // <---- VALIDIERUNGS BEREICH ----         

        // ---- XSLT PIPE BEREICH ---->

        private void button_config_save_Click(object sender, EventArgs e)
        {
            Xsltpipe.saveConfig();
        }

        private void button_config_load_Click(object sender, EventArgs e)
        {
            Xsltpipe.loadConfig();
        }

        private void button_parameterxsltpipe_Click(object sender, EventArgs e)
        {
            Xsltpipe.getAllParams();
        } 

        //bool zieldateiset = false;
        private void button_xsltpipe_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner fehlercheck
            if (Program.konfiguration.xmlfilepathPipe == null
                || Program.konfiguration.xsltfilepathPipe == null
                || Program.konfiguration.xmlfilepathTargetPipe == null) return;


            // wenn ordneranlegen true ist, wird ein ordner angelegt in der klasse pipetarget
            ordneranlegen = true;
            Xsltpipe.ButtonEngage(thepipetarget);
            //Program.optimusprime.deleteLogFile();
            ordneranlegen = false;
            goToLog();
        }
        public void newButton(object sender, EventArgs e)
        {
            Xsltpipe.buttontextboxmagic(sender, e);
        }

        private void button_zieldatei_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml|HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;



                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xsltpipeziel.Text = open.FileName;
                    FileInfo fi = new FileInfo(open.FileName);
                    // dieser eintrag ist primär für das savefile
                    Program.konfiguration.xmlfilepathTargetPipe = open.FileName;
                    thepipetarget.extension = fi.Extension;
                    thepipetarget.dir = fi.DirectoryName;
                    thepipetarget.frontname = fi.Name;
                    //zieldateiset = true;
                }

            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }

        private void xmlfile_pipe_input_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xmlfile_pipe.Text = open.FileName;
                    Program.konfiguration.xmlfilepathPipe = open.FileName;
                    //checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlfilepathPipe, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");

                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void xslt_btn_pipe_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xsltfile_pipe.Text = open.FileName;
                    Program.konfiguration.xsltfilepathPipe = open.FileName;
                    // checken ob xmlfile valide ist
                    
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xsltfilepathPipe, ValidationType.Schema, null);
                    }
                    // Parameter neu einlesen? Nur wenn neues File.
                    Program.konfiguration.parameter_neuesfile = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        // Aufräumen
        private void button_xsltpipeclear_Click(object sender, EventArgs e)
        {

            // hier passiertnichts

        }   

        // <---- XSLT PIPE BEREICH ----         


        // ---- SCHEMATRON BEREICH ---->

        private void button_schematron_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleine fehlerprüfung
            if (Program.konfiguration.schematronXML == null
                || Program.konfiguration.schematronSchema == null) return;

            Program.schematronboy.schema_engage(Program.konfiguration.schematronSchema, Program.konfiguration.schematronXML);
            goToLog();
        }

        private void button_xml_schematron_input_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    Program.schematronboy.folder = false;
                    textBox_xmlfileschematron.Text = open.FileName;
                    Program.konfiguration.schematronXML = open.FileName;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.schematronXML, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_schema_buttn_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Program.schematronboy.folder = true;
                    textBox_xmlfileschematron.Text = open.SelectedPath;
                    Program.konfiguration.schematronXML = open.SelectedPath;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_schematron_input_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Schema file (*.sch)|*.sch";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    textBox_schemafile.Text = open.FileName;
                    Program.konfiguration.schematronSchema = open.FileName;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.schematronSchema, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        // <---- SCHEMATRON BEREICH ----

        // ---- XSD BERICHT ERSTELLEN ---->

        private void xsd_bericht_input_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSD file (*.xsd)|*.xsd";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xsd_bericht_input.Text = open.FileName;
                    Program.konfiguration.xmlSchemaFileName = open.FileName;

                    // checken ob schema valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlSchemaFileName, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xsdbericht_ziel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_bericht_ziel.Text = open.FileName;
                    Program.konfiguration.htmlSchemaBericht = open.FileName;
                }
            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }



        private void button_xsd_bericht_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // Einfacher Fehlercheck
            if (Program.konfiguration.xmlSchemaFileName == null
                || Program.konfiguration.htmlSchemaBericht == null) return;

            Program.konfiguration.htmlSchemaBerichtset = true;

            string fileName = Path.Combine(Application.StartupPath, "lib\\xs3p\\");
            string xs3pschema = fileName + "xs3p.xsl";

            Program.optimusprime.starteProzessor(Program.konfiguration.xmlSchemaFileName, xs3pschema, Program.konfiguration.htmlSchemaBericht);
            Program.konfiguration.htmlSchemaBerichtset = false;

            // Im Browser anzeigen?
            try
            {
                if (Properties.Settings.Default.Schematronberichtbrowser) Process.Start(Program.konfiguration.htmlSchemaBericht);
            }
            catch (Exception ex)
            {

                setLogTxt(ex.Message);

            }
            goToLog();
        }

        private void checkBox_berichtimbrowseranzeigen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_berichtimbrowseranzeigen.Checked)
            {
                checkBox_berichtimbrowseranzeigen.Checked = true;
                Properties.Settings.Default.Schematronberichtbrowser = true;
            }
            else
            {
                Properties.Settings.Default.Schematronberichtbrowser = false;
                checkBox_berichtimbrowseranzeigen.Checked = false;
            }
            Properties.Settings.Default.Save();
        }

        // <---- XSD BERICHT ERSTELLEN -----

        // ---- UNSORTIERTER BEREICH ---->

        private void tabPage_schematron_Click_1(object sender, EventArgs e)
        {
            // hier passiert nichts.
        }        

        private void tabPage_validierung_Click(object sender, EventArgs e)
        {
            // hier passiert nichts
        }             

        private void txt_ausgangordner_Click(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void tabPage_schematron_Click(object sender, EventArgs e)
        {

        }

        // <---- UNSORTIERTER BEREICH ----

        // ---- XSL-FO BEREICH ---->

        bool xsltfofolder = false;

        private void button_fo_xmlfile_input_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {

                    xsltfofolder = false;
                    textBox_xslfo_xmlfilefolder.Text = open.FileName;
                    Program.konfiguration.xmlfileOrFolderFOpath = open.FileName;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlfileOrFolderFOpath, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xsltfo_folder_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    xsltfofolder = true;
                    textBox_xslfo_xmlfilefolder.Text = open.SelectedPath;
                    Program.konfiguration.xmlfileOrFolderFOpath = open.SelectedPath;

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xsltfo_stylesheet_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xslfo_stylesheet.Text = open.FileName;
                    Program.konfiguration.xsltfileFOpath = open.FileName;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xsltfileFOpath, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_xslfo_ziel_Click(object sender, EventArgs e)
        {
            switch (xsltfofolder)
            {

                case true:
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            textBox_xslfo_ziel.Text = open.SelectedPath;
                            Program.konfiguration.xmlfileOrFolderFOTargetpath = open.SelectedPath;
                        }
                    }
                    catch (Exception)
                    {
                        //setStatusTxt("Sie müssen einen Ordner angeben");
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }
                    break;

                case false:
                    try
                    {
                        SaveFileDialog open = new SaveFileDialog();
                        open.Filter = "PDF file (*.pdf)|*.pdf";
                        open.AddExtension = true;
                        open.ValidateNames = true;

                        if (open.ShowDialog() == DialogResult.OK)
                        {

                            textBox_xslfo_ziel.Text = open.FileName;
                            Program.konfiguration.xmlfileOrFolderFOTargetpath = open.FileName;
                            // checken ob xmlfile valide ist
                            //Program.validboy.ausgabeflag = false;
                            //Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlfilepath, ValidationType.Schema, null, "xmlfilevalidexslt");
                            //this.progressBar_valid.Value = 0;
                        }
                    }
                    catch (Exception)
                    {
                        //setStatusTxt("Sie müssen einen Ordner angeben");
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }
                    break;
            }
        }

        private void button_xslo_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner fehlercheck
            if (Program.konfiguration.xmlfileOrFolderFOpath == null
                || Program.konfiguration.xmlfileOrFolderFOpath == null
                || Program.konfiguration.xsltfileFOpath == null) return;

            switch (xsltfofolder)
            {
                // Ordnerweise
                case true:
                    // Der Quell und der Zielordner sind hier identisch, da die *.fo files neben die
                    // xml quellfiles gelegt werden. 
                    string[] quellfolderfiles = Directory.GetFiles(Program.konfiguration.xmlfileOrFolderFOpath, "*.xml");
                    string zielfolder = Program.konfiguration.xmlfileOrFolderFOpath;
                    string xsltfile0 = Program.konfiguration.xsltfileFOpath;
                    // 1. Schritt: Transformieren zu FO
                    Program.optimusprime.starteProzessor(quellfolderfiles, zielfolder, xsltfile0, ".fo");

                    string[] fofiles = Directory.GetFiles(zielfolder, "*.fo");
                    // 2. Schritt: FO Stylesheet in den entsprechenden Formatierer schicken
                    Program.formatboy.formatiere(fofiles, Program.konfiguration.xmlfileOrFolderFOTargetpath, xsltfofolder, Properties.Settings.Default.FoFormatierer);
                    break;

                // Einzelfile
                case false:

                    string[] fofile = { "" };
                    // 1. Schritt: Transformieren zu FO
                    string inputfile = Program.konfiguration.xmlfileOrFolderFOpath;
                    string xsltfile = Program.konfiguration.xsltfileFOpath;
                    string fofiletarget = Program.konfiguration.xmlfileOrFolderFOpath + ".fo";
                    fofile[0] = Program.optimusprime.starteProzessor(inputfile, xsltfile, fofiletarget);

                    // 2. Schritt: FO Stylesheet in den entsprechenden Formatierer schicken
                    Program.formatboy.formatiere(fofile, Program.konfiguration.xmlfileOrFolderFOTargetpath, xsltfofolder, Properties.Settings.Default.FoFormatierer);
                    break;
            }
            goToLog();
        }

        private void tabPage_fo_Click(object sender, EventArgs e)
        {
            // hier passiert nichts.
        }

        private void radioButton_formaterfop_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FoFormatierer = "fop";
            Properties.Settings.Default.Save();
        }

        private void radioButton_formatterantennahouse_CheckedChanged(object sender, EventArgs e)
        {
            // zurückgehen bei startup
            if (initradiofo) return;

            Properties.Settings.Default.FoFormatierer = "antennahouse";
            if (Properties.Settings.Default.AntennahouseLocation == "leer")
            {
                DialogResult result = MessageBox.Show("Bitte geben Sie den Speicherort von Antennahouse an", "Ordner angeben", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return; }
                else
                {
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.AntennahouseLocation = open.SelectedPath;
                            Properties.Settings.Default.AntennahouseLocation += "\\XSLCmd.exe";
                        }
                    }
                    catch (Exception)
                    {
                        setStatusTxt("Sie müssen einen Ordner angeben");
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }

                    if (File.Exists(Properties.Settings.Default.AntennahouseLocation))
                    {
                        Properties.Settings.Default.FoFormatierer = "antennahouse";
                    }
                    else
                    {
                        MessageBox.Show("Konnte die Datei XSLCmd.exe nicht finden", "File not found", MessageBoxButtons.OK);
                        Properties.Settings.Default.AntennahouseLocation = "leer";
                    }
                }
            }
            Properties.Settings.Default.Save();
        }

        private void radioButton_formatterxep_CheckedChanged(object sender, EventArgs e)
        {
            // zurückgehen bei startup
            if (initradiofo) return;

            Properties.Settings.Default.FoFormatierer = "renderx";
            if (Properties.Settings.Default.RenderXLocation == "leer")
            {

                DialogResult result = MessageBox.Show("Bitte geben Sie den Speicherort von RenderX an", "Ordner angeben", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) { return; }
                else
                {
                    try
                    {
                        FolderBrowserDialog open = new FolderBrowserDialog();

                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Properties.Settings.Default.RenderXLocation = open.SelectedPath;
                            Properties.Settings.Default.RenderXLocation += "\\xep.bat";
                        }
                    }
                    catch (Exception)
                    {
                        setStatusTxt("Sie müssen einen Ordner angeben");
                        //setLogTxt("Sie müssen einen Ordner angeben");               
                    }

                    if (File.Exists(Properties.Settings.Default.RenderXLocation))
                    {
                        Properties.Settings.Default.FoFormatierer = "renderx";
                    }
                    else
                    {
                        MessageBox.Show("Konnte die Datei xep.bat nicht finden", "File not found", MessageBoxButtons.OK);
                        Properties.Settings.Default.RenderXLocation = "leer";
                    }
                }
            }
            Properties.Settings.Default.Save();
        }

        private void groupBox_formatter_Enter(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void radioButton_formatterantennahouse_CheckedChanged_1(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void radioButton_formatterxep_CheckedChanged_1(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void checkBox_keepfos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_keepfos.Checked == true)
            {
                Properties.Settings.Default.KeepFoFiles = true;
            }
            else
            {
                Properties.Settings.Default.KeepFoFiles = false;
            }

            Properties.Settings.Default.Save();

        }

        // <---- XSL-FO BEREICH ----

        // ---- Cals2Html BEREICH ---->

        private void button_cals2html_input_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_cals2html_input.Text = open.FileName;

                    Program.konfiguration.cal2htmlinput = open.FileName;

                    // checken ob file valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.cal2htmlinput, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_cals2html_stylesheet_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_cals2html_target.Text = open.FileName;
                    Program.konfiguration.cal2Htmltarget = open.FileName;
                }
            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }

        private void button_cals2html_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // Einfacher Fehlercheck
            if (Program.konfiguration.cal2htmlinput == null
                || Program.konfiguration.cal2Htmltarget == null) return;

            string fileName = Path.Combine(Application.StartupPath, "Ressourcen\\cals2html\\");
            string cals2html = fileName + "CALS2HTML.xsl";

            Program.optimusprime.starteProzessor(Program.konfiguration.cal2htmlinput, cals2html, Program.konfiguration.cal2Htmltarget);

            // Im Browser anzeigen?
            try
            {
                if (Properties.Settings.Default.Cals2htmlberichtbrowser) Process.Start(Program.konfiguration.cal2Htmltarget);
            }
            catch (Exception ex)
            {

                setLogTxt(ex.Message);

            }
            goToLog();

        }

        private void checkBox_cals2htmlbrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_berichtimbrowseranzeigen.Checked)
            {
                checkBox_berichtimbrowseranzeigen.Checked = true;
                Properties.Settings.Default.Cals2htmlberichtbrowser = true;
            }
            else
            {
                Properties.Settings.Default.Cals2htmlberichtbrowser = false;
                checkBox_berichtimbrowseranzeigen.Checked = false;
            }
            Properties.Settings.Default.Save();
        }

        // <---- Cals2Html BEREICH ---- 

        // ---- XML darstellen BEREICH ----> 

        private void button_xmlberichtquelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xmlbericht_quelle.Text = open.FileName;
                    Program.konfiguration.xmlBerichtQuelle = open.FileName;
                    // checken ob file valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlBerichtQuelle, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
            }
        }

        private void button_xmlberichtziel_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xmlbericht_ziel.Text = open.FileName;
                    Program.konfiguration.xmlBerichtZiel = open.FileName;
                }

            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }

        private void button_xmlberichtengage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner fehlercheck
            if (Program.konfiguration.xmlBerichtQuelle == null
                || Program.konfiguration.xmlBerichtZiel == null) return;

            string fileName = Path.Combine(Application.StartupPath, "lib\\XMLbericht\\");
            string xmldarstellen = fileName + "xmlverbatimwrapper.xsl";
            string css = fileName + "xmlverbatim.css";

            FileInfo fi = new FileInfo(Program.konfiguration.xmlBerichtZiel);
            string target = fi.DirectoryName + "\\xmlverbatim.css";

            Program.optimusprime.starteProzessor(Program.konfiguration.xmlBerichtQuelle, xmldarstellen, Program.konfiguration.xmlBerichtZiel);

            try
            {
                File.Copy(css, target, true);
            }
            catch (Exception)
            {

                // hier passiert nichts ... 

            }

            // Im Browser anzeigen?
            try
            {
                if (Properties.Settings.Default.XMLdarstellenbrowser) Process.Start(Program.konfiguration.xmlBerichtZiel);
            }
            catch (Exception ex)
            {

                setLogTxt(ex.Message);

            }
            goToLog();
        }

        private void checkBox_xmlberichtbrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_xmlberichtbrowser.Checked)
            {
                checkBox_xmlberichtbrowser.Checked = true;
                Properties.Settings.Default.XMLdarstellenbrowser = true;
            }
            else
            {
                Properties.Settings.Default.XMLdarstellenbrowser = false;
                checkBox_xmlberichtbrowser.Checked = false;
            }
            Properties.Settings.Default.Save();
        }

        // <---- XML darstellen BEREICH ---- 

        // ---- XProc  BEREICH ----> 

        private void label_xprocinput_Click(object sender, EventArgs e)
        {

            // hier passiert nichts

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        bool xprocfileOrFolder;
        private void button_xprocinput_file_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XPL file (*.xpl)|*.xpl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xprocinput.Text = open.FileName;
                    Program.konfiguration.xprocfile = open.FileName;
                    xprocfileOrFolder = true;
                    // checken ob xmlfile valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xprocfile, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception)
            {
               // setStatusTxt("Sie müssen einen Ordner angeben");
            }

        }

        private void button_xprocinput_folder_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_xprocinput.Text = open.SelectedPath;
                    Program.konfiguration.xprocfile = open.SelectedPath;
                    xprocfileOrFolder = false;
                }
            }
            catch (Exception)
            {
               // setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }


        private void button_xproc_engage_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner fehlercheck
            if (Program.konfiguration.xprocfile == null) return;
            Program.xprocboy.doxproc(Program.konfiguration.xprocfile, xprocfileOrFolder);
            goToLog();
        }

        private void tabpage_einzelfile_Click(object sender, EventArgs e)
        {

        }

        private void label_xsltpipeziel_Click(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        // <---- XProc  BEREICH ----

        // ---- Hotfolder  BEREICH ---->

        private void button_hotfolder_input_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    
                    textBox_hotfolder_input.Text = open.SelectedPath;
                    Program.konfiguration.xmlfilepathHotfolder = open.SelectedPath;                    

                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_hotfolder_ziel_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {
                    
                    textBox_hotfolder_ziel.Text = open.SelectedPath;
                    Program.konfiguration.xmlfilepathTargetHotfolder = open.SelectedPath;
                   
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_hotfolder_stylesheet_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    
                    textBox_hotfolder_stylesheet.Text = open.FileName;
                    Program.konfiguration.xsltfilepathHotfolder = open.FileName;
                    
                    // checken ob xmlfile valide ist                    
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.xsltfilepathHotfolder, ValidationType.Schema, null);
                    }
                    Program.konfiguration.parameter_neuesfile = true;
                }
            }
            catch (Exception)
            {
                //setStatusTxt("Es ist ein Fehler passiert ... ");
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_hotfolder_parameter_Click(object sender, EventArgs e)
        {
            ParameterFenster parameterwindow = new ParameterFenster(Program.konfiguration.xsltfilepathHotfolder);
            parameterwindow.Show();
        }

        private void button_hotfolder_starten_Click(object sender, EventArgs e)
        {
            setProgressbarNull();
            // kleiner Fehlercheck
            if (Program.konfiguration.xmlfilepathHotfolder == null
               || Program.konfiguration.xmlfilepathTargetHotfolder == null
               || Program.konfiguration.xsltfilepathHotfolder == null) return;

            Program.hotfold.FSW_Init(Program.konfiguration.xmlfilepathHotfolder);
            Program.konfiguration.xmlHotfolder = true;
            Program.hauptfenster.setStatusTxt("Hotfolder aktiviert");
            
        }

        private void button_hotfolder_stop_Click(object sender, EventArgs e)
        {

            // kleiner Fehlercheck
            if (Program.konfiguration.xmlHotfolder == false) return;

            Program.hotfold.FSW_Stop();
            Program.konfiguration.xmlHotfolder = false;
            Program.hauptfenster.setStatusTxt("ready");

        }

        // <---- Hotfolder  BEREICH ----

        // ---- WordML  BEREICH ---->

        private void button_wordml_input_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_wordmlfile.Text = open.FileName;
                    Program.konfiguration.wordMLFileName = open.FileName;
                    // checken ob file valide ist
                    if (Properties.Settings.Default.antilles_wellformedcheck)
                    {
                        Program.validboy.ausgabeflag = false;
                        Program.validboy.ValidiereXMLFile(Program.konfiguration.wordMLFileName, ValidationType.Schema, null);
                    }
                }
            }
            catch (Exception ex)
            {
                //setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                setLogTxt(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Einfacher Fehlercheck
            if (Program.konfiguration.wordMLFileName == null
                || Program.konfiguration.wordMLFileNameZiel == null
                ) return;

            // Alte Einstellung
            //string xmltmp = Path.GetTempFileName();
            //Program.optimusprime.starteProzessor(Program.konfiguration.wordMLFileName, "word2formate", xmltmp, true);

            //WordML wordml = new WordML(xmltmp);
            //wordml.Show();

            Program.wordML.ausfuehren();


        }

        private void button_wordml_ziel_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml|HTML file (*.html)|*.html";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {
                    textBox_wordml_ziel.Text = open.FileName;
                   // Program.konfiguration.outfile = open.FileName;
                    Program.konfiguration.wordMLFileNameZiel = open.FileName;
                }

            }
            catch (Exception ex)
            {
                setLogTxt(ex.Message);
            }
        }

        // <--- WordML  BEREICH ----

    }

    // --- ENDE DER KLASSE HAUPTFENSTER ---

    // Diese Klasse hält lediglich den Filenamen des Pipetargets. 
    // TODO: könnte man auch in die config klasse stecken ...
    public class pipetarget
    {

        // Alles noch nicht so optimal hier. Vorallem die Entscheidung ob ein Ordner angelegt werden soll
        // oder nicht. Auch die Herangehensweise was die benamung der Ausgabefiles angeht ... -> Rücksprache halten

        // default werte und initialisierung
        private string Extension;
        private string Frontname;
        private string Dir = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public string dir
        {

            get
            {
                return Dir;
            }

            set
            {
                Dir = value;
            }
        }

        public string extension
        {
            get
            {
                return Extension;
            }

            set
            {
                Extension = value;
            }

        }

        public string frontname
        {
            get
            {
                if (Program.hauptfenster.ordneranlegen == true && Frontname == null)
                {
                    string directory, frontna;
                    FileInfo fi = new FileInfo(Program.konfiguration.xmlfilepathPipe);
                    extension = fi.Extension;
                    directory = fi.DirectoryName;
                    frontna = fi.Name;

                    // extension entfernen
                    frontna = frontna.Replace(Extension, "");

                    try
                    {
                        Directory.CreateDirectory(directory + "\\" + frontna);
                    }
                    catch (Exception)
                    {
                        //Program.hauptfenster.setLogTxt("Fehler beim anlegen des Ordners" + ex.Message);
                    }
                    return directory + "\\" + frontna + "\\" + frontna;
                }
                else
                {
                    // entfernt die extension, falls vorhanden
                    Frontname = Frontname.Replace(Extension, "");
                    return dir + "\\" + Frontname;
                }
            }

            set
            {
                Frontname = value;
            }

        }
    }
}
