using HealthMed.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Configuration
{
    public class HorariosConfiguration : IEntityTypeConfiguration<Horarios>
    {
        public void Configure(EntityTypeBuilder<Horarios> builder)
        {
        }
    }
}
