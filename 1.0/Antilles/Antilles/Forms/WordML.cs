
// ------------------------------------------------------------------------ //
// WordML class                                                         //
//                                                                          //
// Momentan deaktiviert !!!!
// 
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
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Net;
using System.Text.RegularExpressions;

namespace Antilles
{
    public partial class WordML : Form
    {

        public string xmlfile = "";
        private List<WordBox> wordListenElemente = new List<WordBox>();

        public WordML(string formatfile)
        {
            InitializeComponent();
            xmlfile = formatfile;
            DateiLesen();
        }


        private void DateiLesen()
        {

            XmlDocument src = new XmlDocument();
            src.Load(xmlfile);
            XmlElement root = src.DocumentElement;
            int y = 0;

            // Hauptüberschriften erzeugen
            System.Windows.Forms.Label Formatvorlagen = new System.Windows.Forms.Label();
            System.Windows.Forms.Label Inzeilig = new System.Windows.Forms.Label();
            System.Windows.Forms.Label Default = new System.Windows.Forms.Label();
            Formatvorlagen.Text = "Formatvorlagen";
            Inzeilig.Text = "Inzeilig";
            Default.Text = "Default";
            Formatvorlagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Inzeilig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // Hauptüberschriften platzieren und Inhalte aus XML File auslesen und aufbereiten
            Formatvorlagen.Location = new System.Drawing.Point(15, 10);
            this.Controls.Add(Formatvorlagen);
            y = aufbereiten(50, root, "paraFormat");
            y += 20;
            Inzeilig.Location = new System.Drawing.Point(15, y);
            this.Controls.Add(Inzeilig);
            y = aufbereiten(y + 40, root, "lineFormat");
            y += 20;
            Default.Location = new System.Drawing.Point(15, y);
            this.Controls.Add(Default);
            y = aufbereiten(y + 40, root, "default");

            button_wordclose.Location = new System.Drawing.Point(408, y);
            button_wordspeichern.Location = new System.Drawing.Point(487, y);
            button_wordausführen.Location = new System.Drawing.Point(568, y);
            Formatvorlagen.Select();

        }

        private int aufbereiten(int ymark, XmlElement root, string wort)
        {

            List<string> block = new List<string>();
            int y = ymark;
            int j = 0;
            InformationenWord packung = new InformationenWord();


            foreach (XmlNode @daten in root.SelectNodes("//tbody[attribute::class=" + "'" + wort + "'" + "]//td"))
            {


                block.Add(@daten.InnerText);

                if (@daten.Attributes["id"] != null)
                {
                    packung.Id = @daten.Attributes["id"].InnerText;
                }

                if (block.Count == 4)
                {
                    packung.Formatname = block[0].ToString();
                    packung.Targetelement = block[1].ToString();
                    packung.Option = block[2].ToString();
                    packung.Level = block[3].ToString();
                    packung.area = wort;

                    wordListenElemente.Add(new WordBox(packung, 15, y, j));

                    // Abstand zwischen den Blöcken
                    y += 120;
                    block.Clear();

                }

                j++;

            }



            for (int i = 0; i < wordListenElemente.Count; i++)
            {

                this.Controls.Add(wordListenElemente[i].formatname);
                this.Controls.Add(wordListenElemente[i].txtbox);
                this.Controls.Add(wordListenElemente[i].desc_formatnamewirdzu);
                //this.Controls.Add(wordListenElemente[i].targetElement);
                //this.Controls.Add(wordListenElemente[i].option);
                this.Controls.Add(wordListenElemente[i].combobox);
                this.Controls.Add(wordListenElemente[i].desc_option);
                //this.Controls.Add(wordListenElemente[i].level);
                this.Controls.Add(wordListenElemente[i].lvleingabe);
                this.Controls.Add(wordListenElemente[i].desc_level);

            }

            return y;
        }

        private void button_wordclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Diese Funktion wird aufgerufen, wenn der Benutzer auf Ausführen klickt.        
        /// </summary>
        private void button_wordausführen_Click(object sender, EventArgs e)
        {

            string zielname = "";            

            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {

                    zielname = open.FileName;

                }

            }
            catch 
            {
               // setLogTxt(ex.Message);
            }

