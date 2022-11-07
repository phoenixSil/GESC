using Gesc.Api.Dtos.Config.Departements;
using MediatR;
using Gesc.Api.Dtos.Departements;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Departements
{
    public class AjouterUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public DepartementACreerDto DepartementAAjouterDto { get; set; }
    }
}
