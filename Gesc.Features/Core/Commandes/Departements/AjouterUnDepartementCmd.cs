using Gesc.Features.Dtos.Config.Departements;
using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class AjouterUnDepartementCmd : BaseCommand
    {
        public DepartementACreerDto DepartementAAjouterDto { get; set; }
    }
}
