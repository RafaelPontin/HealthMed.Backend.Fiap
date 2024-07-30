using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Horario;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Backend.API.Controllers
{
    public class HorarioController : BaseController
    {
        private readonly IHorarioService _service;

        public HorarioController(IHorarioService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar-horarios")]
        public async Task<IActionResult> AdicionaHorario([FromBody] AdicionarHorarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informações inválidas");
            }

            var user = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var response = await _service.CadastraHorario(dto, user);
           
            return Ok(response);
        }

        [HttpPut("alterar-horarios")]
        public async Task<IActionResult> AlterarHorario(AlterarHorarioDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informações inválidas");
            }

            var user = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var response = await _service.AlterarHorario(dto, user);


            return Ok(response);
        }

        [HttpPut("horario-indisponivel/{idHorario}")]
        public async Task<IActionResult> AlterarHorarioIndisponivel([FromRoute]Guid idHorario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Informações inválidas");
            }

            var response = await _service.AlterarHorarioDisponivel(idHorario);

            return Ok(response);
        }
    }
}
