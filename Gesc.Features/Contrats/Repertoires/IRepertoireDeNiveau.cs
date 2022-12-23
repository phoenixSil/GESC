using Gesc.Domain.Modeles;
using Gesc.Domain.Modeles.Config;
using Gesc.Features.Dtos.Config.Niveaux;
using MsCommun.Repertoires.Contrats;

namespace Gesc.Features.Contrats.Repertoires
{
    public interface IRepertoireDeNiveau : IRepertoireGenerique<Niveau>
    {
        public bool PeuxAjoutter(Niveau niveauACreer);
        public Task<Niveau> LireDetail(Guid id);
    }
}
