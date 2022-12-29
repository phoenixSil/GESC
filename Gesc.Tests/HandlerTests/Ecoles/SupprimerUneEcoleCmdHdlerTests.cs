﻿using AutoMapper;
using FluentAssertions;
using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Core.CommandHandlers.Ecoles;
using Gesc.Features.MappingProfile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.Tests.HandlerTests.Ecoles
{
    public class SupprimerUneEcoleCmdHdlerTests
    {
        private readonly Mock<IPointDaccess> _pointDaccess;
        private readonly Mock<ILogger<SupprimerUneEcoleCmdHdler>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly IMapper _mapper;
        private readonly SupprimerUneEcoleCmdHdler _handler;
        private SchoolConfigDbContext _context;
        private readonly RepertoireDecole _repertoire;
        private readonly Guid _ecoleId;

        public SupprimerUneEcoleCmdHdlerTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);


            Task.Run(() => AjoutterLesDonneesEnMemoire()).Wait();

            _pointDaccess = new Mock<IPointDaccess>();
            _logger = new Mock<ILogger<SupprimerUneEcoleCmdHdler>>();
            _mediator = new Mock<IMediator>();
            var config = new MapperConfiguration(
                configure => { configure.AddProfile<MappingProf>(); });
            _mapper = config.CreateMapper();
            _ecoleId = Guid.NewGuid();
            _handler = new SupprimerUneEcoleCmdHdler(_logger.Object, _pointDaccess.Object, _mediator.Object, _mapper);
            _repertoire = new RepertoireDecole(_context);
        }

        [Fact]
        public async Task Handle_SupprimerUneEcole_DoitBienSupprimerLecole()
        {
            await AjoutterLesDonneesEnMemoire();
            var request = new SupprimerUneEcoleCmd
            {
                Id = _ecoleId
            };

            var ecoles = _context.Ecoles.ToList();

            _pointDaccess.Setup(
             pa => pa.RepertoireDecole.Lire(It.IsAny<Guid>()))
                 .ReturnsAsync(new Ecole
                 {

                     Id = _ecoleId,
                     Cygle = "CYGLE",
                     DateCreation = DateTime.Now,
                     DateDerniereModification = DateTime.Now,
                     Description = "description",
                     Designation = "designation",
                     Specialite = "Specialite"
                 });

            _pointDaccess.Setup(
            pa => pa.RepertoireDecole.Supprimer(It.IsAny<Ecole>()))
                .ReturnsAsync(true);

            var resultat = await _handler.Handle(request, CancellationToken.None).ConfigureAwait(false);

            resultat.Should().BeOfType<ReponseDeRequette>();
            resultat.Success.Should().BeTrue();
            resultat.StatusCode.Should().Be((int)HttpStatusCode.OK);
            resultat.Id.Should().Be(_ecoleId);
        }

        #region PRIVATE FONCTION CLASS

        private async Task AjoutterLesDonneesEnMemoire()
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

            await _context.Ecoles.AddRangeAsync(ecole, ecole2).ConfigureAwait(false);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
