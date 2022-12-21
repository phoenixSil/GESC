using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles.Validations;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Features.Core.BaseFactoryClass;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class AjouterUneEcoleCmdHdler : BaseCommandHandler<AjouterUneEcoleCmd>
    {
        protected readonly ILogger<AjouterUneEcoleCmdHdler> _logger;

        public AjouterUneEcoleCmdHdler(ILogger<AjouterUneEcoleCmdHdler> logger, IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
            _logger = logger;
        }

        public async override Task<ReponseDeRequette> Handle(AjouterUneEcoleCmd request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("On vas essayer dajoutter une ecole dans la base de donnees", JsonConvert.SerializeObject(request.EcoleAAjouterDto));
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDecoleDto();
            var resultatValidation = await validateur.ValidateAsync(request.EcoleAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                _logger.LogError("les donnees entrees ne sont pas valides !!!", JsonConvert.SerializeObject(request.EcoleAAjouterDto));
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Ecole a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                _logger.LogInformation("les donnees ont ete valider  on vas ajoutter l'ecole");
                var ecoleACreer = _mapper.Map<Ecole>(request.EcoleAAjouterDto);
                var result = await _pointDaccess.RepertoireDecole.Ajoutter(ecoleACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'une Ecole";
                    _logger.LogError($"Lecole na pas ete ajoutter", JsonConvert.SerializeObject(request.EcoleAAjouterDto));
                }
                else
                {
                    _logger.LogInformation($"Lecole a Ete Ajoutter avec l'Id: [{result.Id}]");
                    reponse.Success = true;
                    reponse.Message = "Ajout de Ecole Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
