using Gesc.Api.Datas;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Repertoires;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Gesc.Api.Modeles.Config;

namespace Gesc.Tests.Repertoires
{
    public class Tests_RepertoireDeDepartement
    {
        private readonly IRepertoireDeDepartement _repertoire;
        private readonly SchoolConfigDbContext _context;
        private readonly Guid _ecoleId;
        private readonly Guid _departementId;

        public Tests_RepertoireDeDepartement()
        {
            _ecoleId = Guid.NewGuid();
            _departementId = Guid.NewGuid();
            var dbOptions = new DbContextOptionsBuilder<SchoolConfigDbContext>()
                    .UseInMemoryDatabase(databaseName: "testDb")
                    .Options;

            _context = new SchoolConfigDbContext(dbOptions);
            _repertoire = new RepertoireDeDepartement(_context);
            ConfigurationBaseDeDonnee();
        }

        [Fact]
        public async void AjouterUnDepartement_Ok()
        {
            var nberCount = _context.Departements.Count();
            var dto = new Departement
            {
                Id = Guid.NewGuid(),
                Designation = "DGI",
                Description = "Departement de Genie Informatique",
                Cygle = "DGI",
                EcoleId = _ecoleId
            };

            var responseTest = await _repertoire.Ajoutter(dto);
            var currentCount = _context.Departements.Count();

            currentCount.Should().BeGreaterThanOrEqualTo(nberCount + 1);
            responseTest.Should().BeOfType<Departement>();
            responseTest.Designation.Should().BeSameAs("DGI");
        }

        [Fact]
        public async void AjouterUnDepartement_DoitAjoutterMemeSiIDestInexistante()
        {
            var nberCount = _context.Departements.Count();
            var dto = new Departement
            {
                Designation = "DGI",
                Description = "Departement de Genie Informatique",
                Cygle = "DGI",
                EcoleId = _ecoleId
            };

            var responseTest = await _repertoire.Ajoutter(dto);
            var currentCount = _context.Departements.Count();

            currentCount.Should().BeGreaterThanOrEqualTo(nberCount + 1);
            responseTest.Should().BeOfType<Departement>();
            responseTest.Designation.Should().BeSameAs("DGI");
        }


        [Fact]
        public async Task AjouterUnDepartement_DoitThrowSiProprieteObligatoireManquante()
        {
            var dto = new Departement
            {

                Id = Guid.NewGuid(),
                Description = "Departement de Genie Informatique",
                EcoleId = _ecoleId
            };

            Func<Task> act = async () => await _repertoire.Ajoutter(dto);
            act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task LireTousLesDepartement_200Ok()
        {
            var responseList = await _repertoire.Lire();

            responseList.Should().BeOfType<List<Departement>>();
            responseList.Count().Should().BeGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task LireUnDepartement_200Ok()
        {

            var reponseDept = await _repertoire.Lire(_departementId);

            reponseDept.Should().BeOfType<Departement>();
            reponseDept.Should().NotBeNull();
            reponseDept.Id.Should().NotBeEmpty();
            reponseDept.Id.Should().Be(_departementId);
            reponseDept.EcoleId.Should().Be(_ecoleId);
        }

        private void ConfigurationBaseDeDonnee()
        {
            var dto = new Ecole
            {
                Id = _ecoleId,
                Designation = "IPES",
                Description = "Ecole Superieur de Technologie ",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle",
                Departements = new List<Departement>
                {
                    new Departement {
                        Id = _departementId,
                        Designation = "DGE",
                        Description = "Departement de Genie Electrique",
                        Cygle = "DGE",
                        EcoleId = _ecoleId
                    } 
                }
            };

            _context.Ecoles.Add(dto);
            _context.SaveChanges();
        }
    }
}
