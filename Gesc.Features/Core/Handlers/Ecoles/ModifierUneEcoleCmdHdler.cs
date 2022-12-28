using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles.Validations;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Core.BaseFactoryClass;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using System.Net;
using Newtonsoft.Json;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class ModifierUneEcoleCmdHdler : BaseCommandHandler<ModifierUneEcoleCmd>
    {
        private readonly ILogger<ModifierUneEcoleCmdHdler> _logger;

        public ModifierUneEcoleCmdHdler(ILogger<ModifierUneEcoleCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            _logger.LogInformation($"On vas Essayer de modifier les donnees dune ecole d'Id [{request.EcoleId}] ");
            
            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.EcoleId);

            if (ecole is null)
            {
                _logger.LogError($"On vas pas trouver les donnees de l'ecole d'Id [{request.EcoleId}] ");
                reponse.StatusCode = (int)HttpStatusCode.NotFound;
                reponse.Success = false;
                reponse.Message = "il nexiste pas decole avec cet Id";
                reponse.Id = request.EcoleId;
            }
            else
            {
                if (request.EcoleAModifierDto is not null)
                {
                    var validateur = new ValidateurDeLaModificationDecoleDto();
                    var resultatValidation = await validateur.ValidateAsync(request.EcoleAModifierDto, cancellationToken);

                    if (resultatValidation.IsValid is false)
                        throw new ValidationException(resultatValidation);

                    _mapper.Map(request.EcoleAModifierDto, ecole);

                    await _pointDaccess.RepertoireDecole.Modifier(ecole);
                    await _pointDaccess.Enregistrer();

                    reponse.Success = true;
                    reponse.Message = "Modification Reussit";
                    reponse.Id = ecole.Id;
                    reponse.StatusCode = (int)HttpStatusCode.OK;

                    
                }
                else
                {
                    _logger.LogError($"vous navez pas entrer de donner a modifier ");
                    reponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    reponse.Success = false;
                    reponse.Message = $"les donnees a modifier son Null. {JsonConvert.SerializeObject(request.EcoleAModifierDto)}";
                    reponse.Id = request.EcoleId;
                }
            }
            return reponse;
        }
    }
}
