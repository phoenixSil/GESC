using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;
using AutoMapper;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class SupprimerUnNiveauCmdHdler : BaseCommandHandler<SupprimerUnNiveauCmd>
    {
        public SupprimerUnNiveauCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUnNiveauCmd request, CancellationToken cancellationToken)
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
