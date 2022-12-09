using MediatR;
using Gesc.Features.Dtos.Ecoles;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Ecoles
{
    public class SupprimerUneEcoleCmd : BaseCommand 
    {
        public Guid Id { get; set; }
    }
}
