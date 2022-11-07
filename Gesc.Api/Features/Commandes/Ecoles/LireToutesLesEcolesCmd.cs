using Gesc.Api.Dtos.Config.Ecole;
using MediatR;
using Gesc.Api.Dtos.Ecoles;

namespace Gesc.Api.Features.Commandes.Ecoles
{
    public class LireTousLesEcolesCmd : IRequest<List<EcoleDto>>
    {

    }
}
