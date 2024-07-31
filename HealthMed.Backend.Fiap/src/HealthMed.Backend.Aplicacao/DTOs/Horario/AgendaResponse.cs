namespace HealthMed.Backend.Aplicacao.DTOs.Horario;

public class AgendaResponse
{
    public Guid Id { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFinal { get; set; }
    public string NomeMedico { get; set; }
    public Guid MedicoId { get; set; }





}