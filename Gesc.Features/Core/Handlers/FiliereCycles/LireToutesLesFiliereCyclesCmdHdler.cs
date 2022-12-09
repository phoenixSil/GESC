using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.FiliereCycles;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
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
