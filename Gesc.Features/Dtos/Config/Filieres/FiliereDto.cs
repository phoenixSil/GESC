﻿using Gesc.Domain.Modeles.Config;

namespace Gesc.Features.Dtos.Config.Filieres
{
    public class FiliereDto : BaseDomainDto, IFiliereDto
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Cygle { get; set; }
    }
}
