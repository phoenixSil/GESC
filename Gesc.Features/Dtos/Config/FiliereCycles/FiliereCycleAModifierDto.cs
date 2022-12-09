using Gesc.Features.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.FiliereCycles
{
    public class FiliereCycleAModifierDto : BaseDomainDto, IFiliereCycleDto
    {
        [Required]
        public Guid FiliereId { get; set; }

        [Required]
        public Guid CycleId { get; set; }
    }
}
