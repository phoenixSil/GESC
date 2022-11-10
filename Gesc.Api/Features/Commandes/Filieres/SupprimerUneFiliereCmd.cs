using MediatR;
using Gesc.Api.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Filieres
{
    public class SupprimerUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
