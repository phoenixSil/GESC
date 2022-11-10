using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Departements;
using Gesc.Api.Features.Commandes.Departements;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Api.Modeles;
using MsCommun.Exceptions;
using Gesc.Api.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.Departements
{
    public class SupprimerUnDepartementCmdHdler : IRequestHandler<SupprimerUnDepartementCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnDepartementCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnDepartementCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var departement = await _pointDaccess.RepertoireDeDepartement.Lire(request.Id);

            if (departement == null)
                throw new NotFoundException(nameof(Departement), request.Id);

            if (departement != null)
            {
                var resultat = await _pointDaccess.RepertoireDeDepartement.Supprimer(departement);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'departement d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet departement 
                    await _mediator.Send(new SupprimerUnDepartementCmd { Id = departement.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'departement d'Id {request.Id}";
            }
            return response;
        }
    }
}
