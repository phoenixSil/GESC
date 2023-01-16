using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using Gesc.Features.Core.Commandes.FiliereCycles;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;
using System.Net;

namespace Gesc.Features.Core.CommandHandlers.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmdHdler : BaseCommandHandler<SupprimerUneFiliereCycleCmd>
    {
        public SupprimerUneFiliereCycleCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUneFiliereCycleCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var niveau = await _pointDaccess.RepertoireDeFiliereCycle.Lire(request.Id);

            if (niveau is not null)
            {
                var resultat = await _pointDaccess.RepertoireDeFiliereCycle.Supprimer(niveau);
                if (resultat is true)
                {
                    response.Success = true;
                    response.Message = $"la filireCycle d'Id [{request.Id}] a ete supprimer avec success ";
                    response.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas de filireCycle d'Id {request.Id}";
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            return response;
        }
    }
}
