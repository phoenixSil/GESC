using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Cycles
{
    public class CycleDto : BaseDomainDto, ICycleDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }

    }
}
