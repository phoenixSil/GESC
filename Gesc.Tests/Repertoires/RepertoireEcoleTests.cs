using FluentAssertions;
using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Domain.Modeles.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.Tests.Repertoires
{
    public class RepertoireEcoleTests
    {
        private SchoolConfigDbContext _context;
        private RepertoireDecole _repertoire;

        public RepertoireEcoleTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);

            _repertoire = new RepertoireDecole(_context);

            Task.Run(() => ViderLaMemoire()).Wait();
        }

        [Fact]
        public async Task Ajouter_DoitBienAjoutterUneEcole()
        {
            var ecole = new Ecole
            {
                Id = Guid.NewGuid(),
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description",
                Designation = "designation",
                Specialite = "Specialite"
            };

            var resultat = await _repertoire.Ajoutter(ecole).ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Ecole>();
            resultat.Id.Should().Be(ecole.Id);
            resultat.Cygle.Should().Be(ecole.Cygle);
            resultat.DateCreation.Should().Be(ecole.DateCreation);
            resultat.DateDerniereModification.Should().Be(ecole.DateDerniereModification);
            resultat.Description.Should().Be(ecole.Description);
            resultat.Designation.Should().Be(ecole.Designation);
            resultat.Specialite.Should().Be(ecole.Specialite);
        }

        [Fact]
        public async Task Ajouter_AvecUnIdNullDoitBienAjoutterUneEcole()
        {
            var ecole = new Ecole
            {
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description",
                Designation = "designation",
                Specialite = "Specialite"
            };

            var resultat = await _repertoire.Ajoutter(ecole).ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Ecole>();
            resultat.Id.Should().Be(ecole.Id);
            resultat.Cygle.Should().Be(ecole.Cygle);
            resultat.DateCreation.Should().Be(ecole.DateCreation);
            resultat.DateDerniereModification.Should().Be(ecole.DateDerniereModification);
            resultat.Description.Should().Be(ecole.Description);
            resultat.Designation.Should().Be(ecole.Designation);
            resultat.Specialite.Should().Be(ecole.Specialite);
        }

        [Fact]
        public async Task Ajouter_AvecUnIdNullNoDateDoitBienAjoutterUneEcole()
        {
            var ecole = new Ecole
            {
                Cygle = "CYGLE",
                Description = "description",
                Designation = "designation",
                Specialite = "Specialite"
            };

            var resultat = await _repertoire.Ajoutter(ecole).ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Ecole>();
            resultat.Id.Should().Be(ecole.Id);
            resultat.Cygle.Should().Be(ecole.Cygle);
            resultat.DateCreation.Should().Be(ecole.DateCreation);
            resultat.DateDerniereModification.Should().Be(ecole.DateDerniereModification);
            resultat.Description.Should().Be(ecole.Description);
            resultat.Designation.Should().Be(ecole.Designation);
            resultat.Specialite.Should().Be(ecole.Specialite);
        }

        [Fact]
        public async Task Modifier_DoitBienModifierUneEcole()
        {
            var ecoleId = Guid.NewGuid();
            await AjoutterLesDonneesEnMemoire(ecoleId);

            var valeurEcoleModifer = new Ecole
            {
                Id = ecoleId,
                Cygle = "CYGLE MODIF",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "descriptiondd",
                Designation = "designation",
                Specialite = "Specialite"
            };

            var oldSchool = await _repertoire.Lire(ecoleId).ConfigureAwait(false);

            oldSchool.Id = valeurEcoleModifer.Id;
            oldSchool.Cygle = valeurEcoleModifer.Cygle;
            oldSchool.DateCreation = valeurEcoleModifer.DateCreation;
            oldSchool.DateDerniereModification = DateTime.Now;
            oldSchool.Description = valeurEcoleModifer.Description;
            oldSchool.Designation = valeurEcoleModifer.Designation;
            oldSchool.Specialite = valeurEcoleModifer.Specialite;


            var resultat = await _repertoire.Modifier(oldSchool).ConfigureAwait(false);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Ecole>();
            resultat.Id.Should().Be(ecoleId);
            resultat.Cygle.Should().Be(valeurEcoleModifer.Cygle);
            resultat.Description.Should().Be(valeurEcoleModifer.Description);
            resultat.Specialite.Should().Be(oldSchool.Specialite);
        }

        [Fact]
        public async Task LireTous_DoitBienRecupererLesDonnees()
        {
            var ecoleId = Guid.NewGuid();
            await AjoutterLesDonneesEnMemoire(ecoleId);
            var resultat = await _repertoire.Lire();

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<List<Ecole>>();
            resultat.Count().Should().Be(2);
        }

        [Fact]
        public async Task LireUnique_DoitBienRecupererLesDonnees()
        {
            var ecoleId = Guid.NewGuid();
            await AjoutterLesDonneesEnMemoire(ecoleId);
            var resultat = await _repertoire.Lire(ecoleId);

            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<Ecole>();
            resultat.Id.Should().Be(ecoleId);
        }

        [Fact]
        public async Task Supprimer_DoitBienSupprimerLesDonnees()
        {
            var ecoleId = Guid.NewGuid();
            await AjoutterLesDonneesEnMemoire(ecoleId);
            var ecole = await _repertoire.Lire(ecoleId);
            var resultat = await _repertoire.Supprimer(ecole);
            var ecoleLst = await _repertoire.Lire();
            var ecoleInexistante = await _repertoire.Lire(ecoleId);

            resultat.Should().BeTrue();
            ecoleLst.Should().BeOfType<List<Ecole>>();
            ecoleLst.Count().Should().Be(1);
            ecoleInexistante.Should().BeNull();
        }


        #region PRIVATE FONCTION CLASS

        private async Task ViderLaMemoire()
        {
            var lstEcole = await _context.Ecoles.ToListAsync();
            foreach (var item in lstEcole)
            {
                await _repertoire.Supprimer(item);
            }
        }

        private async Task AjoutterLesDonneesEnMemoire(Guid neededId)
        {
            var ecole = new Ecole
            {
                Id = neededId,
                Cygle = "CYGLE",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "description",
                Designation = "designation",
                Specialite = "Specialite"
            };
            var ecole2 = new Ecole
            {
                Id = Guid.NewGuid(),
                Cygle = "CYGLE 2",
                DateCreation = DateTime.Now,
                DateDerniereModification = DateTime.Now,
                Description = "descriptionc2",
                Designation = "designation 2",
                Specialite = "Specialite 2"
            };

            await _repertoire.Ajoutter(ecole).ConfigureAwait(false);
            await _repertoire.Ajoutter(ecole2).ConfigureAwait(false);
        }

        #endregion
    }
}
