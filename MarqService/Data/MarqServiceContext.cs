using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarqService.Models;

namespace MarqService.Data
{
    public class MarqServiceContext : DbContext
    {
        public MarqServiceContext (DbContextOptions<MarqServiceContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnamnesesMedidas>()
                .HasKey(c => new { c.IdAnamnese, c.IdMedidas });
        }

        public DbSet<MarqService.Models.Cliente> Cliente { get; set; }

        public DbSet<MarqService.Models.Massagens> Massagens { get; set; }

        public DbSet<MarqService.Models.Anamnese> Anamnese { get; set; }

        public DbSet<MarqService.Models.Pagamentos> Pagamentos { get; set; }

        public DbSet<MarqService.Models.Medida> Medida { get; set; }
    }
}
