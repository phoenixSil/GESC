using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeCycle : RepertoireGenerique<Cycle>, IRepertoireDeCycle
    {
        public RepertoireDeCycle(SchoolConfigDbContext context) : base(context)
        { }
    }
}
