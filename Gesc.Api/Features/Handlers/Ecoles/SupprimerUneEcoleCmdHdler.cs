using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Ecoles;
using Gesc.Api.Features.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.Ecoles
{
    public class SupprimerUneEcoleCmdHdler : IRequestHandler<SupprimerUneEcoleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUneEcoleCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.Id);

            if (ecole == null)
                throw new NotFoundException(nameof(Ecole), request.Id);

            if (ecole != null)
            {
                var resultat = await _pointDaccess.RepertoireDecole.Supprimer(ecole);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'ecole d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet ecole 
                    await _mediator.Send(new SupprimerUneEcoleCmd { Id = ecole.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'ecole d'Id {request.Id}";
            }
            return response;
        }
    }
}
