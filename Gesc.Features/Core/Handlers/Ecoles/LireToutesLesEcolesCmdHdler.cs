using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Ecole;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class LireTousLesEcolesCmdHdler : IRequestHandler<LireTousLesEcolesCmd, List<EcoleDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesEcolesCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<EcoleDto>> Handle(LireTousLesEcolesCmd request, CancellationToken cancellationToken)
        {

            var listEcole = await _pointDaccess.RepertoireDecole.Lire();

            var listEcoleDto = _mapper.Map<List<EcoleDto>>(listEcole);

            return listEcoleDto;
        }
    }
}
