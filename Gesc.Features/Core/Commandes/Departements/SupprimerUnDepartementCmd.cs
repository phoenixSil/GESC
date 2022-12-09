using MediatR;
using Gesc.Features.Dtos.Departements;
using MsCommun.Reponses;
using Gesc.Features.Core.BaseFactoryClass;

namespace Gesc.Features.Core.Commandes.Departements
{
    public class SupprimerUnDepartementCmd : BaseCommand
    {
        public Guid Id { get; set; }
    }
}
