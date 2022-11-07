using FluentValidation;
using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Niveaus.Validations
{
    public class ValidateurDeDtoDeNiveau : AbstractValidator<INiveauDto>
    {
        public ValidateurDeDtoDeNiveau()
        {
            RuleFor(x => x.Designation)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100)
                .WithMessage("la Designation que vous avez entrer est incorrect ");

            RuleFor(x => x.ValeurCycle)
               .NotEmpty()
               .GreaterThanOrEqualTo(1)
               .LessThanOrEqualTo(6);
        }
    }
}
