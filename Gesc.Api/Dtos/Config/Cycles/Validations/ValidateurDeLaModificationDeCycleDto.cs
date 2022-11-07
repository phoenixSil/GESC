using FluentValidation;
using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Cycles.Validations
{
    public class ValidateurDeLaModificationDeCycleDto : AbstractValidator<CycleAModifierDto>
    {
        public ValidateurDeLaModificationDeCycleDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeCycle());
        }
    }
}
