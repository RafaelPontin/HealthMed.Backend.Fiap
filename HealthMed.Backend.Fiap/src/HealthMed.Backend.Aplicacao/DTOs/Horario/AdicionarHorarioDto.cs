using HealthMed.Backend.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace HealthMed.Backend.Aplicacao.DTOs.Horario
{
    public class AdicionarHorarioDto
    {
        [Required(ErrorMessage = "Horario Inicio é obrigatório.")]
        public DateTime HorarioInicio { get; set; }

        [Required(ErrorMessage = "Horario Final é obrigatório.")]
        public DateTime HorarioFinal { get; set; }
       
    }
}
