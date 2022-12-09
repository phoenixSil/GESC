using FluentValidation;
using Gesc.Features.Dtos.Config.Cycles;

namespace Gesc.Features.Dtos.Cycles.Validations
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
