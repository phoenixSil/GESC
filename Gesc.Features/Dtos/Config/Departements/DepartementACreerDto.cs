using Gesc.Domain.Modeles.Config;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Departements
{
    public class DepartementACreerDto : IDepartementDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }

        [Required]
        public Guid EcoleId { get; set; }
    }
}
