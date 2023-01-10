using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using hrtool;
using HRTOOL_CASUS;

namespace HRTOOL_CASUS
{

    interface IProjectSoorten
    {
        void LaadIn();
    }

    public abstract class ProjectSoort : IProjectSoorten
    {
        public List<Soorten> Lijst = new List<Soorten>();
        public abstract void LaadIn();
    }

    public class RaycoProjectSoorten : ProjectSoort
    {
        Db db = new();

        public override void LaadIn()
        {
            Lijst = db.ReadDataProjectenSoortPI8();
        }

        public List<Soorten> Inzien()
        {
            return Lijst;
        }

        public void Bewerken(string id, string naam)
        {
            db.BewerkProjectensoortPI8(naam, id);
            LaadIn();
        }

        public void Delete(string id)
        {
            db.DeleteProjectensoortPI8(id);
            LaadIn();
        }

        public void Create(string naam)
        {
            db.CreateProjectenSoortPI8(naam);
            LaadIn();
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