using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
