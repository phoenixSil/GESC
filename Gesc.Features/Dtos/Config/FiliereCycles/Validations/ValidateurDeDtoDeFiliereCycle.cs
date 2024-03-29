﻿using FluentValidation;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Dtos.Config.FiliereCycles;



namespace Gesc.Features.Dtos.FiliereCycles.Validations
{
    public class ValidateurDeDtoDeFiliereCycle : AbstractValidator<IFiliereCycleDto>
    {
        private readonly IPointDaccess _pointDaccess;
        public ValidateurDeDtoDeFiliereCycle(IPointDaccess pointDaccess)
        {
            _pointDaccess = pointDaccess;

            RuleFor(p => p.FiliereId)
            .NotEmpty()
            .MustAsync(async (id, token) =>
            {
                var filiereExists = await _pointDaccess.RepertoireDeFiliere.Exists(id);
                return filiereExists;
            })
            .WithMessage($" la Filiere vise nexiste pas dans la base de donnees  ");

            RuleFor(p => p.CycleId)
           .NotEmpty()
           .MustAsync(async (id, token) =>
           {
               var cycleExists = await _pointDaccess.RepertoireDeCycle.Exists(id);
               return cycleExists;
           })
            .WithMessage($" le cycle vise nexiste pas dans la base de donnees  ");
        }
    }
}
