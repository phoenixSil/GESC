using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using Gesc.Api.Dtos.FiliereCycles;
using Gesc.Api.Dtos.FiliereCycles.Validations;
using Gesc.Api.Features.Commandes.FiliereCycles;
using Gesc.Api.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MsCommun.Exceptions;

namespace Gesc.Api.Features.CommandHandlers.FiliereCycles
{
    public class ModifierUneFiliereCycleCmdHdler : IRequestHandler<ModifierUneFiliereCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public ModifierUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUneFiliereCycleCmd request, CancellationToken cancellationToken)
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
