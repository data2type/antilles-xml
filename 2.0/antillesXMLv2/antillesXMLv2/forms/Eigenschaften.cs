// ------------------------------------------------------------------------ //
// Eigenschaften                                                            //
//                                                                          //
// Methoden für die jeweiligen form Features                                //
// Hier wird mit globalen Variablen gearbeitet                              //
//                                                                          //
// ------------------------------------------------------------------------ //

using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace antillesXMLv2
{
    public partial class Eigenschaften : Form
    {
        public Eigenschaften()
        {
            InitializeComponent();
            initTooltips();
            // Felder einstellen
            if (Properties.Settings.Default.saxon_sall) radioButton_Whitespace_ALL.Checked = true;
            if (Properties.Settings.Default.saxon_signorable) radioButton_Whitespace_Ignore.Checked = true;
            if (Properties.Settings.Default.saxon_snone) radioButton_Whitespace_Nothing.Checked = true;

            if (Properties.Settings.Default.saxon_ds) radioButton_linkedtree.Checked = true;
            if (Properties.Settings.Default.saxon_dt) radioButton_TinyTree.Checked = true;

            if (Properties.Settings.Default.saxon_w0) radioButton_w0.Checked = true;
            if (Properties.Settings.Default.saxon_w1) radioButton_w1.Checked = true;
            if (Properties.Settings.Default.saxon_w2) radioButton_w2.Checked = true;

            if (Properties.Settings.Default.saxon_versionwarn) checkBox_VersionWarning.Checked = true;
            if (Properties.Settings.Default.saxon_l) checkBox_linenumber.Checked = true;
            if (Properties.Settings.Default.saxon_timing) checkBox_timing.Checked = true;
            if (Properties.Settings.Default.saxon_explain) checkBox_explain.Checked = true;
            if (Properties.Settings.Default.saxon_traceextfunct) checkBox_traceextfunctions.Checked = true;
            if (Properties.Settings.Default.saxon_xml11) checkBox_xml11.Checked = true;

        }        

        private void button_close_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Hide();
        }

        // Tooltips
        ToolTip tooltip = new ToolTip();

        private void initTooltips()
        {           
            tooltip.SetToolTip(button_close, "Fenster schliessen");
        }

        private void radioButton_Whitespace_ALL_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_sall = true;
            Properties.Settings.Default.saxon_signorable = false;
            Properties.Settings.Default.saxon_snone = false;                      

        }

        private void radioButton_Whitespace_Ignore_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_sall = false;
            Properties.Settings.Default.saxon_signorable = true;
            Properties.Settings.Default.saxon_snone = false;         

        }

        private void radioButton_Whitespace_Nothing_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_sall = false;
            Properties.Settings.Default.saxon_signorable = false;
            Properties.Settings.Default.saxon_snone = true;
              
        }

        private void radioButton_linkedtree_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.saxon_ds = true;
            Properties.Settings.Default.saxon_dt = false;  
        }

        private void radioButton_TinyTree_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.saxon_ds = false;
            Properties.Settings.Default.saxon_dt = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

            // hier passiert nichts

        }

        private void label3_Click(object sender, EventArgs e)
        {

            // hier passiert nichts

        }

        private void radioButton_w1_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_w0 = false;
            Properties.Settings.Default.saxon_w1 = true;
            Properties.Settings.Default.saxon_w2 = false;            

        }

        private void radioButton_w0_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_w0 = true;
            Properties.Settings.Default.saxon_w1 = false;
            Properties.Settings.Default.saxon_w2 = false;

        }

        private void radioButton_w2_CheckedChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.saxon_w0 = false;
            Properties.Settings.Default.saxon_w1 = false;
            Properties.Settings.Default.saxon_w2 = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.saxon_versionwarn == true)
            {
                Properties.Settings.Default.saxon_versionwarn = false;
                //Program.konfiguration.versionWarn = false;
                checkBox_VersionWarning.CheckState = CheckState.Unchecked;

            }

            else
            {
                Properties.Settings.Default.saxon_versionwarn = true;
                //Program.konfiguration.versionWarn = true;
                checkBox_VersionWarning.CheckState = CheckState.Checked;
            }
        }

        private void checkBox_VersionWarning_CheckedChanged(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void checkBox_linenumber_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.saxon_l == true)
            {

                Properties.Settings.Default.saxon_l = false;
                checkBox_linenumber.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.saxon_l = true;
                checkBox_linenumber.CheckState = CheckState.Checked;

            }
        }

        private void checkBox_timing_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.saxon_timing == true)
            {

                Properties.Settings.Default.saxon_timing = false;
                checkBox_timing.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.saxon_timing = true;
                checkBox_timing.CheckState = CheckState.Checked;

            }
        }

        private void checkBox_explain_CheckedChanged(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void checkBox_explain_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.saxon_explain == true)
            {

                Properties.Settings.Default.saxon_explain = false;
                checkBox_explain.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.saxon_explain = true;
                checkBox_explain.CheckState = CheckState.Checked;

            }
        }

        private void checkBox_traceextfunctions_CheckedChanged(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void checkBox_traceextfunctions_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.saxon_traceextfunct == true)
            {

                Properties.Settings.Default.saxon_traceextfunct = false;
                checkBox_traceextfunctions.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.saxon_traceextfunct = true;
                checkBox_traceextfunctions.CheckState = CheckState.Checked;

            }
        }

        private void checkBox_xml11_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.saxon_xml11 == true)
            {

                Properties.Settings.Default.saxon_xml11 = false;
                checkBox_xml11.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.saxon_xml11 = true;
                checkBox_xml11.CheckState = CheckState.Checked;

            }
        }

        private void desc_tinytree_Click(object sender, EventArgs e)
        {
            // hier passiert nichts
        }

        private void Eigenschaften_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Properties.Settings.Default.Save();
            this.Hide();
        }    
    }
}
