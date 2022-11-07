using Gesc.Api.Dtos.Config.Filieres;
using MediatR;
using Gesc.Api.Dtos.Filieres;
using MsCommun.Reponses;

namespace Gesc.Api.Features.Commandes.Filieres
{
    public class ModifierUneFiliereCmd : IRequest<ReponseDeRequette>
    {
        public Guid FiliereId { get; set; }
        public FiliereAModifierDto FiliereAModifierDto { get; set; }
    }
}
