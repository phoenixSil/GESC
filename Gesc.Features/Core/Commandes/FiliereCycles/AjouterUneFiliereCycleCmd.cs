using Gesc.Features.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class AjouterUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public FiliereCycleACreerDto FiliereCycleAAjouterDto { get; set; }
    }
}
