using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using Gesc.Features.Core.Commandes.Filieres;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Filieres;

namespace Gesc.Features.Core.CommandHandlers.Filieres
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
