using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace antillesXMLv2
{
    static class Program
    {


        /// <summary>
        /// Global Vars
        /// </summary>  
        public static bool WINDOW_STATE = false;
        public static bool QUIT = false;

        /// <summary>
        /// Global static Forms & Helper Classes
        /// </summary> 
        /// 
        public static config Config = new config();      
        public static transformer transform = new transformer();       
        public static FileSystemWatcher FSW;      
        public static Splash splash = new Splash();
        public static PleaseWait plsW = new PleaseWait();
        public static schematron schematron = new schematron();       
        public static validator validate = new validator();
        public static hotfolder hotfold = new hotfolder();
        public static word2generic word2gen = new word2generic();         

        public static Mainframe mainframe;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();


            splash.Show();
            Application.DoEvents();
            
           

            if (Properties.Settings.Default.Historie.Count > 30)
            {
                int size = Properties.Settings.Default.Historie.Count-1;
                List<string> helfer = new List<string>();
                for (int i = 0; i < 20; i++)
                {
                    helfer.Add(Properties.Settings.Default.Historie[size]);
                    size--;
                }

                Properties.Settings.Default.Historie.Clear();

                for (int i = 0; i < helfer.Count; i++)
                {

                    Properties.Settings.Default.Historie.Add(helfer[i]);

                }

            }


            if (Properties.Settings.Default.Historie.Count > 1)
            {
                try
                {
                    Config.history = new string[Properties.Settings.Default.Historie.Count];
                    // Aufbereiten der History
                    for (int i = 0; i < Properties.Settings.Default.Historie.Count; i++)
                    {

                        Config.history[i] = Properties.Settings.Default.Historie[i];

                    }

                    string[] helper = new string[Config.history.Length];

                    for (int i = 0; i < Config.history.Length; i++)
                    {

                        helper[i] = Config.history[i];

                    }

                    string[] helper2 = new string[Config.history.Length];

                    for (int i = 0; i < Config.history.Length; i++)
                    {

                        helper2[i] = Config.history[i];

                    }

                    List<string> clean = new List<string>();
                    bool flag = false;

                    for (int i = 0; i < helper.Length; i++)
                    {

                        for (int y = 0; y < helper.Length; y++)
                        {
                            if (helper[i] == helper2[y])
                            {
                                if (!flag) clean.Add(helper[i]);
                                helper2[y] = "duplicate";
                                flag = true;
                            }
                        }

                        flag = false;
                    }

                    Config.history = new string[clean.Count];
                    for (int i = 0; i < clean.Count; i++)
                    {

                        Config.history[i] = clean[i];

                    }
                }
                catch (Exception)
                {

                    Config.history = new string[1];
                    Config.history[0] = "";

                }
               
            }

            string location = Application.StartupPath;
            Environment.SetEnvironmentVariable("SAXON_HOME", location);
            mainframe = new Mainframe();
            System.Threading.Thread.Sleep(2000);

            splash.Hide();
           
            Application.Run(mainframe);
        }
       
    }
}
