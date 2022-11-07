using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using Gesc.Api.Features.Commandes.FiliereCycles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.FiliereCycles;

namespace Gesc.Api.Features.CommandHandlers.FiliereCycles
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
