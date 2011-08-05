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

namespace Antilles
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

            schematronset = true; // für die progressbar

            // schema erzeugen
            try
            {
                theSchema = createSchema(schema);
            }
            catch (Exception ex)
            {

                Program.hauptfenster.setLogTxt(ex.Message);
                return;

            }
            if (folder)
            {
                // operation für einen ordner ausführen
                files = Directory.GetFiles(xmlfile);
                output = makeTmpFolder();
                Program.optimusprime.starteProzessor(files, output, theSchema, "");


                // schematronausgaben in txtfiles schreiben/konvertieren
                files = Directory.GetFiles(output);
                schematronsetstep2 = true; // damit die methode weiss das die jetzt *.txt nehmen soll                
                Program.optimusprime.starteProzessor(files, output, message, "");

                // files auslesen und ins log schreiben
                files = Directory.GetFiles(output, "*.txt");
                for (int i = 0; i < files.Count(); i++)
                {

                    TxTFileAuslesen(files[i], false, "");

                }
                schematronset = false;
                schematronsetstep2 = false;
                deleteFolder();

            }
            else
            {
                output = makeTmpFolder();
                string newfile = output + "\\" + "tmp.xml";

                // ohne folder also einzelfile ausführen
                Program.optimusprime.starteProzessor(xmlfile, theSchema, newfile);

                // Messages aufbereiten, teststadium
                Program.optimusprime.starteProzessor(newfile, message, newfile + ".txt");

                // files auslesen und ins log schreiben
                files = Directory.GetFiles(output, "*.txt");
                for (int i = 0; i < files.Count(); i++)
                {

                    TxTFileAuslesen(files[i], true, xmlfile);

                }

                schematronset = false;
                deleteFolder();
            }
            deletetmpFiles();
        }

        // kompiliert das schemafile
        public string createSchema(string dasInputSchema)
        {
            schema1 = Path.GetTempPath() + "schema1.sch";
            schema2 = Path.GetTempPath() + "schema2.sch";
            theSchema = Path.GetTempPath() + "theSchema.xsl";            
            
            schema1 = Program.optimusprime.starteProzessor(dasInputSchema, step1, schema1);
            schema2 = Program.optimusprime.starteProzessor(schema1, step2, schema2);
            theSchema = Program.optimusprime.starteProzessor(schema2, step3, theSchema);

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

            catch (Exception ex)
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
            catch (Exception ex)
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
                    Program.hauptfenster.setLogTxt("In Datei " + path + ": ");
                }
                Program.hauptfenster.setLogTxt(line);
                flag = false;
            }

            sr.Close();
        }
    }
}
