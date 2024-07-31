using HealthMed.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Configuration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamentos>
    {
        public void Configure(EntityTypeBuilder<Agendamentos> builder)
        {
            builder.ToTable("Agendamentos");
            builder.HasKey(a => a.Id);
            builder.HasOne(x => x.Paciente);
            builder.HasOne(x => x.Horario);
            builder.Property(x => x.HorarioCriacao).HasColumnType("datetime").IsRequired();
        }
    }
}
