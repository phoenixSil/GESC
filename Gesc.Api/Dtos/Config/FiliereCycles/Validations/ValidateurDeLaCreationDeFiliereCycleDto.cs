using FluentValidation;
using Gesc.Api.Dtos.Config.FiliereCycles;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.FiliereCycles.Validations
{
    public class ValidateurDeLaCreationDeFiliereCycleDto : AbstractValidator<FiliereCycleACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDeFiliereCycleDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;
            Include(new ValidateurDeDtoDeFiliereCycle(_pointDaccess));
        }
    }
}
