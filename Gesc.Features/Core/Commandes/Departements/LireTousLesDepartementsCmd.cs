using Gesc.Features.Dtos.Config.Departements;
using MediatR;
using Gesc.Features.Dtos.Departements;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class LireTousLesDepartementsCmd : IRequest<List<DepartementDto>>
    {

    }
    public class LireTousLesDepartementDuneEcoleParEcoleIdCmd : IRequest<List<DepartementDto>>
    {
        public Guid EcoleId { get; set; }
    }

}
