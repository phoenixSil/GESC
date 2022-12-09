using Gesc.Api.Dtos.Config.Departements;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Api.Repertoires.Contrats
{
    public interface IRepertoireDeDepartement : IRepertoireGenerique<Departement>
    {
        public Task<Departement> LireDetailDepartement(Guid id);
    }
}
