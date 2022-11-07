using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Repertoires
{
    public class PointDaccess : IPointDaccess
    {
        private readonly SchoolConfigDbContext _context;
        private IRepertoireDecole _repertoireDecole;
        private IRepertoireDeDepartement _repertoireDeDepartement;
        private IRepertoireDeFiliere _repertoireDeFiliere;
        private IRepertoireDeCycle _repertoireDeCycle;
        private IRepertoireDeFiliereCycle _repertoireDeFiliereCycle;
        private IRepertoireDeNiveau _repertoireDeNiveau;

        public PointDaccess(SchoolConfigDbContext context)
        {
            _context = context;
        }

        public async Task Enregistrer()
        {
            await _context.SaveChangesAsync();
        }

        public IRepertoireDecole RepertoireDecole => _repertoireDecole ??= new RepertoireDecole(_context);
        public IRepertoireDeDepartement RepertoireDeDepartement => _repertoireDeDepartement ??= new RepertoireDeDepartement(_context);
        public IRepertoireDeFiliere RepertoireDeFiliere => _repertoireDeFiliere ??= new RepertoireDeFiliere(_context);
        public IRepertoireDeCycle RepertoireDeCycle => _repertoireDeCycle ??= new RepertoireDeCycle(_context);
        public IRepertoireDeFiliereCycle RepertoireDeFiliereCycle => _repertoireDeFiliereCycle ??= new RepertoireDeFiliereCycle(_context);
        public IRepertoireDeNiveau RepertoireDeNiveau => _repertoireDeNiveau ??= new RepertoireDeNiveau(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
