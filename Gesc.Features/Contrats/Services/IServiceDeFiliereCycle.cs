using Gesc.Features.Dtos.Config.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Features.Services.Contrats
{
    public interface IServiceDeFiliereCycle
    {
        public Task<List<FiliereCycleDto>> LireToutesLesFiliereCycles();
        public Task<ReponseDeRequette> AjouterUneFiliereCycle(FiliereCycleACreerDto filiereCycleAAjouter);
        public Task<ReponseDeRequette> SupprimerUneFiliereCycle(Guid FiliereCycleId);
        public Task<FiliereCycleDetailDto> LireDetailDuneFiliereCycle(Guid id);
        public Task<ReponseDeRequette> ModifierUneFiliereCycle(Guid filiereCycleId, FiliereCycleAModifierDto filiereCycleAModifierDto);
    }
}
