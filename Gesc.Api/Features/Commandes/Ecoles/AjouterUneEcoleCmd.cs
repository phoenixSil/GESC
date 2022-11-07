using Gesc.Api.Dtos.Config.Ecole;
using MediatR;
using Gesc.Api.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Ecoles
{
    public class AjouterUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public EcoleACreerDto EcoleAAjouterDto { get; set; }
    }
}
