using MediatR;
using Gesc.Api.Dtos.Departements;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Departements
{
    public class SupprimerUnDepartementCmd : IRequest<ReponseDeRequette>
    {
        public Guid Id { get; set; }
    }
}
