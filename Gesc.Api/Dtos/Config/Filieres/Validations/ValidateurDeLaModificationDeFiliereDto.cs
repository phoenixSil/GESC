using FluentValidation;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Filieres.Validations
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
