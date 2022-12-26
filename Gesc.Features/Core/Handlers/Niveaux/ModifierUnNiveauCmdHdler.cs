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

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class ModifierUnNiveauCmdHdler : BaseCommandHandler<ModifierUnNiveauCmd>
    {
        private readonly IPublishEndpoint _publishEndPoint;

        public ModifierUnNiveauCmdHdler(IPublishEndpoint publishEndPoint, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _publishEndPoint = publishEndPoint;
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.NiveauId);

            if (niveau is null)
                throw new NotFoundException(nameof(niveau), request.NiveauId);

            if (request.NiveauAModifierDto is not null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeNiveauDto();
                var resultatValidation = await validateur.ValidateAsync(request.NiveauAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeNiveau.Exists(request.NiveauId))
                    throw new BadRequestException($"L'un des Ids Niveau::[{request.NiveauId}] que vous avez entrez est null");

                if (resultatValidation.IsValid is false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.NiveauAModifierDto, niveau);

                var resultat = await _pointDaccess.RepertoireDeNiveau.Modifier(niveau);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = niveau.Id;

                // Communication Asynchrone via le Bus Rabbit MQ
                var dto = await GenererNiveauMessagePourLeBus(resultat);
                await _publishEndPoint.Publish(dto, cancellationToken).ConfigureAwait(false);

                return reponse;
            }
            throw new BadRequestException("niveau a Modifier est null");
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
