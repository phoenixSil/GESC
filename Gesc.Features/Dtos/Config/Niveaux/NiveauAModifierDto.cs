using Gesc.Features.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Niveaux
{
    public class NiveauAModifierDto : BaseDomainDto, INiveauDto
    {
        [Required]
        public int ValeurCycle { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public Guid FiliereCycleId { get; set; }
    }
}
