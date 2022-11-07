using FluentValidation;
using Gesc.Api.Dtos.Config.Departements;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Departements.Validations
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
