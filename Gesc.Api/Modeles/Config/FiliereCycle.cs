﻿using Gesc.Api.Modeles;
using Microsoft.Extensions.Hosting;

namespace Gesc.Api.Modeles.Config
{
    public class FiliereCycle : BaseEntite
    {
        public Guid FiliereId { get; set; }
        public virtual Filiere Filiere { get; set; }
        public Guid CycleId { get; set; }
        public virtual Cycle Cycle { get; set; }
        public virtual List<Niveau> Niveaux { get; set; }
    }
}
