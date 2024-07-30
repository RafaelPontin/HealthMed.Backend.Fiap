using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Backend.API.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar-medico")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarMedicoAsync(CadastrarMedicoDto request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Informações inválidas");
            }

            var response = await _usuarioService.CadastrarMedico(request);

            return Ok(response);
        }

        [HttpPost("cadastrar-paciente")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarPacienteAsync(CadastrarPacienteDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informações inválidas");
            }

            var response = await _usuarioService.CadastrarPaciente(request);

            return Ok(response);
        }
    }
}
