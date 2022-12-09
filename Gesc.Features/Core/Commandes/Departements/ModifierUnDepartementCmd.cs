using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Departements;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class ModifierUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public Guid DepartementId { get; set; }
        public DepartementAModifierDto DepartementAModifierDto { get; set; }
    }
}
