using MediatR;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Niveaux;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : IRequest<ReponseDeRequette>
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
