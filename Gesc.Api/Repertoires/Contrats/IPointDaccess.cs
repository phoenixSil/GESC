using Gesc.Api.Repertoires.Contrats;

namespace Gesc.Api.Repertoires.Contrats
{
    public interface IPointDaccess : IDisposable
    {
        IRepertoireDecole RepertoireDecole { get; }
        IRepertoireDeDepartement RepertoireDeDepartement { get; }
        IRepertoireDeFiliere RepertoireDeFiliere { get; }
        IRepertoireDeCycle RepertoireDeCycle { get; }
        IRepertoireDeFiliereCycle RepertoireDeFiliereCycle { get; }
        IRepertoireDeNiveau RepertoireDeNiveau { get; }
        Task Enregistrer();
    }
}
