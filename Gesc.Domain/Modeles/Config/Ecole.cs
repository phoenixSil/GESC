using Gesc.Domain.Modeles;

namespace Gesc.Domain.Modeles.Config
{
    public class Ecole : ConfigBaseEntite
    {
        public string Specialite { get; set; }
        public virtual List<Departement> Departements { get; set; }
    }
}
