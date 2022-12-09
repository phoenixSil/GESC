using Gesc.Features.Dtos.Config.Cycles;
using Gesc.Features.Dtos.Config.Departements;
using Gesc.Features.Dtos.Config.FiliereCycles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.Filieres
{
    public class FiliereDetailDto : BaseDomainDto, IFiliereDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
        public Guid DepartementId { get; set; }
        public DepartementDto Departement { get; set; }
        public List<CycleDto> Cycles { get; set; }
        public List<FiliereCycleDto> FiliereCycles { get; set; }
    }
}
