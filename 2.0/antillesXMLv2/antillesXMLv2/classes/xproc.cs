// ------------------------------------------------------------------------ //
// xproc class                                                              //
//                                                                          //
// Hier wird calabash gestartet und abgearbeitet. für xproc                 //
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
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;


namespace antillesXMLv2
{
    class xproc
    {

        private static Mutex mutex = new Mutex();
        public List<string> log = new List<string>();   

        public void doxproc(string xprocfile, bool folder) 
        {
            if (folder) 
            { 
                starteCalabash(xprocfile); 
            }
            else 
            {

                string[] files = Directory.GetFiles(xprocfile, "*.xpl");

                for (int i = 0; i < files.Count(); i++)
                {

                    starteCalabash(files[i]); 

                }

            }
        } 

        private void starteCalabash(string xprocfile) 
        {
            
            // Neuer Prozess
            Process p = new Process();            
            string calabash = Path.Combine(Application.StartupPath, "lib\\calabash\\");

            // Keine Shell anzeigen
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            // Ausgaben umleiten zulassen
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
           
            string arguments = @"-cp " + "\"" + @calabash + @"\lib\calabash\calabash.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\saxon\saxon9.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\saxon\saxon9-s9api.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\saxon\saxon9sa.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\apache-commons-http-client\commons-httpclient-3.1.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\apache-commons-logging\commons-logging-1.1.1.jar" + "\"" + ";" + "\"" 
                + @calabash + @"\lib\apache-commons-codec\commons-codec-1.3.jar" + "\""
                + "-Dcom.xmlcalabash.phonehome=false com.xmlcalabash.drivers.Main -a " + "\"" + xprocfile + "\"";

            // -a entfernt

            // Argumente die an den Befehl weitergegebn werden
            p.StartInfo.Arguments = arguments;

            // das Kommando
            p.StartInfo.FileName = "java";

            // ausführen
            p.Start();
           
            // zwei threads erzeugen, da das auslesen der standardstreams blockierend ist 
            Thread errthread = new Thread(leseErrOutput);
            errthread.Start(p);

            Thread standthread = new Thread(leseStandardOutput);
            standthread.Start(p);

            // warten bis alle ausgaben gemacht wurden und prozess beenden
            p.WaitForExit();
             
            //log schreiben
            for (int i = 0; i < log.Count; i++)
            {
               Program.mainframe.results.loadText_results(log[i]);
            }

            log.Clear();     

        }       

        // Die Methode die im Thread aufgerufen wird
        private void leseErrOutput(Object process)
        {            
            // umcasten des übergebenen Objects zum aktuellen Prozess
            Process proz = (Process)process;
            string output;
            output = proz.StandardError.ReadToEnd();
            mutex.WaitOne();
            log.Add(output);
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
            log.Add(output);
            mutex.ReleaseMutex();
        }
    } 
}
