using Gesc.Features.Dtos.Config.Ecole;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class AjouterUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public EcoleACreerDto EcoleAAjouterDto { get; set; }
    }
}
