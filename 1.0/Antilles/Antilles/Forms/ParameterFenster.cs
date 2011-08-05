// ------------------------------------------------------------------------ //
// ParameterFenster class                                                   //
//                                                                          //
// Hier kann der Benutzer die Stylesheet Parameter einstellen               //
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
using System.Reflection;

namespace Antilles
{
    public partial class ParameterFenster : Form
    {

        public ParameterFenster(string stylesheet)
        {
            InitializeComponent();
            initTooltips();      
            

            if (Program.konfiguration.parameter_neuesfile)
            {
                Program.optimusprime.getParameter(stylesheet);
                Program.konfiguration.parameter_neuesfile = false;
                //Program.hauptfenster.setStatusTxt("ready");
            }

            if (Program.konfiguration.parameters.Count > 0)
            {
                dataGridView_parameter.Rows.Add(Program.konfiguration.parameters.Count);
                for (int i = 0; i < Program.konfiguration.parameters.Count; i++)
                {

                    dataGridView_parameter["Column_parametergrid", i].Value = Convert.ToString(Program.konfiguration.parameters[i].param);
                    dataGridView_parameter["parameter_value", i].Value = Convert.ToString(Program.konfiguration.parameters[i].value);

                }
            }
        }

        // Tooltips
        ToolTip tooltip = new ToolTip();

        private void initTooltips()
        {
            tooltip.SetToolTip(button_close, "Fenster schliessen");
            tooltip.SetToolTip(button_clear, "Feld leeren");
            tooltip.SetToolTip(button_save, "Parametereinstellungen übernehmen");
        }

        public ParameterFenster(List<string> stylesheet)
        {
            InitializeComponent();

            if (Program.konfiguration.parameter_neuesfile)
            {
                for (int i = 0; i < stylesheet.Count; i++)
                {
                    Program.optimusprime.getParameter(stylesheet[i]);
                    Program.konfiguration.parameter_neuesfile = false;
                }
                //Program.hauptfenster.setStatusTxt("ready");
            }

            if (Program.konfiguration.parameters.Count > 0)
            {
                dataGridView_parameter.Rows.Add(Program.konfiguration.parameters.Count);
                for (int i = 0; i < Program.konfiguration.parameters.Count; i++)
                {

                    dataGridView_parameter["Column_parametergrid", i].Value = Convert.ToString(Program.konfiguration.parameters[i].param);
                    dataGridView_parameter["parameter_value", i].Value = Convert.ToString(Program.konfiguration.parameters[i].value);

                }
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {


            Program.konfiguration.parameters.Clear();
            for (int i = 0; i < dataGridView_parameter.RowCount; i++)
            {
                if ((dataGridView_parameter["Column_parametergrid", i].Value != null)
                    && (dataGridView_parameter["parameter_value", i].Value != null))
                {

                    parameter Item = new parameter();
                    Item.param = dataGridView_parameter["Column_parametergrid", i].Value.ToString();
                    Item.value = dataGridView_parameter["parameter_value", i].Value.ToString();
                    Program.konfiguration.parameters.Add(Item);

                }
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            dataGridView_parameter.Rows.Clear();
            Program.konfiguration.parameters.Clear();
            Program.konfiguration.parameter_neuesfile = true;
        }

    }
}
