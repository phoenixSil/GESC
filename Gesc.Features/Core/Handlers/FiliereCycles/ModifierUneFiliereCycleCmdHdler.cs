using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles.Validations;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
{
    public class ModifierUneFiliereCycleCmdHdler : BaseCommandHandler<ModifierUneFiliereCycleCmd>
    {
        public ModifierUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        {
        }

        public async override Task<ReponseDeRequette> Handle(ModifierUneFiliereCycleCmd request, CancellationToken cancellationToken)
        {
            var filiereCycle = await _pointDaccess.RepertoireDeFiliereCycle.Lire(request.FiliereCycleId);

            if (filiereCycle is null)
                throw new NotFoundException(nameof(filiereCycle), request.FiliereCycleId);

            if (request.FiliereCycleAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeFiliereCycleDto(_pointDaccess);
                var resultatValidation = await validateur.ValidateAsync(request.FiliereCycleAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeFiliereCycle.Exists(request.FiliereCycleId))
                    throw new BadRequestException($"L'un des Ids FiliereCycle::[{request.FiliereCycleId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.FiliereCycleAModifierDto, filiereCycle);

                await _pointDaccess.RepertoireDeFiliereCycle.Modifier(filiereCycle);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = filiereCycle.Id;

                return reponse;
            }
            throw new BadRequestException("filiereCycle a Modifier est null");
        }
    }
}
