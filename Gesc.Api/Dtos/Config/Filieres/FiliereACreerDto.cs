﻿using Gesc.Api.Dtos.Config.Departements;
using System.ComponentModel.DataAnnotations;

namespace Gesc.Api.Dtos.Config.Filieres
{
    public class FiliereACreerDto : IFiliereDto
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
