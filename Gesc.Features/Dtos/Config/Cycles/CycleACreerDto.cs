using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Cycles
{
    public class CycleACreerDto : ICycleDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
        [Required]
        public int NbreNiveaux { get; set; }
        [Required]
        public string Cygle { get; set; }
    }
}
