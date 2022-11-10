using MediatR;
using Gesc.Api.Dtos.Cycles;
using MsCommun.Reponses;
using Gesc.Api.Dtos.Config.Cycles;

namespace Gesc.Api.Features.Commandes.Cycles
{
    public class ModifierUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid CycleId { get; set; }
        public CycleAModifierDto CycleAModifierDto { get; set; }
    }
}
