using Gesc.Features.Dtos;

namespace Gesc.Features.Dtos.Config.Ecole
{
    public class EcoleDto : BaseDomainDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
        public string Specialite { get; set; }
    }
}
