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

namespace HRTOOL_CASUS
{
    public partial class Verwijderen : Form
    {
        /*Vanuit hier kunnen projecten worden verwijderd op basis van het gegeven ID*/

        Db db = new(); 

        private Dashboard dash;

        public Verwijderen(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;   
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*De gebruiker geeft een ID in de bij het project hoort. Deze ID wordt verwijderd uit de
             database.Als alles correct is verlopen dan wordt een verversing van de ingeplande projecten
             weergeven in de textbox.*/
            

            try
            {
                string id = textBox1.Text;
                db.DeleteWerkuren(id);
                dash.richTextBox1.Clear();
                dash.richTextBox1.AppendText("Uw ID is succesvol verwijderd:\n\n\n");
                dash.richTextBox1.AppendText("ID       HRID\t\tDATUM\t\tWEEK\t\tDAGWEEK\t\tPROJ.SOORT\t\tPROJECT\n");
                this.Hide();

                List<string> lijst = db.ReadWerkuren();

                foreach (string c in lijst)
                {
                    dash.richTextBox1.AppendText(c);
                    dash.richTextBox1.AppendText("\n");

                }

            }
            catch
            {
                MessageBox.Show("Voer ID in alsjeblieft...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
