using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Microsoft.EntityFrameworkCore;
using Gesc.Data.Context;
using Gesc.Features.Dtos.Config.Niveaux;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        private readonly SchoolConfigDbContext _context;

        public RepertoireDeNiveau(SchoolConfigDbContext context) : base(context)
        {
            _context = context;
        }

        public bool PeuxAjoutter(Niveau niveauACreer)
        {
            var niveauxDuCycle = _context.Niveaux
                .Include(niv => niv.FiliereCycle)
                .ThenInclude(niv => niv.Cycle)
                .Where(niv => niv.FiliereCycleId == niveauACreer.FiliereCycleId).ToList();

            if(!niveauxDuCycle.Any())
            {
                return true;
            }

            var nbredeNiveauMax = niveauxDuCycle.ElementAt(0).FiliereCycle.Cycle.NbreNiveaux;

            if (niveauxDuCycle.Count < nbredeNiveauMax && !ContientNiveauSimilaire(niveauACreer))
            {
                return true;
            }

            return false;
        }

        private  bool ContientNiveauSimilaire(Niveau niveauACreer)
        {
            var niveauxDuCycle = _context.Niveaux
               .Where(niv => niv.FiliereCycleId == niveauACreer.FiliereCycleId).ToList();

            foreach (var niveaux in niveauxDuCycle)
            {
                if(niveaux.ValeurCycle == niveauACreer.ValeurCycle)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Niveau> LireDetail(Guid id)
        {
            var niveau = await _context.Niveaux
                            .Include(niv => niv.FiliereCycle)
                            .SingleOrDefaultAsync(niv => niv.Id.Equals(id)).ConfigureAwait(false);
            return niveau;
        }

    }
}
