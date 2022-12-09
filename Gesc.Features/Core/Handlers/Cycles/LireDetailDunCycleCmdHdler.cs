using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using Gesc.Features.Core.Commandes.Cycles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Cycles;

namespace Gesc.Features.Core.CommandHandlers.Cycles
{
    public class LireDetailDUnCycleCmdHdler : IRequestHandler<LireDetailDUnCycleCmd, CycleDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnCycleCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<CycleDetailDto> Handle(LireDetailDUnCycleCmd request, CancellationToken cancellationToken)
        {
            var cycle = await _pointDaccess.RepertoireDeCycle.Lire(request.Id);
            var CycleDetail = _mapper.Map<CycleDetailDto>(cycle);

            return CycleDetail;
        }
    }
}
