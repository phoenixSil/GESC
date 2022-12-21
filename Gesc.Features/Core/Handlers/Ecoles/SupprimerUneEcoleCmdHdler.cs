﻿using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class SupprimerUneEcoleCmdHdler : BaseCommandHandler<SupprimerUneEcoleCmd>
    {
        public SupprimerUneEcoleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.Id);

            if (ecole == null)
                throw new NotFoundException(nameof(Ecole), request.Id);

            if (ecole != null)
            {
                var resultat = await _pointDaccess.RepertoireDecole.Supprimer(ecole);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'ecole d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet ecole 
                    await _mediator.Send(new SupprimerUneEcoleCmd { Id = ecole.Id }, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas d'ecole d'Id {request.Id}";
            }
            return response;
        }
    }
}