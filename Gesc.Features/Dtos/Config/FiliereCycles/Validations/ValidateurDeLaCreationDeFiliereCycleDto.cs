using FluentValidation;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.FiliereCycles;



namespace Gesc.Features.Dtos.FiliereCycles.Validations
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
