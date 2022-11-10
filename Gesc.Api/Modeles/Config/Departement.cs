using Gesc.Api.Modeles;

namespace Gesc.Api.Modeles.Config
{
    public class Departement : ConfigBaseEntite
    {
        public Guid EcoleId { get; set; }
        public virtual Ecole Ecole { get; set; }
        public virtual List<Filiere> Filieres { get; set; }
    }
}
