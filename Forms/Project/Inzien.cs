using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRTOOL_CASUS.Forms.Project
{
    public partial class Inzien : Form
    {
        private Dashboard dash;

        public Inzien(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;

            Load += new EventHandler(Inzien_load);
        }

        private void Inzien_load(object sender, EventArgs e)
        {

            RaycoProjectSoorten ps = new RaycoProjectSoorten();
            ps.LaadIn();
            List<Soorten> projectsoorten = ps.Inzien();

            foreach (var i in projectsoorten)
            {
                comboBox1.Items.Add(i.projectsoortnaam);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dash.richTextBox1.Clear();

            RaycoProjecten proj = new RaycoProjecten();
            proj.Inladen();
            List<Projecten> projecten = proj.Inzien();

            string? vergelijking = comboBox1.SelectedItem.ToString();

            dash.richTextBox1.AppendText("ID\tTIJD\tTIJDMIN\tTIJDMAX\tPRIO\tSTAP\t\tSOORT\t\tNAAM\n\n");

            foreach (var i in projecten)
            {
                if (vergelijking == i.projectsoort)
                {
                    dash.richTextBox1.AppendText(Convert.ToString(i.id));
                    dash.richTextBox1.AppendText("\t");
                    dash.richTextBox1.AppendText(Convert.ToString(i.duur));
                    dash.richTextBox1.AppendText("\t");
                    dash.richTextBox1.AppendText(Convert.ToString(i.duurmin));
                    dash.richTextBox1.AppendText("\t\t");
                    dash.richTextBox1.AppendText(Convert.ToString(i.duurmax));
                    dash.richTextBox1.AppendText("\t\t");
                    dash.richTextBox1.AppendText(Convert.ToString(i.prio));
                    dash.richTextBox1.AppendText("\t");
                    dash.richTextBox1.AppendText(Convert.ToString(i.stap));
                    dash.richTextBox1.AppendText("\t\t");
                    dash.richTextBox1.AppendText(i.projectsoort);
                    dash.richTextBox1.AppendText("\t");
                    dash.richTextBox1.AppendText(i.projectnaam);
                    dash.richTextBox1.AppendText("\n");
                }
            }

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
