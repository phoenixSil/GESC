using Gesc.Domain.Modeles.Config;
using MsCommun.Reponses;

namespace Gesc.Features.Contrats.Proxies
{
    public interface IGieProxy
    {
        public Task<ReponseDeRequette> AjoutterNiveau(Niveau result);
    }
}
