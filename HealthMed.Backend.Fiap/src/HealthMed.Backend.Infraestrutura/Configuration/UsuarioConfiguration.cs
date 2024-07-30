using HealthMed.Backend.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.HasMany(x => x.Agendamentos);
            builder.HasMany(x => x.Horarios);
            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.EnderecoEmail)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar(max)");
            });
        }
    }
}


