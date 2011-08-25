using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace antillesXMLv2
{
    public partial class CheckUpdate : Form
    {
        public CheckUpdate()
        {
            InitializeComponent();

        }

        private void check()
        {

            string version = GetUrlResponse("http://www.data2type.de/ver.txt", null, null);

            // Fehler
            if (version == "0") { label1.Text = "error";  return; }

            double ver = Convert.ToDouble(version);

            if (ver > 1.0)
            {

                label_new.Visible = true;
                label1.Visible = false;

            }

            else
            {

                label1.Visible = false;
                label_ok.Visible = true;

            }

        }

        public static string GetUrlResponse(string url, string username, string password)
        {
            string content = null;

            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                               

                if (username == null || password == null)
                {
                    NetworkCredential networkCredential = new NetworkCredential(username, password);
                    webRequest.PreAuthenticate = true;
                    webRequest.Credentials = networkCredential;
                }

                webRequest.Timeout = 10000;
                WebResponse webResponse = webRequest.GetResponse();
                
                StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII);
                StringBuilder contentBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    contentBuilder.Append(sr.ReadLine());
                    contentBuilder.Append("\r\n");
                }
                content = contentBuilder.ToString();

                return content.ToString();
            }
            catch (Exception)
            {

                Program.results.loadText_log("No Internet Connection or our Servers are Down. Please try again later.");

            }
            return "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_ok.Visible = false;
            label_new.Visible = false;
            label1.Visible = true;
            this.Hide();
        }

        private void CheckUpdate_Shown(object sender, EventArgs e)
        {
            check();
        }

        private void CheckUpdate_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true) { check(); }
        }
    }
}
