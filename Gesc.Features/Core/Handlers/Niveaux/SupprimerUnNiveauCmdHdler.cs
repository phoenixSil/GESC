using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class SupprimerUnNiveauCmdHdler : IRequestHandler<SupprimerUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnNiveauCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.Id);

            if (niveau is not null)
            {
                var resultat = await _pointDaccess.RepertoireDeNiveau.Supprimer(niveau);
                if (resultat is true)
                {
                    response.Success = true;
                    response.Message = $"l'niveau d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime le Niveau dans les autre Microservices
                    // TODO: supprimer les Niveau dans les autres microservices
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas d'niveau d'Id {request.Id}";
            }
            return response;
        }
    }
}
