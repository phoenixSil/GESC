using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;
using Gesc.Features.Dtos.Config.Departements;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class ModifierUnDepartementCmd : BaseCommand
    {
        public Guid DepartementId { get; set; }
        public DepartementAModifierDto DepartementAModifierDto { get; set; }
    }
}
