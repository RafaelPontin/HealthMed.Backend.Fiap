using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Dominio.Test
{
    public class AgendamentoTest
    {
        [Fact(DisplayName = "Adiciona agendamento Valido")]
        public void Adicionar_Agendamento_Valido()
        {
            var paciente = GetPacienteValido();
            var medico = GetMedicoValido();
            DateTime horarioInicioValido = DateTime.Now.AddMinutes(30);
            DateTime horaioFinalValido = DateTime.Now;
            Guid idHorario = Guid.NewGuid();

            Horarios horario = new Horarios();
            horario.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);

            Agendamentos agendamentos = new Agendamentos(paciente,horario);


            Assert.False(agendamentos.Erros.Any());
        }

        [Fact(DisplayName = "Adiciona agendamento invalido")]
        public void Adicionar_Agendamento_Invalido()
        {
            var paciente = GetPacienteValido();
            var medico = GetMedicoValido();
            DateTime horarioInicioValido = DateTime.Now.AddMinutes(30);
            DateTime horaioFinalValido = DateTime.Now;
            Guid idHorario = Guid.NewGuid();

            Horarios horario = new Horarios();
            horario.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);
            horario.HorarioIndisponivel();

            Agendamentos agendamentos = new Agendamentos(paciente, horario);

            Assert.True(agendamentos.Erros.Any()); 
        }


        private Usuario GetPacienteValido() => new Usuario("paciente Teste", "1234567890", "123123", "paciente@mail.com", ETipoUsuario.Paciente);

        private Usuario GetMedicoValido() => new Usuario("Medico", "1234567890", "1ab2c3", "email@medico.com", Enum.ETipoUsuario.Medico, "123123");
    }
}
