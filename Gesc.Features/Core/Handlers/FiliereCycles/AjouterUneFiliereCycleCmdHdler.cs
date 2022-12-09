using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles.Validations;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
{
    public class AjouterUneFiliereCycleCmdHdler : BaseCommandHandler<AjouterUneFiliereCycleCmd>
    {
        public AjouterUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(AjouterUneFiliereCycleCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeFiliereCycleDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.FiliereCycleAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune FiliereCycle a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var filiereCycleACreer = _mapper.Map<FiliereCycle>(request.FiliereCycleAAjouterDto);
                filiereCycleACreer.Id = Guid.NewGuid();
                var result = await _pointDaccess.RepertoireDeFiliereCycle.Ajoutter(filiereCycleACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'une FiliereCycle a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de FiliereCycle Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
