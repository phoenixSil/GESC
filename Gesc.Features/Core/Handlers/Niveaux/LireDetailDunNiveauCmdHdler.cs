using AutoMapper;
using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Features.Dtos.Config.Niveaux;
using Gesc.Features.Contrats.Repertoires;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class LireDetailDUnNiveauCmdHdler : IRequestHandler<LireDetailDUnNiveauCmd, NiveauDetailDto>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public LireDetailDUnNiveauCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }

        public async Task<NiveauDetailDto> Handle(LireDetailDUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var niveau = await _pointDaccess.RepertoireDeNiveau.LireDetail(request.Id);
            var NiveauDetail = _mapper.Map<NiveauDetailDto>(niveau);

            return NiveauDetail;
        }
    }
}
