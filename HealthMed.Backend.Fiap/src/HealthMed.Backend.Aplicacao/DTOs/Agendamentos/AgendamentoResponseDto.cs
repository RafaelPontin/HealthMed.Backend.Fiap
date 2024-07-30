using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Agendamentos;

public class AgendamentoResponseDto
{
    public Guid Id { get; private set; }
    public DateTime HorarioCriacao { get; private set; }
    public Usuario Paciente { get; private set; }
    public Horarios Horario { get; private set; }
    public AgendamentoResponseDto(Dominio.Entidades.Agendamentos agendamento)
    {
        Id = agendamento.Id;
        HorarioCriacao = agendamento.HorarioCriacao;
        Paciente = agendamento.Paciente;
        Horario = agendamento.Horario;
    }
}
