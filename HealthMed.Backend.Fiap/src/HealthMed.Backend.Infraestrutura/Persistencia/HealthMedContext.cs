using HealthMed.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Persistencia
{
    public class HealthMedContext : DbContext
    {
        public HealthMedContext(DbContextOptions<HealthMedContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthMedContext).Assembly);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
    }
}
