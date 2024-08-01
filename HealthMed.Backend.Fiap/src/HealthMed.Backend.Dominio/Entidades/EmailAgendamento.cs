using HealthMed.Backend.Dominio.Enum;
using HealthMed.Backend.Dominio.ObjetosDeValor;

namespace HealthMed.Backend.Dominio.Entidades;

public class EmailAgendamento
{
    public string NomeMedico { get; private set; }
    public Email EmailMedico { get; private set; }
    public string NomePaciente { get; private set; }
    public DateTime DataHoraConsulta { get; private set; }
    public ETipoMensagem TipoDaMensagem { get; private set; }
    public IList<string> Erros { get; private set; } = new List<string>(); // Inicialização da lista de erros

    public EmailAgendamento(string nomeMedico, Email emailMedico, string nomePaciente, DateTime dataHoraConsulta, ETipoMensagem tipoMensagem)
    {
        ValidarEmailAgendamento(nomeMedico, emailMedico, nomePaciente, dataHoraConsulta, tipoMensagem);

        NomeMedico = nomeMedico;
        NomePaciente = nomePaciente;
        DataHoraConsulta = dataHoraConsulta;
        EmailMedico = emailMedico;
        TipoDaMensagem = tipoMensagem;
    }

    private void ValidarEmailAgendamento(string nomeMedico, Email emailMedico, string nomePaciente, DateTime dataHoraConsulta, ETipoMensagem tipoMensagem)
    {
        if (string.IsNullOrWhiteSpace(nomeMedico))
            Erros.Add("Nome do médico é obrigatório");

        if (emailMedico == null)
            Erros.Add("Email do médico é obrigatório");

        if (string.IsNullOrWhiteSpace(nomePaciente))
            Erros.Add("Nome do paciente é obrigatório");

        if (dataHoraConsulta == default)
            Erros.Add("Data e hora da consulta são obrigatórios");

        if (tipoMensagem == ETipoMensagem.Cancelamento && DateTime.Now.AddHours(24) > dataHoraConsulta)
            Erros.Add("Não é possível cancelar uma consulta com menos de 24 horas de antecedência");
    }

    public string Assunto => TipoDaMensagem switch
    {
        ETipoMensagem.Agendamento => "Health&Med - Nova consulta agendada",
        ETipoMensagem.Cancelamento => "Health&Med - Consulta cancelada",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string Mensagem =>
        TipoDaMensagem switch
        {
            ETipoMensagem.Agendamento => $"Olá, Dr. {NomeMedico}!\n\n" +
                                           "Você tem uma nova consulta marcada!\n" +
                                           $"Paciente: {NomePaciente}.\n" +
                                           $"Data e horário: {DataHoraConsulta:dd/MM/yyyy} às {DataHoraConsulta:HH:mm}.",

            ETipoMensagem.Cancelamento => $"Olá, Dr. {NomeMedico}!\n\n" +
                                           "Sua consulta foi cancelada!\n" +
                                           $"Paciente: {NomePaciente}.\n" +
                                           $"Data e horário: {DataHoraConsulta:dd/MM/yyyy} às {DataHoraConsulta:HH:mm}.",
            _ => throw new ArgumentOutOfRangeException()
        };
}
