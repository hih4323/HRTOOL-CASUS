using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRTOOL_CASUS.Forms.ProjectSoort
{
    public partial class Aanmaken : Form
    {
        private Dashboard dash;
        public Aanmaken(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RaycoProjectSoorten ps = new RaycoProjectSoorten();
                string projectsoortnaam = textBox1.Text;
                ps.Create(projectsoortnaam);
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Controleer gegevens...");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
