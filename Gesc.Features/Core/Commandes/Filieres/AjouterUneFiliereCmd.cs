using Gesc.Features.Dtos.Config.Filieres;
using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class AjouterUneFiliereCmd : BaseCommand
    {
        public FiliereACreerDto FiliereAAjouterDto { get; set; }
    }
}
