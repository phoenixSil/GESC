using AutoMapper;
using MediatR;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using Castle.Core.Logging;
using System.Net;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class SupprimerUneEcoleCmdHdler : BaseCommandHandler<SupprimerUneEcoleCmd>
    {
        private readonly ILogger<SupprimerUneEcoleCmdHdler> _logger;
        public SupprimerUneEcoleCmdHdler(ILogger<SupprimerUneEcoleCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public async override Task<ReponseDeRequette> Handle(SupprimerUneEcoleCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de suprimer lecole dÌd [{request.Id}]");
            
            var response = new ReponseDeRequette();
            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.Id);

            if (ecole is null)
            {
                _logger.LogError($"lecole dÌd  [{request.Id}] nexiste pas ");
                response.Success = false;
                response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                response.StatusCode = (int)HttpStatusCode.NotFound;
            } 
            else
            {

                var resultat = await _pointDaccess.RepertoireDecole.Supprimer(ecole);
                if (resultat is true)
                {
                    response.Success = true;
                    response.Message = $"l'ecole d'Id [{request.Id}] a ete supprimer avec success ";
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Id = request.Id;
                    _logger.LogInformation($"lecole dÌd  [{request.Id}] a ete supprimer ");
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogWarning($"Echec lors de la suppression de lecole diD [{request.Id}]");
                }
            }
            return response;
        }
    }
}
