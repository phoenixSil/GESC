using Gesc.Api.Dtos.Config.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Api.Services.Contrats
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
