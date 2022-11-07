using MediatR;
using Gesc.Api.Dtos.Departements;
using MsCommun.Reponses;
using Gesc.Api.Dtos.Config.Departements;

namespace Gesc.Api.Features.Commandes.Departements
{
    public class ModifierUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public Guid DepartementId { get; set; }
        public DepartementAModifierDto DepartementAModifierDto { get; set; }
    }
}
