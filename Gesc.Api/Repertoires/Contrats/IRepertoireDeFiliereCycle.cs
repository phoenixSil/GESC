using Gesc.Api.Dtos.Config.Niveaux;
using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Api.Repertoires.Contrats
{
    public interface IRepertoireDeFiliereCycle : IRepertoireGenerique<FiliereCycle>
    {
        Task<bool> CustomExists(Guid id);
    }
}
