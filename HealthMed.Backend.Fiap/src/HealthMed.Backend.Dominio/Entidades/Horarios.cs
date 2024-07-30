namespace HealthMed.Backend.Dominio.Entidades;
public class Horarios : Base
{
    public DateTime HorarioInicio { get; private set; }
    public DateTime HorarioFinal {  get; private set; }
    public DateTime HorarioCriacao { get; private set; }

    public Usuario Medico { get; private set; }
}
