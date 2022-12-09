using FluentValidation;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.Niveaux;



namespace Gesc.Features.Dtos.Niveaus.Validations
{
    public class ValidateurDeLaCreationDeNiveauDto : AbstractValidator<NiveauACreerDto>
    {
        private readonly IPointDaccess _pointDaccess;

        public ValidateurDeLaCreationDeNiveauDto(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.FiliereCycleId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var filiereCycleExists = await _pointDaccess.RepertoireDeFiliereCycle.CustomExists(id);
                return filiereCycleExists;
            })
         .WithMessage($" la filiereCycle vise nexiste pas dans la base de donnees  ");
            Include(new ValidateurDeDtoDeNiveau());
        }
    }
}
