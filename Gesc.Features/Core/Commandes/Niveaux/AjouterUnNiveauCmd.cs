using Gesc.Features.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public NiveauACreerDto NiveauAAjouterDto { get; set; }
    }
}
