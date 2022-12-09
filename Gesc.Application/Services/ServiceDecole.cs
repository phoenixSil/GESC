using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Dtos.Config.Ecole;
using Gesc.Features.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDecole : IServiceDecole
    {
        private readonly IMediator _mediator;
        public ServiceDecole(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUneEcole(EcoleACreerDto ecoleAAjouter)
        {
            var resultatAjoutEcole = await _mediator.Send(new AjouterUneEcoleCmd { EcoleAAjouterDto = ecoleAAjouter });
            return resultatAjoutEcole;
        }

        public async Task<EcoleDetailDto> LireDetailDuneEcole(Guid id)
        {
            var ecole = await _mediator.Send(new LireDetailDUneEcoleCmd { Id = id });
            return ecole;
        }

        public async Task<List<EcoleDto>> LireToutesLesEcoles()
        {
            var listEcole = await _mediator.Send(new LireTousLesEcolesCmd { });
            return listEcole;
        }

        public async Task<ReponseDeRequette> SupprimerUneEcole(Guid EcoleId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUneEcoleCmd { Id = EcoleId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUneEcole(Guid ecoleId, EcoleAModifierDto ecoleAModifier)
        {

            var resultatEcoleAModifier = await _mediator.Send(new ModifierUneEcoleCmd { EcoleAModifierDto = ecoleAModifier });
            return resultatEcoleAModifier;
        }
    }
}