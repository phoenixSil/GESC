using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Ecole
{
    public class EcoleACreerDto : IEcoleDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }

        [Required]
        public string Cygle { get; set; }

        [Required]
        public string Specialite { get; set; }
    }
}
