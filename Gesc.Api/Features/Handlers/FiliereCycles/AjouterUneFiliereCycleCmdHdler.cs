using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles.Validations;
using Gesc.Api.Features.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.FiliereCycles
{
    public class AjouterUneFiliereCycleCmdHdler : IRequestHandler<AjouterUneFiliereCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneFiliereCycleCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUneFiliereCycleCmd request, CancellationToken cancellationToken)
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
