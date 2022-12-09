using Gesc.Features.Dtos.Config.Ecole;
using MediatR;
using Gesc.Features.Dtos.Ecoles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class ModifierUneEcoleCmd : BaseCommand 
    {
        public Guid EcoleId { get; set; }
        public EcoleAModifierDto EcoleAModifierDto { get; set; }
    }
}
