using Gesc.Features.Dtos.Config.Departements;
using MediatR;
using Gesc.Features.Dtos.Departements;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class LireDetailDUnDepartementCmd : IRequest<DepartementDetailDto>
    {
        public Guid Id { get; set; }
    }

    public class LireDetailInfoDunDepartementCmd : IRequest<DepartementDetailDto>
    {
        public Guid Id { get; set; }
    }
}
