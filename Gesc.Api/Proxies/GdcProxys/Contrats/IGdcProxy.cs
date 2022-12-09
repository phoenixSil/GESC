using Gesc.Domain.Modeles.Config;
using MsCommun.Reponses;

namespace Gesc.Api.Proxies.GdcProxys.Contrats
{
    public interface IGdcProxy
    {
        public Task<ReponseDeRequette> AjoutterNiveau(Niveau result);
    }
}
