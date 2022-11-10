using Gesc.Api.Modeles.Config;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.FiliereCycles
{
    public class FiliereCycleDto : BaseDomainDto
    {
        public Guid FiliereId { get; set; }
        public Guid CycleId { get; set; }
    }
}
