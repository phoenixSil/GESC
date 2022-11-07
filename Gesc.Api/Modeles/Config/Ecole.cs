using Gesc.Api.Modeles;

namespace Gesc.Api.Modeles.Config
{
    public class Ecole : ConfigBaseEntite
    {
        public string Specialite { get; set; }
        public virtual List<Departement> Departements { get; set; }
    }
}
