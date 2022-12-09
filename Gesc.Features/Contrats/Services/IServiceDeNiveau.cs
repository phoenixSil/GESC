using Gesc.Features.Dtos.Config.Niveaux;
using MsCommun.Reponses;

namespace Gesc.Features.Services.Contrats
{
    public interface IServiceDeNiveau
    {
        public Task<List<NiveauDto>> LireTousLesNiveaus();
        public Task<ReponseDeRequette> AjouterUnNiveau(NiveauACreerDto niveauAAjouter);
        public Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId);
        public Task<NiveauDetailDto> LireDetailDunNiveau(Guid id);
        public Task<ReponseDeRequette> ModifierUnNiveau(Guid niveauId, NiveauAModifierDto niveauAModifierDto);
    }
}
