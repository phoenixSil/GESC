using Gesc.Api.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.Filieres
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
