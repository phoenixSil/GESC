using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Departements;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Departements;

namespace Gesc.Features.Core.CommandHandlers.Departements
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
