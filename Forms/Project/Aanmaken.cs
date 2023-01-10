using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HRTOOL_CASUS.Forms.Project
{
    public partial class Aanmaken : Form
    {
        private Dashboard dash;
        RaycoProjectSoorten projs = new RaycoProjectSoorten();
        RaycoProjecten rp = new RaycoProjecten();

        public Aanmaken(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;

            Load += new EventHandler(Aanmaken_load);
        }

        private void Aanmaken_load(object sender, EventArgs e)
        {
            RaycoProjectSoorten projs = new RaycoProjectSoorten();
            projs.LaadIn();
            List<Soorten> projectensoort = projs.Inzien();

            foreach (Soorten p in projectensoort)
            {
                comboBox1.Items.Add(p.projectsoortnaam);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aanmaken
            dash.richTextBox1.Clear();

            try
            {
                string naam = textBox1.Text;
                string duur = textBox2.Text;
                string duurmin = textBox3.Text;
                string duurmax = textBox4.Text;
                string prio = textBox5.Text;
                string stap = textBox6.Text;
                string projectsoort = comboBox1.Text;

                rp.Create(naam, duur, duurmin, duurmax, prio, stap, projectsoort);
                dash.richTextBox1.AppendText("Uw projectonderdeel is succesvol aangemaakt");

                this.Hide();
            }
            catch
            {
                MessageBox.Show("Controleer gegevens...");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
