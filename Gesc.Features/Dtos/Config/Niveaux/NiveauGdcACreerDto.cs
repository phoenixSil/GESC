namespace Gesc.Features.Dtos.Config.Niveaux
{
    public class NiveauGdcACreerDto 
    {
        public Guid Id { get; set; }
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}
