using MediatR;
using Gesc.Features.Dtos.Ecoles;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class SupprimerUneEcoleCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
