using hrtool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRTOOL_CASUS
{
    public partial class Beschikbaarheid : Form
    {
        /*Vanuit hier kan de beschikbaarheid worden opgevraagd dit wordt gedaan op basis van de ingplande uren
         die afkomstig zijn vanuit de database. Deze uren worden verrekend met de contract uren. Op deze
         manier wordt het inzichtelijk hoeveel uur iemand werkt,over heeft of tekort heeft.*/

        HRKoppeling hrKoppeling = new HRKoppeling("http://127.0.0.1:8008/");
        Db db = new();

        private Dashboard dash;

        public Beschikbaarheid(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Beschikbaarheid_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*Eerst zetten we op basis van de ingegeven gegevens de naam en hrid neer,hierna halen we
             de uren op die beschikbaarzijn volgens het rooster. Hierna halen we de gegevens op die
             ingepland staan in de database. Als deze binnen zijn worden deze gegevens verrekend op
             basis van de uren (ma t/m vrij).*/

            try
            {
                dash.richTextBox1.Clear();

                int HRID = Convert.ToInt32(textBox1.Text);
                int WEEKNR = Convert.ToInt32(textBox2.Text);
                int JAAR = 2022;

                var lijstnaam = hrKoppeling.WerknemerIndex();
                var beschikbaar = hrKoppeling.Beschikbaarheid(HRID, JAAR, WEEKNR);
                List<int> uren = new List<int> { };
                List<string> medewerker = new List<string> { };
                dash.richTextBox1.AppendText("HRID | Naam\n");
                dash.richTextBox1.AppendText("--------------------------------------------------------------------------------------------\n");

             
                foreach (var werknemer in lijstnaam)
                {
                    medewerker.Add($"{werknemer.Key,4:D}\t{werknemer.Value}\n");
                }


                dash.richTextBox1.AppendText(medewerker[HRID - 1]);
                dash.richTextBox1.AppendText("\n");
                dash.richTextBox1.AppendText($"Overzicht Planning Week: {WEEKNR}\n");
                dash.richTextBox1.AppendText("--------------------------------------------------------------------------------------------\n");
                dash.richTextBox1.AppendText("\t\t\t\t\tMA\tDI\tWO\tDO\tVR\tZA\tZO");
                dash.richTextBox1.AppendText("\n");
                dash.richTextBox1.AppendText("Contracturen");
                dash.richTextBox1.AppendText("\t\t\t");

                foreach (var werkuren in beschikbaar)
                {
                    dash.richTextBox1.AppendText($"{werkuren}\t");
                    uren.Add(Convert.ToInt32(werkuren));
                }

                dash.richTextBox1.AppendText("\n");
                dash.richTextBox1.AppendText("Planning");
                dash.richTextBox1.AppendText("\t\t\t\t");

                List<int> ureninzet = db.ReadInzetUren(HRID, WEEKNR);

                foreach (int i in ureninzet)
                {
                    dash.richTextBox1.AppendText(Convert.ToString(i));
                    dash.richTextBox1.AppendText("\t");
                }

                dash.richTextBox1.AppendText("\n\n");
                dash.richTextBox1.AppendText("Resultaat");
                dash.richTextBox1.AppendText("\t\t\t\t");

                for (int i = 0; i < 7; i++)
                {
                    int result = beschikbaar[i] - ureninzet[i];
                    dash.richTextBox1.AppendText(Convert.ToString(result));
                    dash.richTextBox1.AppendText("\t");
                }

                this.Close();
            }

            catch
            {
                MessageBox.Show("Voer de juiste gegevens in...");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
