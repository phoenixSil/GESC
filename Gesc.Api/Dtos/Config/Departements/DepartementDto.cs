using Gesc.Api.Modeles.Config;
using Gesc.Api.Dtos;

namespace Gesc.Api.Dtos.Config.Departements
{
    public class DepartementDto : BaseDomainDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
    }
}
