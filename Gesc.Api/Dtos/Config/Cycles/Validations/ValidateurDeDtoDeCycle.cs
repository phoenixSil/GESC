using FluentValidation;
using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Cycles.Validations
{
    public class ValidateurDeDtoDeCycle : AbstractValidator<ICycleDto>
    {
        public ValidateurDeDtoDeCycle()
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
