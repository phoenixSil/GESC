using MediatR;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class SupprimerUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
