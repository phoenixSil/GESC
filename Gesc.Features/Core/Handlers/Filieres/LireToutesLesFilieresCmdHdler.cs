using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using Gesc.Features.Core.Commandes.Filieres;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Filieres;

namespace Gesc.Features.Core.CommandHandlers.Filieres
{
    public class LireTousLesFilieresCmdHdler : IRequestHandler<LireTousLesFilieresCmd, List<FiliereDto>>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireTousLesFilieresCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<List<FiliereDto>> Handle(LireTousLesFilieresCmd request, CancellationToken cancellationToken)
        {

            var listFiliere = await _pointDaccess.RepertoireDeFiliere.Lire();

            var listFiliereDto = _mapper.Map<List<FiliereDto>>(listFiliere);

            return listFiliereDto;
        }
    }
}
