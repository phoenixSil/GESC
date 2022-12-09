using FluentValidation;
using Gesc.Features.Dtos.Config.Filieres;


namespace Gesc.Features.Dtos.Filieres.Validations
{
    public class ValidateurDeLaModificationDeFiliereDto : AbstractValidator<FiliereAModifierDto>
    {
        public ValidateurDeLaModificationDeFiliereDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeFiliere());
        }
    }
}
