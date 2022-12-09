using FluentValidation;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.FiliereCycles;


namespace Gesc.Features.Dtos.FiliereCycles.Validations
{
    public class ValidateurDeLaModificationDeFiliereCycleDto : AbstractValidator<FiliereCycleAModifierDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaModificationDeFiliereCycleDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.Id).NotNull()
                .NotEmpty()
                .WithMessage("Id doit pas etre null");

            Include(new ValidateurDeDtoDeFiliereCycle(_pointDaccess));
        }
    }
}
