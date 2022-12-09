using FluentValidation;
using Gesc.Features.Dtos.Config.Cycles;

namespace Gesc.Features.Dtos.Cycles.Validations
{
    public class ValidateurDeLaCreationDeCycleDto : AbstractValidator<CycleACreerDto>
    {
        public ValidateurDeLaCreationDeCycleDto()
        {
            Include(new ValidateurDeDtoDeCycle());
        }
    }
}
