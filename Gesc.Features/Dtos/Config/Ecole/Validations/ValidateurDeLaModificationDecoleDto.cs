using FluentValidation;
using Gesc.Features.Dtos.Config.Ecole;


namespace Gesc.Features.Dtos.Ecoles.Validations
{
    public class ValidateurDeLaModificationDecoleDto : AbstractValidator<EcoleAModifierDto>
    {
        public ValidateurDeLaModificationDecoleDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDecole());
        }
    }
}
