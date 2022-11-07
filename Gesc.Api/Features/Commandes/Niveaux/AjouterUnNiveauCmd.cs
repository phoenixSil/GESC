using Gesc.Api.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public NiveauACreerDto NiveauAAjouterDto { get; set; }
    }
}
