using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.FiliereCycles
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
