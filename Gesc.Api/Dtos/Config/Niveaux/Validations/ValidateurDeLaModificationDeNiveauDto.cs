using FluentValidation;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Niveaus.Validations
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
