using Gesc.Features.Dtos.Config.Niveaux;
using MediatR;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class LireTousLesNiveauxCmd : IRequest<List<NiveauDto>>
    {

    }
}
