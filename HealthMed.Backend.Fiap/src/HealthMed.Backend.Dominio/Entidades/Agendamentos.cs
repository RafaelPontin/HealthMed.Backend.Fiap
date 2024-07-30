namespace HealthMed.Backend.Dominio.Entidades
{
    public class Agendamentos : Base
    {
        
        public DateTime HorarioCriacao { get; private set; }
        public Usuario Paciente { get; private set; }
        public Horarios Horario { get; private set; }

        public Agendamentos() { }

        public Agendamentos(Usuario paciente, Horarios horario)
        {
            if (!AgendamentoEhValido(paciente, horario))
                Erros.Add($"É necessário informar todos os campos.");

            Paciente = paciente;
            Horario = horario;
            HorarioCriacao = DateTime.Now;
        }
        
        private bool AgendamentoEhValido(Usuario paciente, Horarios horario)
        {
            if (paciente == null)
                Erros.Add("O paciente não pode ser nulo.");

            if (horario == null)
                Erros.Add("O horário não pode ser nulo.");

            if (horario.Disponivel == false)
                Erros.Add("Horário não disponível.");

            return !Erros.Any();
        }
    }
}
