using Gesc.Features.Core.BaseFactoryClass;
using MediatR;
using MsCommun.Reponses;

namespace Gesc.Features.Core.Commandes.Niveaux
{
    public class SupprimerUnNiveauCmd : BaseCommand 
    {
        public Guid Id { get; set; }
    }
}
