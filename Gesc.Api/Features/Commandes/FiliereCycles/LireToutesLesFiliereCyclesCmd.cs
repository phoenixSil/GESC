using Gesc.Api.Dtos.Config.FiliereCycles;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;

namespace Gesc.Api.Features.Commandes.FiliereCycles
{
    public class LireTousLesFiliereCyclesCmd : IRequest<List<FiliereCycleDto>>
    {

    }
}
