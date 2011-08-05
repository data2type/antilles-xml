// ------------------------------------------------------------------------ //
// xsltpipe class                                                           //
//                                                                          //
// Hier ist die Funktionalität einer Xslt Pipe implementiert. Primär wird   //
// hier die Logik der Windows Form und der Laden/Speichern Mechanik reali.  // 
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
    class xsltpipe
    {
        private List<TxTBoxButtonCombo> txtbuttnbundle = new List<TxTBoxButtonCombo>();
        System.Windows.Forms.Button minusbutton = new System.Windows.Forms.Button();
        System.Windows.Forms.Button delallbutton = new System.Windows.Forms.Button();

        public bool minbuttonset = false;
        public bool delbttnset = false;
        public bool minbuttongrow = false;
        // Falls zuviele Eingaben, muss die FOrm größer werden. Das is das Flag dafür
        public bool ueberdemrand = false;
        // Zum einlesen der Config wichtig
        public bool keinefilesmehr = false;

        // hier wird der minusbutton zum ersten mal angelegt
        private void minbutton()
        {
            minusbutton.Visible = true;
            minbuttonlocation(410, 182);
            minusbutton.Name = "minusbutton";
            minusbutton.Size = new System.Drawing.Size(30, 25);
            minusbutton.Image = global::Antilles.Properties.Resources.remove;
            minusbutton.UseVisualStyleBackColor = true;
            Program.hauptfenster.tabPage_xsltexpert.Controls.Add(minusbutton);
            minusbutton.Click += new System.EventHandler(this.erasestep);            
            minbuttonset = true;
        }

        // hier der alles clear button
        private void deleallbutton()
        {
            delallbutton.Visible = true;
            dellallbtnlocation(447, 182);
            delallbutton.Name = "deleteAllbutton";
            delallbutton.Size = new System.Drawing.Size(30, 25);
            delallbutton.Image = global::Antilles.Properties.Resources.clear;
            delallbutton.UseVisualStyleBackColor = true;
            Program.hauptfenster.tabPage_xsltexpert.Controls.Add(delallbutton);
            delallbutton.Click += new System.EventHandler(this.clearAll);
            delbttnset = true;
        }

        // kleine methode zum ändern der lage vom minusbutton
        private void minbuttonlocation(int x, int y)
        {
            minusbutton.Location = new System.Drawing.Point(x, y);
        }

        // kleine methode zum ändern der lage vom minusbutton
        private void dellallbtnlocation(int x, int y)
        {
            delallbutton.Location = new System.Drawing.Point(x, y);
        }

        // diese funktion entfernt die elemente aus der liste und rückt die buttons
        // entsprechend ein und entfernt die Controls wenn sie nicht mehr gebraucht 
        // werden.
        private void erasestep(object sender, EventArgs e)
        {

            int j = 0;

            if (txtbuttnbundle.Count == 0) return;
            j = txtbuttnbundle.Count - 1;

            Program.hauptfenster.tabPage_xsltexpert.Controls.Remove(txtbuttnbundle[j].btn);
            Program.hauptfenster.tabPage_xsltexpert.Controls.Remove(txtbuttnbundle[j].textbox);            
            //// Zielbutton wandern lassen
            //int yloc_btnziel = Program.hauptfenster.button_zieldatei.Location.Y;
            //int xloc_btnziel = Program.hauptfenster.button_zieldatei.Location.X;
            //Program.hauptfenster.button_zieldatei.Location = new System.Drawing.Point(xloc_btnziel, yloc_btnziel - 30);

            if (j == 0)
            {                
                Program.hauptfenster.button_new.Size = new System.Drawing.Size(30, 25);
               // Program.hauptfenster.button_new.Text = "+";
                Program.hauptfenster.button_new.Image = global::Antilles.Properties.Resources.add;
                Program.hauptfenster.button_new.Click -= new System.EventHandler(txtbuttnbundle[0].selectFile);
                Program.hauptfenster.button_new.Click += new System.EventHandler(Program.hauptfenster.newButton);
                int miny = minusbutton.Location.Y;
                minbuttonlocation(410, miny - 30);
                dellallbtnlocation(447, miny - 30);
                int yloc = Program.hauptfenster.panel_groupbox.Location.Y;
                int xloc = Program.hauptfenster.panel_groupbox.Location.X;
                Program.hauptfenster.panel_groupbox.Location = new System.Drawing.Point(xloc, yloc - 30);
                txtbuttnbundle.RemoveAt(j);
                keinefilesmehr = false;
                minusbutton.Visible = false;
                delallbutton.Visible = false;
            }
            else
            {
                txtbuttnbundle[j - 1].btn.Size = new System.Drawing.Size(30, 25);
                txtbuttnbundle[j - 1].btn.Image = global::Antilles.Properties.Resources.add;
                txtbuttnbundle[j - 1].btn.Click -= new System.EventHandler(txtbuttnbundle[j].selectFile);
                txtbuttnbundle[j - 1].btn.Click += new System.EventHandler(Program.hauptfenster.newButton);
                int miny = minusbutton.Location.Y;
                minbuttonlocation(410, miny - 30);
                dellallbtnlocation(447, miny - 30);
                int yloc = Program.hauptfenster.panel_groupbox.Location.Y;
                int xloc = Program.hauptfenster.panel_groupbox.Location.X;
                Program.hauptfenster.panel_groupbox.Location = new System.Drawing.Point(xloc, yloc - 30);
                txtbuttnbundle.RemoveAt(j);
            }
            Program.hauptfenster.Height -= 50;
            Program.hauptfenster.tabControl.TabPages["tabPage_xsltexpert"].Height -= 50;
            Program.hauptfenster.tabControl.Height -= 50;
            //Program.hauptfenster.tabControl.Refresh();


        }

        public void buttontextboxmagic(object sender, EventArgs e)
        {
            int x = 0, y = 0;

            try
            {
                // Standort vom Button ermitteln
                x = (sender as Button).Location.X;
                y = (sender as Button).Location.Y;
            }
            catch (Exception)
            {

            }
            int j = 0;

            // Hier wird ein neuer button und textbox erzeugt        
            j = txtbuttnbundle.Count;
            txtbuttnbundle.Add(new TxTBoxButtonCombo(j.ToString(), j.ToString(), x, y));
            Program.hauptfenster.tabPage_xsltexpert.Controls.Add(txtbuttnbundle[j].btn);            
            Program.hauptfenster.tabPage_xsltexpert.Controls.Add(txtbuttnbundle[j].textbox);
            keinefilesmehr = true;
            minusbutton.Visible = true;
            delallbutton.Visible = true;

            if (minbuttongrow)
            {
                int miny = minusbutton.Location.Y;
                minbuttonlocation(410, miny + 30);
                dellallbtnlocation(447, miny + 30);
            }

            if (!minbuttonset)
            {
                minbutton();
                deleallbutton();
                minbuttongrow = true;
            }

            // Hier wird der aktuelle Button umgebaut  
            (sender as Button).Name = j.ToString();
            (sender as Button).Size = new System.Drawing.Size(50, 25);
            (sender as Button).TabIndex = 0;
            (sender as Button).Image = global::Antilles.Properties.Resources.file;
            (sender as Button).UseVisualStyleBackColor = true;
            // Clickhandler umleiten
            (sender as Button).Click -= new System.EventHandler(Program.hauptfenster.newButton);
            (sender as Button).Click += new System.EventHandler(txtbuttnbundle[j].selectFile);
            int yloc = Program.hauptfenster.panel_groupbox.Location.Y;
            int xloc = Program.hauptfenster.panel_groupbox.Location.X;
            Program.hauptfenster.panel_groupbox.Location = new System.Drawing.Point(xloc, yloc + 30);
            
            Program.hauptfenster.Height += 50;
            Program.hauptfenster.tabControl.Height += 50;
            Program.hauptfenster.tabControl.TabPages["tabPage_xsltexpert"].Height += 50;
            Program.hauptfenster.tabControl.Refresh();

        }

        public void ButtonEngage(pipetarget output)
        {

            // Diese Liste beinhaltet die Pfade zu den Xslt Stylesheets
            List<string> stuff = new List<string>();
            string erzeugtesfile = output.frontname + "_step0" + output.extension;

            // Bzw nach dieser Schleife. Sie wird an dieser Stelle gefüllt.
            for (int i = 0; i < txtbuttnbundle.Count; i++)
            {

                stuff.Add(txtbuttnbundle[i].filename);

            }

            // pipeline erzeugen
            string pipeline = Program.konfiguration.xmlfilepathPipe;

            try
            {
                Program.optimusprime.starteProzessor(pipeline, Program.konfiguration.xsltfilepathPipe, erzeugtesfile);
            }

            catch (Exception)
            {
                // Hier würden XML Exceptions geworfen werden, die sich um das Resultatfile drehen
                // wollen wir das wirklich? nein                
                // Program.hauptfenster.setLogTxt("Es gab Fehler in der Pipe." + ex.Message);
            }

            if (stuff.Count > 0)
            {

                try
                {

                    //pipeline.Load(erzeugtesfile);
                    pipeline = erzeugtesfile;

                }
                catch (Exception)
                {
                    // Dasselbe wie oben...                    
                    // Program.hauptfenster.setLogTxt("Es gab Fehler in der Pipe." + ex.Message);
                }
            }

            int j = 0;
            for (int i = 0; i < stuff.Count; i++)
            {
                if (i + 1 < stuff.Count)
                {
                    j = i + 1;
                    erzeugtesfile = output.frontname + "_step" + j + output.extension;
                }
                else
                {
                    erzeugtesfile = output.frontname + output.extension;
                }
                try
                {
                    // Das ist ein rekursiver Aufruf in einer Schleife.
                    // Die Funktion gibt einen String zurück und diesen
                    // dann wieder in die Funktion
                    pipeline = (Program.optimusprime.starteProzessor(pipeline, stuff[i], erzeugtesfile));


                }
                catch (Exception)
                {
                    // Dasselbe wie oben...
                    // Program.hauptfenster.setLogTxt(DateTime.Now.ToString());
                    // Program.hauptfenster.setLogTxt("Es gab Fehler in der Pipe." + ex.Message);
                }
            }

        }

        // Speichert die notwendigen Daten ab und schreibt sie in ein XML File
        public void saveConfig()
        {

            string target = "";

            try
            {

                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    target = open.FileName;
                    List<String> Config = new List<string>();
                    Config.Add(Program.konfiguration.xmlfilepathPipe);                    
                    Config.Add(Program.konfiguration.xsltfilepathPipe);
                    Config.Add(Program.konfiguration.xmlfilepathTargetPipe);

                    for (int i = 0; i < txtbuttnbundle.Count; i++)
                    {

                        Config.Add(txtbuttnbundle[i].filename);

                    }

                    XmlSerializer ser = new XmlSerializer(typeof(List<String>));
                    FileStream str = new FileStream(target, FileMode.Create);
                    ser.Serialize(str, Config);
                    str.Close();
                }
            }
            catch (Exception)
            {
                // setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt(DateTime.Now.ToString());                
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }

        }

        public void getAllParams() 
        {

            // Diese Liste beinhaltet die Pfade zu den Xslt Stylesheets
            List<string> stuff = new List<string>();
            stuff.Add(Program.konfiguration.xsltfilepathPipe);
            Program.konfiguration.piplelineaktiv = true;
            // Bzw nach dieser Schleife. Sie wird an dieser Stelle gefüllt.
            for (int i = 0; i < txtbuttnbundle.Count; i++)
            {
                
                stuff.Add(txtbuttnbundle[i].filename);

            }            
            ParameterFenster parameterwindow = new ParameterFenster(stuff);
            Program.konfiguration.piplelineaktiv = false;
            parameterwindow.Show();        
        
        }

        public void clearAll(object sender, EventArgs e)
        {           
            // aufräumen
            while (keinefilesmehr)
            {

                erasestep(new object(), new EventArgs());

            }
            keinefilesmehr = false;
        }

        public void loadConfig()
        {

            string target = "";

            try
            {

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "XML file (*.xml)|*.xml";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    target = open.FileName;
                    List<String> Config = new List<string>();
                    XmlSerializer ser = new XmlSerializer(typeof(List<String>));
                    StreamReader sr = new StreamReader(target);
                    Config = (List<string>)ser.Deserialize(sr);
                    sr.Close();

                    // aufräumen
                    while (keinefilesmehr)
                    {

                        erasestep(new object(), new EventArgs());

                    }
                    keinefilesmehr = false;
                    Program.hauptfenster.textBox_xmlfile_pipe.Text = "";
                    Program.hauptfenster.textBox_xsltfile_pipe.Text = "";
                    Program.hauptfenster.textBox_xsltpipeziel.Text = "";

                    // auffüllen
                    Program.hauptfenster.textBox_xmlfile_pipe.Text = Config[0];
                    Program.hauptfenster.textBox_xsltfile_pipe.Text = Config[1];
                    Program.hauptfenster.textBox_xsltpipeziel.Text = Config[2]; 
                    Program.konfiguration.xmlfilepathPipe = Config[0];
                    Program.konfiguration.xsltfilepathPipe = Config[1];
                    Program.konfiguration.xmlfilepathTargetPipe = Config[2];

                    // Ziel einstellen
                    FileInfo fi = new FileInfo(Config[2]);
                    Program.hauptfenster.thepipetarget.extension = fi.Extension;
                    Program.hauptfenster.thepipetarget.dir = fi.DirectoryName;
                    Program.hauptfenster.thepipetarget.frontname = fi.Name;

                    if (Config.Count > 2)
                    {
                        txtbuttnbundle.Clear();
                        Program.hauptfenster.newButton(Program.hauptfenster.button_new, new EventArgs());
                        txtbuttnbundle[0].filename = Config[3];
                        txtbuttnbundle[0].textbox.Text = Config[3];

                        for (int i = 0; i < Config.Count - 4; i++)
                        {

                            Program.hauptfenster.newButton(txtbuttnbundle[i].btn, new EventArgs());
                            txtbuttnbundle[i + 1].filename = Config[i + 4];
                            txtbuttnbundle[i + 1].textbox.Text = Config[i + 4];

                        }
                    }
                    Config.Clear();
                }
            }


            catch (Exception)
            {
                // setStatusTxt("Sie müssen einen Ordner angeben");
                //setLogTxt(DateTime.Now.ToString());                
                //setLogTxt("Sie müssen einen Ordner angeben");               
            }
        }

        // Diese Klasse enthält einen button und eine textbox. sie werden hier angelegt
        // und eine methode kümmert sich darum wenn ein file ausgewählt wurde, das dieser
        // pfad dann in der textbox steht. diese klasse wird als listenelement benötigt
        // um das dynamische erzeugen einer "pipeline" grafisch darzustellen.
        class TxTBoxButtonCombo
        {
            public System.Windows.Forms.Button btn;            
            public System.Windows.Forms.TextBox textbox;
            public string filename = "";

            public TxTBoxButtonCombo(string txtboxname, string buttonname, int x, int y)
            {

                // Hier wird der neue Plus Button erzeugt
                btn = new System.Windows.Forms.Button();
                btn.Location = new System.Drawing.Point(x, y + 30);
                btn.Name = buttonname;
                btn.Size = new System.Drawing.Size(30, 25);
                btn.TabIndex = 0;
                btn.Image = global::Antilles.Properties.Resources.add;
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(Program.hauptfenster.newButton);

                // Hier wird die neue Textbox erzeugt
                textbox = new System.Windows.Forms.TextBox();
                textbox.Location = new System.Drawing.Point(118, y);
                textbox.Size = new System.Drawing.Size(234, 20);
                textbox.Text = "";
                textbox.Name = txtboxname;

            }

            public void selectFile(object sender, EventArgs e)
            {

                try
                {

                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "XSLT file (*.xslt, *.xsl)|*.xslt;*.xsl";

                    if (open.ShowDialog() == DialogResult.OK)
                    {

                        textbox.Text = open.FileName;
                        filename = open.FileName;

                        // checken ob schema valide ist
                        //Program.validboy.ausgabeflag = false;
                        //Program.validboy.ValidiereXMLFile(Program.konfiguration.xmlSchemaFileName, ValidationType.Schema, null, "schema");

                    }
                }
                catch (Exception ex)
                {
                   // Program.hauptfenster.setStatusTxt("Es gibt Meldungen. Bitte schauen Sie ins log");
                    Program.hauptfenster.setLogTxt(ex.Message);
                }
            }            
        }
    }
}
