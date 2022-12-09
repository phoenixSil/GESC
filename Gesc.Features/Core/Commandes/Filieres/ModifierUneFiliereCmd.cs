using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class ModifierUneFiliereCmd : BaseCommand 
    {
        public Guid FiliereId { get; set; }
        public FiliereAModifierDto FiliereAModifierDto { get; set; }
    }
}
