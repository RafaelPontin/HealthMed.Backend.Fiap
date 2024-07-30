using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Horario;

public class HorarioResponse
{
    public Guid Id { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFinal { get; set; }

    public HorarioResponse(Horarios horario)
    {
        Id = horario.Id;
        HorarioInicio = horario.HorarioInicio;  
        HorarioFinal = horario.HorarioFinal;
    }
}
