using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Gesc.Data.Context;
using Gesc.Features.Dtos.Config.Ecole;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDecole : RepertoireGenerique<Ecole>, IRepertoireDecole
    {
        private SchoolConfigDbContext _context;

        public RepertoireDecole(SchoolConfigDbContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<Ecole> Lire(Guid id) 
        { 
            var ecole = await _context.Ecoles
                .Include(ecl => ecl.Departements)
                .FirstOrDefaultAsync(ecl => ecl.Id == id);

            return ecole;
        }
    }
}
