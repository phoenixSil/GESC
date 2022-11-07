using FluentValidation;
using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Ecoles.Validations
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
