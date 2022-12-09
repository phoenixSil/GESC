using Gesc.Domain.Modeles;

namespace Gesc.Domain.Modeles.Config
{
    public class Filiere : ConfigBaseEntite
    {
        public Guid DepartementId { get; set; }
        public virtual Departement Departement { get; set; }
        public virtual List<Cycle> Cycles { get; set; }
        public virtual List<FiliereCycle> FiliereCycles { get; set; }
    }
}
