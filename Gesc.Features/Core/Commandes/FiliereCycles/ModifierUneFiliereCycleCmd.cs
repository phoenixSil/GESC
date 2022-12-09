using Gesc.Features.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class ModifierUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid FiliereCycleId { get; set; }
        public FiliereCycleAModifierDto FiliereCycleAModifierDto { get; set; }
    }
}
