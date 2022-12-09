using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using MsCommun.Repertoires;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDecole : RepertoireGenerique<Ecole>, IRepertoireDecole
    {
        public RepertoireDecole(SchoolConfigDbContext context) : base(context)
        { }
    }
}
