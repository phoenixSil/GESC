using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using Gesc.Features.Core.Commandes.Cycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Cycles;

namespace Gesc.Features.Core.CommandHandlers.Cycles
{
    public class LireTousLesCyclesCmdHdler : IRequestHandler<LireTousLesCyclesCmd, List<CycleDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesCyclesCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<CycleDto>> Handle(LireTousLesCyclesCmd request, CancellationToken cancellationToken)
        {

            var listCycle = await _pointDaccess.RepertoireDeCycle.Lire();

            var listCycleDto = _mapper.Map<List<CycleDto>>(listCycle);

            return listCycleDto;
        }
    }
}
