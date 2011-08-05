// ------------------------------------------------------------------------ //
// Help class                                                               //
//                                                                          //
// Der Help Bereich des Prorgamms. Öffnet eine Webseite im Browser...       //
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

namespace Antilles
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            //string helppath = Path.Combine(Application.StartupPath, "Help\\help_de.xhtml");
            initTooltips();
            webBrowser_help.Navigate(Application.StartupPath + "\\Help\\help_de.html");
        }

        // Tooltips
        ToolTip tooltip = new ToolTip();

        private void initTooltips()
        {
            tooltip.SetToolTip(button_close, "Fenster schliessen");
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
