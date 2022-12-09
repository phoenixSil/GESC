using Gesc.Features.Dtos.Config.Niveaux;
using MediatR;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class LireDetailDUnNiveauCmd : IRequest<NiveauDetailDto>
    {
        public Guid Id { get; set; }
    }
}
