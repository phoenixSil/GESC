using MediatR;
using Gesc.Api.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Ecoles
{
    public class SupprimerUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
