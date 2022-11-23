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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Windows.Input;

namespace HRTOOL_CASUS
{
    public partial class Inloggen : Form
    {
        Db db = new();

        public Inloggen()
        {
            InitializeComponent();
        }


        private void FormInloggen_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Gebruikersnaam_Click(object sender, EventArgs e)
        {

        }

        private void Wachtwoord_Click(object sender, EventArgs e)
        {

        }

        private void InvoerGebruikersnaam_TextChanged(object sender, EventArgs e)
        {

        }

        private void InvoerWachtwoord_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string InvoerGebruiker = InvoerGebruikersnaam.Text;
            string InvoerWW = InvoerWachtwoord.Text;

            bool inlog = db.Login(InvoerGebruiker, InvoerWW);

            if (inlog == true)
            {
                Dashboard dash = new Dashboard();

                this.Hide();
                dash.Show();

            }
            else
            {
                MessageBox.Show("Voer de juiste gegevens in!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Inloggen_Load(object sender, EventArgs e)
        {

        }
    }
}
