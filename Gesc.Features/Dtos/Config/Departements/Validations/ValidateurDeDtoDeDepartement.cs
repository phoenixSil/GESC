using FluentValidation;
using Gesc.Features.Dtos.Config.Departements;



namespace Gesc.Features.Dtos.Departements.Validations
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
