using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeFiliereCycle : RepertoireGenerique<FiliereCycle>, IRepertoireDeFiliereCycle
    {
        private readonly SchoolConfigDbContext _context;
        public RepertoireDeFiliereCycle(SchoolConfigDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CustomExists(Guid id)
        {
            var filiereCycle = await _context.FiliereCycles.SingleOrDefaultAsync(x => x.Id == id);
            return filiereCycle != null;
        }

        public async Task<FiliereCycle> Lire(Guid id)
        {
            var filiereCycle = await _context.FiliereCycles
                .Include(fc => fc.Filiere)
                .Include(fc => fc.Cycle)
                .Include(fc => fc.Niveaux)
                .SingleOrDefaultAsync(fc => fc.Id == id).ConfigureAwait(false);

            return filiereCycle;
        }
    }
}
