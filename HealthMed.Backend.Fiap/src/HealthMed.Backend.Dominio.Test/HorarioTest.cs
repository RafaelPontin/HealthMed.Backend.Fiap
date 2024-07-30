using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Dominio.Test
{
    public class HorarioTest
    {
        [Fact(DisplayName = "Adicionando um horario valido")]
        public void Criar_Horario_Valido()
        {
            Usuario medico = new Usuario() { 
                TipoUsuario = Enum.ETipoUsuario.Medico,
            };

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);

            Horarios horarioValido = new Horarios();
            horarioValido.AdicionarHorario(medico, horarioInicioValido, horaioFinalValido);

            Assert.False(horarioValido.Id == Guid.Empty);
            Assert.Equal(horarioValido.HorarioInicio, horarioInicioValido);
            Assert.Equal(horarioValido.HorarioFinal, horaioFinalValido);
            Assert.NotNull(horarioValido.Medico);
            Assert.NotNull(horarioValido.HorarioCriacao);
            Assert.False(horarioValido.Erros.Any());
        }

        [Fact(DisplayName = "Adicionar Horario com usuario invalido")]
        public void Criar_Horario_Medico_Invalido()
        {
            Usuario medico = new Usuario()
            {
                TipoUsuario = Enum.ETipoUsuario.Paciente,
            };

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.AdicionarHorario(medico, horarioInicioValido, horaioFinalValido);

            Assert.True(horarioInvalido.Erros.Any());
        }


        [Fact(DisplayName = "Adiciona Horario com data Invalida")]
        public void Criar_Horario_Com_Data_Invalida()
        {
            Usuario medico = new Usuario()
            {
                TipoUsuario = Enum.ETipoUsuario.Medico,
            };

            DateTime horarioInicioInvalido = DateTime.Now.AddMinutes(30);
            DateTime horaioFinalInvalido = DateTime.Now;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.AdicionarHorario(medico, horarioInicioInvalido, horaioFinalInvalido);

            Assert.True(horarioInvalido.Erros.Any());

        }


        [Fact(DisplayName = "Adiciona Horario com data Iguais")]
        public void Criar_Horario_Com_Data_Iguais()
        {
            Usuario medico = new Usuario()
            {
                TipoUsuario = Enum.ETipoUsuario.Medico,
            };

            DateTime horarioInicioInvalido = DateTime.Now;
            DateTime horaioFinalInvalido = horarioInicioInvalido;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.AdicionarHorario(medico, horarioInicioInvalido, horaioFinalInvalido);

            Assert.True(horarioInvalido.Erros.Any());

        }


        [Fact(DisplayName = "Alterar um horario valido")]
        public void Alterar_Horario_Valido()
        {
            Usuario medico = new Usuario()
            {
                TipoUsuario = Enum.ETipoUsuario.Medico,
            };

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);
            Guid idHorario = Guid.NewGuid();

            Horarios horarioValido = new Horarios();
            horarioValido.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);

            Assert.False(horarioValido.Id == Guid.Empty);
            Assert.Equal(horarioValido.HorarioInicio, horarioInicioValido);
            Assert.Equal(horarioValido.HorarioFinal, horaioFinalValido);
            Assert.NotNull(horarioValido.Medico);
            Assert.NotNull(horarioValido.HorarioCriacao);
            Assert.False(horarioValido.Erros.Any());
        }


        [Fact(DisplayName = "Alterar horario invalido")]
        public void Alterar_Horario_Guid_Vazio()
        {
            Usuario medico = new Usuario()
            {
                TipoUsuario = Enum.ETipoUsuario.Medico,
            };

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);
            Guid idHorario = Guid.Empty;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);

            Assert.True(horarioInvalido.Erros.Any());
        }

    }
}
