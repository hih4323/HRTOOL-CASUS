using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.DataFormats;

namespace HRTOOL_CASUS
{
    public partial class Inplannen : Form
    {
        /*Vanuit hier kunnen projecten worden ingepland je kunt kiezen uit:
         
         1.Datum
         2.HRID
         3.Week
         4.Dag van week
         5.Project
         6.Projectsoort*/

        Db db = new();

        private Dashboard dash;

        public Inplannen(Dashboard dash)
        {
            InitializeComponent();

            this.dash = dash;

        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Inplannen_Load(object sender, EventArgs e)
        {
            /*Ophalen van de projecten en soorten om in een dropdown menu
             weer te geven.*/

            List<string> lijst = db.ReadDataProjecten();

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

        private void button1_Click(object sender, EventArgs e)
        {   /*Vanuit hier worden gegevens ingevoerd en doorgezet naar de database. Als
             alles correct is verlopen dan wordt een verversing van de ingeplande projecten
             weergeven in de textbox.*/

            try
            {
                int HRID = Convert.ToInt32(textBox1.Text);
                string DATUM = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                int WEEKNR = Convert.ToInt32(textBox2.Text);
                int WEEKDAG = Convert.ToInt32(textBox3.Text);
                string PROJECT = comboBox1.Text;
                string PROJECTSOORT = comboBox2.Text;

                Db db = new();

                db.Inplannen(HRID, DATUM, WEEKNR, WEEKDAG, PROJECT, PROJECTSOORT);
                this.Hide();

                dash.richTextBox1.Clear();
                dash.richTextBox1.AppendText("Uw gegevens zijn succesvol in de database geplaatst:\n\n\n");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
