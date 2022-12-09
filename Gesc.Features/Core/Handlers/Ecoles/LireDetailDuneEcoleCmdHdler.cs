using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Ecole;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
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
