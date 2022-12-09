using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.FiliereCycles;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
{
    public class LireDetailDUneFiliereCycleCmdHdler : IRequestHandler<LireDetailDUneFiliereCycleCmd, FiliereCycleDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUneFiliereCycleCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<FiliereCycleDetailDto> Handle(LireDetailDUneFiliereCycleCmd request, CancellationToken cancellationToken)
        {
            var filiereCycle = await _pointDaccess.RepertoireDeFiliereCycle.Lire(request.Id);
            var FiliereCycleDetail = _mapper.Map<FiliereCycleDetailDto>(filiereCycle);

            return FiliereCycleDetail;
        }
    }
}
