using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Departements;
using Gesc.Api.Features.Commandes.Departements;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Departements;

namespace Gesc.Api.Features.CommandHandlers.Departements
{
    public class LireDetailDUnDepartementCmdHdler : IRequestHandler<LireDetailDUnDepartementCmd, DepartementDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnDepartementCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<DepartementDetailDto> Handle(LireDetailDUnDepartementCmd request, CancellationToken cancellationToken)
        {
            var departement = await _pointDaccess.RepertoireDeDepartement.Lire(request.Id);
            var DepartementDetail = _mapper.Map<DepartementDetailDto>(departement);

            return DepartementDetail;
        }
    }

    public class LireDetailInfoDunDepartementCmdHdler : IRequestHandler<LireDetailInfoDunDepartementCmd, DepartementDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailInfoDunDepartementCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<DepartementDetailDto> Handle(LireDetailInfoDunDepartementCmd request, CancellationToken cancellationToken)
        {
            var departement = await _pointDaccess.RepertoireDeDepartement.LireDetailDepartement(request.Id);
            var DepartementDetail = _mapper.Map<DepartementDetailDto>(departement);

            return DepartementDetail;
        }
    }
}
