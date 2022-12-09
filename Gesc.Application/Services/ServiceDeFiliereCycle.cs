using Gesc.Features.Dtos.Config.FiliereCycles;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Features.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDeFiliereCycle : IServiceDeFiliereCycle
    {
        private readonly IMediator _mediator;
        public ServiceDeFiliereCycle(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUneFiliereCycle(FiliereCycleACreerDto filiereCycleAAjouter)
        {
            var resultatAjoutFiliereCycle = await _mediator.Send(new AjouterUneFiliereCycleCmd { FiliereCycleAAjouterDto = filiereCycleAAjouter });
            return resultatAjoutFiliereCycle;
        }

        public async Task<FiliereCycleDetailDto> LireDetailDuneFiliereCycle(Guid id)
        {
            var filiereCycle = await _mediator.Send(new LireDetailDUneFiliereCycleCmd { Id = id });
            return filiereCycle;
        }

        public async Task<List<FiliereCycleDto>> LireToutesLesFiliereCycles()
        {
            var listFiliereCycle = await _mediator.Send(new LireTousLesFiliereCyclesCmd { });
            return listFiliereCycle;
        }

        public async Task<ReponseDeRequette> SupprimerUneFiliereCycle(Guid FiliereCycleId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUneFiliereCycleCmd { Id = FiliereCycleId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUneFiliereCycle(Guid filiereCycleId, FiliereCycleAModifierDto filiereCycleAModifier)
        {

            var resultatFiliereCycleAModifier = await _mediator.Send(new ModifierUneFiliereCycleCmd { FiliereCycleAModifierDto = filiereCycleAModifier });
            return resultatFiliereCycleAModifier;
        }
    }
}
