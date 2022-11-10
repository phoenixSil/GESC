using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Cycles;
using Gesc.Api.Features.Commandes.Cycles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Cycles;

namespace Gesc.Api.Features.CommandHandlers.Cycles
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
