using FluentValidation;
using Gesc.Features.Dtos.Config.Ecole;



namespace Gesc.Features.Dtos.Ecoles.Validations
{
    public class ValidateurDeLaCreationDecoleDto : AbstractValidator<EcoleACreerDto>
    {
        public ValidateurDeLaCreationDecoleDto()
        {
            Include(new ValidateurDeDtoDecole());
        }
    }
}
