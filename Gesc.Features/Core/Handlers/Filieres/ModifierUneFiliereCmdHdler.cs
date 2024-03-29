﻿using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using Gesc.Features.Dtos.Filieres;
using Gesc.Features.Dtos.Filieres.Validations;
using Gesc.Features.Core.Commandes.Filieres;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Filieres
{
    public class ModifierUneFiliereCmdHdler : BaseCommandHandler<ModifierUneFiliereCmd>
    {
        public ModifierUneFiliereCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUneFiliereCmd request, CancellationToken cancellationToken)
        {
            var filiere = await _pointDaccess.RepertoireDeFiliere.Lire(request.FiliereId);

            if (filiere is null)
                throw new NotFoundException(nameof(filiere), request.FiliereId);

            if (request.FiliereAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeFiliereDto();
                var resultatValidation = await validateur.ValidateAsync(request.FiliereAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeFiliere.Exists(request.FiliereId))
                    throw new BadRequestException($"L'un des Ids Filiere::[{request.FiliereId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.FiliereAModifierDto, filiere);

                await _pointDaccess.RepertoireDeFiliere.Modifier(filiere);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = filiere.Id;

                return reponse;
            }
            throw new BadRequestException("filiere a Modifier est null");
        }
    }
}
