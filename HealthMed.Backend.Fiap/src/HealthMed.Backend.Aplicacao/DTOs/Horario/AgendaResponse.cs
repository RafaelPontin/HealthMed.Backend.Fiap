using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.DTOs.Horario;

public class AgendaResponse
{
    public Guid Id { get; set; }
    public DateTime HorarioInicio { get; set; }
    public DateTime HorarioFinal { get; set; }
    public string NomeMedico { get; set; }
    public Guid MedicoId { get; set; }

    public virtual AgendaResponse ConvertToDto(Horarios agenda)
    {
        Id = agenda.Id;
        HorarioInicio = agenda.HorarioInicio;
        HorarioFinal = agenda.HorarioFinal;
        NomeMedico = agenda.Medico.Nome;
        MedicoId = agenda.Medico.Id;

        return this;
    }



}