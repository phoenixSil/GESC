using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Cycles;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class ModifierUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid CycleId { get; set; }
        public CycleAModifierDto CycleAModifierDto { get; set; }
    }
}
