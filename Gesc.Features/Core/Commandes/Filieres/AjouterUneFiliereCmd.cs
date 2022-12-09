using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class AjouterUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public FiliereACreerDto FiliereAAjouterDto { get; set; }
    }
}
