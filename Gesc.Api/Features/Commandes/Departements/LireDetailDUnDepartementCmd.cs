using Gesc.Api.Dtos.Config.Departements;
using MediatR;
using Gesc.Api.Dtos.Departements;

namespace Gesc.Api.Features.Commandes.Departements
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
