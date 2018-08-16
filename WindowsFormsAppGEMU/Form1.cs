using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using ClassLibraryStream;
using static System.Diagnostics.Process;


namespace WindowsFormsAppGEMU
{

    using iop = System.Diagnostics.Process;
    public partial class Form1 : Form
    {

        Helper swr = new Helper();
        string[] pathVett = new string[500];
        int iv = 0;
        public int x = 12;
        public int y = 27;
        public Form1()
        {
            InitializeComponent();

        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string fName;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Inserisci file da aggiungere";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {


                fName = ofd.FileName;
                Button btn = new Button();
                btn.Name = fName;
                btn.Text = ofd.SafeFileName;
                btn.Size = new Size(150, 65);
                btn.Location = new Point(x, y);
                btn.Visible = true;
                btn.ImageAlign = ContentAlignment.TopLeft;
                btn.Image = Icon.ExtractAssociatedIcon(fName)?.ToBitmap();
                btn.Click += button_Clicked;
                Controls.Add(btn);
                pathVett[iv] = btn.Name;
                iv++;
            }


            x += 166;
            if (x > 671)
            {
                y += 71;
                x = 12;
            }


        }

        private void button_Clicked(object sender, EventArgs e)
        {

            var path = new string[5];
            var btn = (Button)sender;
            var pathC = btn.Name;
            //MessageBox.Show(pathC);
            try
            {
                Start(pathC);
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("config/config.txt"))
            {
                StreamReader wr = new StreamReader("config/config.txt");
                do
                {
                    var fName = wr.ReadLine();
                    if (fName == "")
                    {
                        break;
                    }
                    else
                    {
                        pathVett[iv] = fName;
                        iv++;
                        var btn = new Button();
                        btn.Name = fName;
                        btn.Text = Helper.GetFileName(fName);
                        btn.Size = new Size(150, 65);
                        btn.Location = new Point(x, y);
                        btn.Visible = true;
                        //btn.ImageAlign = ContentAlignment.TopLeft;             
                        //  btn.BackgroundImage = System.Drawing.Icon.ExtractAssociatedIcon(fName).ToBitmap();
                        btn.ContextMenuStrip = contextMenuStrip1;
                        btn.Click += button_Clicked;
                        Controls.Add(btn);
                        x += 166;
                        if (x > 671)
                        {
                            y += 71;
                            x = 12;
                        }
                    }

                } while (!wr.EndOfStream);
                wr.Close();
            }

        }

        private void steamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start("G:/GameStation[WIP]/Steam");
        }

        private void launchBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void Salva()
        {
            if (!Directory.Exists("config"))
            {
                Directory.CreateDirectory("config");
            }
            StreamWriter sw = new StreamWriter("config/config.txt");
            foreach (string t in pathVett)
            {
                sw.WriteLine(t);
            }
            sw.Close();
            StreamWriter swxy = new StreamWriter("config/xy.txt");
            swxy.WriteLine(x);
            swxy.WriteLine(y);
            swxy.Close();

        }

        private void giochiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Salva();
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aggiornaInBloccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool b = false;
            for (int iA = 0; iA < iv; iA++)
            {

                if (!File.Exists(pathVett[iA]))
                {
                    pathVett[iA] = "";
                    b = true;
                }
            }
            if (b == true)
            {
                MessageBox.Show("Sono stati trovati percorsi non disponibili \r L'applicazione verrà ora riavviata");
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Tutti i percorsi sono disponibili");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = iv;
            toolStripStatusLabel1.Text = iv.ToString() + "/500";

        }

        private void cartellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName;
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"D:\\GameStation[WIP]\\TTTT";
            fbd.Description = "Seleziona cartella";
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                var vett = Helper.DirSearch(path).Distinct().ToList();
                foreach (var f in vett)
                {
                    fName = f;
                    var btn = new Button
                    {
                        Name = fName,
                        Text = Helper.GetFileName(f),
                        Size = new Size(150, 65),
                        Location = new Point(x, y),
                        Visible = true,
                        ImageAlign = ContentAlignment.TopLeft,
                        Image = Icon.ExtractAssociatedIcon(fName)?.ToBitmap()
                    };
                    btn.Click += button_Clicked;
                    Controls.Add(btn);
                    pathVett[iv] = btn.Name;
                    iv++;
                    x += 166;
                    if (x <= 671) continue;
                    y += 71;
                    x = 12;
                }

            }


            x += 166;
            if (x > 671)
            {
                y += 71;
                x = 12;
            }

        }
    }
}