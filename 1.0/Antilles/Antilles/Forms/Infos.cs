using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Antilles
{
    public partial class Infos : Form
    {
        public Infos()
        {
            InitializeComponent();
            try
            {
                pictureBox_startscreen.Load("http://www.data2type.de/files/Antilles/antillesstart.png");
            }
            catch (Exception)
            {

                // Standardbild laden ...

            }
        }

        private void checkBox_janein_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.antilles_willkommensbild == true)
            {

                Properties.Settings.Default.antilles_willkommensbild = false;
                checkBox_janein.CheckState = CheckState.Unchecked;

            }
            else
            {

                Properties.Settings.Default.antilles_willkommensbild = true;
                checkBox_janein.CheckState = CheckState.Checked;

            }
            Properties.Settings.Default.Save();
        }

        private void pictureBox_startscreen_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.data2type.de");
        }
    }
}
