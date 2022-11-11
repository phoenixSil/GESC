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
using Gesc.Api.Proxies.Contrats;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class AjouterUnNiveauCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly IGieProxy _gieProxy;

        public AjouterUnNiveauCmdHdler(IGieProxy gieProxy, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _gieProxy = gieProxy;
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

                    // On ajoutte le Niveau dans la Ms Dinscription des Etudiants 
                    await _gieProxy.AjoutterNiveau(result);
                }
            }

            return reponse;
        }
    }
}
