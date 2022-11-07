using Gesc.Api.Dtos.Config.Departements;
using Microsoft.AspNetCore.Mvc;
using MsCommun.Reponses;

namespace Gesc.Api.Services.Contrats
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
