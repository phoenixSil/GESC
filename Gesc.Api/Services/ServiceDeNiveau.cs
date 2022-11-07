using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Features.Commandes.Niveaux;
using Gesc.Api.Services.Contrats;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Services
{
    public class ServiceDeNiveau : IServiceDeNiveau
    {
        private readonly IMediator _mediator;
        public ServiceDeNiveau(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> AjouterUnNiveau(NiveauACreerDto niveauAAjouter)
        {
            var resultatAjoutNiveau = await _mediator.Send(new AjouterUnNiveauCmd { NiveauAAjouterDto = niveauAAjouter });
            return resultatAjoutNiveau;
        }

        public async Task<NiveauDetailDto> LireDetailDunNiveau(Guid id)
        {
            var niveau = await _mediator.Send(new LireDetailDUnNiveauCmd { Id = id });
            return niveau;
        }

        public async Task<List<NiveauDto>> LireTousLesNiveaus()
        {
            var listNiveau = await _mediator.Send(new LireTousLesNiveauxCmd { });
            return listNiveau;
        }

        public async Task<ReponseDeRequette> SupprimerUnNiveau(Guid NiveauId)
        {
            var resultatSuppression = await _mediator.Send(new SupprimerUnNiveauCmd { Id = NiveauId });
            return resultatSuppression;
        }

        public async Task<ReponseDeRequette> ModifierUnNiveau(Guid niveauId, NiveauAModifierDto niveauAModifier)
        {

            var resultatNiveauAModifier = await _mediator.Send(new ModifierUnNiveauCmd { NiveauAModifierDto = niveauAModifier });
            return resultatNiveauAModifier;
        }
    }
}