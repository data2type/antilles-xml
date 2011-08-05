// ------------------------------------------------------------------------ //
// about  class                                                             //
//                                                                          //
// Der About Bereich                                                        //
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

namespace Antilles
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            initTooltips();
            textBox_abouttxt.Text = "(c) 2010 data2type/AntillesXML" + Environment.NewLine + "In Zusammenarbeit mit der Hochschule der Medien Stuttgart, Fakultät Druck und Medien" + Environment.NewLine + Environment.NewLine + "AntillesXML verwendet Saxon - http://www.saxonica.com"
            + Environment.NewLine + "AntillesXML verwendet FamFamFam Icons - http://www.famfamfam.com/lab/icons/silk/" + Environment.NewLine + Environment.NewLine + "fehler/bugs bitte an goertz@data2type.de";

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
