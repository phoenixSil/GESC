﻿using Gesc.Domain.Modeles.Config;
using Gesc.Features.Contrats.Repertoires;
using Microsoft.EntityFrameworkCore;
using MsCommun.Repertoires;
using Gesc.Data.Context;

namespace Gesc.Data.Repertoires
{
    public class RepertoireDeDepartement : RepertoireGenerique<Departement>, IRepertoireDeDepartement
    {
        private readonly SchoolConfigDbContext _context;
        public RepertoireDeDepartement(SchoolConfigDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Departement> LireDetailDepartement(Guid id)
        {
            var departement = _context.Departements
                                .Where(x => x.Id.CompareTo(id) == 0)
                                .Include(y => y.Ecole)
                                .Include(z => z.Filieres)
                                .FirstOrDefault();

            return departement;
        }
    }
}