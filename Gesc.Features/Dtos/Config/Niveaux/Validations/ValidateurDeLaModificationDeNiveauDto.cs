using FluentValidation;
using Gesc.Features.Dtos.Config.Niveaux;


namespace Gesc.Features.Dtos.Niveaus.Validations
{
    public class ValidateurDeLaModificationDeNiveauDto : AbstractValidator<NiveauAModifierDto>
    {
        public ValidateurDeLaModificationDeNiveauDto()
        {
            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
