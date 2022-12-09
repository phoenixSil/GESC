using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class SupprimerUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
