using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Repertoires;
using Microsoft.EntityFrameworkCore;

namespace Gesc.Api.Repertoires
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
