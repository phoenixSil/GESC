using Gesc.Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.FiliereCycles
{
    public class FiliereCycleAModifierDto : BaseDomainDto, IFiliereCycleDto
    {
        [Required]
        public Guid FiliereId { get; set; }

        [Required]
        public Guid CycleId { get; set; }
    }
}
