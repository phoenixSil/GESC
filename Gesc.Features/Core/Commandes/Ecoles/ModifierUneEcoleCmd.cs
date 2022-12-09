using Gesc.Features.Dtos.Config.Ecole;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class ModifierUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public Guid EcoleId { get; set; }
        public EcoleAModifierDto EcoleAModifierDto { get; set; }
    }
}
