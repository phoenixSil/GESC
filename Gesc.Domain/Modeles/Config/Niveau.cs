using Gesc.Domain.Modeles;

namespace Gesc.Domain.Modeles.Config
{
    public class Niveau : BaseEntite
    {
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid FiliereCycleId { get; set; }
        public virtual FiliereCycle FiliereCycle { get; set; }
    }
}
