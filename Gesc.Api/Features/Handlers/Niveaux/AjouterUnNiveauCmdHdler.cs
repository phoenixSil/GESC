using AutoMapper;
using MediatR;
using Gesc.Api.Features.Commandes.Niveaux;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Dtos.Niveaus.Validations;
using Gesc.Api.Dtos.Config.Niveaux;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class AjouterUneNiveauAUnePersonneCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AjouterUneNiveauAUnePersonneCmdHdler(IMediator mediator, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeNiveauDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.NiveauAAjouterDto, cancellationToken);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
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
                    reponse.Message = "Echec de Lajout dune Niveau a la personne donc l'Id est notee dans le champs d'Id";
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
