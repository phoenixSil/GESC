using MediatR;
using Gesc.Features.Dtos.Filieres;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Filieres
{
    public class SupprimerUneFiliereCmd : BaseCommand 
    {
        public Guid Id { get; set; }
    }
}
