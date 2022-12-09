using Gesc.Domain.Modeles.Config;
using Gesc.Domain.Modeles;
using Gesc.Features.Dtos;
using Gesc.Features.Dtos.Config.FiliereCycles;

namespace Gesc.Features.Dtos.Config.Niveaux
{
    public class NiveauDetailDto : BaseDomainDto, INiveauDto
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid FiliereCycleId { get; set; }
        public FiliereCycleDto FiliereCycle { get; set; }
    }
}
