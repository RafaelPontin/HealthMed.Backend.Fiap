using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.Backend.API.Controllers;

[Authorize(Roles = "Paciente")]
public class AgendamentoController : BaseController
{
    private readonly IAgendamentoService _agendamentoService;

    public AgendamentoController(IAgendamentoService agendamentoService)
    {
        _agendamentoService = agendamentoService;
    }

    [HttpGet("ObterAgendamentoPorPaciente")]
    public async Task<IActionResult> ObterAgendamentosPorPaciente()
    {
        var user = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        var response = await _agendamentoService.ObterAgendamentosPorPaciente(user);

        return StatusCode(response.Status, response);
    }

    [HttpPost("NovoAgendamento")]
    public async Task<IActionResult> NovoAgendamento(NovoAgendamentoDto dto)
    {
        var user = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        var response = await _agendamentoService.NovoAgendamento(dto,user);

        return StatusCode(response.Status, response);
    }

    [HttpDelete("CancelarAgendamento/{idAgendamento}")]
    public async Task<IActionResult> CancelarAgendamento(Guid idAgendamento)
    {
        var response = await _agendamentoService.CancelarAgendamento(idAgendamento);

        return StatusCode(response.Status, response);
    }

}
