using Gesc.Api.Dtos.Config.Filieres;
using MediatR;
using Gesc.Api.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Filieres
{
    public class AjouterUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public FiliereACreerDto FiliereAAjouterDto { get; set; }
    }
}
