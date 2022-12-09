using MediatR;
using Gesc.Features.Dtos.Cycles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Cycles
{
    public class SupprimerUnCycleCmd : BaseCommand
    {
        public Guid Id { get; set; }
    }
}
