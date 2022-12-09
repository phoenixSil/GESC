using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using Gesc.Features.Core.Commandes.Cycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Features.Core.CommandHandlers.Cycles
{
    public class SupprimerUnCycleCmdHdler : IRequestHandler<SupprimerUnCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;

        public SupprimerUnCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
        }

        public async Task<ReponseDeRequette> Handle(SupprimerUnCycleCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var cycle = await _pointDaccess.RepertoireDeCycle.Lire(request.Id);

            if (cycle == null)
                throw new NotFoundException(nameof(Cycle), request.Id);

            if (cycle != null)
            {
                var resultat = await _pointDaccess.RepertoireDeCycle.Supprimer(cycle);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'cycle d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet cycle 
                    await _mediator.Send(new SupprimerUnCycleCmd { Id = cycle.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'cycle d'Id {request.Id}";
            }
            return response;
        }
    }
}
