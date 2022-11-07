using Gesc.Api.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.FiliereCycles
{
    public class ModifierUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid FiliereCycleId { get; set; }
        public FiliereCycleAModifierDto FiliereCycleAModifierDto { get; set; }
    }
}
