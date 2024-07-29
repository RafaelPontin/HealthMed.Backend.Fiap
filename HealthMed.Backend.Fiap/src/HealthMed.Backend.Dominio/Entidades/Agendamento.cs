namespace HealthMed.Backend.Dominio.Entidades
{
    public class Agendamento : Base
    {
        public Guid IdPaciente { get; private set; }
        public Guid IdHorario { get; private set; }
        public DateTime HorarioCriacao { get; private set; }
    }
}
