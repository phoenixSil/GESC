﻿using Gesc.Features.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class ModifierUneFiliereCycleCmd : BaseCommand 
    {
        public Guid FiliereCycleId { get; set; }
        public FiliereCycleAModifierDto FiliereCycleAModifierDto { get; set; }
    }
}
