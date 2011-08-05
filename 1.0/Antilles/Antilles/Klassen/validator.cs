// ------------------------------------------------------------------------ //
// validatorclass                                                           //
//                                                                          //
// Hier wird die Validierung gegen XML Schema und DTD implementiert         //
// Sowohl Ordner als auch Einzelfiles sind möglich                          //
//                                                                          //
//                                                                          //
// ------------------------------------------------------------------------ //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Antilles
{
    class validator
    {

        public List<string> errors;
        public List<string> warnings;
        // ausgabeflag ist für die valid anzeige. die grüne/rote lampe
        public bool ausgabeflag = true;
        // variablen für den dtd workaround
        public string aktuellerFilename = "";
        public bool dtdsetflasg = false;

        public enum XmlValidatorResult
        {
            Valid,
            ErrorExists,
            WarningExists
        }

        public validator()
        {
            this.errors = new List<string>();
            this.warnings = new List<string>();
        }

        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {

            if (args.Severity == XmlSeverityType.Error)
            {
                // wenn das flag true ist, wird der dateiname aus dem globalen string eingefügt. wenn nicht, dann die Exception.SourceUri. 
                // muss so gemacht werden, wegen dem dtd workaround
                if (dtdsetflasg)
                {
                    this.errors.Add("Fehler gefunden in File: " + aktuellerFilename + Environment.NewLine + "In den Zeilen " + args.Exception.LineNumber.ToString() + " und " + args.Exception.LinePosition + Environment.NewLine + "Meldung: " + args.Message);
                }
                else
                {
                    this.errors.Add("Fehler gefunden in File: " + args.Exception.SourceUri + Environment.NewLine + "In den Zeilen " + args.Exception.LineNumber.ToString() + " und " + args.Exception.LinePosition + Environment.NewLine + "Meldung: " + args.Message);
                }
            }

            else if (dtdsetflasg)
            {
                this.warnings.Add("Warning gefunden in File: " + aktuellerFilename + Environment.NewLine + "In den Zeilen " + args.Exception.LineNumber.ToString() + " und " + args.Exception.LinePosition + Environment.NewLine + "Meldung: " + args.Message);
            }
            else
            {
                this.warnings.Add("Warning gefunden in File: " + args.Exception.SourceUri + Environment.NewLine + "In den Zeilen " + args.Exception.LineNumber.ToString() + " und " + args.Exception.LinePosition + Environment.NewLine + "Meldung: " + args.Message);
            }
        }

        private XmlValidatorResult ValidateXML(XmlReader xmlReader, ValidationType validationType, string schemaUri, string xmlFileName, bool dtdset)
        {

            this.errors.Clear();
            this.warnings.Clear();
            
            // umweg mit globalen variablen für das dtd workaround
            // damit korrekte fehlerausgaben möglich sind mit filename
            if (dtdset == true)
            {
                dtdsetflasg = true;
                aktuellerFilename = xmlFileName;
            }
            
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            settings.ValidationType = validationType;

            Program.hauptfenster.raiseProgressbar(); // progressbar++

            if (schemaUri != null)
            {
                try
                {
                   
                    // 22.07.2010
                    // Diese Kombination verhindert den "WurzelElement nicht deklariert" Bug

                    XmlSchema schema = new XmlSchema();
                    schema.SourceUri = schemaUri;

                    settings.ProhibitDtd = false;
                    settings.ProhibitDtd = false;
                    settings.IgnoreWhitespace = true;
                    settings.IgnoreComments = true;
                    settings.Schemas.Add(null, schemaUri);
                    //settings.Schemas.Add(schema);
                   
                    Program.hauptfenster.raiseProgressbar(); // progressbar++

                }
                catch (Exception ex)
                {
                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                    
                  //  Program.hauptfenster.setLogTxt("Fehler beim hinzufügen des externen Schemas" + schemaUri);
                    Program.hauptfenster.setLogTxt(ex.Message);

                }

            }

            
            settings.ValidationEventHandler += this.ValidationCallBack;
            XmlReader validationReader = null;

            try
            {

                validationReader = XmlReader.Create(xmlReader, settings);
                
                Program.hauptfenster.raiseProgressbar(); // progressbar++
            }

            /*
            catch (Exception ex)
            {

                errors.Add(ex.Message);

            }
            */

            catch (XmlException ex)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                //Program.hauptfenster.setLogTxt("Fehler beim einlesen des XML-Dokuments " + ex.Message);
                errors.Add(ex.Message);

            }
            catch (XmlSchemaException ex)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                //  Program.hauptfenster.setLogTxt(ex.Message);
                //Program.hauptfenster.setLogTxt(ex.InnerException.ToString());
                errors.Add("Fehler in Zeile: " + ex.LinePosition.ToString());
                errors.Add("Fehler in Zeile: " + ex.LineNumber.ToString());
                // Program.hauptfenster.setLogTxt(ex.Source);
                // Program.hauptfenster.setLogTxt(ex.SourceUri);
                //Program.hauptfenster.setLogTxt(ex.StackTrace);
                errors.Add(ex.Message);

            }

            try
            {
                
                while (validationReader.Read())
                {

                    Program.hauptfenster.raiseProgressbar(); // progressbar++

                }

            }
            catch (Exception ex)
            {

                this.errors.Add(ex.Message);


            }
           
            if (this.errors.Count == 0 && this.warnings.Count == 0)
            {

                Program.hauptfenster.setProgressbarMax();
                xmlReader.Close();
                return XmlValidatorResult.Valid;

            }
            else if (this.errors.Count == 0)
            {

                Program.hauptfenster.setProgressbarMax();
                xmlReader.Close();
                return XmlValidatorResult.WarningExists;

            }
            else
            {
                xmlReader.Close();
                return XmlValidatorResult.ErrorExists;

            }
                       
        }

        public void ValidiereXMLFile(string xmlFileName, ValidationType validationType, string schemeUri)
        {
            XmlValidatorResult result = XmlValidatorResult.Valid;           

            try
            {

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ProhibitDtd = false;
                result = ValidateXML(XmlReader.Create(xmlFileName, settings), validationType, schemeUri, xmlFileName, false);
            }

            catch (Exception ex)
            {
                //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                
                Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
            }
            

            switch (result)
            {

                case XmlValidatorResult.Valid:
                    if (ausgabeflag)
                    {
                        Program.hauptfenster.setStatusTxt("Das XML-File ist valide");
                        //Program.hauptfenster.setLogTxt("Das XML-File ist valide");
                    }
                    else
                    {
                        // valide, nachricht ans livelog senden
                        Regex r = new Regex(@".*\\");
                        string[] inputs = r.Split(xmlFileName);
                        Program.hauptfenster.setFehlermarker(true, inputs[1]);
                        ausgabeflag = true;
                    }
                    break;

                case XmlValidatorResult.WarningExists:
                    if (ausgabeflag)
                    {
                        //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                        Program.hauptfenster.setLogTxt("Das XML-File ist valide, aber es wurden Warnungen gemeldet: ");
                        
                        for (int i = 0; i < warnings.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(warnings[i].ToString());

                        }
                    }
                    else
                    {
                        //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                        // nicht valide, nachricht ans livelog senden
                        ausgabeflag = true;
                        Regex r = new Regex(@".*\\");
                        string[] inputs = r.Split(xmlFileName);
                        Program.hauptfenster.setFehlermarker(false, inputs[1]);                        
                        for (int i = 0; i < warnings.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(warnings[i].ToString());

                        }
                    }
                    break;

                case XmlValidatorResult.ErrorExists:
                    if (ausgabeflag)
                    {
                        //Program.hauptfenster.setStatusTxt("Das Dokument ist nicht valide. Bitte schauen sie ins Log");                        
                        for (int i = 0; i < errors.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(errors[i].ToString());

                        }
                        if (warnings.Count > 0)
                        {
                            Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {
                                Program.hauptfenster.setLogTxt(warnings[i].ToString());
                            }

                        }
                    }
                    else
                    {
                        // fehlerfeld rot färben. nur ein gag
                        //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                        ausgabeflag = true;
                        Regex r = new Regex(@".*\\");
                        string[] inputs = r.Split(xmlFileName);
                        Program.hauptfenster.setFehlermarker(false, inputs[1]);                        
                        for (int i = 0; i < errors.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(errors[i].ToString());

                        }
                        if (warnings.Count > 0)
                        {
                            Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {
                                Program.hauptfenster.setLogTxt(warnings[i].ToString());
                            }

                        }
                    }
                    break;
            }
            
        }
        // Überladene Funktion für Ordnerverarbeitung. Im wesentlichen sehr ähnlich. Nur der Anfang unterscheidet sich
        public void ValidiereXMLFile(string[] files, ValidationType validationType, string schemeUri, string marker)
        {

            Regex r = new Regex(@".*\\");

            for (int j = 0; j < files.Length; j++)
            {
                
                string[] inputs = r.Split(files[j]);
                string xmlFileName = files[j];

                XmlValidatorResult result = XmlValidatorResult.Valid;

                try
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ProhibitDtd = false;
                    result = ValidateXML(XmlReader.Create(xmlFileName, settings), validationType, schemeUri, xmlFileName, false);
                    
                }
                catch (XmlException ex)
                {
                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                    
                    Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
                }

                switch (result)
                {

                    case XmlValidatorResult.Valid:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Das XML-File ist valide");
                            //Program.hauptfenster.setLogTxt("Das XML-File ist valide");
                        }
                        else
                        {
                            // fehlerfeld grün färben. nur ein gag
                            Program.hauptfenster.setFehlermarker(true, marker);
                            ausgabeflag = true;
                        }
                        break;

                    case XmlValidatorResult.WarningExists:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");                            
                            Program.hauptfenster.setLogTxt("Das XML-File ist valide, aber es wurden Warnungen gemeldet: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(warnings[i].ToString());

                            }
                        }
                        else
                        {
                            //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                            // fehlerfeld rot färben. nur ein gag
                            ausgabeflag = true;                           
                            Program.hauptfenster.setFehlermarker(false, marker);
                            for (int i = 0; i < warnings.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(warnings[i].ToString());

                            }
                        }
                        break;

                    case XmlValidatorResult.ErrorExists:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Das Dokument ist nicht valide. Bitte schauen sie ins Log");                           
                            for (int i = 0; i < errors.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(errors[i].ToString());

                            }
                            if (warnings.Count > 0)
                            {
                                Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                                for (int i = 0; i < warnings.Count; i++)
                                {
                                    Program.hauptfenster.setLogTxt(warnings[i].ToString());
                                }

                            }
                        }
                        else
                        {
                            // fehlerfeld rot färben. nur ein gag
                            //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                            ausgabeflag = true;
                            Program.hauptfenster.setFehlermarker(false, marker);                            
                            for (int i = 0; i < errors.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(errors[i].ToString());

                            }
                            if (warnings.Count > 0)
                            {
                                Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                                for (int i = 0; i < warnings.Count; i++)
                                {
                                    Program.hauptfenster.setLogTxt(warnings[i].ToString());
                                }

                            }
                        }
                        break;
                }
            }           
        }


        // da die c# engine keine externen dtds parsen kann, wenn sie NICHT im xml file selbst vorkommen,
        // muss dieser workaround herhalten. Hier wird eine kopie des zu lesenden files gemacht, welches
        // mit einem doctype eintrag für die dtd erweitert wird. dieses file wird dann geparst und einwandfrei
        // gegen die dtd geprüft. Aber nur wenn keine DTD inline deklariert wurde. 
        public void ValidiereXMLFileDtD(string xmlFileName, ValidationType validationType, string schemeUri, string marker)
        {

            XmlDocument doc = new XmlDocument();
            XmlValidatorResult result = XmlValidatorResult.Valid;
            bool docflag = false;
            try
            {
                doc.Load(xmlFileName);
            }
            catch (Exception)
            {
                // nix
            }
            
            // Prüfen ob eine DTD im xml file vorliegt. 
            try
            {

                string doctype = doc.DocumentType.SystemId;

            }
                
            catch (Exception)
            {

                docflag = true;

            }

            if (docflag)
            {
                string rootelementname = "";
                try
                {
                    rootelementname = doc.DocumentElement.Name;
                }
                catch (Exception)
                {
                    //Program.hauptfenster.setLogTxt(ex.Message);
                    rootelementname = "debug";
                }

                doc.InsertBefore(doc.CreateDocumentType(rootelementname, null, schemeUri, null),
                        doc.DocumentElement);

                StringWriter sw = new StringWriter();
                doc.Save(sw);
                
                try
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ProhibitDtd = false;
                    result = ValidateXML(XmlReader.Create(new StringReader(sw.ToString()), settings), validationType, schemeUri, xmlFileName, true);                    
                    sw.Close();
                }
                catch (XmlException ex)
                {
                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                    
                    Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
                }

            }
            else
            {

                try
                {

                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ProhibitDtd = false;
                    result = ValidateXML(XmlReader.Create(xmlFileName, settings), validationType, schemeUri, xmlFileName, false);
                    
                }
                catch (XmlException ex)
                {
                    //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                    
                    Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
                }

            }
            

            switch (result)
            {

                case XmlValidatorResult.Valid:
                    if (ausgabeflag)
                    {
                        //Program.hauptfenster.setStatusTxt("Das XML-File ist valide");
                        //Program.hauptfenster.setLogTxt("Das XML-File ist valide");
                    }
                    else
                    {
                        // fehlerfeld grün färben. nur ein gag
                        Program.hauptfenster.setFehlermarker(true, marker);
                        ausgabeflag = true;
                    }
                    break;

                case XmlValidatorResult.WarningExists:
                    if (ausgabeflag)
                    {
                       // Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");                       
                        Program.hauptfenster.setLogTxt("Das XML-File ist valide, aber es wurden Warnungen gemeldet: ");
                        for (int i = 0; i < warnings.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(warnings[i].ToString());

                        }
                    }
                    else
                    {
                        //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");                       
                        // fehlerfeld rot färben. nur ein gag                        
                        ausgabeflag = true;
                        Program.hauptfenster.setFehlermarker(false, marker);
                        for (int i = 0; i < warnings.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(warnings[i].ToString());

                        }
                    }
                    break;

                case XmlValidatorResult.ErrorExists:
                    if (ausgabeflag)
                    {
                        //Program.hauptfenster.setStatusTxt("Das Dokument ist nicht valide. Bitte schauen sie ins Log");                       
                        for (int i = 0; i < errors.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(errors[i].ToString());

                        }
                        if (warnings.Count > 0)
                        {
                            Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {
                                Program.hauptfenster.setLogTxt(warnings[i].ToString());
                            }

                        }
                    }
                    else
                    {
                        // fehlerfeld rot färben. nur ein gag
                        //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                        ausgabeflag = true;                        
                        Program.hauptfenster.setFehlermarker(false, marker);
                        for (int i = 0; i < errors.Count; i++)
                        {

                            Program.hauptfenster.setLogTxt(errors[i].ToString());

                        }
                        if (warnings.Count > 0)
                        {
                            Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {
                                Program.hauptfenster.setLogTxt(warnings[i].ToString());
                            }

                        }
                    }
                    break;
            }    
            
        }

        // überladung auch für ordner
        public void ValidiereXMLFileDtD(string[] files, ValidationType validationType, string schemeUri, string marker)
        {
            Regex r = new Regex(@".*\\");
            XmlValidatorResult result = XmlValidatorResult.Valid;

            
            for (int j = 0; j < files.Length; j++)
            {                
                string[] inputs = r.Split(files[j]);
                string xmlFileName = files[j];                
                XmlDocument doc = new XmlDocument();                
                bool docflag = false;
                doc.Load(xmlFileName);

                // Prüfen ob eine DTD im xml file vorliegt. 
                try
                {

                    string doctype = doc.DocumentType.SystemId;

                }

                catch (Exception)
                {

                    docflag = true;

                }

                if (docflag)
                {

                    string rootelementname = "";

                    try
                    {
                        rootelementname = doc.DocumentElement.Name;
                    }
                    catch (Exception)
                    {
                        //Program.hauptfenster.setLogTxt(ex.Message);
                        rootelementname = "debug";
                    }
                    
                    doc.InsertBefore(doc.CreateDocumentType(rootelementname, null, schemeUri, null),
                            doc.DocumentElement);

                    StringWriter sw = new StringWriter();
                    doc.Save(sw);

                    try
                    {
                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.ProhibitDtd = false;
                        result = ValidateXML(XmlReader.Create(new StringReader(sw.ToString()), settings), validationType, schemeUri, xmlFileName, true);
                    }
                    catch (XmlException ex)
                    {
                        //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");
                        Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
                    }

                }
                else
                {

                    try
                    {

                        XmlReaderSettings settings = new XmlReaderSettings();
                        settings.ProhibitDtd = false;
                        result = ValidateXML(XmlReader.Create(xmlFileName, settings), validationType, schemeUri, xmlFileName, false);
                    }
                    catch (XmlException ex)
                    {
                        //Program.hauptfenster.setStatusTxt("Es gab einen oder mehrere Fehler. Bitte schauen Sie ins Log");                      
                        Program.hauptfenster.setLogTxt("Fehler " + ex.Message);
                    }

                }

                switch (result)
                {

                    case XmlValidatorResult.Valid:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Durchlauf fertig. Bitte schauen sie ins Log.");
                            //Program.hauptfenster.setLogTxt("Das XML-File ist valide");
                        }
                        else
                        {
                            // fehlerfeld grün färben. nur ein gag
                            Program.hauptfenster.setFehlermarker(true, marker);
                            ausgabeflag = true;
                        }
                        break;

                    case XmlValidatorResult.WarningExists:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");                          
                            Program.hauptfenster.setLogTxt("Das XML-File ist valide, aber es wurden Warnungen gemeldet: ");
                            for (int i = 0; i < warnings.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(warnings[i].ToString());

                            }
                        }
                        else
                        {
                            //Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                            // fehlerfeld rot färben. nur ein gag
                            ausgabeflag = true;
                            Program.hauptfenster.setFehlermarker(false, marker);
                            for (int i = 0; i < warnings.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(warnings[i].ToString());

                            }
                        }
                        break;

                    case XmlValidatorResult.ErrorExists:
                        if (ausgabeflag)
                        {
                            //Program.hauptfenster.setStatusTxt("Das Dokument ist nicht valide. Bitte schauen sie ins Log");                            
                            for (int i = 0; i < errors.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(errors[i].ToString());

                            }
                            if (warnings.Count > 0)
                            {
                                Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                                for (int i = 0; i < warnings.Count; i++)
                                {
                                    Program.hauptfenster.setLogTxt(warnings[i].ToString());
                                }

                            }
                        }
                        else
                        {
                            // fehlerfeld rot färben. nur ein gag
                           // Program.hauptfenster.setStatusTxt("Bitte schauen sie ins Log");
                            ausgabeflag = true;                           
                            Program.hauptfenster.setFehlermarker(false, marker);
                            for (int i = 0; i < errors.Count; i++)
                            {

                                Program.hauptfenster.setLogTxt(errors[i].ToString());

                            }
                            if (warnings.Count > 0)
                            {
                                Program.hauptfenster.setLogTxt("Folgende Warnungen: ");
                                for (int i = 0; i < warnings.Count; i++)
                                {
                                    Program.hauptfenster.setLogTxt(warnings[i].ToString());
                                }

                            }
                        }
                        break;
                }
            }            
        }
    }
}

