// ------------------------------------------------------------------------ //
// parameter class                                                          //
//                                                                          //
// Kleine Helper Klasse. Da hier nur die Rohinformationen für Parameter     //
// in Stylesheets gespeichert werden. Diese werden später in einer          //
// entsprechenden Liste weiterverarbeitet.                                  //
//                                                                          //
// ------------------------------------------------------------------------ //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace antillesXMLv2
{
    class parameter
    {
       
        // variablen für stylesheet parameter
        private string Param = "";
        public string param
        {

            set
            {
                Param = value;
            }
            get
            {
                return Param;
            }

        }

        private string Value = "";
        public string value
        {

            set
            {
                Value = value;
            }
            get
            {
                return Value;
            }

        }     

    }
}
