using AutoMapper;
using MediatR;
using Gesc.Api.Dtos.Cycles;
using Gesc.Api.Dtos.Cycles;
using Gesc.Api.Dtos.Cycles.Validations;
using Gesc.Api.Features.Commandes.Cycles;
using Gesc.Domain.Modeles;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Reponses;
using MsCommun.Exceptions;

namespace Gesc.Api.Features.CommandHandlers.Cycles
{
    public class ModifierUnCycleCmdHdler : IRequestHandler<ModifierUnCycleCmd, ReponseDeRequette>
    {
        private readonly IPointDaccess _pointDaccess;
        private readonly IMapper _mapper;

        public ModifierUnCycleCmdHdler(IPointDaccess pointDaccess, IMapper mapper)
        {
            _pointDaccess = pointDaccess;
            _mapper = mapper;
        }
        public async Task<ReponseDeRequette> Handle(ModifierUnCycleCmd request, CancellationToken cancellationToken)
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
