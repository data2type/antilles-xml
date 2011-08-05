// ------------------------------------------------------------------------ //
// Antilles Eigenschaften class                                             //
//                                                                          //
// Hier kann der Benutzer Eigenschaften von Programm einstellen             //
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
    public partial class AntillesEigenschaften : Form
    {
        public AntillesEigenschaften()
        {
            InitializeComponent();
            initTooltips();
            textBox_antennahouselocation.Text = Properties.Settings.Default.AntennahouseLocation;
            textBox_renderxlocation.Text = Properties.Settings.Default.RenderXLocation;
            textBox_arbeitsverzeichnis.Text = Environment.CurrentDirectory;
            // Voreinstellung der Checkboxen checken ...
            if (Properties.Settings.Default.antilles_wellformedcheck) checkBox_antilles_wellformdcheck.Checked = true;
            if (Properties.Settings.Default.antilles_willkommensbild) checkBox_antillesstartupinfo.Checked = true;
        }

        // Tooltips
        ToolTip tooltip = new ToolTip();

        private void initTooltips()
        {
                      
            tooltip.SetToolTip(button_antennahousechange, "Pfadangabe für Antenna House ändern");
            tooltip.SetToolTip(button_renderxchange, "Pfadangabe für RenderX ändern");
            tooltip.SetToolTip(button_close, "Fenster schliessen");

        }

        private void button_antennahousechange_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    textBox_antennahouselocation.Text = open.SelectedPath;
                    Properties.Settings.Default.AntennahouseLocation = open.SelectedPath;
                    Properties.Settings.Default.AntennahouseLocation += "\\XSLCmd.exe";
                    Properties.Settings.Default.Save();

                }
            }
            catch (Exception)
            {
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_renderxchange_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    textBox_renderxlocation.Text = open.SelectedPath;
                    Properties.Settings.Default.RenderXLocation = open.SelectedPath;
                    Properties.Settings.Default.RenderXLocation += "\\xep.bat";
                    Properties.Settings.Default.Save();

                }
            }
            catch (Exception)
            {
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void AntillesEigenschaften_Shown(object sender, EventArgs e)
        {
            textBox_antennahouselocation.Text = Properties.Settings.Default.AntennahouseLocation;
            textBox_renderxlocation.Text = Properties.Settings.Default.RenderXLocation;
            if (Properties.Settings.Default.antilles_wellformedcheck)
            {
                checkBox_antilles_wellformdcheck.Checked = true;
            }
            else
            {
                checkBox_antilles_wellformdcheck.Checked = false;
            }
            if (Properties.Settings.Default.antilles_willkommensbild)
            {
                checkBox_antillesstartupinfo.Checked = true;
            }
            else
            {
                checkBox_antillesstartupinfo.Checked = false;
            }
        }

        private void checkBox_antilles_wellformdcheck_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.antilles_wellformedcheck == true)
            {

                Properties.Settings.Default.antilles_wellformedcheck = false;
                checkBox_antilles_wellformdcheck.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.antilles_wellformedcheck = true;
                checkBox_antilles_wellformdcheck.CheckState = CheckState.Checked;

            }
            Properties.Settings.Default.Save();
        }

        private void checkBox_antillesstartupinfo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.antilles_willkommensbild == true)
            {

                Properties.Settings.Default.antilles_willkommensbild = false;
                checkBox_antillesstartupinfo.CheckState = CheckState.Unchecked;


            }
            else
            {

                Properties.Settings.Default.antilles_willkommensbild = true;
                checkBox_antillesstartupinfo.CheckState = CheckState.Checked;

            }
            Properties.Settings.Default.Save();

        }

        private void button_arbeitsverzeichnis_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog open = new FolderBrowserDialog();

                if (open.ShowDialog() == DialogResult.OK)
                {

                    textBox_arbeitsverzeichnis.Text = open.SelectedPath;
                    Environment.CurrentDirectory = open.SelectedPath;
                    Properties.Settings.Default.antilles_arbeitsordner = open.SelectedPath;

                    //speichern ...
                    Properties.Settings.Default.Save();

                }
            }
            catch (Exception)
            {
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }

        }
    }
}
