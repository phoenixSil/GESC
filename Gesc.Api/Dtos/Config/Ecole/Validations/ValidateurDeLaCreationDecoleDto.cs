using FluentValidation;
using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Ecoles.Validations
{
    public class ValidateurDeLaCreationDecoleDto : AbstractValidator<EcoleACreerDto>
    {
        public ValidateurDeLaCreationDecoleDto()
        {
            Include(new ValidateurDeDtoDecole());
        }
    }
}
