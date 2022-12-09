using Gesc.Domain.Modeles.Config;

namespace Gesc.Features.Dtos.Config.FiliereCycles
{
    public interface IFiliereCycleDto
    {
        public Guid FiliereId { get; set; }
        public Guid CycleId { get; set; }
    }
}
