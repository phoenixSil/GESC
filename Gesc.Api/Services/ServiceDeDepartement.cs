using Gesc.Api.Dtos.Config.Departements;
using Gesc.Api.Features.Commandes.Departements;
using Gesc.Api.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDeDepartement : IServiceDeDepartement
    {
        private readonly IMediator _mediator;
        public ServiceDeDepartement(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnDepartement(DepartementACreerDto departementAAjouter)
        {
            var resultatAjoutDepartement = await _mediator.Send(new AjouterUnDepartementCmd { DepartementAAjouterDto = departementAAjouter });
            return resultatAjoutDepartement;
        }

        public async Task<DepartementDetailDto> LireDetailDunDepartement(Guid id)
        {
            var departement = await _mediator.Send(new LireDetailDUnDepartementCmd { Id = id });
            return departement;
        }

        public async Task<DepartementDetailDto> LireDetailInfoDunDepartement(Guid id)
        {
            var departement = await _mediator.Send(new LireDetailInfoDunDepartementCmd { Id = id });
            return departement;
        }

        public async Task<List<DepartementDto>> LireTousLesDepartements()
        {
            var listDepartement = await _mediator.Send(new LireTousLesDepartementsCmd { });
            return listDepartement;
        }

        public async Task<List<DepartementDto>> LireTousLesDepartementDuneEcoleParEcoleId(Guid ecoleId)
        {
            var listDepartement = await _mediator.Send(new LireTousLesDepartementDuneEcoleParEcoleIdCmd { EcoleId = ecoleId });
            return listDepartement;
        }

        public async Task<ReponseDeRequette> SupprimerUnDepartement(Guid DepartementId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnDepartementCmd { Id = DepartementId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnDepartement(Guid departementId, DepartementAModifierDto departementAModifier)
        {

            var resultatDepartementAModifier = await _mediator.Send(new ModifierUnDepartementCmd { DepartementAModifierDto = departementAModifier });
            return resultatDepartementAModifier;
        }
    }
}