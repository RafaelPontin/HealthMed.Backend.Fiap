using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
public class NovoAgendamentoDto
{

    [Required(ErrorMessage = "Horário é obrigatório.")]
    public Guid HorarioId { get; set; }
}
