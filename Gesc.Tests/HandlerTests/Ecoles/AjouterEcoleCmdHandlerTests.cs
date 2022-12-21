using AutoMapper;
using Castle.Core.Logging;
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
using MsCommun.Reponses;
using MsCommun.Utils;

namespace Gesc.Tests.Handlers.Ecoles
{
    public class AjouterEcoleCmdHandlerTests
    {
        private readonly Mock<IPointDaccess> _pointDaccess;
        private readonly Mock<ILogger<AjouterUneEcoleCmdHdler>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly IMapper _mapper;
        private readonly AjouterUneEcoleCmdHdler _handler;
        private SchoolConfigDbContext _context;
        private readonly RepertoireDecole _repertoire;
        private readonly Guid ecoleId;


        public AjouterEcoleCmdHandlerTests()
        {
            var builder = new DbContextOptionsBuilder<SchoolConfigDbContext>().UseInMemoryDatabase(databaseName: "TestDB")
                               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _context = new SchoolConfigDbContext(builder.Options);


            Task.Run(() => AjoutterLesDonneesEnMemoire()).Wait();

            _pointDaccess = new Mock<IPointDaccess>();
            _logger = new Mock<ILogger<AjouterUneEcoleCmdHdler>>();
            _mediator = new Mock<IMediator>();
            var config = new MapperConfiguration(
                configure => { configure.AddProfile<MappingProf>(); });
            _mapper = config.CreateMapper();
            ecoleId = Guid.NewGuid();
            _handler = new AjouterUneEcoleCmdHdler(_logger.Object, _pointDaccess.Object, _mediator.Object, _mapper);
            _repertoire = new RepertoireDecole(_context);
        }

        [Fact]
        public async Task Handle_DoitBienAjouterUneEcoleALaBase()
        {
            var ecole = new EcoleACreerDto
            {
                Cygle = "Cygle",
                Description = "description",
                Designation = "la designation",
                Specialite = "la specialite"
            };

            var request = new AjouterUneEcoleCmd
            {
                EcoleAAjouterDto = ecole
            };

            _pointDaccess.Setup(
                pa => pa.RepertoireDecole.Ajoutter(It.IsAny<Ecole>()))
                    .ReturnsAsync(new Ecole
                    {
                        Id = Guid.NewGuid(),
                        Cygle = "Cygle",
                        Description = "description",
                        Designation = "la designation",
                        Specialite = "la specialite"
                    });
            var resultat = await _handler.Handle(request, CancellationToken.None).ConfigureAwait(false);
            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<ReponseDeRequette>();
            resultat.Success.Should().BeTrue();
            resultat.Id.Should().NotBeEmpty();

            // _logger.CustomVerify(LogLevel.Information, Times.AtLeast(3));
        }

        [Fact]
        public async Task Handle_DoitRenvoyerUnResultatSuccessFalseSiLajoutNapaMarcher()
        {
            var ecole = new EcoleACreerDto
            {
                Cygle = "C",
                Description = "description",
                Designation = "la designation",
                Specialite = "la specialite"
            };

            var request = new AjouterUneEcoleCmd
            {
                EcoleAAjouterDto = ecole
            };

            var resultat = await _handler.Handle(request, CancellationToken.None).ConfigureAwait(false);
            resultat.Should().NotBeNull();
            resultat.Should().BeOfType<ReponseDeRequette>();
            resultat.Success.Should().BeFalse();
            resultat.Message.Should().BeEquivalentTo("Echec de Lajout dune Ecole ");
            resultat.Errors.Should().NotBeNull();

            // _logger.CustomVerify(LogLevel.Information, Times.AtLeast(3));
        }

        #region PRIVATE FONCTION CLASS

        private async Task AjoutterLesDonneesEnMemoire()
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

            await _context.Ecoles.AddAsync(ecole).ConfigureAwait(false);
            await _context.Ecoles.AddAsync(ecole2).ConfigureAwait(false);
        }

        #endregion

    }
}
