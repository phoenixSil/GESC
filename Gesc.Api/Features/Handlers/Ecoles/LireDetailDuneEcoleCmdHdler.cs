using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Ecoles;
using Gesc.Api.Features.Commandes.Ecoles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Ecole;

namespace Gesc.Api.Features.CommandHandlers.Ecoles
{
    public class LireDetailDUneEcoleCmdHdler : IRequestHandler<LireDetailDUneEcoleCmd, EcoleDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUneEcoleCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<EcoleDetailDto> Handle(LireDetailDUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.Id);
            var EcoleDetail = _mapper.Map<EcoleDetailDto>(ecole);

            return EcoleDetail;
        }
    }
}
