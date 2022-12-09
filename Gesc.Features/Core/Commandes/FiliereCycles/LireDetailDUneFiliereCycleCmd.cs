using Gesc.Features.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class LireDetailDUneFiliereCycleCmd : IRequest<FiliereCycleDetailDto>
    {
        public Guid Id { get; set; }
    }
}
