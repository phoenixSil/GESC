using FluentAssertions;
using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Domain.Modeles.Config;
using Microsoft.EntityFrameworkCore;

namespace Gesc.Tests.Repertoires
{
    public class RepertoireDeDepartementTests
    {
        private SchoolConfigDbContext _context;
        private RepertoireDeDepartement _repertoire;
        private Guid _departementId;
        private readonly Guid _ecoleId;

        public RepertoireDeDepartementTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);

            _repertoire = new RepertoireDeDepartement(_context);

            _departementId = Guid.NewGuid();
            _ecoleId = Guid.NewGuid();

            Task.Run(() => ViderLaMemoire()).Wait();
        }

        [Fact]
        public async Task Ajouter_DoitBienAjoutterUnDepartement()
        {
            var departement = new Departement
            {
                Id = Guid.NewGuid(),
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description departement",
                Designation = "designation departement",
            };

            var resultat = await _repertoire.Ajoutter(departement).ConfigureAwait(false);
            var departmentLst = await _repertoire.Lire().ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Departement>();
            resultat.Id.Should().Be(departement.Id);
            resultat.Cygle.Should().Be(departement.Cygle);
            resultat.DateCreation.Should().Be(departement.DateCreation);
            resultat.DateDerniereModification.Should().Be(departement.DateDerniereModification);
            resultat.Description.Should().Be(departement.Description);
            departmentLst.Count().Should().Be(1);
        }

        [Fact]
        public async Task Ajouter_AvecUnIdNullDoitBienAjoutterUnDepartement()
        {
            var departement = new Departement
            {
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description",
                Designation = "designation",
            };

            var resultat = await _repertoire.Ajoutter(departement).ConfigureAwait(false);
            var departmentLst = await _repertoire.Lire().ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Departement>();
            resultat.Id.Should().Be(departement.Id);
            resultat.Cygle.Should().Be(departement.Cygle);
            resultat.DateCreation.Should().Be(departement.DateCreation);
            resultat.DateDerniereModification.Should().Be(departement.DateDerniereModification);
            resultat.Description.Should().Be(departement.Description);
            departmentLst.Count().Should().Be(1);
        }

        [Fact]
        public async Task Ajouter_AvecUnIdNullNoDateDoitBienAjoutterUnDepartement()
        {
            var departement = new Departement
            {
                Cygle = "CYGLE",
                Description = "description",
                Designation = "designation",
            };

            var resultat = await _repertoire.Ajoutter(departement).ConfigureAwait(false);
            var departmentLst = await _repertoire.Lire().ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Departement>();
            resultat.Id.Should().Be(departement.Id);
            resultat.Cygle.Should().Be(departement.Cygle);
            resultat.DateCreation.Should().Be(departement.DateCreation);
            resultat.DateDerniereModification.Should().Be(departement.DateDerniereModification);
            resultat.Description.Should().Be(departement.Description);
            departmentLst.Count().Should().Be(1);
        }

        [Fact]
        public async Task Modifier_DoitBienModifierUnDepartement()
        {
            await AjoutterLesDonneesEnMemoire(_departementId);
            var valeurDepartementModifer = new Departement
            {
                Id = _departementId,
                Cygle = "CYGLE MODIF",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "descriptiondd",
                Designation = "designation",
            };

            var oldSchool = await _repertoire.Lire(_departementId).ConfigureAwait(false);

            oldSchool.Id = valeurDepartementModifer.Id;
            oldSchool.Cygle = valeurDepartementModifer.Cygle;
            oldSchool.DateCreation = valeurDepartementModifer.DateCreation;
            oldSchool.DateDerniereModification = DateTime.Now;
            oldSchool.Description = valeurDepartementModifer.Description;
            oldSchool.Designation = valeurDepartementModifer.Designation;

            var resultat = await _repertoire.Modifier(oldSchool).ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Departement>();
            resultat.Id.Should().Be(_departementId);
            resultat.Cygle.Should().Be(valeurDepartementModifer.Cygle);
            resultat.Description.Should().Be(valeurDepartementModifer.Description);
        }

        [Fact]
        public async Task LireTous_DoitBienRecupererLesDonnees()
        {
            await AjoutterLesDonneesEnMemoire(_departementId);
            var resultat = await _repertoire.Lire();

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<List<Departement>>();
            resultat.Count().Should().Be(2);
        }

        [Fact]
        public async Task LireTousLesDepartementDuneEcole_DoitBienRecupererLesDonnees()
        {
            await AjoutterLesDonneesEnMemoire(_departementId);
            var resultat = await _repertoire.LireDepartementDuneEcole(_ecoleId);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<List<Departement>>();
            resultat.Count().Should().Be(2);
        }

        [Fact]
        public async Task LireUnique_DoitBienRecupererLesDonnees()
        {
            await AjoutterLesDonneesEnMemoire(_departementId);
            var resultat = await _repertoire.Lire(_departementId);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Departement>();
            resultat.Id.Should().Be(_departementId);
        }

        [Fact]
        public async Task Supprimer_DoitBienSupprimerLesDonnees()
        {
            await AjoutterLesDonneesEnMemoire(_departementId);
            var departement = await _repertoire.Lire(_departementId);
            var resultat = await _repertoire.Supprimer(departement);
            var departementLst = await _repertoire.Lire();
            var departementInexistante = await _repertoire.Lire(_departementId);

            resultat.Should().BeTrue();
            departementLst.Should().BeOfType<List<Departement>>();
            departementLst.Count().Should().Be(1);
            departementInexistante.Should().BeNull();
        }


        #region PRIVATE FONCTION CLASS

        private async Task ViderLaMemoire()
        {
            var lstDepartement = await _context.Departements.ToListAsync();
            foreach (var item in lstDepartement)
            {
                await _repertoire.Supprimer(item);
            }
        }

        private async Task AjoutterLesDonneesEnMemoire(Guid neededId)
        {
            var ecole = new Ecole
            {
                Id = _ecoleId,
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description",
                Designation = "designation",
                Specialite = "Specialite"
            };
            var departement = new Departement
            {
                Id = neededId,
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description departement",
                Designation = "designation departement",
                EcoleId = _ecoleId,
            };
            var departement2 = new Departement
            {
                Id = Guid.NewGuid(),
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description departement deux",
                Designation = "designation departement deux ",
                EcoleId = _ecoleId,
            };

            await _context.Ecoles.AddAsync(ecole);
            await _repertoire.Ajoutter(departement).ConfigureAwait(false);
            await _repertoire.Ajoutter(departement2).ConfigureAwait(false);
        }

        #endregion

    }
}
