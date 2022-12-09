using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Departements;
using Gesc.Features.Core.Commandes.Departements;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Departements
{
    public class SupprimerUnDepartementCmdHdler : BaseCommandHandler<SupprimerUnDepartementCmd>
    {
        public SupprimerUnDepartementCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUnDepartementCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var departement = await _pointDaccess.RepertoireDeDepartement.Lire(request.Id);

            if (departement == null)
                throw new NotFoundException(nameof(Departement), request.Id);

            if (departement != null)
            {
                var resultat = await _pointDaccess.RepertoireDeDepartement.Supprimer(departement);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'departement d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet departement 
                    await _mediator.Send(new SupprimerUnDepartementCmd { Id = departement.Id }, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Une Erreur Inconnu est Survenue dans le Serveur ";
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"il n'existe pas d'departement d'Id {request.Id}";
            }
            return response;
        }
    }
}
