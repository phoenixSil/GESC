using Gesc.Api.Modeles;

namespace Gesc.Api.Modeles.Config
{
    public class Cycle : ConfigBaseEntite
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public virtual List<Filiere> Filieres { get; set; }
        public virtual List<FiliereCycle> FiliereCycles { get; set; }
    }
}
