using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmdHdler : BaseCommandHandler<SupprimerUneFiliereCycleCmd>
    {
        public SupprimerUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUneFiliereCycleCmd request, CancellationToken cancellationToken)
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
