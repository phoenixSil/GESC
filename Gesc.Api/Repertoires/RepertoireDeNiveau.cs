using Gesc.Api.Modeles;
using Gesc.Api.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using Gesc.Api.Repertoires.Contrats;
using MsCommun.Repertoires;

namespace Gesc.Api.Repertoires
{
    public class RepertoireDeNiveau : RepertoireGenerique<Niveau>, IRepertoireDeNiveau
    {
        public RepertoireDeNiveau(SchoolConfigDbContext context) : base(context)
        { }
    }
}
