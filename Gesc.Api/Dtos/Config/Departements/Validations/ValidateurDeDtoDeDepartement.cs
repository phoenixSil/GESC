using FluentValidation;
using Gesc.Api.Dtos.Config.Departements;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Departements.Validations
{
    public class ValidateurDeDtoDeDepartement : AbstractValidator<IDepartementDto>
    {
        public ValidateurDeDtoDeDepartement()
        {
            RuleFor(x => x.Designation)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(100)
                .WithMessage("la Designation que vous avez entrer est incorrect ");

            RuleFor(x => x.Cygle)
               .NotEmpty()
               .MinimumLength(2)
               .MaximumLength(10);
        }
    }
}
