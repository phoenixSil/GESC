using FluentValidation;
using Gesc.Features.Dtos.Config.Ecole;



namespace Gesc.Features.Dtos.Ecoles.Validations
{
    public class ValidateurDeDtoDecole : AbstractValidator<IEcoleDto>
    {
        public ValidateurDeDtoDecole()
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
