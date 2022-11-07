using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Numerics;

namespace Gesc.Api.Datas
{
    public class SchoolConfigDbContext : DbContext
    {
        public SchoolConfigDbContext(DbContextOptions<SchoolConfigDbContext> options) : base(options)
        {}

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntite>())
            {
                entry.Entity.DateDerniereModification = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreation = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolConfigDbContext).Assembly);
        }

        public DbSet<Ecole> Ecoles { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<FiliereCycle> FiliereCycles { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
    }
}
