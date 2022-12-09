using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Cycles;
using Gesc.Features.Dtos.Cycles;
using Gesc.Features.Dtos.Cycles.Validations; using Gesc.Features.Dtos.Niveaus.Validations;
using Gesc.Features.Core.Commandes.Cycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using MsCommun.Exceptions;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Cycles
{
    public class ModifierUnCycleCmdHdler : BaseCommandHandler<ModifierUnCycleCmd>
    {

        public ModifierUnCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(ModifierUnCycleCmd request, CancellationToken cancellationToken)
        {
            var cycle = await _pointDaccess.RepertoireDeCycle.Lire(request.CycleId);

            if (cycle is null)
                throw new NotFoundException(nameof(cycle), request.CycleId);

            if (request.CycleAModifierDto != null)
            {
                var reponse = new ReponseDeRequette();
                var validateur = new ValidateurDeLaModificationDeCycleDto();
                var resultatValidation = await validateur.ValidateAsync(request.CycleAModifierDto, cancellationToken);

                if (!await _pointDaccess.RepertoireDeCycle.Exists(request.CycleId))
                    throw new BadRequestException($"L'un des Ids Cycle::[{request.CycleId}] que vous avez entrez est null");

                if (resultatValidation.IsValid == false)
                    throw new ValidationException(resultatValidation);

                _mapper.Map(request.CycleAModifierDto, cycle);

                await _pointDaccess.RepertoireDeCycle.Modifier(cycle);
                await _pointDaccess.Enregistrer();

                reponse.Success = true;
                reponse.Message = "Modification Reussit";
                reponse.Id = cycle.Id;

                return reponse;
            }
            throw new BadRequestException("cycle a Modifier est null");
        }
    }
}
