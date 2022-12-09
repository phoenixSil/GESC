using MediatR;
using Gesc.Features.Dtos.FiliereCycles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.FiliereCycles
{
    public class SupprimerUneFiliereCycleCmd : BaseCommand 
    {
        public Guid Id { get; set; }
    }
}
