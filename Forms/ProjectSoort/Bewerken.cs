﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HRTOOL_CASUS.Forms.ProjectSoort
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

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //textbox projectnaam
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textbox id 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //inladen knop

            RaycoProjectSoorten projs = new RaycoProjectSoorten();
            projs.LaadIn();
            List<Soorten> projectensoort = projs.Inzien();

            foreach (Soorten p in projectensoort)
            {
                if (textBox1.Text == Convert.ToString(p.id))
                {
                    textBox2.Clear();
                    textBox2.Text += p.projectsoortnaam;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Verwijderen via database
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //aanpassen via database
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
