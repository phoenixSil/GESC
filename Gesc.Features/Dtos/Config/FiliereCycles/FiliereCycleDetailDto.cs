using Gesc.Features.Dtos.Config.Cycles;
using Gesc.Features.Dtos.Config.Filieres;
using Gesc.Features.Dtos.Config.Niveaux;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.FiliereCycles
{
    public class FiliereCycleDetailDto : BaseDomainDto, IFiliereCycleDto
    {
        public Guid FiliereId { get; set; }
        public FiliereDto Filiere { get; set; }
        public Guid CycleId { get; set; }
        public CycleDto Cycle { get; set; }
        public List<NiveauDto> Niveaux { get; set; }
    }
}
