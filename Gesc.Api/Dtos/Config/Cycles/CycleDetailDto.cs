using Gesc.Api.Dtos.Config.FiliereCycles;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Cycles
{
    public class CycleDetailDto : BaseDomainDto, ICycleDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
        public List<FiliereDto> Filieres { get; set; }
        public List<FiliereCycleDto> FiliereCycles { get; set; }
    }
}
