using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRTOOL_CASUS.Forms.Project
{
    public partial class Bewerken : Form
    {
        private Dashboard dash;

        public Bewerken(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;

            Load += new EventHandler(Bewerken_load);
        }

        private void Bewerken_load(object sender, EventArgs e)
        {
            RaycoProjectSoorten projs = new RaycoProjectSoorten();
            projs.LaadIn();
            List<Soorten> projectensoort = projs.Inzien();

            foreach (Soorten p in projectensoort)
            {
                comboBox1.Items.Add(p.projectsoortnaam);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //opvragen

            RaycoProjecten proj = new RaycoProjecten();
            proj.Inladen();
            List<Projecten> projecten = proj.Inzien();


            foreach (Projecten i in projecten)
            {
                if (textBox1.Text == Convert.ToString(i.id))
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox1.ResetText();
                    textBox7.Clear();

                    textBox2.Text += Convert.ToString(i.duur);
                    textBox3.Text += Convert.ToString(i.duurmin);
                    textBox4.Text += Convert.ToString(i.duurmax);
                    textBox5.Text += Convert.ToString(i.prio);
                    textBox6.Text += Convert.ToString(i.stap);
                    comboBox1.Text += i.projectsoort;
                    textBox7.Text += i.projectnaam;

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //id
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //duur
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //duurmin
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //duurmax
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //prio
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //stap
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //projectsoort
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //projectnaam
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aanpassen
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Verwijderen
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
