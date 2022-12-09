using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Cycles;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class ModifierUnCycleCmd : BaseCommand 
    { 
        public Guid CycleId { get; set; }
        public CycleAModifierDto CycleAModifierDto { get; set; }
    }
}
