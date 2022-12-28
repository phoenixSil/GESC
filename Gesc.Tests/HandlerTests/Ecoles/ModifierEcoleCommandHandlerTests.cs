using AutoMapper;
using Castle.Core.Resource;
using FluentAssertions;
using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Gesc.Features.Core.Commandes.Ecoles;
using Gesc.Features.Core.CommandHandlers.Ecoles;
using Gesc.Features.Dtos.Config.Ecole;
using Gesc.Features.MappingProfile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MsCommun.Exceptions;
using MsCommun.Reponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.Tests.HandlerTests.Ecoles
{
    public class ModifierEcoleCommandHandlerTests
    {

        private readonly Mock<IPointDaccess> _pointDaccess;
        private readonly Mock<ILogger<ModifierUneEcoleCmdHdler>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly IMapper _mapper;
        private readonly ModifierUneEcoleCmdHdler _handler;
        private SchoolConfigDbContext _context;
        private readonly RepertoireDecole _repertoire;
        private readonly Guid _ecoleId;

        public ModifierEcoleCommandHandlerTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);

            _pointDaccess = new Mock<IPointDaccess>();
            _logger = new Mock<ILogger<ModifierUneEcoleCmdHdler>>();
            _mediator = new Mock<IMediator>();
            var config = new MapperConfiguration(
                configure => { configure.AddProfile<MappingProf>(); });
            _mapper = config.CreateMapper();
            _ecoleId = Guid.NewGuid();
            _handler = new ModifierUneEcoleCmdHdler(_logger.Object, _pointDaccess.Object, _mediator.Object, _mapper);
            _repertoire = new RepertoireDecole(_context);
        }

        [Fact]
        public async Task Handle_ModifierEcole_DoitBienModifierUneEcole()
        {
            await AjoutterLesDonneesEnMemoire();

            var nouvelleEcoleAModifier = new EcoleAModifierDto
            {
                Id = _ecoleId,
                Cygle = "CYGLE",
                Description = "Description Nouvelle",
                Designation = "designation Nouvelle",
                Specialite = "Specialite Nouvelle"
            };


            var request = new ModifierUneEcoleCmd
            {
                EcoleAModifierDto = nouvelleEcoleAModifier,
                EcoleId = _ecoleId
            };

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
               pa => pa.RepertoireDecole.Modifier(It.IsAny<Ecole>()))
                   .ReturnsAsync(new Ecole
                   {
                       Id = _ecoleId,
                       Cygle = nouvelleEcoleAModifier.Cygle,
                       Description = nouvelleEcoleAModifier.Description,
                       Designation = nouvelleEcoleAModifier.Designation,
                       Specialite = nouvelleEcoleAModifier.Specialite
                   });

            var resultat = await _handler.Handle(request, CancellationToken.None).ConfigureAwait(false);
            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<ReponseDeRequette>();
            resultat.Success.Should().BeTrue();
            resultat.Id.Should().NotBeEmpty();
            resultat.Id.Should().Be(_ecoleId);
            resultat.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }


        [Fact]
        public async Task Handle_ModifierEcole_DoitLeverUneExceptionSiDonneeInvalide()
        {
            await AjoutterLesDonneesEnMemoire();

            var nouvelleEcoleAModifier = new EcoleAModifierDto
            {
                Id = _ecoleId,
                Cygle = "C",
                Description = "",
                Designation = "",
                Specialite = ""
            };
            var request = new ModifierUneEcoleCmd
            {
                EcoleAModifierDto = nouvelleEcoleAModifier,
                EcoleId = _ecoleId
            };

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

            var act = () => _handler.Handle(request, CancellationToken.None).ConfigureAwait(false);
            act.Should().Throw<ValidationException>();
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

            await _context.Ecoles.AddRangeAsync(ecole,ecole2).ConfigureAwait(false);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}
