using Gesc.Domain.Modeles;

namespace Gesc.Domain.Modeles.Config
{
    public class Departement : ConfigBaseEntite
    {
        public Guid EcoleId { get; set; }
        public virtual Ecole Ecole { get; set; }
        public virtual List<Filiere> Filieres { get; set; }
    }
}
