using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gesc.Features.Dtos.Config.Niveaux
{
    public class NiveauGieACreerDto 
    { 
        public Guid Id { get; set; }
        public int ValeurCycle { get; set; }
        public string Designation { get; set; }
        public Guid NumeroExterne { get; set; }
        public string DesignationFiliere { get; set; }
        public string DesignationCycle { get; set; }
    }
}