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
    public partial class Inzien : Form
    {
        private Dashboard dash;

        public Inzien(Dashboard dash)
        {
            InitializeComponent();
            this.dash = dash;
        }
    }
}
