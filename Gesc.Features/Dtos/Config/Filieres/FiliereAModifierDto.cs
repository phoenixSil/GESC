using Gesc.Features.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Filieres
{
    public class FiliereAModifierDto : BaseDomainDto, IFiliereDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }

        [Required]
        public string Cygle { get; set; }

        [Required]
        public Guid DepartementId { get; set; }
    }
}
