using Gesc.Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.Cycles
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
