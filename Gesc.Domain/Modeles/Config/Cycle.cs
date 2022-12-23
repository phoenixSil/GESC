using Gesc.Domain.Modeles;

namespace Gesc.Domain.Modeles.Config
{
    public class Cycle : ConfigBaseEntite
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public int NbreNiveaux { get; set; } 
        public virtual List<Filiere> Filieres { get; set; }
        public virtual List<FiliereCycle> FiliereCycles { get; set; }
    }
}
