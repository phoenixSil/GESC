using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Filieres;
using Gesc.Api.Features.Commandes.Filieres;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Dtos.Config.Filieres;

namespace Gesc.Api.Features.CommandHandlers.Filieres
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
