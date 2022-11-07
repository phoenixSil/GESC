﻿using Gesc.Api.Modeles.Config;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.Departements
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
