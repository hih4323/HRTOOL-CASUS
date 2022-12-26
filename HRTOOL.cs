using HRTOOL_CASUS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hrtool
{

    class Program
    {
        /*Het hoofdprogramma van de HR Tool voor Rayco. Vanuit hier wordt het eerste vanster gestart (inloggen)
         
         Er kan worden ingelogd met':

            gebruiker:  ww:     admin:
            Bryan       1234    ja
            Ivo         1234    nee
        
            Veel succes!

         */

        public static void Main()
        {
            Dashboard dash = new Dashboard();
            Application.Run(dash);

            /*            Inloggen inlog = new Inloggen();
                        Application.Run(inlog);*/

        }
    }
}