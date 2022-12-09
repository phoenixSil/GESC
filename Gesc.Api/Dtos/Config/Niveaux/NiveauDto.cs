using Gesc.Domain.Modeles.Config;
using Gesc.Domain.Modeles;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Niveaux
{
    public class NiveauDto : BaseDomainDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
    }
}
