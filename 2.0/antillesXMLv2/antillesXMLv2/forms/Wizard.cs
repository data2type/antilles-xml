using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace antillesXMLv2
{
    public partial class Wizard : Form
    {

        public Wizard()
        {
            InitializeComponent();
            List<string> input = new List<string>();
            input.Add("XSLT Transformation");
            input.Add("XSL-FO");
            input.Add("XProc");
            listBox1.Items.Add(new Entry("XSL", input));
            List<string> input1 = new List<string>();
            input1.Add("XML Schema");
            input1.Add("DTD");
            input1.Add("Schematron");
            listBox1.Items.Add(new Entry("Validation", input1));
            List<string> input2 = new List<string>();
            input2.Add("Word to XML");
            input2.Add("CSV to XML");
            input2.Add("XML Syntaxhighlighting");
            input2.Add("Hotfolder");
            input2.Add("XSD Documentation");
            listBox1.Items.Add(new Entry("Tools", input2));
            
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            Entry ent = (Entry)listBox1.SelectedItem;
            for (int i = 0; i < ent.features.Count; i++)
            {
                listBox2.Items.Add(ent.features[i]);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem == null) return;

            switch (listBox2.SelectedItem.ToString()) {

                case "XSLT Transformation":
                    label.Text = "With this Feature you can execute XSLT Stylesheets.";
                    return;                    

                case "XSL-FO":
                    label.Text = "With XSL-FO Stylesheets PDF Files can be created. You need to define a XSL Formatter Tool. By Default the Open Source Solution Apache FOP comes preinstalled with antillesXML and is set. However you can also select Antenna House or RenderX as a Formatter.";
                    return;

                case "XProc":
                    label.Text = "With this Feature you can execute XProc Pipelines. In XProc complex Workflows can be defined and executed. You can find a complete Reference and Code Examples on our Website (http://www.data2type.de).";
                    return;
                   
                case "XML Schema":
                    label.Text = "Here you can Validate XML Files against a XML Schema.";
                    return;

                case "DTD":
                    label.Text = "Here you can Validate XML Files against a DTD.";
                    return;

                case "Schematron":
                    label.Text = "Here you can Validate/Check XML Files against a Schematron File.";
                    return;

                case "Word to XML":
                    label.Text = "This Feature gives you the possibility to turn a Microsoft Word File into a generic XML Output. The Input File won´t be changend in any way.";
                    return;

                case "CSV to XML":
                    label.Text = "This Feature turns CSV Files into XML.";
                    return;

                case "XML Syntaxhighlighting":
                    label.Text = "A given XML File will be transformed into an HTML Output, where the XML Content is displayed with Syntaxhighlighting. The original Input File won´t be changend in any way.";
                    return;

                case "Hotfolder":
                    label.Text = "Here you can define a Hotfolder and assign a Stylesheet to it. Every XML File which is dropped into this Hotfolder will be transformed with the given Stylesheet. The Output is written to an Output Folder.";
                    return;

                case "XSD Documentation":
                    label.Text = "With this Feature you can create a Documentation File about a XMl Schema File.";
                    return; 
            
            }
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem != null)
            {

                switch (listBox2.SelectedItem.ToString())
                {

                    case "XSLT Transformation":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xslt.Show();
                        Program.results.Show();
                        return;

                    case "XSL-FO":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();

                        Program.xslfo.Show();
                        Program.results.Show();
                        return;

                    case "XProc":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xproc.Show();
                        Program.results.Show();
                        return;

                    case "XML Schema":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xsd.Show();
                        Program.results.Show();
                        return;

                    case "DTD":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.dtd.Show();
                        Program.results.Show();
                        return;

                    case "Schematron":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.schematronvalidate.Show();
                        Program.results.Show();
                        return;

                    case "Word to XML":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.word.Show();
                        Program.results.Show();
                        return;

                    case "CSV to XML":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.csv2xml.Show();
                        Program.results.Show();
                        return;

                    case "XML Syntaxhighlighting":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.syntaxhighlighting.Show();
                        Program.results.Show();
                        return;

                    case "Hotfolder":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.hotfoldForm.Show();
                        Program.results.Show();
                        return;

                    case "XSD Documentation":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xsddoku.Show();
                        Program.results.Show();
                        return;

                    default:
                        this.Hide();
                        return;
                }
            }

            this.Hide();
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {

                switch (listBox2.SelectedItem.ToString())
                {

                    case "XSLT Transformation":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xslt.Show();
                        Program.results.Show();
                        return;

                    case "XSL-FO":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();

                        Program.xslfo.Show();
                        Program.results.Show();
                        return;

                    case "XProc":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xproc.Show();
                        Program.results.Show();
                        return;

                    case "XML Schema":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xsd.Show();
                        Program.results.Show();
                        return;

                    case "DTD":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.dtd.Show();
                        Program.results.Show();
                        return;

                    case "Schematron":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.schematronvalidate.Show();
                        Program.results.Show();
                        return;

                    case "Word to XML":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.word.Show();
                        Program.results.Show();
                        return;

                    case "CSV to XML":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.csv2xml.Show();
                        Program.results.Show();
                        return;

                    case "XML Syntaxhighlighting":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.syntaxhighlighting.Show();
                        Program.results.Show();
                        return;

                    case "Hotfolder":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.hotfoldForm.Show();
                        Program.results.Show();
                        return;

                    case "XSD Documentation":
                        Program.WINDOW_STATE = true;
                        Program.mainframe.formSwitcher();
                        Program.xsddoku.Show();
                        Program.results.Show();
                        return;

                    default:
                        this.Hide();
                        return;
                }
            }
        }
    }

    public class Entry 
    {

        public string theme;
        public List<string> features;

        public Entry( string Theme, List<string> Features) 
        {

            theme = Theme;
            features = Features;      
        
        }

        public override string ToString()
        {
            return this.theme;
        }

    }
}
