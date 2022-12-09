using FluentValidation;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Departements;



namespace Gesc.Features.Dtos.Departements.Validations
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
