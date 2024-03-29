﻿using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Departements.Validations;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Departements
{
    public class AjouterUnDepartementCmdHdler :  BaseCommandHandler<AjouterUnDepartementCmd>
    {
        public AjouterUnDepartementCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(AjouterUnDepartementCmd request, CancellationToken cancellationToken)
        {
            var reponse = new ReponseDeRequette();
            var validateur = new ValidateurDeLaCreationDeDepartementDto(_pointDaccess);
            var resultatValidation = await validateur.ValidateAsync(request.DepartementAAjouterDto);

            if (resultatValidation.IsValid == false)
            {
                reponse.Success = false;
                reponse.Message = "Echec de Lajout dune Departement a la personne donc l'Id est notee dans le champs d'Id";
                reponse.Errors = resultatValidation.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var departementACreer = _mapper.Map<Departement>(request.DepartementAAjouterDto);
                var result = await _pointDaccess.RepertoireDeDepartement.Ajoutter(departementACreer);
                await _pointDaccess.Enregistrer();

                if (result == null)
                {
                    reponse.Success = false;
                    reponse.Message = "Echec de Lajout d'un Departement a la personne donc l'Id est notee dans le champs d'Id";
                }
                else
                {
                    reponse.Success = true;
                    reponse.Message = "Ajout de Departement Reussit";
                    reponse.Id = result.Id;
                }
            }

            return reponse;
        }
    }
}
