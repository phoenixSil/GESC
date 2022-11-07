using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using Gesc.Api.Features.Commandes.FiliereCycles;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.FiliereCycles;

namespace Gesc.Api.Features.CommandHandlers.FiliereCycles
{
    public class LireTousLesFiliereCyclesCmdHdler : IRequestHandler<LireTousLesFiliereCyclesCmd, List<FiliereCycleDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesFiliereCyclesCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<FiliereCycleDto>> Handle(LireTousLesFiliereCyclesCmd request, CancellationToken cancellationToken)
        {

            var listFiliereCycle = await _pointDaccess.RepertoireDeFiliereCycle.Lire();

            var listFiliereCycleDto = _mapper.Map<List<FiliereCycleDto>>(listFiliereCycle);

            return listFiliereCycleDto;
        }
    }
}
