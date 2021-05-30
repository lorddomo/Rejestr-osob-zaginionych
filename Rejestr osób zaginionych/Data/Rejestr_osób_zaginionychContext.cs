using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rejestr_osób_zaginionych.Models;

namespace Rejestr_osób_zaginionych.Data
{
    public class Rejestr_osób_zaginionychContext : DbContext
    {
        public Rejestr_osób_zaginionychContext (DbContextOptions<Rejestr_osób_zaginionychContext> options)
            : base(options)
        {
        }

        public DbSet<Rejestr_osób_zaginionych.Models.LostViewModel> LostViewModel { get; set; }
    }
}
