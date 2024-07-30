using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Usuarios
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Login é obrigatório.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string Senha { get; set; }
    }
}
