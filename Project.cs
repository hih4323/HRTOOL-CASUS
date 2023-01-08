using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTOOL_CASUS
{
    interface IProjecten
    {
        void Inladen();
    }

    public abstract class Project : IProjecten
    {
        public List<Projecten> Lijst = new List<Projecten>();

        public abstract void Inladen();

    }

    public class RaycoProjecten : Project
    {
        Db db = new();

        public override void Inladen()
        {
            Lijst = db.ReadDataProjectenPI8();
        }

        public List<Projecten> Inzien()
        {
            return Lijst;
        }

        public void Bewerken(string id, string naam, string duur, string duurmin, string duurmax, string prio, string stap, string projectsoort)
        {
            db.BewerkProjectenPI8(id,naam,duur,duurmin,duurmax,prio,stap,projectsoort);
            Inladen();
        }

        public void Delete(string id)
        {
            db.DeleteProjectenPI8(id);
            Inladen();   
        }

        public void Create(string naam, string duur, string duurmin, string duurmax, string prio, string stap, string projectsoort)
        {
            db.CreateProjectenPI8(naam, duur, duurmin, duurmax, prio, stap, projectsoort);
            Inladen();
        }

    }

    public class Projecten
    {
        public int id;
        public string projectnaam;
        public int duur;
        public int duurmin;
        public int duurmax;
        public int prio;
        public int stap;
        public string projectsoort;

        public Projecten(int id, string projectnaam, int duur, int duurmin, int duurmax, int prio, int stap, string projectsoort)
        {
            this.id = id;
            this.projectnaam = projectnaam;
            this.duur = duur;
            this.duurmin = duurmin;
            this.duurmax = duurmax;
            this.prio = prio;
            this.stap = stap;
            this.projectsoort = projectsoort;
        }

    }
}
