using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class ModifierUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public Guid FiliereId { get; set; }
        public FiliereAModifierDto FiliereAModifierDto { get; set; }
    }
}
