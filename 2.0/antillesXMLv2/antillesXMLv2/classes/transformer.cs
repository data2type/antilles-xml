// ------------------------------------------------------------------------ //
// transformer class                                                        //
//                                                                          //
// Diese Klasse stellt die Methoden für die Transformierung mit XSLT bereit //
// Eventuell werden hier auch Xerces und Schematron Realisert ... ma sehen  //
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
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;



namespace antillesXMLv2
{
    class transformer
    {       
       
        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. String als Rückgabewert.
        /// </summary>
        public string starteProzessor(string doc, string xsltfile, string target)
        {
            
            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);
                
                // Create a Processor instance.
                Processor processor = new Processor(true); 

                // die abfrage der einstellungen 
                processor = checkSettings(processor);

                XdmNode input = processor.NewDocumentBuilder().Build(new Uri(doc));

                // Create the XSLT Compiler
                XsltCompiler compiler = processor.NewXsltCompiler();

                compiler.ErrorList = FehlerListe;

                // transformer erzeugen und compilieren              
                XsltTransformer xslttransformer = compiler.Compile(new Uri(xsltfile)).Load();

                // Set the root node of the source document to be the initial context node
                xslttransformer.InitialContextNode = input;

                // parameter prüfen
                xslttransformer = checkParameter(xslttransformer);

                // Create a serializer                 
                FileStream ziel = new FileStream(target, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(ziel);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);
                
                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                ziel.Close();                

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);               
                serializer.Close();

                string inhalt = "";
                StreamReader myFile = new StreamReader(target, System.Text.Encoding.Default);
                inhalt = myFile.ReadToEnd();
                myFile.Close();
                Program.results.loadText_results(inhalt);

