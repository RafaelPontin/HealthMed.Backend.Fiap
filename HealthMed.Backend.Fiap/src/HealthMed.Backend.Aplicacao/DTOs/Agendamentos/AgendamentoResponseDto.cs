using HealthMed.Backend.Aplicacao.DTOs.Horario;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Agendamentos;

public class AgendamentoResponseDto
{
    public Guid Id { get; private set; }
    public DateTime HorarioCriacao { get; private set; }
    public PacienteResponse Paciente { get; private set; }
    public HorarioResponse Horario { get; private set; }
    public AgendamentoResponseDto(Dominio.Entidades.Agendamentos agendamento)
    {
        Id = agendamento.Id;
        HorarioCriacao = agendamento.HorarioCriacao;
        Paciente = new PacienteResponse().ConvertToDto(agendamento.Paciente) as PacienteResponse;
        Horario = new HorarioResponse(agendamento.Horario);
    }
}
