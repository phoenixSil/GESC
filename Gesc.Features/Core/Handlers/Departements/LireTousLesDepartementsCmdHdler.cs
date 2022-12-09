using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Departements;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Departements;

namespace Gesc.Features.Core.CommandHandlers.Departements
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
