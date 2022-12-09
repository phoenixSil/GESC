using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class LireTousLesFilieresCmd : IRequest<List<FiliereDto>>
    {

    }
}
