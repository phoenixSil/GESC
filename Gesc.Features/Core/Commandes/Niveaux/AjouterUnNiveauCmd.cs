using Gesc.Features.Core.BaseFactoryClass;
using Gesc.Features.Dtos.Config.Niveaux;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class AjouterUnNiveauCmd : BaseCommand
    {
        public NiveauACreerDto NiveauAAjouterDto { get; set; }
    }
}
