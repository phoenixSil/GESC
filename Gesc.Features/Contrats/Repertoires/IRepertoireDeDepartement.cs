using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeDepartement : IRepertoireGenerique<Departement>
    {
        public Task<Departement> LireDetailDepartement(Guid id);
    }
}
