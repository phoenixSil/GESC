using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Domain.Modeles.Config;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Departements
{
    public class DepartementDetailDto : BaseDomainDto, IDepartementDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
        public Guid EcoleId { get; set; }
        public virtual EcoleDto Ecole { get; set; }
        public virtual List<FiliereDto> Filieres { get; set; }
    }
}
