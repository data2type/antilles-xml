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
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Net;
using System.Text.RegularExpressions;

namespace Antilles
{
    class word2generic
    {


        public void ausfuehren() 
        {

            try
            {
                string mapping = Path.GetTempFileName();               
                string result = "";


                result = Program.optimusprime.starteProzessor(Program.konfiguration.wordMLFileName, "vorprozess1", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess2", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess3", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess4", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess5", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess6", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess7", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess8", Program.konfiguration.wordMLFileNameZiel, true);

               

               
            }

            catch (Exception ex)
            {
                Program.hauptfenster.setLogTxt(ex.Message);
            }
        
        
        }



    }
}
