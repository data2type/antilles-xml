// ------------------------------------------------------------------------ //
// tests class                                                              //
//                                                                          //
// hier werden tests implementiert, die beim startup gemacht werden         //
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
using System.Net.NetworkInformation;


namespace Antilles
{
    class tests
    {

        public bool java = true;
        public bool internet = true;

        // Testmethoden 

        /// <summary>
        /// Prüft ob Java vorhanden ist.
        /// </summary>
        /// <returns>
        /// true/false
        /// </returns>
        public bool checkJava()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("java", "-version ");

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                switch (proc.StandardError.ReadToEnd())
                {
                    case "null": return false; 

                    default: return true; 
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Prüft ob eine Internetverbindung vorhanden ist.
        /// </summary>
        /// <returns>
        /// true/false
        /// </returns>
        public bool CheckInternetConnection()
        {
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.data2type.de", 80);
                clnt.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
