using MediatR;
using Gesc.Api.Dtos.FiliereCycles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
