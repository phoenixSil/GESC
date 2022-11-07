using Gesc.Api.Modeles.Config;
using Gesc.Api.Modeles;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Niveaux
{
    public class NiveauDto : BaseDomainDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public bool Complete { get; set; }
    }
}
