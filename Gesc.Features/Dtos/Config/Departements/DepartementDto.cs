using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.Departements
{
    public class DepartementDto : BaseDomainDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
    }
}
