using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Domain.Modeles.Config;
using Microsoft.EntityFrameworkCore;

namespace Gesc.Tests.RepertoireTests
{
    public class RepertoireDeNiveauxTests
    {
        private SchoolConfigDbContext _context;
        private RepertoireDeNiveau _repertoire;
        private readonly Guid _filiereCycleId;

        public RepertoireDeNiveauxTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);

            _repertoire = new RepertoireDeNiveau(_context);

            _filiereCycleId = Guid.NewGuid();

            Task.Run(() => ViderLaMemoire()).Wait();
            Task.Run(() => AjoutterLesDonneesEnMemoire(default));
        }

       

        #region PRIVATE FONCTION CLASS

        private async Task ViderLaMemoire()
        {
            var lstNiveau = await _context.Niveaux.ToListAsync();
            foreach (var item in lstNiveau)
            {
                await _repertoire.Supprimer(item);
            }
        }

        private async Task AjoutterLesDonneesEnMemoire(Guid neededId)
        {
            var niveau = new Niveau
            {
                Id = neededId == default ? Guid.NewGuid(): neededId,
                ValeurCycle = 1,
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Designation = "designation",
                FiliereCycleId = _filiereCycleId
            };
            var niveau2 = new Niveau
            {
                Id = Guid.NewGuid(),
                ValeurCycle = 2,
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Designation = "designation",
                FiliereCycleId = _filiereCycleId
            };
            await _repertoire.Ajoutter(niveau);
            await _repertoire.Ajoutter(niveau2);
        }

        #endregion
    }
}
