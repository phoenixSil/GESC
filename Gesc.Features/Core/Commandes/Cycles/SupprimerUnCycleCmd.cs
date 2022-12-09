using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class SupprimerUnCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
