using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeFiliereCycle : IRepertoireGenerique<FiliereCycle>
    {
        Task<bool> CustomExists(Guid id);
    }
}
