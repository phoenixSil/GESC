using Gesc.Features.Dtos.Config.FiliereCycles;
using Gesc.Features.Dtos.Config.Filieres;
using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.Cycles
{
    public class CycleDetailDto : BaseDomainDto, ICycleDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
        public int NbreNiveaux { get; set; }
        public List<FiliereDto> Filieres { get; set; }
        public List<FiliereCycleDto> FiliereCycles { get; set; }
    }
}
