using Gesc.Api.Dtos.Config.Filieres;
using MediatR;
using Gesc.Api.Dtos.Filieres;

namespace Gesc.Api.Features.Commandes.Filieres
{
    public class LireDetailDUneFiliereCmd : IRequest<FiliereDetailDto>
    {
        public Guid Id { get; set; }
    }
}
