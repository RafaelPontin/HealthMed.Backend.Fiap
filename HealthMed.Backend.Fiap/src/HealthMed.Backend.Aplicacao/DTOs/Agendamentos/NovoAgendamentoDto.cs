using HealthMed.Backend.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
public class NovoAgendamentoDto
{
    [Required(ErrorMessage = "Paciente é obrigatório.")]
    public Usuario Paciente { get; private set; }

    [Required(ErrorMessage = "Horário é obrigatório.")]
    public Horarios Horario { get; private set; }
}
