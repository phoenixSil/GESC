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

namespace Gesc.Features.Core.CommandHandlers.Niveaux
{
    public class AjouterUnNiveauCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndPoint;

        public AjouterUnNiveauCmdHdler(IPublishEndpoint publishEndPoint, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _publishEndPoint = publishEndPoint;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout d'un Niveau a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var niveauACreer = _mapper.Map<Niveau>(request.NiveauAAjouterDto);
                niveauACreer.Id = Guid.NewGuid();
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
                    await _publishEndPoint.Publish(dto).ConfigureAwait(false);
                }
            }

            return reponse;
        }

        #region Private

        private async Task<AjouterNiveauMessage> GenerateDtoForGieNiveau(Niveau niveau)
        {
            var niveauDetail = await _pointDaccess.RepertoireDeNiveau.LireDetail(niveau.Id);
            var niveauMapper = _mapper.Map<AjouterNiveauMessage>(niveauDetail);
            return niveauMapper;
        }

        #endregion
    }
}
