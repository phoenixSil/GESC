using AutoMapper;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using Gesc.Features.Core.Commandes.Filieres;
using Gesc.Domain.Modeles;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Reponses;
using Gesc.Domain.Modeles;
using MsCommun.Exceptions;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.CommandHandlers.Filieres
{
    public class SupprimerUneFiliereCmdHdler : BaseCommandHandler<SupprimerUneFiliereCmd>
    {
        public SupprimerUneFiliereCmdHdler(IPointDaccess pointDaccess, IMediator mediator, IMapper mapper) : base(pointDaccess, mediator, mapper)
        { }

        public async override Task<ReponseDeRequette> Handle(SupprimerUneFiliereCmd request, CancellationToken cancellationToken)
        {
            var response = new ReponseDeRequette();

            var filiere = await _pointDaccess.RepertoireDeFiliere.Lire(request.Id);

            if (filiere == null)
                throw new NotFoundException(nameof(Filiere), request.Id);

            if (filiere != null)
            {
                var resultat = await _pointDaccess.RepertoireDeFiliere.Supprimer(filiere);
                if (resultat == true)
                {
                    response.Success = true;
                    response.Message = $"l'filiere d'Id [{request.Id}] a ete supprimer avec success ";

                    // on supprime la personne associer a cet filiere 
                    await _mediator.Send(new SupprimerUneFiliereCmd { Id = filiere.Id }, cancellationToken).ConfigureAwait(false);
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
                response.Message = $"il n'existe pas d'filiere d'Id {request.Id}";
            }
            return response;
        }
    }
}
