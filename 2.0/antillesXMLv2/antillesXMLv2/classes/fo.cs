// ------------------------------------------------------------------------ //
// xslformater class                                                        //
//                                                                          //
// Hier werden die Formater auf der Kommandozeile angesprochen              //
//                                                                          //
//                                                                          //
// ------------------------------------------------------------------------ //
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Threading;


namespace antillesXMLv2
{
    class xslformater
    {
        // bekannter pfad zu fop
        
        string fop = Path.Combine(Application.StartupPath, "lib\\fop\\fop.bat");
        private static Mutex mutex = new Mutex();
        public string log; 

        public xslformater()
        {

            // wahrscheinlich brauchts hier keinen konstruktor

        }

        public void formatiere(string[] fofile, bool fileOrFolder, string formatierer)
        {
            string kommadozeilenaufruf = "";
            string location = Program.Config.target;
            string originalformatierer = formatierer;

            switch (fileOrFolder)
            {
                // Ordnerweise
                case true:

                    string target = "";
                    Regex r = new Regex(@".*\\");
                    for (int i = 0; i < fofile.Length; i++)
                    {

                        switch (formatierer)
                        {
                            case "fop":
                                formatierer = fop;
                                target = fofile[i].Replace(".xml.fo", ".pdf");
                                string[] filename0 = r.Split(target);
                                kommadozeilenaufruf = " -fo " + "\"" + fofile[i] + "\"" + " " + "\"" + location + "\\" + filename0[1] + "\"" + " -d ";
                                break;

                            case "antennahouse":
                                formatierer = Properties.Settings.Default.AntennahouseLocation;                                
                                target = fofile[i].Replace(".xml.fo", ".pdf");
                                string[] filename1 = r.Split(target);
                                kommadozeilenaufruf = " -extlevel 4 -d " + "\"" + fofile[i] + "\"" + " -o " + "\"" + location + "\\" + filename1[1] + "\"";
                                break;

                            case "renderx":                                
                                formatierer = Properties.Settings.Default.RenderXLocation;
                                target = fofile[i].Replace(".xml.fo", ".pdf");
                                string[] filename2 = r.Split(target);
                                kommadozeilenaufruf = " -fo " + "\"" + fofile[i] + "\"" + " -out " + "\"" + location + "\\" + filename2[1] + "\"";
                                break;

                        }         
               
                        formatiererStart(formatierer, kommadozeilenaufruf);
                        formatierer = originalformatierer; // zurückstellen, damit switch funktion noch geht

                    }
                    if (Properties.Settings.Default.KeepFoFiles == false) 
                    {

                        for (int i = 0; i < fofile.Length; i++)
                        {

                            try
                            {
                                System.IO.File.Delete(fofile[i]);
                            }
                            catch (Exception ex)
                            {

                                Program.mainframe.results.loadText_log("Problems with removing fo files" + ex.Message);                                

                            }

                        }
                    
                    }
                    break;

                // Einzelfile
                case false:
                   
                    switch (formatierer)
                    {
                        case "fop":
                            formatierer = fop;
                            string foinput = fofile[0];
                            kommadozeilenaufruf = " -fo " + "\"" + foinput + "\"" + " " + "\"" + location + "\"" + " -d ";
                            break;

                        case "antennahouse":
                            if (File.Exists(Properties.Settings.Default.AntennahouseLocation))
                            {
                                string foinputantenna = fofile[0];
                                formatierer = Properties.Settings.Default.AntennahouseLocation;
                                kommadozeilenaufruf = " -extlevel 4 -d " + "\"" + foinputantenna + "\"" + " -o " + "\"" + location + "\"";
                            }
                            else 
                            {
                                MessageBox.Show("Couldnt find the Antenna House File", "File not found", MessageBoxButtons.OK);
                                Properties.Settings.Default.AntennahouseLocation = "empty";
                                return;  
                            }
                            
                            break;

                        case "renderx":
                            if (File.Exists(Properties.Settings.Default.RenderXLocation))
                            {                                
                                string foinputrenderx = fofile[0];
                                formatierer = Properties.Settings.Default.RenderXLocation;
                                kommadozeilenaufruf = " -fo " + "\"" + foinputrenderx + "\"" + " -out " + "\"" + location + "\"";
                            }
                            else 
                            {
                                MessageBox.Show("Couldnt find the RenderX File", "File not found", MessageBoxButtons.OK);
                                Properties.Settings.Default.RenderXLocation = "empty";
                                return; 
                            }
                            break;

                    }                    
                    formatiererStart(formatierer, kommadozeilenaufruf);
                    if (Properties.Settings.Default.KeepFoFiles == false) 
                    {
                        try
                        {
                            System.IO.File.Delete(fofile[0]);
                        }
                        catch (Exception ex)
                        {

                            Program.mainframe.results.loadText_log("Problems with removing fo files" + ex.Message);

                        }                    
                    
                    }
                    break;
            }
        }

        // Die Methode für den formatierer. 
        private void formatiererStart(string formatierer, string kommandozeilenaufruf)
        {
            // Neuer Prozess
            Process p = new Process();
           
            
            // Keine Shell anzeigen
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            // Ausgaben umleiten zulassen
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
           

            // Argumente die an den Befehl weitergegebn werden
            p.StartInfo.Arguments = kommandozeilenaufruf;

            // das Kommando
            p.StartInfo.FileName = formatierer;

            // ausführen
            p.Start();
            
           

            // zwei threads erzeugen, da das auslesen der standardstreams blockierend ist 
            Thread errthread = new Thread(leseErrOutput);
            errthread.Start(p);

            Thread standthread = new Thread(leseStandardOutput);
            standthread.Start(p);

           

            // warten bis alle ausgaben gemacht wurden und prozess beenden
            p.WaitForExit();

            Program.mainframe.results.loadText_log(log);            
            log = "";
            
          
        }

        // Die Methode die im Thread aufgerufen wird
        private void leseErrOutput(Object process)
        {            
            // umcasten des übergebenen Objects zum aktuellen Prozess
            Process proz = (Process)process;
            string output;
            output = proz.StandardError.ReadToEnd();
            mutex.WaitOne();
            log += output;
            mutex.ReleaseMutex();
        }

        // Die Methode die im Thread aufgerufen wird
        private void leseStandardOutput(Object process)
        {            
            // umcasten des übergebenen Objects zum aktuellen Prozess
            Process proz = (Process)process;
            string output;
            output = proz.StandardOutput.ReadToEnd();
            mutex.WaitOne();
            log += output;
            mutex.ReleaseMutex();
        }
    }
}