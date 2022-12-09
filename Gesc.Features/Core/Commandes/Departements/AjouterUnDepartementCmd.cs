using Gesc.Features.Dtos.Config.Departements;
using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class AjouterUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public DepartementACreerDto DepartementAAjouterDto { get; set; }
    }
}
