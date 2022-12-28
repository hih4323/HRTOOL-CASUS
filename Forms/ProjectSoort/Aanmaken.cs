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
    }
}
