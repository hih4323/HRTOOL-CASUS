using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.DataFormats;

namespace HRTOOL_CASUS
{
    public partial class Aanpassen : Form
    {
        /*Vanuit hier kunnen projecten worden aangepast door middel van de huigige gegevens
         eerst in te laden en dan te bewerken (wegschrijven naar database)*/

        Db db = new();

        private Dashboard dash;

        public Aanpassen(Dashboard dash)
        {
            InitializeComponent();
            Load += new EventHandler(Aanpassen_Load);

            this.dash = dash;

        }

        private void Aanpassen_Load(object sender, EventArgs e)
        {
            Db db = new();
            List<string> lijst = db.ReadDataProjecten();

            /*Ophalen van de projecten en soorten om in een dropdown menu
            weer te geven.*/

            foreach (string c in lijst)
            {
                comboBox1.Items.Add(c);
            }


            List<string> lijst1 = db.ReadDataProjectenSoort();

            foreach (string c in lijst1)
            {
                comboBox2.Items.Add(c);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Als een geldig ID wordt ingegeven dan worden de waardes die bij het ID horen
             in de velden weergeven om ze te kunnen bijwerken. De velden worden eerst leeggemaakt
             om er zeker van te zijn dat geen waardes met elkaar verbonden raken die niet bij elkaar
             thuis horen.*/

            try
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.ResetText();
                comboBox2.ResetText();

                List<string> lijst = db.ReadForEdit(textBox1.Text);

                textBox2.Text += lijst[0];
                textBox3.Text += lijst[1];
                textBox4.Text += lijst[2];
                textBox5.Text += lijst[3];
                comboBox1.Text += lijst[4];
                comboBox2.Text += lijst[5];
            }
            catch
            {
                MessageBox.Show("Uw ingegeven ID is niet gevonden");
            }


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Als de waardes zijn bijgwerkt kunnen ze onder deze knop worden doorgevoerd naar
             de database. Als alles correct is verlopen dan wordt een verversing van de ingeplande projecten
             weergeven in de textbox.*/

            try
            {
                int ID = Convert.ToInt32(textBox1.Text);
                int HRID = Convert.ToInt32(textBox2.Text);
                string DATUM = textBox3.Text;
                int WEEK = Convert.ToInt32(textBox4.Text);
                int WEEKDAG = Convert.ToInt32(textBox5.Text);
                string PROJECT = comboBox1.Text;
                string PROJECTSOORT = comboBox2.Text;

                db.UpdateAanpassen(HRID, DATUM, WEEK, WEEKDAG, PROJECT, PROJECTSOORT, ID);
                this.Hide();

                dash.richTextBox1.Clear();
                dash.richTextBox1.AppendText("Uw gegevens zijn succesvol in de database aangepast:\n\n\n");
                dash.richTextBox1.AppendText("ID       HRID\t\tDATUM\t\tWEEK\t\tDAGWEEK\t\tPROJ.SOORT\t\tPROJECT\n");
                List<string> lijst = db.ReadWerkuren();

                foreach (string c in lijst)
                {
                    dash.richTextBox1.AppendText(c);
                    dash.richTextBox1.AppendText("\n");

                }
            }
            catch
            {
                MessageBox.Show("Voer A.U.B. alle gegevens in...");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
