using Gesc.Features.Dtos.Config.Departements;
using MsCommun.Reponses;

namespace Gesc.Features.Services.Contrats
{
    public interface IServiceDeDepartement
    {
        public Task<List<DepartementDto>> LireTousLesDepartements();
        public Task<ReponseDeRequette> AjouterUnDepartement(DepartementACreerDto departementAAjouter);
        public Task<ReponseDeRequette> SupprimerUnDepartement(Guid DepartementId);
        public Task<DepartementDetailDto> LireDetailDunDepartement(Guid id);
        public Task<ReponseDeRequette> ModifierUnDepartement(Guid departementId, DepartementAModifierDto departementAModifierDto);
        public Task<List<DepartementDto>> LireTousLesDepartementDuneEcoleParEcoleId(Guid ecoleId);
        public Task<DepartementDetailDto> LireDetailInfoDunDepartement(Guid id);
    }
}
