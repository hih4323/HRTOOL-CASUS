using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using hrtool;

namespace HRTOOL_CASUS
{

    interface IProjectSoorten
    {
        void LaadIn();
        void Aanmaken(Soorten soorten);
        void Bewerken();
        

    }

    public abstract class ProjectSoort : IProjectSoorten
    {
        public List<Soorten> Lijst = new List<Soorten>();

        public abstract void LaadIn();
        public abstract void Aanmaken(Soorten soorten);
        public abstract void Bewerken();
        

    }

    public class RaycoProjectSoorten : ProjectSoort
    {
        Db db = new();

        public override void LaadIn()
        {
            Lijst = db.ReadDataProjectenSoortPI8(); 
        }
        public override void Aanmaken(Soorten soorten)
        {
            LaadIn();
            Lijst.Add(soorten);

            //functie wegschrijven naar db
        }

        public override void Bewerken()
        {
            throw new NotImplementedException();
        }

        public List<Soorten> Inzien()
        { 
            return Lijst;
        }


    }

    public class Soorten
    {
        public string projectsoortnaam;
        public int id;

        public Soorten(string projectsoortnaam, int id)
        {
            this.projectsoortnaam = projectsoortnaam;
            this.id = id;
        }
 
    }

}
        /*    class ProjectSoort
            {
                Db db = new();



                public void Aanmaken(string Projectnaam)
                {
                    try
                    {

                        db.AanmakenProjectSoort(Projectnaam);

                    }
                    catch
                    {
                        MessageBox.Show("Vul a.u.b. de juiste gegevens in...");
                    }
                }

                public void *//*List<string>*//* WelkeProjecten()
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }

                public void *//*List<int>*//*DoorlooptijdProjectSoort()
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }

                public void Bewerken()
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }

                public void Verwijderen()
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                }
            }*/
    
