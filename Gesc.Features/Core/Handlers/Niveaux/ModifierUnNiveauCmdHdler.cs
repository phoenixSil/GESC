using AutoMapper;
using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Dtos.Niveaus.Validations; 
using Gesc.Features.Core.BaseFactoryClass;
using MassTransit;
using MsCommun.Messages.Niveaux;
using Gesc.Domain.Modeles.Config;
using MsCommun.Messages.Utils;
using Newtonsoft.Json;
using System.Net;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class ModifierUnNiveauCmdHdler : BaseCommandHandler<ModifierUnNiveauCmd>
    {
        private readonly IPublishEndpoint _publishEndPoint;
        private readonly ILogger<ModifierUnNiveauCmdHdler> _logger;

        public ModifierUnNiveauCmdHdler(ILogger<ModifierUnNiveauCmdHdler> logger, IPublishEndpoint publishEndPoint, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _publishEndPoint = publishEndPoint;
            _logger = logger;
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUnNiveauCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"On vas essayer de Modifier un Niveau . Donness {JsonConvert.SerializeObject(request.NiveauAModifierDto)}");
            var reponse = new ReponseDeRequette();
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.NiveauId);

            if (niveau is null)
            {
                reponse.Success = false;
                reponse.Message = "Le niveau specifier est introuvable ";
                reponse.Id = request.NiveauId;
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogWarning($"le niveau nexsite pas Id : [{request.NiveauId}]");
            }
            else
            {
                var validateur = new ValidateurDeLaModificationDeNiveauDto();
                var resultatValidation = await validateur.ValidateAsync(request.NiveauAModifierDto, cancellationToken);

                if (resultatValidation.IsValid is false)
                {
                    reponse.Success = false;
                    reponse.Message = "Les Donnees du niveau ne sont pas valides  ";
                    reponse.Id = request.NiveauId;
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logger.LogError($"Les Donnees du niveau ne sont pas valides : {JsonConvert.SerializeObject(request.NiveauAModifierDto)}");

                }
                else
                {
                    _mapper.Map(request.NiveauAModifierDto, niveau);

                    await _pointDaccess.RepertoireDeNiveau.Modifier(niveau);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = niveau.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation($"Modification du Niveau Reussit ID: [{request.NiveauId}]");

                    // mise a jour message Bus
                    var dto = await GenererNiveauMessagePourLeBus(niveau).ConfigureAwait(false);
                    await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);

                }
            }
            return reponse;
        }

        #region PRIVATE FUNCTION

        private async Task<NiveauAModifierMessage> GenererNiveauMessagePourLeBus(Niveau niveau)
        {
            var niveauDetail = await _pointDaccess.RepertoireDeNiveau.LireDetail(niveau.Id);
            var niveauMapper = _mapper.Map<NiveauAModifierMessage>(niveauDetail);
            niveauMapper.Service = DesignationService.SERVICE_GESC;
            niveauMapper.Type = TypeMessage.CREATION;
            return niveauMapper;
        }

        #endregion
    }
}
