using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Usuarios
{
    public class UsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string CRM { get; set; }

        public UsuarioResponse ConvertToDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            Cpf = usuario.Cpf;
            CRM = usuario.CRM;

            return this;
        }
    }
}
