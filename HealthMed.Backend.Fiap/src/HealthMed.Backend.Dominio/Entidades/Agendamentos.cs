namespace HealthMed.Backend.Dominio.Entidades
{
    public class Agendamentos : Base
    {
        public Guid IdPaciente { get; private set; }
        public Guid IdHorario { get; private set; }
        public DateTime HorarioCriacao { get; private set; }
        public Usuario Paciente { get; private set; }

    }
}
