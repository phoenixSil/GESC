using Gesc.Api.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using MsCommun.Repertoires;

namespace Gesc.Api.Repertoires
{
    public class RepertoireDecole : RepertoireGenerique<Ecole>, IRepertoireDecole
    {
        public RepertoireDecole(SchoolConfigDbContext context) : base(context)
        { }
    }
}
