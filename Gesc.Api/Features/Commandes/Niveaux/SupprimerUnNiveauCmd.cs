using MediatR;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class SupprimerUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
