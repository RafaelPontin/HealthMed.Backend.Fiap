using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;
using HealthMed.Backend.Dominio.ObjetosDeValor;

namespace HealthMed.Backend.Dominio.Test;
public class EmailAgendamentoTest
{
    [Fact(DisplayName = "Criar email de agendamento válido")]
    public void Criar_Email_Agendamento_Valido()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            emailMedico,
            "Fulano Paciente",
            dataHoraConsulta,
            ETipoMensagem.Agendamento
        );

        Assert.False(emailAgendamento.Erros.Any());
        Assert.Equal("Fulano Médico", emailAgendamento.NomeMedico);
        Assert.Equal(emailMedico, emailAgendamento.EmailMedico);
        Assert.Equal("Fulano Paciente", emailAgendamento.NomePaciente);
        Assert.Equal(dataHoraConsulta, emailAgendamento.DataHoraConsulta);
        Assert.Equal(ETipoMensagem.Agendamento, emailAgendamento.TipoDaMensagem);
    }

    [Fact(DisplayName = "Criar email de agendamento com nome médico vazio")]
    public void Criar_Email_Agendamento_Nome_Medico_Vazio()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "",
            emailMedico,
            "Fulano Paciente",
            dataHoraConsulta,
            ETipoMensagem.Agendamento
        );

        Assert.True(emailAgendamento.Erros.Any(e => e == "Nome do médico é obrigatório"));
    }

    [Fact(DisplayName = "Criar email de agendamento com email médico nulo")]
    public void Criar_Email_Agendamento_Email_Medico_Nulo()
    {
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            null,
            "Fulano Paciente",
            dataHoraConsulta,
            ETipoMensagem.Agendamento
        );

        Assert.True(emailAgendamento.Erros.Any(e => e == "Email do médico é obrigatório"));
    }

    [Fact(DisplayName = "Criar email de agendamento com nome paciente vazio")]
    public void Criar_Email_Agendamento_Nome_Paciente_Vazio()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            emailMedico,
            "",
            dataHoraConsulta,
            ETipoMensagem.Agendamento
        );

        Assert.True(emailAgendamento.Erros.Any(e => e == "Nome do paciente é obrigatório"));
    }

    [Fact(DisplayName = "Criar email de agendamento com data inválida")]
    public void Criar_Email_Agendamento_Data_Invalida()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.MinValue;

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            emailMedico,
            "Fulano Paciente",
            dataHoraConsulta,
            ETipoMensagem.Agendamento
        );

        Assert.True(emailAgendamento.Erros.Any(e => e == "Data e hora da consulta são obrigatórios"));
    }

    [Fact(DisplayName = "Criar email de agendamento para cancelamento com menos de 24 horas de antecedência")]
    public void Criar_Email_Agendamento_Cancelamento_Menos_24_Horas()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            emailMedico,
            "Fulano Paciente",
            dataHoraConsulta,
            ETipoMensagem.Cancelamento
        );

        Assert.True(emailAgendamento.Erros.Any(e => e == "Não é possível cancelar uma consulta com menos de 24 horas de antecedência"));
    }

    [Fact(DisplayName = "Criar email de agendamento com tipo de mensagem inválido")]
    public void Criar_Email_Agendamento_Tipo_Mensagem_Invalido()
    {
        var emailMedico = new Email("fulano@email.com");
        var dataHoraConsulta = DateTime.Now.AddHours(1);

        var emailAgendamento = new EmailAgendamento(
            "Fulano Médico",
            emailMedico,
            "Fulano Paciente",
            dataHoraConsulta,
            (ETipoMensagem)999 // Tipo inválido
        );

        Assert.Throws<ArgumentOutOfRangeException>(() => emailAgendamento.Assunto);
        Assert.Throws<ArgumentOutOfRangeException>(() => emailAgendamento.Mensagem);
    }
}
