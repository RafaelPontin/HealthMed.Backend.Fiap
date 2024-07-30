using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Usuarios
{
    public abstract class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string CRM { get; set; }

        public virtual UsuarioResponse ConvertToDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Cpf = usuario.Cpf;            

            return this;
        }
    }


    public class PacienteResponse : UsuarioResponse
    {
        public override UsuarioResponse ConvertToDto(Usuario usuario)
        {
            return base.ConvertToDto(usuario);
        }
    }
    public class MedicoResponse : UsuarioResponse
    {
        public override UsuarioResponse ConvertToDto(Usuario usuario)
        {
            CRM = usuario.CRM;
            return base.ConvertToDto(usuario);
        }
    }
}
