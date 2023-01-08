using hrtool;
using HRTOOL_CASUS.Forms.Project;
using HRTOOL_CASUS.Forms.ProjectSoort;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Aanmaken = HRTOOL_CASUS.Forms.ProjectSoort.Aanmaken;
using Bewerken = HRTOOL_CASUS.Forms.Project.Bewerken;
using Image = System.Drawing.Image;

namespace HRTOOL_CASUS
{
    public partial class Dashboard : Form
    {
        /*Dit is het hoofdscherm van de Rayco planner, genaamd het Dashboard. Dit is de centrale plek
         om:
        
         1. Medewerkers te kunnen inzien.
         2. Het standaard rooster van medewerkers te kunnen opvragen.
         3. De beschikbaarheid op te vragen van een betreffend HRID en bijhorend weeknummer.
         4. Een medewerker te kunnen inplannen op een project.
         5. Project gegevens te kunnen opvragen en het aanpassen daarvan op basis van het ID.
         6. Een project geheel te kunnen verwijderen op basis van het ID.
         7. De Rayco afbeelding is gekoppeld aan de HR 'Website' van Rayco (Dubbelklik op de afbeelding).
         8. De verbinding van het HR Systeem te kunnen controleren en een geschikte tekst te kunnen teruggeven.
        
         Verder wordt er bij het aanpassen en verwijderen een bijgewerkte lijst teruggeven om te kunnen controleren
         of de bewerking ook naar behoren is voltooid.*/

        HRKoppeling hrKoppeling = new HRKoppeling("http://127.0.0.1:8008");
        Db db = new();

