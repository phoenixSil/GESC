using Gesc.Features.Dtos.Config.Cycles;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class AjouterUnCycleCmd : BaseCommand
    {
        public CycleACreerDto CycleAAjouterDto { get; set; }
    }
}
