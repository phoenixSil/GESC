using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Microsoft.EntityFrameworkCore;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        private readonly SchoolConfigDbContext _context;

        public RepertoireDeNiveau(SchoolConfigDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Niveau> LireDetail(Guid id)
        {
            var niveau = await _context.Niveaux
                            .Include(niv => niv.FiliereCycle.Filiere)
                            .Include(niv => niv.FiliereCycle.Cycle).
                            Where(niv => niv.Id.Equals(id)).FirstOrDefaultAsync();
            return niveau;
        }
    }
}
