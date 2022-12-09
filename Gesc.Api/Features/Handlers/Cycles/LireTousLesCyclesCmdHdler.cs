using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Cycles;
using Gesc.Api.Features.Commandes.Cycles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Cycles;

namespace Gesc.Api.Features.CommandHandlers.Cycles
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
