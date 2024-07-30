namespace HealthMed.Backend.Dominio.Entidades
{
    public class Agendamentos : Base
    {
        
        public DateTime HorarioCriacao { get; private set; }
        public Usuario Paciente { get; private set; }
        public Horarios Horarios { get; private set; }
        
    }
}
