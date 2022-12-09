using FluentValidation;
using Gesc.Features.Dtos.Config.Departements;


namespace Gesc.Features.Dtos.Departements.Validations
{
    public class ValidateurDeLaModificationDeDepartementDto : AbstractValidator<DepartementAModifierDto>
    {
        public ValidateurDeLaModificationDeDepartementDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeDepartement());
        }
    }
}
