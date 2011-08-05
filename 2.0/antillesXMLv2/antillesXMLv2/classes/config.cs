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

namespace antillesXMLv2
{
    class config
    {
        public string[] history = {""};
        public bool hotfolder = false;
        public bool success = false;

        public config()
        {
            
            
        }

        // Parameter
        public List<parameter> parameters = new List<parameter>();
        public bool parameter_neuesfile = false;     

        // Wurde ein Stylesheet eingeladen?
        private bool ParameterIsSet = false;
        public bool parameterIsSet
        {
            set
            {

                ParameterIsSet = value;
            }
            get
            {
                return ParameterIsSet;

            }
        }

        // Standard Übergabe Werte für Transformationen
        private string Input = ""; 
        public string input
        {
            set
            {
                Input = value;
            }
            get
            {
                return Input;
            }

        }

        private string Stylesheet = "";
        public string stylesheet
        {
            set
            {
                Stylesheet = value;
            }
            get
            {
                return Stylesheet;
            }

        }

        private string Target = "";
        public string target
        {
            set
            {
                Target = value;
            }
            get
            {
                return Target;
            }

        }

        private bool Piplelineaktiv = false;
        public bool piplelineaktiv
        {
            set
            {
                Piplelineaktiv = value;
            }
            get
            {
                return Piplelineaktiv;
            }

        }

    }    
}
