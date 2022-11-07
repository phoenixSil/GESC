using Gesc.Api.Dtos.Config.Niveaux;
using MediatR;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class LireTousLesNiveauxCmd : IRequest<List<NiveauDto>>
    {

    }
}
