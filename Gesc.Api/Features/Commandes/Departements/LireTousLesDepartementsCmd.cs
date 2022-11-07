using Gesc.Api.Dtos.Config.Departements;
using MediatR;
using Gesc.Api.Dtos.Departements;

namespace Gesc.Api.Features.Commandes.Departements
{
    public class LireTousLesDepartementsCmd : IRequest<List<DepartementDto>>
    {

    }
    public class LireTousLesDepartementDuneEcoleParEcoleIdCmd : IRequest<List<DepartementDto>>
    {
        public Guid EcoleId { get; set; }
    }

}
