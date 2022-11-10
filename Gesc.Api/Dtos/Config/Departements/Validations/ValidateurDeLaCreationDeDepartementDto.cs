using FluentValidation;
using Gesc.Api.Dtos.Config.Departements;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Departements.Validations
{
    public class ValidateurDeLaCreationDeDepartementDto : AbstractValidator<DepartementACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDeDepartementDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.EcoleId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var ecoleExists = await _pointDaccess.RepertoireDecole.Exists(id);
                return ecoleExists;
            })
         .WithMessage($" l'Ecole vise nexiste pas dans la base de donnees  ");
            Include(new ValidateurDeDtoDeDepartement());
        }
    }
}
