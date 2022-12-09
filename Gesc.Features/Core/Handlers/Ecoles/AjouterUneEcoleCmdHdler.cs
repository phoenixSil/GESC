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

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class AjouterUneEcoleCmdHdler : BaseCommandHandler<AjouterUneEcoleCmd>
    {
        public AjouterUneEcoleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(AjouterUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDecoleDto();
            var resultatValidation = await validateur.ValidateAsync(request.EcoleAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Ecole a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ecoleACreer = _mapper.Map<Ecole>(request.EcoleAAjouterDto);
                var result = await _pointDaccess.RepertoireDecole.Ajoutter(ecoleACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'une Ecole a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Ecole Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
