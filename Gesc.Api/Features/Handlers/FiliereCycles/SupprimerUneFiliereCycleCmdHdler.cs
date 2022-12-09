using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using Gesc.Api.Features.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmdHdler : IRequestHandler<SupprimerUneFiliereCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUneFiliereCycleCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var filiereCycle = await _pointDaccess.RepertoireDeFiliereCycle.Lire(request.Id);

            if (filiereCycle == null)
                throw new NotFoundException(nameof(FiliereCycle), request.Id);

            if (filiereCycle != null)
            {
                var resultat = await _pointDaccess.RepertoireDeFiliereCycle.Supprimer(filiereCycle);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'filiereCycle d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet filiereCycle 
                    await _mediator.Send(new SupprimerUneFiliereCycleCmd { Id = filiereCycle.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'filiereCycle d'Id {request.Id}";
            }
            return response;
        }
    }
}
