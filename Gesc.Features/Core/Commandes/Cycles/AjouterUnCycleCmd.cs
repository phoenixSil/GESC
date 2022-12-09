using Gesc.Features.Dtos.Config.Cycles;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class AjouterUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public CycleACreerDto CycleAAjouterDto { get; set; }
    }
}
