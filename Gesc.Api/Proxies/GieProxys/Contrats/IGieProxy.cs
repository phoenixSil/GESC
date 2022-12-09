using Gesc.Domain.Modeles.Config;
using MsCommun.Reponses;

namespace Gesc.Api.Proxies.Contrats
{
    public interface IGieProxy
    {
        public Task<ReponseDeRequette> AjoutterNiveau(Niveau result);
    }
}
