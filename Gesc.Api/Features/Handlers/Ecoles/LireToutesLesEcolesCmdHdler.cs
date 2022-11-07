using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Ecoles;
using Gesc.Api.Features.Commandes.Ecoles;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Ecole;

namespace Gesc.Api.Features.CommandHandlers.Ecoles
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
