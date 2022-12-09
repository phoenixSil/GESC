using Gesc.Features.Dtos.Config.Ecole;
using MediatR;
using Gesc.Features.Dtos.Ecoles;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class LireTousLesEcolesCmd : IRequest<List<EcoleDto>>
    {

    }
}
