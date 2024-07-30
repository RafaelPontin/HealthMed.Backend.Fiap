using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Dominio.Test
{
    public class HorarioTest
    {
        [Fact(DisplayName = "Adicionando um horario valido")]
        public void Criar_Horario_Valido()
        {
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);

            Horarios horarioValido = new Horarios();
            horarioValido.Adicionar(medico, horarioInicioValido, horaioFinalValido);

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
            Usuario medico = GetMedicoInvalido();

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Adicionar(medico, horarioInicioValido, horaioFinalValido);

            Assert.True(horarioInvalido.Erros.Any());
        }


        [Fact(DisplayName = "Adiciona Horario com data Invalida")]
        public void Criar_Horario_Com_Data_Invalida()
        {
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioInvalido = DateTime.Now.AddMinutes(30);
            DateTime horaioFinalInvalido = DateTime.Now;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Adicionar(medico, horarioInicioInvalido, horaioFinalInvalido);

            Assert.True(horarioInvalido.Erros.Any());

        }


        [Fact(DisplayName = "Adiciona Horario com data Iguais")]
        public void Criar_Horario_Com_Data_Iguais()
        {
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioInvalido = DateTime.Now;
            DateTime horaioFinalInvalido = horarioInicioInvalido;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Adicionar(medico, horarioInicioInvalido, horaioFinalInvalido);

            Assert.True(horarioInvalido.Erros.Any());

        }


        [Fact(DisplayName = "Alterar um horario valido")]
        public void Alterar_Horario_Valido()
        {
            Usuario medico = GetMedicoValido();

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
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);
            Guid idHorario = Guid.Empty;

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);

            Assert.True(horarioInvalido.Erros.Any());
        }


        [Fact(DisplayName = "Alterar Horario com usuario invalido")]
        public void Alterarar_Horario_Medico_Invalido()
        {
            Usuario medico = GetMedicoInvalido();

            DateTime horarioInicioValido = DateTime.Now;
            DateTime horaioFinalValido = DateTime.Now.AddMinutes(30);
            Guid idHorario = Guid.NewGuid();

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Alterar(medico, horarioInicioValido, horaioFinalValido, idHorario);

            Assert.True(horarioInvalido.Erros.Any());
        }

        [Fact(DisplayName = "Alterar Horario com data Invalida")]
        public void Alterar_Horario_Com_Data_Invalida()
        {
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioInvalido = DateTime.Now.AddMinutes(30);
            DateTime horaioFinalInvalido = DateTime.Now;
            Guid idHorario = Guid.NewGuid();

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Alterar(medico, horarioInicioInvalido, horaioFinalInvalido, idHorario);

            Assert.True(horarioInvalido.Erros.Any());

        }

        [Fact(DisplayName = "Alterar Horario com data Iguais")]
        public void Alterar_Horario_Com_Data_Iguais()
        {
            Usuario medico = GetMedicoValido();

            DateTime horarioInicioInvalido = DateTime.Now;
            DateTime horaioFinalInvalido = horarioInicioInvalido;
            Guid idHorario = Guid.NewGuid();

            Horarios horarioInvalido = new Horarios();
            horarioInvalido.Alterar(medico, horarioInicioInvalido, horaioFinalInvalido, idHorario);

            Assert.True(horarioInvalido.Erros.Any());

        }


        private Usuario GetMedicoValido() 
                => new Usuario("Medico", "1234567890", "1ab2c3", "email@medico.com", Enum.ETipoUsuario.Medico, "123123");
        
        private Usuario GetMedicoInvalido() =>
            new Usuario("Medico", "1234567890", "1ab2c3", "email@medico.com", Enum.ETipoUsuario.Paciente, "123123");
    }
}
