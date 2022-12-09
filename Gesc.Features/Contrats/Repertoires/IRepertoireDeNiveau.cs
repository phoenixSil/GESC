using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        public Task<Niveau> LireDetail(Guid id);
    }
}