        public Dashboard()
        {
            InitializeComponent();

            richTextBox1.AppendText("Welkom bij de RAYCO planner!");
            richTextBox1.AppendText("\n\nControleer of er verbinding is met de HR server");
            richTextBox1.AppendText("\nof maak uw keuze in het menu...");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ophalen van gebruikers

            richTextBox1.Clear();

            var lijst = hrKoppeling.WerknemerIndex();

            if (lijst != null)
            {
                richTextBox1.AppendText("HRID | Naam\n");
                richTextBox1.AppendText("-----+--------------\n");

               
                foreach (var werknemer in lijst)
                {
                    richTextBox1.AppendText($"{werknemer.Key,4:D} \t {werknemer.Value}\n");
                    richTextBox1.AppendText("\n");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            //Ophalen van werkuren uit een datum uit het verleden
            //Geeft inzicht hoeveel uur iemand inzetbaar is

            richTextBox1.Clear();

            var lijst = hrKoppeling.WerknemerIndex();

            richTextBox1.AppendText("HRID | Naam |\t\t\tWerkweek\n");
            richTextBox1.AppendText("-----+--------------------------------------------------------------------------------------\n");

            if (lijst != null)
            {
                int HRID = 1;
                int JAAR = 2022;
                int WEEKNR = 1;

                foreach (var werknemer in lijst)
                {

                    richTextBox1.AppendText($"{werknemer.Key,4:D}\t{werknemer.Value}\n");
                    richTextBox1.AppendText($"\t\t\t\t\tMA\tDI\tWO\tDO\tVR\tZA\tZO");
                    richTextBox1.AppendText($"\n");
                    richTextBox1.AppendText($"\t\t\t\t\t");
                    

                    var beschikbaar = hrKoppeling.Beschikbaarheid(HRID,JAAR,WEEKNR);


                    foreach (var werkuren in beschikbaar)
                    {
                        
                        richTextBox1.AppendText($"{werkuren}\t");
                        
                    }

                    HRID ++;

                    richTextBox1.AppendText($"\n\n");
                    
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Openen van venster beschikbaarheid

            richTextBox1.Clear();
            richTextBox1.AppendText("Voer de gegevens in om de beschikbaarheid in te kunnen zien");

            Beschikbaarheid bes = new Beschikbaarheid(this);
            bes.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Openen van venster inplannen

            richTextBox1.Clear();
            richTextBox1.AppendText("U kunt nu een medewerker inplannen op een project");

            Inplannen planin = new Inplannen(this);
            planin.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Openen van aanpassingsvenster + ophalen projectplanning (compleet)

            richTextBox1.Clear();
            richTextBox1.AppendText("ID       HRID\t\tDATUM\t\tWEEK\t\tDAGWEEK\t\tPROJ.SOORT\t\tPROJECT\n");

            List<string> lijst = db.ReadWerkuren();

            foreach (string c in lijst)
            {
                richTextBox1.AppendText(c);
                richTextBox1.AppendText("\n");

            }

            Aanpassen pasaan = new Aanpassen(this);
            pasaan.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //standaard kleuren voor textbox meegeven

            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Openen van functie en teruggeven of verbinding is

            richTextBox1.Clear();
            bool check = hrKoppeling.CheckPort();

            if (check== true)
            {
                richTextBox1.AppendText("Er is verbinding met de HR-TOOL van Rayco!");
            }
            else
            {
                richTextBox1.AppendText("Er is helaas geen verbinding met de HR-TOOL van Rayco...\n\n");
                richTextBox1.AppendText("Maak verbinding of vraag hulp aan uw systeembeheerder.");
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //openen van browser indien iemand op de Rayco afbeelding klikt

            richTextBox1.Clear();
            Process.Start("explorer.exe", "http://127.0.0.1:8008");

            richTextBox1.AppendText("U wordt omgeleid naar de website van het Rayco HR Systeem...");


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Openen van verwijderingsvenster + ophalen projectplanning (compleet)

            richTextBox1.Clear();

            richTextBox1.AppendText("ID       HRID\t\tDATUM\t\tWEEK\t\tDAGWEEK\t\tPROJ.SOORT\t\tPROJECT\n");

            List<string> lijst = db.ReadWerkuren();

            foreach (string c in lijst)
            {
                richTextBox1.AppendText(c);
                richTextBox1.AppendText("\n");

            }

            Verwijderen del = new Verwijderen(this);
            del.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //tooltip gebruik indien muiscursor over afbeelding beweegt

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

            ToolTip1.Show("Webpagina: Rayco HR systeem", pictureBox1);
            ToolTip1.ForeColor = Color.White;
            ToolTip1.BackColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            HRTOOL_CASUS.Forms.ProjectSoort.Bewerken bewerken = new Forms.ProjectSoort.Bewerken(this);
            bewerken.Show();

            RaycoProjectSoorten ps = new RaycoProjectSoorten();
            ps.LaadIn();
            List<Soorten> projectsoorten = ps.Inzien();

            richTextBox1.AppendText("ID\tNAAM\n\n");

            foreach (var i in projectsoorten)
            {
                richTextBox1.AppendText(Convert.ToString(i.id));
                richTextBox1.AppendText("\t");
                richTextBox1.AppendText(i.projectsoortnaam);
                richTextBox1.AppendText("\n");
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            HRTOOL_CASUS.Forms.Project.Aanmaken aanmaken = new Forms.Project.Aanmaken(this);

            aanmaken.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            Aanmaken aanmaken = new Aanmaken(this);

            aanmaken.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            RaycoProjectSoorten ps = new RaycoProjectSoorten();
            ps.LaadIn();
            List<Soorten> projectsoorten = ps.Inzien();

            RaycoProjecten rp = new RaycoProjecten();
            rp.Inladen();
            List<Projecten> projecten = rp.Inzien();

            foreach (var i in projectsoorten)
            {
                richTextBox1.AppendText(Convert.ToString(i.id));
                richTextBox1.AppendText("\t");
                richTextBox1.AppendText(i.projectsoortnaam);
                richTextBox1.AppendText("\n");

                int mintijdprio10 = 0;
                int maxtijdprio10 = 0;
                int mintijdprio1 = 0;
                int maxtijdprio1 = 0;

                foreach (var j in projecten)
                {
                    if (i.projectsoortnaam == j.projectsoort)
                    {
                        if (j.prio == 1 || j.prio == 0)
                        {   
                            mintijdprio10+= j.duurmin;
                            maxtijdprio10+= j.duurmax; 
                        }

                        if (j.prio == 1 )
                        {                     
                            mintijdprio1+= j.duurmin;
                            maxtijdprio1+= j.duurmax;
                        }

                    }

                }

                richTextBox1.AppendText("\t");
                richTextBox1.AppendText($"Uitvoeren van alle prioriteiten in uren:\n\tMIN TIJD= {mintijdprio10}\n\tMAX TIJD= {maxtijdprio10}");

                richTextBox1.AppendText("\n\t");
                richTextBox1.AppendText($"Niet uitvoeren van alle prioriteiten in uren:\n\tMIN TIJD= {mintijdprio1}\n\tMAX TIJD= {maxtijdprio1}");

                richTextBox1.AppendText("\n");
                richTextBox1.AppendText("__________________________________________________________________________________________________\n\n");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            Inzien inzien = new Inzien(this); 
            inzien.Show();

            richTextBox1.AppendText("Selecteer in het menu welke projecten u van de projectsoort wilt inzien");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            Bewerken bewerken = new Bewerken(this);
            bewerken.Show();


        }
    }
}
