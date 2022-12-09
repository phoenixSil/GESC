using Gesc.Features.Dtos.Config.Cycles;
using MediatR;
using Gesc.Features.Dtos.Cycles;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class LireTousLesCyclesCmd : IRequest<List<CycleDto>>
    {

    }
}
