using Gesc.Api.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.FiliereCycles
{
    public class AjouterUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public FiliereCycleACreerDto FiliereCycleAAjouterDto { get; set; }
    }
}
