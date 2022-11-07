using MediatR;
using Gesc.Api.Dtos.Cycles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Cycles
{
    public class SupprimerUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
