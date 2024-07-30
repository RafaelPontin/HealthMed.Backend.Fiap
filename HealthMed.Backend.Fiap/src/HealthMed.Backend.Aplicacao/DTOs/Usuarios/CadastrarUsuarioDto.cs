using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Usuarios
{
    public class CadastrarUsuarioDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }        

        [Required(ErrorMessage = "Confirmação de senha é obrigatório.")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
        public string Senha { get; set; }        
    }

    public class CadastrarPacienteDto: CadastrarUsuarioDto { }
    public class CadastrarMedicoDto: CadastrarUsuarioDto 
    {
        [Required(ErrorMessage = "CRM é obrigatório.")]
        public string CRM { get; set; }
    }
}
