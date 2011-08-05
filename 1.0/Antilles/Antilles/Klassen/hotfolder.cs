// ------------------------------------------------------------------------ //
// hotfolder class                                                          //
//                                                                          //
// Diese Klasse stellt die Methoden für das Hotfolder Feature bereit        //
//                                                                          //
// ------------------------------------------------------------------------ //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Antilles
{
    class hotfolder
    { 

        

        public void FSW_Init(string ordner)
        {
            // Filesystemwatcher anlegen
            Program.FSW = new FileSystemWatcher();

            // Pfad und Filter festlegen
            Program.FSW.Path = ordner;
            Program.FSW.Filter = "*.xml";

            // Events definieren
            Program.FSW.Changed += new FileSystemEventHandler(FSW_Changed);
            Program.FSW.Created += new FileSystemEventHandler(FSW_Created);
            Program.FSW.Deleted += new FileSystemEventHandler(FSW_Deleted);
            Program.FSW.Renamed += new RenamedEventHandler(FSW_Renamed);

            // Filesystemwatcher aktivieren
            Program.FSW.EnableRaisingEvents = true;
            
        }

        public void FSW_Stop() 
        {
            // Filesystemwatcher ausschalten
            Program.FSW.EnableRaisingEvents = false;
        
        }

        // Handler für alle Events
        void FSW_Renamed(object sender, RenamedEventArgs e)
        {
            // tue nichts
        }

        void FSW_Deleted(object sender, FileSystemEventArgs e)
        {
            // tue nichts
        }

        void FSW_Created(object sender, FileSystemEventArgs e)
        {
            Program.optimusprime.starteProzessorHotfolder(e.FullPath, Program.konfiguration.xsltfilepathHotfolder, Program.konfiguration.xmlfilepathTargetHotfolder + "\\" + e.Name);
            
        }

        void FSW_Changed(object sender, FileSystemEventArgs e)
        {
            Program.optimusprime.starteProzessorHotfolder(e.FullPath, Program.konfiguration.xsltfilepathHotfolder, Program.konfiguration.xmlfilepathTargetHotfolder + "\\" + e.Name);            
        }        
    }
}
