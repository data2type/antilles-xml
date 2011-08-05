// ------------------------------------------------------------------------ //
// Program class                                                            //
//                                                                          //
// Diese Klasse wird beim ersten Programstart ausgeführt                    //
// Sie stellt Instanzen sämtlicher Klassen statisch zur Verfügung           //
// Somit können auf diese von anderen Stellen zugegriffen werden            //
// Auch wird auch das Vorhandensein von Java getestet                       //
//                                                                          //
// ------------------------------------------------------------------------ //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Antilles

{
    static class Program
    {
        // Statische Instanzen der Klassen
        public static tests tester = new tests();
        public static Hauptfenster hauptfenster = new Hauptfenster();
        public static Eigenschaften eigenschaften = new Eigenschaften();
        public static Help help = new Help();
        public static About about = new About();
        public static config konfiguration = new config();
        public static transformer optimusprime = new transformer();
        public static validator validboy = new validator();
        public static schematron schematronboy = new schematron();
        public static xslformater formatboy = new xslformater();
        public static AntillesEigenschaften antilleseigenschaften = new AntillesEigenschaften();
        public static xproc xprocboy = new xproc();                
        public static TextWriter log = new StringWriter();
        public static hotfolder hotfold = new hotfolder();
        public static word2generic wordML = new word2generic();
        public static FileSystemWatcher FSW;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            // SplashForm
            Splash splash = new Splash();            
            splash.Show();
            Application.DoEvents();
            bool tests = true;

            // Abhängigkeiten prüfen
            try
            {
                while (tests)
                {                    
                    splash.label_splash.Text = "...teste: Java";
                    splash.label_splash.Refresh();

                    bool java = tester.checkJava();
                    switch (java)
                    {
                        case true:
                            splash.label_splash.Text = "...teste: ok";
                            tester.java = true;
                            splash.label_splash.Refresh();
                            break;

                        case false:
                            splash.label_splash.Text = "...teste: fail";
                            tester.java = false;
                            splash.label_splash.Refresh();
                            break;
                    }

                    splash.label_splash.Text = "...teste: Internet";
                    splash.label_splash.Refresh();

                    bool internet = tester.CheckInternetConnection();
                    switch (internet)
                    {

                        case true:
                            splash.label_splash.Text = "...teste: ok";
                            tester.internet = true;
                            splash.label_splash.Refresh();
                            break;

                        case false:
                            splash.label_splash.Text = "...teste: fail";
                            tester.internet = false;
                            splash.label_splash.Refresh();
                            break;

                    }

                    splash.label_splash.Text = "...tests: fertig";
                    splash.label_splash.Text = "...starte";
                    splash.label_splash.Refresh();

                    System.Threading.Thread.Sleep(1000);
                    tests = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Initialisieren: " + ex.Message,
                   Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            splash.Close();           
            
            Application.Run(hauptfenster);
        }        
    }
}

