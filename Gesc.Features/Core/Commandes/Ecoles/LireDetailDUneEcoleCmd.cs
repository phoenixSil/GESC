using Gesc.Features.Dtos.Config.Ecole;
using MediatR;
using Gesc.Features.Dtos.Ecoles;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class LireDetailDUneEcoleCmd : IRequest<EcoleDetailDto>
    {
        public Guid Id { get; set; }
    }
}
