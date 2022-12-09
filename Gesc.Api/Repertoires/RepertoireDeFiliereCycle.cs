using Gesc.Domain.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;

namespace Gesc.Api.Repertoires
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
    }
}
