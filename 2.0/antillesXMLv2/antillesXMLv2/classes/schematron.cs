// ------------------------------------------------------------------------ //
// schematron class                                                         //
//                                                                          //
// Hier wird die Schematron Funktionalität implementiert                    //
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



namespace antillesXMLv2
{
    /*
      xslt -stylesheet iso_dsdl_include.xsl  theSchema.sch > theSchema1.sch
      xslt -stylesheet iso_abstract_expand.xsl  theSchema1.sch > theSchema2.sch
      xslt -stylesheet iso_svrl_for_xslt2.xsl  theSchema2.sch > theSchema.xsl
      xslt -stylesheet theSchema.xsl  myDocument.xml > myResult.xml
    */

    class schematron
    {
        string fileName = Path.Combine(Application.StartupPath, "lib\\schematron\\");
        
        public string step1;
        public string step2;
        public string step3;
        public string message;
        public string schema1 = "schema1.sch";
        public string schema2 = "schema2.sch";
        public string theSchema = "theSchema.xsl";
        public string output = null;
        public string tmpfile = null;
        public bool folder = false;
        public bool schematronset = false; // für die progressbar 
        public bool schematronsetstep2 = false; // für die nachbearbeitung
        public string[] files;

        public schematron()
        {

            step1 = fileName + "iso_dsdl_include.xsl";
            step2 = fileName + "iso_abstract_expand.xsl";
            step3 = fileName + "iso_svrl_for_xslt2.xsl";

            message = fileName + "SvrlReportText.xslt";

        }

        // die hauptfunktion die aufgerufen wird
        public void schema_engage(string schema, string xmlfile)
        {

            //schematronset = true; // für die progressbar

            // schema erzeugen
            try
            {
                theSchema = createSchema(schema);
            }
            catch (Exception ex)
            {

                Program.mainframe.results.loadText_log(ex.Message);
                return;

            }
            if (folder)
            {
               
                //prepare folder
                try
                {
                    // init array
                    string[] files2;

                    List<string> filezList = new List<string>();
                    DirectoryInfo directory = new DirectoryInfo(xmlfile);
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

                    Program.mainframe.results.loadText_log(ex.Message);
                    Program.plsW.Hide();
                    return;

                }  

                output = makeTmpFolder();
                Program.transform.starteProzessor(files, output, theSchema, "");

                //prepare folder
                try
                {
                    // init array
                    string[] files2;

                    List<string> filezList = new List<string>();
                    DirectoryInfo directory = new DirectoryInfo(output);
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

                    Program.mainframe.results.loadText_log(ex.Message);
                    Program.plsW.Hide();
                    return;

                }  
                
                schematronsetstep2 = true; // damit die methode weiss das die jetzt *.txt nehmen soll                
                Program.transform.starteProzessor(files, output, message, "");


                //prepare folder
                try
                {
                    // init array
                    string[] files2;

                    List<string> filezList = new List<string>();
                    DirectoryInfo directory = new DirectoryInfo(output);
                    FileInfo[] filez = directory.GetFiles();

                    for (int i = 0; i < filez.Length; i++)
                    {

                        if (filez[i].Attributes == (FileAttributes.Hidden | FileAttributes.Archive)) continue;
                        if (filez[i].Extension != ".txt") continue;
                        
                        filezList.Add(filez[i].FullName);

                        
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

                    Program.mainframe.results.loadText_log(ex.Message);
                    Program.plsW.Hide();
                    return;

                }  
                
                for (int i = 0; i < files.Count(); i++)
                {

                    TxTFileAuslesen(files[i], false, "");

                }
                schematronset = false;
                schematronsetstep2 = false;
                deleteFolder();
                Program.Config.success = true;

            }
            else
            {
                output = makeTmpFolder();
                string newfile = output + "\\" + "tmp.xml";

                // ohne folder also einzelfile ausführen
                Program.transform.starteProzessor(xmlfile, theSchema, newfile);

                // Messages aufbereiten, teststadium
                Program.transform.starteProzessor(newfile, message, newfile + ".txt");

                // files auslesen und ins log schreiben
                files = Directory.GetFiles(output, "*.txt");
                for (int i = 0; i < files.Count(); i++)
                {

                    TxTFileAuslesen(files[i], true, xmlfile);

                }

                schematronset = false;
                deleteFolder();
                Program.Config.success = true;
            }
            deletetmpFiles();
        }

        // kompiliert das schemafile
        public string createSchema(string dasInputSchema)
        {
            schema1 = Path.GetTempPath() + "schema1.sch";
            schema2 = Path.GetTempPath() + "schema2.sch";
            theSchema = Path.GetTempPath() + "theSchema.xsl";

            schema1 = Program.transform.starteProzessor(dasInputSchema, step1, schema1);
            schema2 = Program.transform.starteProzessor(schema1, step2, schema2);
            theSchema = Program.transform.starteProzessor(schema2, step3, theSchema);

            return theSchema;

        }

        // erzeugt einen temporären ordner
        private string makeTmpFolder()
        {
            string tmp;
            string path = Path.GetTempPath();
            string nowdate = DateTime.Now.Millisecond.ToString();
            tmp = System.IO.Directory.CreateDirectory(path + "AntillesTmpSchematronWork" + nowdate).FullName;
            return tmp;
        }

        // löscht den temp ordner
        public void deleteFolder()
        {

            // löschen des logfiles
            try
            {
                System.IO.Directory.Delete(output, true);
            }

            catch (Exception)
            {                
                //Program.hauptfenster.setLogTxt("Fehler beim löschen des Ordners");
               // Program.hauptfenster.setLogTxt(ex.Message.ToString());

            }

        }

        // löschen der temp schema files
        public void deletetmpFiles()
        {
            try
            {

                System.IO.File.Delete(schema1);
                System.IO.File.Delete(schema2);
                System.IO.File.Delete(theSchema);

            }
            catch (Exception)
            {
               // Program.hauptfenster.setLogTxt("Fehler beim löschen der Schemafiles");
               // Program.hauptfenster.setLogTxt(ex.Message.ToString());
            }

        }

        // methode zum auslesen der temp textfiles. das bool und der letzte string sind
        // für das verhalten im falle einer einzeldatei relevant
        public void TxTFileAuslesen(string infile, bool style, string xmlfilename)
        {            

            Regex r = new Regex(@".*\\");
            bool flag = true;
            string path = "";

            // aufbereitung der eingangsdaten
            string[] input = r.Split(infile);

            // aufarbeitung der pfadangabe für das logfile
            if (style)
            {
                string[] input_orgfile = r.Split(xmlfilename);
                path = input_orgfile[1];
            }
            else path = input[1];           

            // Streamreader aufsetzen und aus file lesen ... und danach löschen.
            StreamReader sr = null;

            try
            {

                sr = new StreamReader(infile);

            }
            catch (Exception)
            {
                
              //  Program.hauptfenster.setLogTxt("Fehler beim Lesen des Logfiles");

            }

            string line = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (flag)
                {
                    Program.mainframe.results.loadText_log("In Datei " + path + ": ");
                }
                Program.mainframe.results.loadText_log(line);
                flag = false;
            }

            sr.Close();
        }
    }
}
