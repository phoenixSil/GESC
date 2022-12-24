using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;
using AutoMapper;
using MassTransit;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Utils;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class SupprimerUnNiveauCmdHdler : BaseCommandHandler<SupprimerUnNiveauCmd>
    {
        private readonly IPublishEndpoint _publishEndPoint;

        public SupprimerUnNiveauCmdHdler(IPublishEndpoint publishEndPoint, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _publishEndPoint = publishEndPoint;
        }

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

                    // Communication Asynchrone via le Bus Rabbit MQ
                    var dto = GenererNiveauMessagePourLeBus(request.Id);
                    await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);
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

        #region PRIVATE FUNCTION

        private static NiveauASupprimerMessage GenererNiveauMessagePourLeBus(Guid id)
        {
            var dto = new NiveauASupprimerMessage
            {
                Service = DesignationService.SERVICE_GESC,
                NumeroExterne = id,
                Type = TypeMessage.SUPPRESSION
            };

            return dto;
        }

        #endregion
    }
}
