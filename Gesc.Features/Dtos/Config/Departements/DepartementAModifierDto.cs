﻿using Gesc.Features.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Features.Dtos.Config.Departements
{
    public class DepartementAModifierDto : BaseDomainDto, IDepartementDto
    {
        [Required]
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }

        [Required]
        public Guid EcoleId { get; set; }
    }
}
