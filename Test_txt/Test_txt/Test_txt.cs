using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test_txt
{
    public partial class Test_txt : Form
    {
        public Test_txt()
        {
            this.Text = "Test txt";
            this.ShowIcon = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader ctenar = new StreamReader("soubor.txt"))
            {
                while (!ctenar.EndOfStream)
                {
                    String line = ctenar.ReadLine();
                    listBox1.Items.Add(line + "\r\n");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int pocet_zen = 0;
            int vek_soucet = 0;
            int vek_pocet = 100;
            int mzda_max = int.MinValue;
            if (File.Exists("soubor.txt"))
            {
                using (StreamReader ctenar = new StreamReader("soubor.txt"))
                {
                    while (!ctenar.EndOfStream)
                    {
                        string gender = string.Empty;
                        string vek = string.Empty;
                        string mzda = string.Empty;
                        string line = ctenar.ReadLine();
                        int pocet = 0;

                        foreach (char znaky in line)
                        {
                            if (znaky == '"')
                            {
                                pocet++;
                            }
                            if (pocet == 7)
                            {
                                while (znaky != '"')
                                {
                                    gender += znaky;
                                }
                                if (gender == "Female")
                                {
                                    pocet_zen++;
                                    gender = string.Empty;
                                }
                                else
                                {
                                    gender = string.Empty;
                                }

                            }

                            else if (pocet == 11)
                            {
                                while (znaky != '"')
                                {
                                    vek += znaky;
                                }
                            }

                            else if (pocet == 15)
                            {
                                while (znaky != '"')
                                {
                                    mzda += znaky;
                                }
                                if (Convert.ToInt32(mzda) < 15200)
                                {
                                    listBox2.Items.Add(line);
                                }
                                else if (Convert.ToInt32(mzda) > mzda_max)
                                {
                                    mzda_max = Convert.ToInt32(mzda);
                                }
                            }
                        }
                    }
                }
           
                MessageBox.Show("Počet vygenerovaných žen: " + pocet_zen);
                double prumer = vek_soucet / vek_pocet;

                using (StreamWriter zapisnik = new StreamWriter("best.txt"))
                {
                    zapisnik.Write("Průměrný věk: " + prumer + "\r\n");
                    zapisnik.Write("Největší výplata: " + mzda_max + "Kč \r\n");
                }
            }
                    else
                    {
                        MessageBox.Show("Soubor nebyl nalezen");
                    }
        }
    } 
}



  
       
      
        

       



