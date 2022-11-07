using Gesc.Api.Modeles.Config;
using Gesc.Api.Modeles;
using Gesc.Api.Dtos;
using Gesc.Api.Dtos.Config.FiliereCycles;

namespace Gesc.Api.Dtos.Config.Niveaux
{
    public class NiveauDetailDto : BaseDomainDto, INiveauDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid FiliereCycleId { get; set; }
        public FiliereCycleDto FiliereCycle { get; set; }
    }
}