            try
            {
                string mapping = Path.GetTempFileName();                
                xmlmappingschreiben(mapping);
                string result = "";
                
                result = Program.optimusprime.starteProzessor(Program.konfiguration.wordMLFileName, "vorprozess1", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess2", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess3", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess4", Path.GetTempFileName(), true);
                result = Program.optimusprime.starteProzessor(result, "vorprozess5", Path.GetTempFileName(), true);

                parameter Item = new parameter();
                Item.param = "config";
                Item.value = mapping;
                Program.konfiguration.parameters.Add(Item);

                result = Program.optimusprime.starteProzessor(result, "converter", Path.GetTempFileName(), true);

                Program.konfiguration.parameters.Clear();

                result = Program.optimusprime.starteProzessor(result, "converter2", Path.GetTempFileName(), true);

                Program.optimusprime.starteProzessor(result, "converter3", zielname, true);
            }

            catch (Exception ex) 
            {
                Program.hauptfenster.setLogTxt(ex.Message);            
            }

        }        

        
        /// <summary>
        /// Diese Funktion erstellt die Mapping-Tabelle
        /// </summary>
        private void xmlmappingschreiben(string mapping)
        {

            bool flag = true;            
            XmlTextWriter xml = new XmlTextWriter(mapping,
                                                   System.Text.Encoding.UTF8);
            xml.Formatting = Formatting.Indented;
            xml.WriteStartDocument(true);

            xml.WriteStartElement("html");

            xml.WriteComment("Erstellt von antillesXML.");

            xml.WriteStartElement("head");
            xml.WriteElementString("title", "mapping");
            xml.WriteEndElement();

            xml.WriteStartElement("body");
            xml.WriteStartElement("table");

            for (int i = 0; i < wordListenElemente.Count(); i++)
            {

                switch (wordListenElemente[i].area)
                {

                    case "paraFormat":

                        if (flag)
                        {
                            xml.WriteStartElement("tbody");
                            xml.WriteAttributeString("class", wordListenElemente[i].area);
                            flag = false;
                        }

                        break;

                    case "lineFormat":

                        if (!flag)
                        {
                            xml.WriteEndElement();
                            xml.WriteStartElement("tbody");
                            xml.WriteAttributeString("class", wordListenElemente[i].area);
                            flag = true;
                        }
                        break;

                    case "default":

                        if (flag)
                        {
                            xml.WriteEndElement();
                            xml.WriteStartElement("tbody");
                            xml.WriteAttributeString("class", wordListenElemente[i].area);
                            flag = false;
                        }
                        break;

                    default:

                        xml.WriteEndElement();
                        break;

                }

                xml.WriteStartElement("tr");

                xml.WriteStartElement("td");
                xml.WriteAttributeString("class", "formatName");
                xml.WriteAttributeString("id", wordListenElemente[i].id);
                xml.WriteValue(wordListenElemente[i].formatname.Text);
                xml.WriteEndElement();

                xml.WriteStartElement("td");
                xml.WriteAttributeString("class", "targetElement");
                if (wordListenElemente[i].txtbox.Text == "") { wordListenElemente[i].txtbox.Text = wordListenElemente[i].id; }
                xml.WriteValue(wordListenElemente[i].txtbox.Text);
                xml.WriteEndElement();
                

                // NCName prüfen ... TODO
                //txtbox prüfen
                //Regex regx = new Regex(@"[\i-[:]][\c-[:]]*");
                //if (regx.IsMatch(wordListenElemente[i].txtbox.Text))
                //{
                //    xml.WriteValue(wordListenElemente[i].id);
                //    xml.WriteEndElement();
                //}
                //else
                //{
                //    xml.WriteValue(wordListenElemente[i].txtbox.Text);
                //    xml.WriteEndElement();
                //}

                xml.WriteStartElement("td");
                xml.WriteAttributeString("class", "option");                
                xml.WriteValue(wordListenElemente[i].combobox.Text);
                xml.WriteEndElement();

                xml.WriteStartElement("td");
                xml.WriteAttributeString("class", "level");
                xml.WriteValue(wordListenElemente[i].lvleingabe.Text);
                xml.WriteEndElement();

                xml.WriteEndElement();


            }
            xml.WriteEndElement();
            xml.WriteEndElement();
            xml.WriteEndElement();

            xml.Flush();
            xml.Close();

        }

        /// <summary>
        /// Hier wird das Mapping File gespeichert. 
        /// </summary>
        private void button_wordspeichern_Click(object sender, EventArgs e)
        {

            string zielname = "";

            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";
                open.AddExtension = true;
                open.ValidateNames = true;

                if (open.ShowDialog() == DialogResult.OK)
                {

                    zielname = open.FileName;

                }

            }
            catch
            {
                // setLogTxt(ex.Message);
            }

