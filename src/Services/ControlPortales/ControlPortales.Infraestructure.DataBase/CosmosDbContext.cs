using ControlPortales.Domain.AggregatesModel.PuertaAggregate;
using ControlPortales.Infraestructure.DataBase.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.DataBase
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options)
        {
        }

        public DbSet<Puerta> Puertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PuertaEntityTypeConfiguration());
        }
    }
}
