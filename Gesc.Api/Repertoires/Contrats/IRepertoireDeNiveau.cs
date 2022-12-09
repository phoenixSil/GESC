using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Api.Repertoires.Contrats
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        public Task<Niveau> LireDetail(Guid id);
    }
}
