using AutoMapper;
using MediatR;
using Gesc.Features.Core.Commandes.Niveaux;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos.Niveaus.Validations;
using Gesc.Features.Dtos.Config.Niveaux;
using MassTransit;
using MsCommun.Messages.Niveaux;
using Gesc.Features.Core.BaseFactoryClass;
using MsCommun.Messages.Utils;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class AjouterUnNiveauCmdHdler : BaseCommandHandler<AjouterUnNiveauCmd>
    {
        private readonly IPublishEndpoint _publishEndPoint;
        private readonly ILogger<AjouterUnNiveauCmdHdler> _logger;

        public AjouterUnNiveauCmdHdler(ILogger<AjouterUnNiveauCmdHdler> logger, IPublishEndpoint publishEndPoint, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _publishEndPoint = publishEndPoint;
            _logger = logger;
        }

        public async override Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"on vas ammorcer la creation du Niveau {JsonConvert.SerializeObject(request.NiveauAAjouterDto)}");
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogInformation($"on vas ammorcer la creation du Niveau {JsonConvert.SerializeObject(request.NiveauAAjouterDto)}");
                reponse.Success = false;
                reponse.Message = "Echec de Lajout d'un Niveau a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
                _logger.LogWarning($"Echec de la validation de donnees {JsonConvert.SerializeObject(reponse)}");
            }
            else
            {
                var niveauACreer = _mapper.Map<Niveau>(request.NiveauAAjouterDto);
                niveauACreer.Id = Guid.NewGuid();

                if(_pointDaccess.RepertoireDeNiveau.PeuxAjoutter(niveauACreer))
                {
                    reponse.Success = false;
                    reponse.Message = "le Cycle est deja complet ou contient deja un niveau ayant la meme valeur ";
                    _logger.LogWarning(message: $"le Cycle est deja complet ou contient deja un niveau ayant la meme valeur  {JsonConvert.SerializeObject(reponse)}");
                } 
                else
                {
                    var result = await _pointDaccess.RepertoireDeNiveau.Ajoutter(niveauACreer);
                    await _pointDaccess.Enregistrer();

                    if (result == null)
                    {
                        reponse.Success = false;
                        reponse.Message = "Echec de Lajout d'un Niveau a la personne donc l'Id est notee dans le champs d'Id";
                    }
                    else
                    {
                        reponse.Success = true;
                        reponse.Message = "Ajout de Niveau Reussit";
                        reponse.Id = result.Id;

                        // Communication Asynchrone via le Bus Rabbit MQ
                        var dto = await GenerateDtoForGieNiveau(result).ConfigureAwait(false);
                        await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);
                    }
                }

                
            }

            return reponse;
        }

        #region Private

        private async Task<NiveauACreerMessage> GenerateDtoForGieNiveau(Niveau niveau)
        {
            var niveauDetail = await _pointDaccess.RepertoireDeNiveau.LireDetail(niveau.Id);
            var niveauMapper = _mapper.Map<NiveauACreerMessage>(niveauDetail);
            niveauMapper.Service = DesignationService.SERVICE_GESC;
            niveauMapper.Type = TypeMessage.CREATION;
            return niveauMapper;
        }

        #endregion
    }
}
