using Gesc.Api.Dtos.Config.Cycles;
using MediatR;
using Gesc.Api.Dtos.Cycles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Cycles
{
    public class AjouterUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public CycleACreerDto CycleAAjouterDto { get; set; }
    }
}
