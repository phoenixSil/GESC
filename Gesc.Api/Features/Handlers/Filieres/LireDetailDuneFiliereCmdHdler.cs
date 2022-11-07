using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Filieres;
using Gesc.Api.Features.Commandes.Filieres;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Filieres;

namespace Gesc.Api.Features.CommandHandlers.Filieres
{
    public class LireDetailDUneFiliereCmdHdler : IRequestHandler<LireDetailDUneFiliereCmd, FiliereDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUneFiliereCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<FiliereDetailDto> Handle(LireDetailDUneFiliereCmd request, CancellationToken cancellationToken)
        {
            var filiere = await _pointDaccess.RepertoireDeFiliere.Lire(request.Id);
            var FiliereDetail = _mapper.Map<FiliereDetailDto>(filiere);

            return FiliereDetail;
        }
    }
}
