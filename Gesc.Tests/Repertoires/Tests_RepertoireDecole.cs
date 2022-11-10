using MediatR;
using Moq;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gesc.Api.Dtos.Config.Ecole;
using Gesc.Api.Services.Contrats;
using Gesc.Api.Services;
using FluentAssertions;
using Gesc.Api.Repertoires.Contrats;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Gesc.Api.Datas;
using Gesc.Api.Repertoires;
using Gesc.Api.Modeles.Config;

namespace Gesc.Tests.Services
{
    public class Tests_RepertoireDecole
    {
        private readonly IRepertoireDecole _repertoire;
        private readonly SchoolConfigDbContext _context;

        public Tests_RepertoireDecole()
        {

            var dbOptions = new DbContextOptionsBuilder<SchoolConfigDbContext>()
                    .UseInMemoryDatabase(databaseName: "testDb")
                    .Options;

            _context = new SchoolConfigDbContext(dbOptions);
            _repertoire = new RepertoireDecole(_context);
        }

        [Fact]
        public async void AjouterUneEcole_Ok()
        {
            var nberCount = _context.Ecoles.Count();
            var dto = new Ecole
            {
                Id = Guid.NewGuid(),
                Designation = "IPES",
                Description = "Ecole Superieur de Technologie ",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle"
            };

            var responseTest = await _repertoire.Ajoutter(dto);
            var currentCount = _context.Ecoles.Count();

            currentCount.Should().BeGreaterThanOrEqualTo(nberCount + 1);
            responseTest.Should().BeOfType<Ecole>();
            responseTest.Designation.Should().BeSameAs("IPES");
        }

        [Fact]
        public async void AjouterUneEcole_DoitAjouterLecoleAvecIdNull()
        {
            var nberCount = _context.Ecoles.Count();
            var dto = new Ecole
            {
                Designation = "IPES",
                Description = "Ecole Superieur de Technologie ",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle"
            };

            var responseTest = await _repertoire.Ajoutter(dto);
            var currentCount = _context.Ecoles.Count();

            currentCount.Should().BeGreaterThanOrEqualTo(nberCount + 1);
            responseTest.Should().BeOfType<Ecole>();
            responseTest.Designation.Should().BeSameAs("IPES");
        }

        [Fact]
        public async Task AjouterUneEcole_DoitThrowSiProprieteObligatoireManquante()
        {
            var nberCount = _context.Ecoles.Count();
            var dto = new Ecole
            {
                Id = Guid.NewGuid(),
                Description = "Ecole Superieur de Technologie ",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle"
            };

            Func<Task> act = async () => await _repertoire.Ajoutter(dto);
            act.Should().ThrowAsync<InvalidOperationException>();
        }

        [Fact]
        public async Task ModifierUneEcole_DoitThrowSiIdInexsitante()
        {
            var ecoleId = Guid.NewGuid();
            var dto = new Ecole
            {
                Id = ecoleId,
                Designation = "IPES",
                Description = "Ecole Superieur de Technologie ",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle"
            };

            var dtoModifier = new Ecole
            {
                Designation = "ISTDI",
                Description = "Institut universitaire De la Cote",
                Cygle = "ISTDI",
                Specialite = "Technologie Industrielle"
            };


            var responseAjout = await _repertoire.Ajoutter(dto);

            Func<Task> act = async () => await _repertoire.Modifier(dtoModifier);

            act.Should().ThrowAsync<InvalidOperationException>();

        }
    }
}
