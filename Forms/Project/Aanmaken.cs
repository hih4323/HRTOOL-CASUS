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
    public partial class Aanmaken : Form
    {
        private Dashboard dash;

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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
