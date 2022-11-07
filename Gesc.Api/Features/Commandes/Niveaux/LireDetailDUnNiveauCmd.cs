using Gesc.Api.Dtos.Config.Niveaux;
using MediatR;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class LireDetailDUnNiveauCmd : IRequest<NiveauDetailDto>
    {
        public Guid Id { get; set; }
    }
}
