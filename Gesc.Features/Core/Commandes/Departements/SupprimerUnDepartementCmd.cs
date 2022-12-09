using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class SupprimerUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
