using MediatR;
using MsCommun.Reponses;
using Gesc.Api.Dtos.Config.Niveaux;

namespace Gesc.Api.Features.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
