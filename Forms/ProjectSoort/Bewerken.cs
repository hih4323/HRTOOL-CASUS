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
    public partial class Bewerken : Form
    {
        private Dashboard dash;

        public Bewerken(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;
        }
    }
}
