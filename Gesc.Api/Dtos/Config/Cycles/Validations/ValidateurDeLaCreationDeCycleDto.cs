using FluentValidation;
using Gesc.Api.Dtos.Config.Cycles;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Cycles.Validations
{
    public class ValidateurDeLaCreationDeCycleDto : AbstractValidator<CycleACreerDto>
    {
        public ValidateurDeLaCreationDeCycleDto()
        {
            Include(new ValidateurDeDtoDeCycle());
        }
    }
}
