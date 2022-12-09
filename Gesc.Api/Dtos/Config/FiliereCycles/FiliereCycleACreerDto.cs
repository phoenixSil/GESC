using Gesc.Domain.Modeles.Config;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.FiliereCycles
{
    public class FiliereCycleACreerDto : IFiliereCycleDto
    {
        [Required]
        public Guid FiliereId { get; set; }

        [Required]
        public Guid CycleId { get; set; }
    }
}
