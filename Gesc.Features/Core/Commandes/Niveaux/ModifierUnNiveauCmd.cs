using MediatR;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Niveaux;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class ModifierUnNiveauCmd : BaseCommand 
    {
        public Guid NiveauId { get; set; }
        public NiveauAModifierDto NiveauAModifierDto { get; set; }
    }
}
