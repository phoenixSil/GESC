using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Features.Commandes.Cycles;
using Gesc.Api.Services.Contrats;
using Gesc.Api.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDeCycle : IServiceDeCycle
    {
        private readonly IMediator _mediator;
        public ServiceDeCycle(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnCycle(CycleACreerDto cycleAAjouter)
        {
            var resultatAjoutCycle = await _mediator.Send(new AjouterUnCycleCmd { CycleAAjouterDto = cycleAAjouter });
            return resultatAjoutCycle;
        }

        public async Task<CycleDetailDto> LireDetailDunCycle(Guid id)
        {
            var cycle = await _mediator.Send(new LireDetailDUnCycleCmd { Id = id });
            return cycle;
        }

        public async Task<List<CycleDto>> LireTousLesCycles()
        {
            var listCycle = await _mediator.Send(new LireTousLesCyclesCmd { });
            return listCycle;
        }

        public async Task<ReponseDeRequette> SupprimerUnCycle(Guid CycleId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnCycleCmd { Id = CycleId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnCycle(Guid cycleId, CycleAModifierDto cycleAModifier)
        {

            var resultatCycleAModifier = await _mediator.Send(new ModifierUnCycleCmd { CycleAModifierDto = cycleAModifier });
            return resultatCycleAModifier;
        }
    }
}