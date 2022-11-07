using Gesc.Api.Dtos.Config.Cycles;
using MediatR;
using Gesc.Api.Dtos.Cycles;

namespace Gesc.Api.Features.Commandes.Cycles
{
    public class LireDetailDUnCycleCmd : IRequest<CycleDetailDto>
    {
        public Guid Id { get; set; }
    }
}
