using Gesc.Api.Dtos.Config.Filieres;
using MsCommun.Reponses;

namespace Gesc.Api.Services.Contrats
{
    public interface IServiceDeFiliere
    {
        public Task<List<FiliereDto>> LireToutesLesFilieres();
        public Task<ReponseDeRequette> AjouterUneFiliere(FiliereACreerDto filiereAAjouter);
        public Task<ReponseDeRequette> SupprimerUneFiliere(Guid FiliereId);
        public Task<FiliereDetailDto> LireDetailDuneFiliere(Guid id);
        public Task<ReponseDeRequette> ModifierUneFiliere(Guid filiereId, FiliereAModifierDto filiereAModifierDto);
    }
}
