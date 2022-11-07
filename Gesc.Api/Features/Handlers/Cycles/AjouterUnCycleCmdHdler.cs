using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Cycles.Validations;
using Gesc.Api.Features.Commandes.Cycles;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;

namespace Gesc.Api.Features.CommandHandlers.Cycles
{
    public class AjouterUneCycleAUnePersonneCmdHdler : IRequestHandler<AjouterUnCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AjouterUneCycleAUnePersonneCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnCycleCmd request, CancellationToken cancellationToken)
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
                    reponse.Message = "Echec de Lajout dune Cycle a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Personne Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
