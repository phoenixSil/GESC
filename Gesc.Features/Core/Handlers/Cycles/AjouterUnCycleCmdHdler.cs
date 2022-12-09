using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Cycles.Validations;
using Gesc.Features.Core.Commandes.Cycles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Cycles
{
    public class AjouterUnCycleCmdHdler : BaseCommandHandler<AjouterUnCycleCmd>
    {

        public AjouterUnCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {}

        public async override Task<ReponseDeRequette> Handle(AjouterUnCycleCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeCycleDto();
            var resultatValidation = await validateur.ValidateAsync(request.CycleAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Cycle a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var cycleACreer = _mapper.Map<Cycle>(request.CycleAAjouterDto);
                var result = await _pointDaccess.RepertoireDeCycle.Ajoutter(cycleACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'un Cycle a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Cycle Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
