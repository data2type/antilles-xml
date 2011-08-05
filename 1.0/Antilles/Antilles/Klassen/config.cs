// ------------------------------------------------------------------------ //
// config class                                                             //
//                                                                          //
// Diese Klasse stellt die Configeinstellungen bereit                       //
// Also die Pfade im Dateisystem zu den entsprechenden Dokumenten           //
//                                                                          //
// ------------------------------------------------------------------------ //

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml;

namespace Antilles
{
    class config
    {

        // parameter liste und bool flag für transformationen
        // und flag für pipeline. relevant für die parameter-
        // übergabe, da diese bei der pipeline anders implementiert
        // werden musste.
        public List<parameter> parameters = new List<parameter>();
        public bool parameter_neuesfile = false;
        public bool piplelineaktiv = false;

        // Boolschwer Wert für XsdBerichterstellung
        private bool HtmlSchemaBerichtset = false; // Standard Wert
        public bool htmlSchemaBerichtset
        {
            set
            {
                HtmlSchemaBerichtset = value;
            }
            get
            {
                return HtmlSchemaBerichtset;
            }

        }

        // Werte für die XSL-FO Variablen
        private string XmlfileOrFolderFOpath;
        public string xmlfileOrFolderFOpath
        {
            set
            {
                XmlfileOrFolderFOpath = value;
            }
            get
            {
                return XmlfileOrFolderFOpath;
            }

        }

        private string XmlfileOrFolderFOTargetpath;
        public string xmlfileOrFolderFOTargetpath
        {
            set
            {
                XmlfileOrFolderFOTargetpath = value;
            }
            get
            {
                return XmlfileOrFolderFOTargetpath;
            }

        }

        private string XsltfileFOpath;
        public string xsltfileFOpath
        {
            set
            {
                XsltfileFOpath = value;
            }
            get
            {
                return XsltfileFOpath;
            }

        }

        // Variablen für WordML Feature
        private string WordMLFileName;
        public string wordMLFileName
        {
            set
            {
                WordMLFileName = value;
            }
            get
            {
                return WordMLFileName;
            }

        }

        private string WordMLFileNameZiel;
        public string wordMLFileNameZiel
        {
            set
            {
                WordMLFileNameZiel = value;
            }
            get
            {
                return WordMLFileNameZiel;
            }

        }

        // Stringübergaben und auslesen für Dateien 
        // und Ordnerangaben (Für Transformationen)
        // also XSLT Einzel und Ordnerweise
        private string Xmlfilepath;
        public string xmlfilepath
        {
            set
            {
                Xmlfilepath = value;
            }
            get
            {
                return Xmlfilepath;
            }

        }

        private string Xsltfilepath;
        public string xsltfilepath
        {
            set
            {
                Xsltfilepath = value;
            }
            get
            {
                return Xsltfilepath;
            }

        }

        private string Outfile;
        public string outfile
        {
            set
            {
                Outfile = value;
            }
            get
            {
                return Outfile;
            }

        }

        private string Inputpath;
        public string inputpath
        {
            set
            {
                Inputpath = value;
            }
            get
            {
                return Inputpath;
            }

        }

        private string Outputpath;
        public string outputpath
        {
            set
            {
                Outputpath = value;
            }
            get
            {
                return Outputpath;
            }

        }

        // Strings für Schematron
        private string SchematronSchema;
        public string schematronSchema
        {
            set
            {
                SchematronSchema = value;
            }
            get
            {
                return SchematronSchema;
            }

        }

        private string SchematronXML;
        public string schematronXML
        {
            set
            {
                SchematronXML = value;
            }
            get
            {
                return SchematronXML;
            }

        }

        // String für XSD Schemabericht Ziel
        private string HtmlSchemaBericht;
        public string htmlSchemaBericht
        {
            set
            {
                HtmlSchemaBericht = value;
            }
            get
            {
                return HtmlSchemaBericht;
            }

        }

