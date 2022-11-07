using Gesc.Api.Modeles;

namespace Gesc.Api.Modeles.Config
{
    public class Filiere : ConfigBaseEntite
    {
        public Guid DepartementId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual List<Cycle> Cycles { get; set; }
        public virtual List<FiliereCycle> FiliereCycles { get; set; }
    }
}
