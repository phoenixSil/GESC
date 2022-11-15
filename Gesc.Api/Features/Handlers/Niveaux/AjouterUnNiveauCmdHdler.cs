﻿using AutoMapper;
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
using Gesc.Api.Proxies.GdcProxys.Contrats;
using MassTransit;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class AjouterUnNiveauCmdHdler : IRequestHandler<AjouterUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;
        private readonly IGieProxy _gieProxy;
        private readonly IGdcProxy _gdcProxy;
        private readonly IPublishEndpoint _publishEndPoint;

        public AjouterUnNiveauCmdHdler(IPublishEndpoint publishEndPoint, IGdcProxy gdcProxy, IGieProxy gieProxy, IMapper mapper, IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
            _gieProxy = gieProxy;
            _gdcProxy = gdcProxy;
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

                    // On ajoutte le Niveau dans la Ms Dinscription des Etudiants 
                    // _gieProxy.AjoutterNiveau(result);

                    // on ajoutte le Niveau dans la Ms de Gestion des Cours 
                    //await _gdcProxy.AjoutterNiveau(result);

                    // Communication Asynchrone via le Bus Rabbit MQ
                    _publishEndPoint.Publish(result);
                }
            }

            return reponse;
        }
    }
}
