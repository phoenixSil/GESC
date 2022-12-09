using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Departements;
using Gesc.Features.Dtos.Departements;
using Gesc.Features.Dtos.Departements.Validations; using Gesc.Features.Dtos.Niveaus.Validations;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Departements
{
    public class ModifierUnDepartementCmdHdler : BaseCommandHandler<ModifierUnDepartementCmd>
    {
        public ModifierUnDepartementCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUnDepartementCmd request, CancellationToken cancellationToken)
        {
            var departement = await _pointDaccess.RepertoireDeDepartement.Lire(request.DepartementId);

            if (departement is null)
                throw new NotFoundException(nameof(departement), request.DepartementId);

            if (request.DepartementAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeDepartementDto();
                var resultatValidation = await validateur.ValidateAsync(request.DepartementAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeDepartement.Exists(request.DepartementId))
                    throw new BadRequestException($"L'un des Ids Departement::[{request.DepartementId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.DepartementAModifierDto, departement);

                await _pointDaccess.RepertoireDeDepartement.Modifier(departement);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = departement.Id;

                return reponse;
            }
            throw new BadRequestException("departement a Modifier est null");
        }
    }
}
