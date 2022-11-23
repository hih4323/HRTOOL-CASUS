using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrtool.HRModel
{
    /*Een eigen class voor het opvragen van de beschikbaarheid*/

    internal class Availability
    {
        public IList<int>? availability { get; set; }
        public string? name { get; set; }
    }
}