using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Filieres;
using Gesc.Api.Features.Commandes.Filieres;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Api.Modeles;
using MsCommun.Exceptions;
using Gesc.Api.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.Filieres
{
    public class SupprimerUneFiliereCmdHdler : IRequestHandler<SupprimerUneFiliereCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUneFiliereCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUneFiliereCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var filiere = await _pointDaccess.RepertoireDeFiliere.Lire(request.Id);

            if (filiere == null)
                throw new NotFoundException(nameof(Filiere), request.Id);

            if (filiere != null)
            {
                var resultat = await _pointDaccess.RepertoireDeFiliere.Supprimer(filiere);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'filiere d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet filiere 
                    await _mediator.Send(new SupprimerUneFiliereCmd { Id = filiere.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'filiere d'Id {request.Id}";
            }
            return response;
        }
    }
}
