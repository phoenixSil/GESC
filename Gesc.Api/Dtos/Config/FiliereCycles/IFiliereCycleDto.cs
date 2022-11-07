using Gesc.Api.Modeles.Config;

namespace Gesc.Api.Dtos.Config.FiliereCycles
{
    public interface IFiliereCycleDto
    {
        public Guid FiliereId { get; set; }
        public Guid CycleId { get; set; }
    }
}
