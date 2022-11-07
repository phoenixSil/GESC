using Gesc.Api.Dtos.Config.Filieres;
using MediatR;
using Gesc.Api.Dtos.Filieres;

namespace Gesc.Api.Features.Commandes.Filieres
{
    public class LireTousLesFilieresCmd : IRequest<List<FiliereDto>>
    {

    }
}
