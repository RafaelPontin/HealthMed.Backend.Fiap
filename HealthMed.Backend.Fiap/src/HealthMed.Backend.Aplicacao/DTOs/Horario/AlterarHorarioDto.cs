using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Horario;
public class AlterarHorarioDto : AdicionarHorarioDto
{
    [Required(ErrorMessage = "Horario Id é obrigatório.")]
    public Guid IdHorario { get; set; }
}