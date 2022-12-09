using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.FiliereCycles
{
    public class FiliereCycleDto : BaseDomainDto
    {
        public Guid FiliereId { get; set; }
        public Guid CycleId { get; set; }
    }
}
