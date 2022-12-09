using Gesc.Domain.Modeles.Config;
using MsCommun.Reponses;

namespace Gesc.Features.Contrats.Proxies
{
    public interface IGdcProxy
    {
        public Task<ReponseDeRequette> AjoutterNiveau(Niveau result);
    }
}
