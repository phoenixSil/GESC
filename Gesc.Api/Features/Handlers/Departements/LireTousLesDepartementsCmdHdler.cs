using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Departements;
using Gesc.Api.Features.Commandes.Departements;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Departements;

namespace Gesc.Api.Features.CommandHandlers.Departements
{
    public class LireTousLesDepartementsCmdHdler : IRequestHandler<LireTousLesDepartementsCmd, List<DepartementDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesDepartementsCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<DepartementDto>> Handle(LireTousLesDepartementsCmd request, CancellationToken cancellationToken)
        {

            var listDepartement = await _pointDaccess.RepertoireDeDepartement.Lire();

            var listDepartementDto = _mapper.Map<List<DepartementDto>>(listDepartement);

            return listDepartementDto;
        }
    }

    public class LireTousLesDepartementDuneEcoleParEcoleIdCmdHdler : IRequestHandler<LireTousLesDepartementDuneEcoleParEcoleIdCmd, List<DepartementDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesDepartementDuneEcoleParEcoleIdCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<DepartementDto>> Handle(LireTousLesDepartementDuneEcoleParEcoleIdCmd request, CancellationToken cancellationToken)
        {

            var listDepartement = (await _pointDaccess.RepertoireDeDepartement.Lire())
                                    .Where(x => x.EcoleId.CompareTo(request.EcoleId) == 0).ToList();

            var listDepartementDto = _mapper.Map<List<DepartementDto>>(listDepartement);

            return listDepartementDto;
        }
    }
}
