using Gesc.Api.Dtos.Config.Ecole;
using MediatR;
using Gesc.Api.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Ecoles
{
    public class ModifierUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public Guid EcoleId { get; set; }
        public EcoleAModifierDto EcoleAModifierDto { get; set; }
    }
}