        // Strings für Xslt Pipe
        // die Target Variable ist
        // nur für das speichern der
        // pipe relevant
        private string XsltfilepathPipe;
        public string xsltfilepathPipe
        {
            set
            {
                XsltfilepathPipe = value;
            }
            get
            {
                return XsltfilepathPipe;
            }

        }

        private string XmlfilepathPipe;
        public string xmlfilepathPipe
        {
            set
            {
                XmlfilepathPipe = value;
            }
            get
            {
                return XmlfilepathPipe;
            }

        }

        private string XmlfilepathTargetPipe;
        public string xmlfilepathTargetPipe
        {
            set
            {
                XmlfilepathTargetPipe = value;
            }
            get
            {
                return XmlfilepathTargetPipe;
            }

        }

        // Strings für cal2html
        private string Cal2Htmlinput;
        public string cal2htmlinput
        {

            set
            {

                Cal2Htmlinput = value;

            }
            get
            {

                return Cal2Htmlinput;

            }

        }

        private string Cal2Htmltarget;
        public string cal2Htmltarget
        {

            set
            {

                Cal2Htmltarget = value;

            }
            get
            {

                return Cal2Htmltarget;

            }

        }

        // Strings für XML darstellen
        private string XmlBerichtQuelle;
        public string xmlBerichtQuelle
        {

            set
            {

                XmlBerichtQuelle = value;

            }
            get
            {

                return XmlBerichtQuelle;

            }

        }

        private string XmlBerichtZiel;
        public string xmlBerichtZiel
        {

            set
            {

                XmlBerichtZiel = value;

            }
            get
            {

                return XmlBerichtZiel;

            }

        }
        // Strings/Bool für Xproc
        private string Xprocfile;
        public string xprocfile
        {

            set
            {

                Xprocfile = value;

            }
            get
            {

                return Xprocfile;

            }

        }

        // Strings für Xslt Kompilierungen
        private string XsltFileKompilierungInput;
        public string xsltFileKompilierungInput
        {
            set
            {
                XsltFileKompilierungInput = value;
            }
            get
            {
                return XsltFileKompilierungInput;
            }

        }

        private string XsltFileKompilierungZiel;
        public string xsltFileKompilierungZiel
        {
            set
            {
                XsltFileKompilierungZiel = value;
            }
            get
            {
                return XsltFileKompilierungZiel;
            }

        }

        // Strings für Validierung

        private string XmlFilenameValid;
        public string xmlFilenameValid
        {
            set
            {
                XmlFilenameValid = value;
            }
            get
            {
                return XmlFilenameValid;
            }

        }

        private string XmlFilenameValidFolder;
        public string xmlFilenameValidFolder
        {
            set
            {
                XmlFilenameValidFolder = value;
            }
            get
            {
                return XmlFilenameValidFolder;
            }

        }

        private string XmlSchemaFileName;
        public string xmlSchemaFileName
        {
            set
            {
                XmlSchemaFileName = value;
            }
            get
            {
                return XmlSchemaFileName;
            }

        }

        private string DtDSchemaFile;
        public string dtdSchemaFile
        {
            set
            {
                DtDSchemaFile = value;
            }
            get
            {
                return DtDSchemaFile;
            }

        }

        // Strings für XSLT Hotfolder
        private string XmlfilepathHotfolder;
        public string xmlfilepathHotfolder
        {
            set
            {
                XmlfilepathHotfolder = value;
            }
            get
            {
                return XmlfilepathHotfolder;
            }

        }

        private string XmlfilepathTargetHotfolder;
        public string xmlfilepathTargetHotfolder
        {
            set
            {
                XmlfilepathTargetHotfolder = value;
            }
            get
            {
                return XmlfilepathTargetHotfolder;
            }

        }

        private string XsltfilepathHotfolder;
        public string xsltfilepathHotfolder
        {
            set
            {
                XsltfilepathHotfolder = value;
            }
            get
            {
                return XsltfilepathHotfolder;
            }

        }

        private bool XmlHotfolder = false; // standard wert
        public bool xmlHotfolder
        {
            set
            {
                XmlHotfolder = value;
            }
            get
            {
                return XmlHotfolder;
            }

        }

    }

}
