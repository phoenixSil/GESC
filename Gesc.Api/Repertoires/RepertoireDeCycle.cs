using Gesc.Domain.Modeles.Config;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using MsCommun.Repertoires;

namespace Gesc.Api.Repertoires
{
    public class RepertoireDeCycle : RepertoireGenerique<Cycle>, IRepertoireDeCycle
    {
        public RepertoireDeCycle(SchoolConfigDbContext context) : base(context)
        { }
    }
}
