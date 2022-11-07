using AutoMapper;
using MediatR;
using Gesc.Api.Features.Commandes.Niveaux;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Api.Dtos.Niveaus.Validations;

namespace Gesc.Api.Features.CommandHandlers.Niveaux
{
    public class ModifierUnNiveauCmdHdler : IRequestHandler<ModifierUnNiveauCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ModifierUnNiveauCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnNiveauCmd request, CancellationToken cancellationToken)
        {
            var niveau = await _pointDaccess.RepertoireDeNiveau.Lire(request.NiveauId);

            if (niveau is null)
                throw new NotFoundException(nameof(niveau), request.NiveauId);

            if (request.NiveauAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeNiveauDto();
                var resultatValidation = await validateur.ValidateAsync(request.NiveauAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeNiveau.Exists(request.NiveauId))
                    throw new BadRequestException($"L'un des Ids Niveau::[{request.NiveauId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.NiveauAModifierDto, niveau);

                await _pointDaccess.RepertoireDeNiveau.Modifier(niveau);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = niveau.Id;

                return reponse;
            }
            throw new BadRequestException("niveau a Modifier est null");
        }
    }
}
