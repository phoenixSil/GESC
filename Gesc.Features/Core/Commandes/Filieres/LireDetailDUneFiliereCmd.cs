using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class LireDetailDUneFiliereCmd : IRequest<FiliereDetailDto>
    {
        public Guid Id { get; set; }
    }
}