            xmlmappingschreiben(zielname);

        }
        
    }

    class InformationenWord
    {
        public string Formatname = "";
        public string Targetelement = "";
        public string Option = "";
        public string Level = "";
        public string Id = "";
        public string area = "";

        public InformationenWord()
        {

            // default

        }

        public InformationenWord(string formatn, string targetele, string opt, string lvl, string idd)
        {
            Formatname = formatn;
            Targetelement = targetele;
            Option = opt;
            Level = lvl;
            Id = idd;
        }



    }

    class WordBox
    {

        /* Die Labels bis auf formatname sind nicht wirklich notwendig 
           -> eventuell ganz entfernen */

        public System.Windows.Forms.Label formatname;
        public System.Windows.Forms.TextBox txtbox;
        //public System.Windows.Forms.Label targetElement;
        //public System.Windows.Forms.Label option;
        public System.Windows.Forms.ComboBox combobox;
        //public System.Windows.Forms.Label level;
        public System.Windows.Forms.TextBox lvleingabe;

        public System.Windows.Forms.Label desc_formatnamewirdzu;
        public System.Windows.Forms.Label desc_option;
        public System.Windows.Forms.Label desc_level;

        public string id = "";
        public string area = "";

        public WordBox(InformationenWord pack, int x, int y, int counter)
        {

            // init
            id = pack.Id;
            area = pack.area;

            formatname = new System.Windows.Forms.Label();
            formatname.Text = pack.Formatname;
            formatname.Size = new System.Drawing.Size(100, 13);
            formatname.AutoSize = true;
            txtbox = new System.Windows.Forms.TextBox();
            txtbox.Name = "txtbox_" + counter.ToString();
            txtbox.Size = new System.Drawing.Size(300, 20);
            txtbox.Text = pack.Targetelement;
            desc_formatnamewirdzu = new System.Windows.Forms.Label();
            desc_formatnamewirdzu.Text = "-->";
            desc_formatnamewirdzu.Size = new System.Drawing.Size(20, 13);


            //targetElement = new System.Windows.Forms.Label();
            //targetElement.Text = pack.Targetelement;
            //targetElement.Size = new System.Drawing.Size(100, 13);
            //targetElement.AutoSize = true;

            //option = new System.Windows.Forms.Label();
            //option.Text = pack.Option;
            //option.Size = new System.Drawing.Size(100, 13);
            //option.AutoSize = true;
            combobox = new System.Windows.Forms.ComboBox();
            combobox.Name = "combobox_" + counter.ToString();
            combobox.Size = new System.Drawing.Size(300, 20);
            combobox.FormattingEnabled = true;
            combobox.Items.AddRange(new object[] {
            "container",
            "clear",
            "delete"});
            combobox.Name = "combobox" + counter.ToString();
            combobox.Text = pack.Option;
            desc_option = new System.Windows.Forms.Label();
            desc_option.Text = "Option";
            desc_option.Size = new System.Drawing.Size(40, 13);

            //level = new System.Windows.Forms.Label();
            //level.Text = pack.Level;
            //level.Size = new System.Drawing.Size(100, 13);
            //level.AutoSize = true;
            lvleingabe = new System.Windows.Forms.TextBox();
            lvleingabe.Name = "txtboxlvleingabe_" + counter.ToString();
            lvleingabe.Size = new System.Drawing.Size(300, 20);
            lvleingabe.Text = pack.Level;
            desc_level = new System.Windows.Forms.Label();
            desc_level.Text = "Level";
            desc_level.Size = new System.Drawing.Size(35, 13);

            //platzieren
            formatname.Location = new System.Drawing.Point(x, y);
            desc_formatnamewirdzu.Location = new System.Drawing.Point(x + 250, y);
            txtbox.Location = new System.Drawing.Point(x + 300, y);
            //targetElement.Location = new System.Drawing.Point(x, y + 20);
            //option.Location = new System.Drawing.Point(x, y + 40);
            combobox.Location = new System.Drawing.Point(x + 300, y + 30);
            desc_option.Location = new System.Drawing.Point(x + 250, y +  30);
            //level.Location = new System.Drawing.Point(x, y + 60);
            lvleingabe.Location = new System.Drawing.Point(x + 300, y + 60);
            desc_level.Location = new System.Drawing.Point(x + 250, y + 60);


        }


    }

}

