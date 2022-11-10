using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.Niveaux
{
    public class NiveauACreerDto : INiveauDto
    {
        [Required]
        public int ValeurCycle { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public Guid FiliereCycleId { get; set; }
        public bool Complete { get; set; } = false;
    }
}
