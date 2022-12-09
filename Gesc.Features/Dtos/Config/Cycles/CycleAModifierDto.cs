using Gesc.Features.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Cycles
{
    public class CycleAModifierDto : BaseDomainDto, ICycleDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }

        [Required]
        public string Cygle { get; set; }
    }
}
