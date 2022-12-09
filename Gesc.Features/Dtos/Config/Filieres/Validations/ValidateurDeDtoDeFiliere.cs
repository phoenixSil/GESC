using FluentValidation;
using Gesc.Features.Dtos.Config.Filieres;



namespace Gesc.Features.Dtos.Filieres.Validations
{
    public class ValidateurDeDtoDeFiliere : AbstractValidator<IFiliereDto>
    {
        public ValidateurDeDtoDeFiliere()
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
