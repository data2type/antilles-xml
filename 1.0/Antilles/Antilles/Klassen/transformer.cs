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
using System.Reflection;  


namespace Antilles
{
    class transformer
    {
        public bool pipelineaktiv = true;

        /// <summary>
        /// Methode die den Saxon Prozessor startet. Benötigt keine Übergabevariablen, da diese von der Config 
        /// Klasse geliefert werden.
        /// </summary>
        public void starteProzessor()
        {

            Program.hauptfenster.raiseProgressbar(); // progressbar++
            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor();

                // die abfrage der einstellungen 
                processor = checkSettings(processor);

                XdmNode input = processor.NewDocumentBuilder().Build(new Uri(Program.konfiguration.xmlfilepath));

                // Create the XSLT Compiler
                XsltCompiler compiler = processor.NewXsltCompiler();

                compiler.ErrorList = FehlerListe;

                // Create a transformer for the stylesheet.
                XsltTransformer xslttransformer = compiler.Compile(new Uri(Program.konfiguration.xsltfilepath)).Load();

                // Set the root node of the source document to be the initial context node
                xslttransformer.InitialContextNode = input;

                // parameter prüfen
                xslttransformer = checkParameter(xslttransformer);

                // Create a serializer                

                FileStream target = new FileStream(Program.konfiguration.outfile, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(target);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                Program.hauptfenster.raiseProgressbar(); // progressbar++

                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                target.Close();

                //Program.hauptfenster.setStatusTxt("Ausgabe geschrieben in " + Program.konfiguration.outfile);
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }

                Program.hauptfenster.raiseProgressbar(); // progressbar++

                //serializer.Close();
                deleteLogFile(meinlog);

            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                Program.hauptfenster.setLogTxt(ausgabe);
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }

            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                //string mama = test.getMessage().ToString();
                Program.hauptfenster.setLogTxt(ausgabe);

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
                    Program.hauptfenster.setLogTxt(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {

                        Program.hauptfenster.setLogTxt(FehlerListe[i].ToString());

                    }
                }
            }
            // deleteLogFile(meinlog);
            serializer.Close();
            Program.hauptfenster.setProgressbarMax(); // progressbarmax          
        }

        // Überladene Funktion für Ordnerauslesen. Bekommt einen Stringarray (die strings mit filenamen
        // einen String mit dem Zieldordner und den Pfad zum Xslt Stylesheet
        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese überladene Variante braucht einen string Array, 
        /// einen Zielordner und das Stylesheet, abschliessend noch die extension...kam mit der fo implementierung
        /// dazu.
        /// </summary>
        public void starteProzessor(string[] files, string outputfolder, string xsl, string extension)
        {
            ArrayList FehlerListe = new ArrayList();
            Program.hauptfenster.raiseProgressbar(); // progressbar++
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

                    Program.hauptfenster.raiseProgressbar();

                    // aufbereitung der eingangsdaten
                    string[] inputs = r.Split(files[i]);
                    string outputfilename = outputfolder + "\\" + inputs[1];
                    // falls schematron läuft, dann *.txt hinten anhängen
                    if (Program.schematronboy.schematronsetstep2) outputfilename = outputfolder + "\\" + inputs[1] + ".txt";
                    if (extension != "") Program.konfiguration.outfile = outputfilename + extension;
                    else Program.konfiguration.outfile = outputfilename;
                    Program.konfiguration.xsltfilepath = xsl;
                    Program.konfiguration.xmlfilepath = files[i];
                    Program.hauptfenster.raiseProgressbar(); // progressbar++

                    // Create a Processor instance.
                    Processor processor = new Processor();

                    // die abfrage der einstellungen 
                    processor = checkSettings(processor);

                    // Create the XSLT Compiler
                    XsltCompiler compiler = processor.NewXsltCompiler();

                    compiler.ErrorList = FehlerListe;

                    XdmNode input = processor.NewDocumentBuilder().Build(new Uri(Program.konfiguration.xmlfilepath));

                    // Create a transformer for the stylesheet.
                    XsltTransformer xslttransformer = compiler.Compile(new Uri(Program.konfiguration.xsltfilepath)).Load();

                    // Set the root node of the source document to be the initial context node
                    xslttransformer.InitialContextNode = input;

                    // parameter prüfen
                    xslttransformer = checkParameter(xslttransformer);

                    // Create a serializer           

                    FileStream target = new FileStream(Program.konfiguration.outfile, FileMode.Create, FileAccess.Write);
                    serializer.SetOutputStream(target);
                    // Transform the source XML to System.out.
                    xslttransformer.Run(serializer);
                    Program.hauptfenster.raiseProgressbar(); // progressbar++
                    // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                    target.Close();

                    if (Program.schematronboy.schematronset)
                    {
                        //Program.hauptfenster.setStatusTxt("Schematron fertig");
                    }
                    //else Program.hauptfenster.setStatusTxt("Ausgabe erstellt in " + outputfolder);
                    //serializer.Close();
                }


                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.raiseProgressbar(); // progressbar++

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
                Program.hauptfenster.setLogTxt(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                // Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                Program.hauptfenster.setLogTxt(ausgabe);
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
            }
            catch (Exception exc)
            {
                if (exc.Message == "Value cannot be null.\r\nParameter name: uriString")
                {
                    //Program.hauptfenster.setStatusTxt("Sie haben keine Dateien angegeben");
                }
                else
                {

                    // Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                    string ausgabe = "Failed unexpectedly: " + exc.Message;
                    Program.hauptfenster.setLogTxt(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {

                        Program.hauptfenster.setLogTxt(FehlerListe[i].ToString());

                    }


                }

            }

            finally
            {
                deleteLogFile(meinlog);
                Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
            }

            serializer.Close();
            Program.hauptfenster.setProgressbarMax(); // progressbarmax

        }

        // überladene funktion
        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. Mit "step" als Bezeichnung schlecht gewählt.
        /// </summary>
        public string starteProzessor(string doc, string xsltfile, string step)
        {
            Program.hauptfenster.raiseProgressbar(); // progressbar++
            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor();

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
                FileStream target = new FileStream(step, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(target);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                Program.hauptfenster.raiseProgressbar(); // progressbar++
                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                target.Close();

                if (Program.schematronboy.schematronset)
                {
                    //Program.hauptfenster.setStatusTxt("Schematron fertig (Bitte schauen Sie ins Log)");
                }
                else if (Program.konfiguration.htmlSchemaBerichtset)
                {
                    //Program.hauptfenster.setStatusTxt("Bericht erstellt");
                }
                //else Program.hauptfenster.setStatusTxt("Ausgabe geschrieben in " + Program.konfiguration.outfile);

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);
                Program.hauptfenster.raiseProgressbar(); // progressbar++
                Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
                serializer.Close();
                return step;
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
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
                    Program.hauptfenster.setLogTxt(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {

                        Program.hauptfenster.setLogTxt(FehlerListe[i].ToString());

                    }
                }
            }
            serializer.Close();
            Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
            //deleteLogFile(meinlog);
            return step;
        }

        // überladene funktion
        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. Mit "step" als Bezeichnung schlecht gewählt.
        /// Angepasst für die WordML Verarbeitung ...
        /// </summary>
        public string starteProzessor(string doc, string xsltfileWord, string step, bool dummy)
        {
            Program.hauptfenster.raiseProgressbar(); // progressbar++
            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor();

                // die abfrage der einstellungen 
                processor = checkSettings(processor);

                XdmNode input = processor.NewDocumentBuilder().Build(new Uri(doc));

                // Create the XSLT Compiler
                XsltCompiler compiler = processor.NewXsltCompiler();

                compiler.ErrorList = FehlerListe;
              
                // transformer erzeugen und compilieren        
                string filePath = "Antilles.Stylesheets." + xsltfileWord + ".xsl";               
                Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);
                XsltTransformer xslttransformer = compiler.Compile(fileStream).Load();

                // Set the root node of the source document to be the initial context node
                xslttransformer.InitialContextNode = input;

                // parameter prüfen
                xslttransformer = checkParameter(xslttransformer);

                // Create a serializer                 
                FileStream target = new FileStream(step, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(target);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                Program.hauptfenster.raiseProgressbar(); // progressbar++
                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                target.Close();

                if (Program.schematronboy.schematronset)
                {
                    //Program.hauptfenster.setStatusTxt("Schematron fertig (Bitte schauen Sie ins Log)");
                }
                else if (Program.konfiguration.htmlSchemaBerichtset)
                {
                    //Program.hauptfenster.setStatusTxt("Bericht erstellt");
                }
                //else Program.hauptfenster.setStatusTxt("Ausgabe geschrieben in " + Program.konfiguration.outfile);

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);
                Program.hauptfenster.raiseProgressbar(); // progressbar++
                Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
                serializer.Close();
                return step;
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
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
                    Program.hauptfenster.setLogTxt(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {

                        Program.hauptfenster.setLogTxt(FehlerListe[i].ToString());

                    }
                }
            }
            serializer.Close();
            Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
            //deleteLogFile(meinlog);
            return step;
        }
        
        /// <summary>
        /// Methode die den Saxon Prozessor startet. Diese Variante bekommt zunächst das Eingangsfile, 
        /// dann das Stylesheet und Abschliessend den Zielfilenamen. Hat keinen Rückgabewert und ist 
        /// eine Variante für das Hotfolder Feature.
        /// </summary>        
        public void starteProzessorHotfolder(string doc, string xsltfile, string ziel)
        {

            Program.hauptfenster.raiseProgressbar(); // progressbar++            
            ArrayList FehlerListe = new ArrayList();
            Serializer serializer = new Serializer();
            string meinlog = makeTmpFile();

            try
            {

                RedirectStdErr(meinlog);

                // Create a Processor instance.
                Processor processor = new Processor();

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
                FileStream target = new FileStream(ziel, FileMode.Create, FileAccess.Write);
                serializer.SetOutputStream(target);

                // Transform the source XML to System.out.              
                xslttransformer.Run(serializer);

                //Program.hauptfenster.raiseProgressbar(); // progressbar++
                // Hier filestream schliessen, da sonst überschreiben von selbem filename nicht möglich ist
                target.Close();

                if (Program.schematronboy.schematronset)
                {
                    //Program.hauptfenster.setStatusTxt("Schematron fertig (Bitte schauen Sie ins Log)");
                }
                else if (Program.konfiguration.htmlSchemaBerichtset)
                {
                    //Program.hauptfenster.setStatusTxt("Bericht erstellt");
                }
                //else Program.hauptfenster.setStatusTxt("Ausgabe geschrieben in " + Program.konfiguration.outfile);

                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                deleteLogFile(meinlog);
                serializer.Close();
                Program.hauptfenster.raiseProgressbar(); // progressbar++
            }


            catch (Saxon.Api.StaticError se)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Static error: " + se.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
            }
            catch (Saxon.Api.DynamicError de)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                string ausgabe = "Dynamic error: " + de.Message;
                if (LogFileAuslesen(meinlog))
                {

                    //Program.hauptfenster.setStatusTxt("Bitte schauen Sie ins Log");

                }
                Program.hauptfenster.setLogTxt(ausgabe);
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
                    Program.hauptfenster.setLogTxt(ausgabe);
                    for (int i = 0; i < FehlerListe.Count; i++)
                    {

                        Program.hauptfenster.setLogTxt(FehlerListe[i].ToString());

                    }
                }
            }
            serializer.Close();
            Program.hauptfenster.setProgressbarMax(); // Progressbar auf 200 setzen
            //deleteLogFile(meinlog);

        }

        public XsltTransformer checkParameter(XsltTransformer transformer)
        {

            for (int i = 0; i < Program.konfiguration.parameters.Count; i++)
            {

                XdmAtomicValue val = new XdmAtomicValue(Program.konfiguration.parameters[i].value);
                QName param = new QName("", "", Program.konfiguration.parameters[i].param);

                transformer.SetParameter(param, val);


            }

            return transformer;
            

        }

        public void getParameter(string xsltfile)
        {

            if (xsltfile == null || xsltfile == "") return;

            // Liste leeren, nur wenn nicht in Pipeline
            if (!Program.konfiguration.piplelineaktiv) Program.konfiguration.parameters.Clear();

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

                    Program.konfiguration.parameters.Add(Item);
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

                Program.hauptfenster.setLogTxt("Fehler beim Lesen des Logfiles");
                return lukeskywalker;

            }

            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                Program.hauptfenster.setLogTxt(line);
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