                Program.mainframe.toolStripStatusLabel.Text = "Operation succeeded at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");
                Program.Config.success = true;

                return target;
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Exception exc)
            {
                if (exc.Message == "Value cannot be null.\r\nParameter name: uriString")
                {
                    //Program.hauptfenster.setStatusTxt("Sie haben keine Dateien angegeben");
                }
                else
                {

                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                   
                    string ausgabe = "Failed unexpectedly: " + exc.Message;
                    Program.results.loadText_log(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {                  
                        Program.results.loadText_log(FehlerListe[i].ToString());
                    }
                }
            }
            serializer.Close();
            
           
            return target;
        }

        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. Kein Rückgabewert.
        /// </summary>
        public void starteProzessorImHotfolder(string doc, string xsltfile, string target)
        {

            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor(true);

                // die abfrage der einstellungen 
                processor = checkSettings(processor);

                XdmNode input = processor.NewDocumentBuilder().Build(new Uri(doc));

                // Create the XSLT Compiler
                XsltCompiler compiler = processor.NewXsltCompiler();

                compiler.ErrorList = FehlerListe;

                // transformer erzeugen und compilieren              
                XsltTransformer xslttransformer = compiler.Compile(new Uri(xsltfile)).Load();

                // Set the root node of the source document to be the initial context node
                xslttransformer.InitialContextNode = input;

                // parameter prüfen
                xslttransformer = checkParameter(xslttransformer);

                // Create a serializer                 
                FileStream ziel = new FileStream(target, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(ziel);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                ziel.Close();

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);
                serializer.Close();

                string inhalt = "";
                StreamReader myFile = new StreamReader(target, System.Text.Encoding.Default);
                inhalt = myFile.ReadToEnd();
                myFile.Close();
                Program.results.loadText_results(inhalt);
                Program.mainframe.toolStripStatusLabel.Text = "Operation succeeded at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");
                Program.Config.success = true;

                
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Exception exc)
            {
                if (exc.Message == "Value cannot be null.\r\nParameter name: uriString")
                {
                    //Program.hauptfenster.setStatusTxt("Sie haben keine Dateien angegeben");
                }
                else
                {

                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                   
                    string ausgabe = "Failed unexpectedly: " + exc.Message;
                    Program.results.loadText_log(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {
                        Program.results.loadText_log(FehlerListe[i].ToString());
                    }
                }
            }
            serializer.Close();

          
        }


        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. Angepasst für WordML/Cals2Html
        /// </summary>
        public string starteProzessor(string doc, string xsltfile, string target, bool dummy)
        {

            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor(true);

                // die abfrage der einstellungen 
                processor = checkSettings(processor);

                XdmNode input = processor.NewDocumentBuilder().Build(new Uri(doc));

                // Create the XSLT Compiler
                XsltCompiler compiler = processor.NewXsltCompiler();

                compiler.ErrorList = FehlerListe;

                // transformer erzeugen und compilieren        
                string filePath = "antillesXMLv2.styles." + xsltfile + ".xsl";
                Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);
                XsltTransformer xslttransformer = compiler.Compile(fileStream).Load();
                               

                // Set the root node of the source document to be the initial context node
                xslttransformer.InitialContextNode = input;

                // parameter prüfen
                xslttransformer = checkParameter(xslttransformer);

                // Create a serializer                 
                FileStream ziel = new FileStream(target, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(ziel);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                ziel.Close();

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);
                serializer.Close();

                string inhalt = "";
                StreamReader myFile = new StreamReader(target, System.Text.Encoding.Default);
                inhalt = myFile.ReadToEnd();
                myFile.Close();
                Program.results.loadText_results(inhalt);
                Program.mainframe.toolStripStatusLabel.Text = "Operation succeeded at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");
                Program.Config.success = true;

                return target;
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Exception exc)
            {
                if (exc.Message == "Value cannot be null.\r\nParameter name: uriString")
                {
                    //Program.hauptfenster.setStatusTxt("Sie haben keine Dateien angegeben");
                }
                else
                {

                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                   
                    string ausgabe = "Failed unexpectedly: " + exc.Message;
                    Program.results.loadText_log(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {
                        Program.results.loadText_log(FehlerListe[i].ToString());
                    }
                }
            }
            serializer.Close();

            return target;
        }


        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese überladene Variante braucht einen string Array, 
        /// einen Zielordner und das Stylesheet, abschliessend noch die extension.
        /// </summary>
        public void starteProzessor(string[] files, string outputfolder, string xsl, string extension)
        {
            ArrayList FehlerListe = new ArrayList();           
            string meinlog = "";
            Serializer serializer = new Serializer();

            try
            {

                meinlog = makeTmpFile();

                // Funktion zur Fehlerausgabeumleitung
                RedirectStdErr(meinlog);


                Regex r = new Regex(@".*\\");

                for (int i = 0; i < files.Length; i++)
                {                   

                    // aufbereitung der eingangsdaten
                    string[] inputs = r.Split(files[i]);
                    string outputfilename = outputfolder + "\\" + inputs[1];
                    if (Program.schematron.schematronsetstep2) outputfilename = outputfolder + "\\" + inputs[1] + ".txt";                   
                    if (extension != "") outputfilename = outputfilename + extension;

                    // Create a Processor instance.
                    Processor processor = new Processor(true);

                    // die abfrage der einstellungen 
                    processor = checkSettings(processor);

                    // Create the XSLT Compiler
                    XsltCompiler compiler = processor.NewXsltCompiler();

                    compiler.ErrorList = FehlerListe;

                    XdmNode input = processor.NewDocumentBuilder().Build(new Uri(files[i]));

                    // Create a transformer for the stylesheet.
                    XsltTransformer xslttransformer = compiler.Compile(new Uri(xsl)).Load();

                    // Set the root node of the source document to be the initial context node
                    xslttransformer.InitialContextNode = input;

                    // parameter prüfen
                    xslttransformer = checkParameter(xslttransformer);

                    // Create a serializer           

                    FileStream target = new FileStream(outputfilename, FileMode.Create, FileAccess.Write);
                    serializer.SetOutputStream(target);
                    // Transform the source XML to System.out.
                    xslttransformer.Run(serializer);
                   
                    // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                    target.Close();
                    Program.mainframe.toolStripStatusLabel.Text = "Operation succeeded at " + DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss");
                    Program.Config.success = true;
                }


                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                

                deleteLogFile(meinlog);

            }

            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.results.loadText_log(ausgabe);
            }
            catch (Exception exc)
            {
                if (exc.Message == "Value cannot be null.\r\nParameter name: uriString")
                {
                    //Program.hauptfenster.setStatusTxt("Sie haben keine Dateien angegeben");
                }
                else
                {

                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                   
                    string ausgabe = "Failed unexpectedly: " + exc.Message;
                    Program.results.loadText_log(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {
                        Program.results.loadText_log(FehlerListe[i].ToString());
                    }
                }
            }
            serializer.Close();           
        }
              
        public XsltTransformer checkParameter(XsltTransformer transformer)
        {

            for (int i = 0; i < Program.Config.parameters.Count; i++)
            {

                XdmAtomicValue val = new XdmAtomicValue(Program.Config.parameters[i].value);
                QName param = new QName("", "", Program.Config.parameters[i].param);


                transformer.SetParameter(param, val);
                


            }

            return transformer;
            

        }

        public void getParameter(string xsltfile)
        {

            if (xsltfile == null || xsltfile == "") return;


            XmlReader xmlReader = null;
            try
            {
                xmlReader = XmlReader.Create(xsltfile);
            }
            catch (Exception)
            {

            }

            while (xmlReader.Read())
            {

                if (xmlReader.Name == "xsl:param" && xmlReader.IsStartElement() && xmlReader.Depth == 1)
                {
                    parameter Item = new parameter();
                    bool select = false;
                    Item.param = xmlReader.GetAttribute("name");

                    if (xmlReader.MoveToAttribute("select"))
                    {

                        Item.value = xmlReader.ReadInnerXml();
                        select = true;

                    }

                    if (xmlReader.MoveToContent() != XmlNodeType.None && select == false)
                    {
                        Item.value = xmlReader.ReadInnerXml();
                        Item.value = Item.value.Trim();
                        select = false;
                    }

                    Program.Config.parameters.Add(Item);
                }
            }
            xmlReader.Close();
        }        

        // Methode die dem Saxon Prozessor je nach Config Einstellungen übergibt
        public Processor checkSettings(Processor processor)
        {
            // Whitespace Settings

            if (Properties.Settings.Default.saxon_sall == true)
            {


                processor.SetProperty("http://saxon.sf.net/feature/strip-whitespace", "all");


            }

            if (Properties.Settings.Default.saxon_snone == true)
            {


                processor.SetProperty("http://saxon.sf.net/feature/strip-whitespace", "none");


            }

            if (Properties.Settings.Default.saxon_signorable == true)
            {


                processor.SetProperty("http://saxon.sf.net/feature/strip-whitespace", "ignorable");


            }

            // Datenstruktur Settings

            if (Properties.Settings.Default.saxon_ds == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/treeModelName", "linkedTree");

            }

            if (Properties.Settings.Default.saxon_dt == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/treeModelName", "tinyTree");

            }

            // Fehlerbehandlungssettings

            if (Properties.Settings.Default.saxon_w0 == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/recoveryPolicyName", "recoverSilently");

            }

            if (Properties.Settings.Default.saxon_w1 == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/recoveryPolicyName", "recoverWithWarnings");

            }

            if (Properties.Settings.Default.saxon_w2 == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/recoveryPolicyName", "doNotRecover");

            }

            // Versionswarnung wegen Stylesheet ... wenn 1.0 dann Warnung

            if (Properties.Settings.Default.saxon_versionwarn == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/version-warning", "true");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/version-warning", "false");

            }

            // Zeilennummerrierung erhalten
            if (Properties.Settings.Default.saxon_l == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/linenumbering", "true");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/linenumbering", "false");

            }

            // timing aktivieren
            if (Properties.Settings.Default.saxon_timing == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/timing", "true");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/timing", "false");

            }

            // explain aktivieren
            if (Properties.Settings.Default.saxon_explain == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/trace-optimizer-decisions", "true");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/trace-optimizer-decisions", "false");

            }

            // trace externe funktionen aktivieren
            if (Properties.Settings.Default.saxon_traceextfunct == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/trace-external-functions", "true");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/trace-external-functions", "false");

            }

            // xml 1.0 oder 1.1 aktivieren
            if (Properties.Settings.Default.saxon_xml11 == true)
            {

                processor.SetProperty("http://saxon.sf.net/feature/xml-version", "1.1");

            }
            else
            {

                processor.SetProperty("http://saxon.sf.net/feature/xml-version", "1.0");

            }

            // Diese beiden Properties scheinen ohne Wirkung zu sein.
            //processor.SetProperty("http://saxon.sf.net/feature/compile-with-tracing", "true");           
            //processor.SetProperty("http://saxon.sf.net/feature/validation-warnings", "true");  

            return processor;
        }

        // Umlenken des Fehlerkanals auf log.log ... Muss mit Java erledigt
        // werden, da Saxon nur auf die Fehlerausgabe von Java schreibt....
        // Dies ist möglich durch: http://www.ikvm.net/.
        public void RedirectStdErr(string meinlog)
        {

            java.lang.System.setErr(new java.io.PrintStream(meinlog));
            
        }

        // erzeugt eine temporäre datei, die als logfile dient
        private string makeTmpFile()
        {
            //gettempfilename() erzeugt direkt ein tempfile
            string tempFile = Path.GetTempFileName();
            return tempFile;
        }

        // Da die dotNet Implementierung "nur" auf den Standard Fehler Kanal unter Java System.err
        // schreibt, muss diese umgeleitet werden. Das passiert oben mit dem java.* aufruf. Ein wenig 
        // gefrickel. Aber was solls. Die Idee kam von Michael Kay persönlich. 
        // Die Ausgaben werden auf eine Datei namens "log.txt" umgeleitet. Diese gilt es nun auszulesen
        // und auszugeben. Genau das macht diese Funktion hier ... Danach wird diese temp. Datei gelöscht
        public bool LogFileAuslesen(string meinlog)
        {
            // Wird für die Rückgabe gebraucht, damit das Programm weiss, was es
            // in die Statuszeile schreiben soll ...
            bool lukeskywalker = false;

            // Fehlerkanal ausschalten, damit von der Datei gelesen werden kann
            java.lang.System.err.close();

            // Streamreader aufsetzen und aus Logfile lesen ... und danach löschen.
            StreamReader sr = null;

            try
            {

                sr = new StreamReader(meinlog);

            }
            catch (Exception)
            {

                Program.results.loadText_log("Fehler beim Lesen des Logfiles");
                return lukeskywalker;

            }

            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                Program.results.loadText_log(line);
                lukeskywalker = true;
            }

            sr.Close();

            return lukeskywalker;
        }

        public void deleteLogFile(string meinlog)
        {

            // löschen des logfiles
            try
            {
                System.IO.File.Delete(meinlog);
            }

            catch (Exception)
            {
                //Program.hauptfenster.setLogTxt("Fehler beim löschen der Logdatei");
                //Program.hauptfenster.setLogTxt(ex.Message.ToString());

            }

        }
    }
}