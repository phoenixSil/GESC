using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using Gesc.Features.Dtos.Ecoles;
using Gesc.Features.Dtos.Ecoles.Validations;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;

namespace Gesc.Features.Core.CommandHandlers.Ecoles
{
    public class ModifierUneEcoleCmdHdler : IRequestHandler<ModifierUneEcoleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifierUneEcoleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUneEcoleCmd request, CancellationToken cancellationToken)
        {
            var ecole = await _pointDaccess.RepertoireDecole.Lire(request.EcoleId);

            if (ecole is null)
                throw new NotFoundException(nameof(ecole), request.EcoleId);

            if (request.EcoleAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDecoleDto();
                var resultatValidation = await validateur.ValidateAsync(request.EcoleAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDecole.Exists(request.EcoleId))
                    throw new BadRequestException($"L'un des Ids Ecole::[{request.EcoleId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.EcoleAModifierDto, ecole);

                await _pointDaccess.RepertoireDecole.Modifier(ecole);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = ecole.Id;

                return reponse;
            }
            throw new BadRequestException("ecole a Modifier est null");
        }
    }
}
