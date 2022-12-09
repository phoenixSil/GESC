using Gesc.Features.Dtos.Config.Cycles;
using MsCommun.Reponses;

namespace Gesc.Features.Services.Contrats
{
    public interface IServiceDeCycle
    {
        public Task<List<CycleDto>> LireTousLesCycles();
        public Task<ReponseDeRequette> AjouterUnCycle(CycleACreerDto cycleAAjouter);
        public Task<ReponseDeRequette> SupprimerUnCycle(Guid CycleId);
        public Task<CycleDetailDto> LireDetailDunCycle(Guid id);
        public Task<ReponseDeRequette> ModifierUnCycle(Guid cycleId, CycleAModifierDto cycleAModifierDto);
    }
}
