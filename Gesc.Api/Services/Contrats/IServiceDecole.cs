using Gesc.Api.Dtos.Config.Ecole;
using MsCommun.Reponses;

namespace Gesc.Api.Services.Contrats
{
    public interface IServiceDecole
    {
        public Task<List<EcoleDto>> LireToutesLesEcoles();
        public Task<ReponseDeRequette> AjouterUneEcole(EcoleACreerDto ecoleAAjouter);
        public Task<ReponseDeRequette> SupprimerUneEcole(Guid EcoleId);
        public Task<EcoleDetailDto> LireDetailDuneEcole(Guid id);
        public Task<ReponseDeRequette> ModifierUneEcole(Guid ecoleId, EcoleAModifierDto ecoleAModifierDto);
    }
}
