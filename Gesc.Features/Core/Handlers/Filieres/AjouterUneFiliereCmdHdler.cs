using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Filieres.Validations;
using Gesc.Features.Core.Commandes.Filieres;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;

namespace Gesc.Features.Core.CommandHandlers.Filieres
{
    public class AjouterUneFiliereCmdHdler : IRequestHandler<AjouterUneFiliereCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public AjouterUneFiliereCmdHdler(IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(AjouterUneFiliereCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeFiliereDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.FiliereAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Filiere a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var filiereACreer = _mapper.Map<Filiere>(request.FiliereAAjouterDto);
                var result = await _pointDaccess.RepertoireDeFiliere.Ajoutter(filiereACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout dune Filiere a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Filiere Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
