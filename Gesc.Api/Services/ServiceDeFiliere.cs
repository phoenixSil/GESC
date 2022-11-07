using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Services.Contrats;
using MediatR;
using Gesc.Api.Features.Commandes.Filieres;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDeFiliere : IServiceDeFiliere
    {
        private readonly IMediator _mediator;
        public ServiceDeFiliere(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUneFiliere(FiliereACreerDto filiereAAjouter)
        {
            var resultatAjoutFiliere = await _mediator.Send(new AjouterUneFiliereCmd { FiliereAAjouterDto = filiereAAjouter });
            return resultatAjoutFiliere;
        }

        public async Task<FiliereDetailDto> LireDetailDuneFiliere(Guid id)
        {
            var filiere = await _mediator.Send(new LireDetailDUneFiliereCmd { Id = id });
            return filiere;
        }

        public async Task<List<FiliereDto>> LireToutesLesFilieres()
        {
            var listFiliere = await _mediator.Send(new LireTousLesFilieresCmd { });
            return listFiliere;
        }

        public async Task<ReponseDeRequette> SupprimerUneFiliere(Guid FiliereId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUneFiliereCmd { Id = FiliereId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUneFiliere(Guid filiereId, FiliereAModifierDto filiereAModifier)
        {

            var resultatFiliereAModifier = await _mediator.Send(new ModifierUneFiliereCmd { FiliereAModifierDto = filiereAModifier });
            return resultatFiliereAModifier;
        }
    }
}