using FluentValidation;
using Gesc.Api.Dtos.Config.Filieres;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Dtos.Filieres.Validations
{
    public class ValidateurDeLaCreationDeFiliereDto : AbstractValidator<FiliereACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeLaCreationDeFiliereDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.DepartementId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var departementExists = await _pointDaccess.RepertoireDeDepartement.Exists(id);
                return departementExists;
            })
         .WithMessage($" le departement vise nexiste pas dans la base de donnees  ");
            Include(new ValidateurDeDtoDeFiliere());
        }
    }
}
