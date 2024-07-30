using HealthMed.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Configuration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamentos>
    {
        public void Configure(EntityTypeBuilder<Agendamentos> builder)
        {
        }
    }
}
