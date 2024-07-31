using HealthMed.Backend.Dominio.Enum;
using HealthMed.Backend.Dominio.ObjetosDeValor;

namespace HealthMed.Backend.Dominio.Entidades;
public class EmailAgendamento
{
    public string NomeMedico { get; private set; }
    public Email EmailMedico { get; private set; }
    public string NomePaciente { get; private set; }
    public DateTime DataHoraConsulta { get; private set; }
    public ETipoMensangem TipoDaMensangem { get; private set; }

    public EmailAgendamento(string nomeMedico, Email emailMedico, string nomePaciente, DateTime dataHoraConsulta, ETipoMensangem tipoMensangem)
    {
        NomeMedico = nomeMedico;
        NomePaciente = nomePaciente;
        DataHoraConsulta = dataHoraConsulta;
        EmailMedico = emailMedico;
        TipoDaMensangem = tipoMensangem;
    }

    public string Assunto => TipoDaMensangem switch
    {
        ETipoMensangem.Agendamento => "HealthMed - Nova consulta agendada",

        ETipoMensangem.Cancelamento => "HealthMed - Consulta cancelada",
        _ => throw new ArgumentOutOfRangeException()
    };

    public string Mensagem =>
        TipoDaMensangem switch
        {
            ETipoMensangem.Agendamento => $"Olá, Dr. {NomeMedico}!\n\n" +
                                           "Você tem uma nova consulta marcada!\n" +
                                          $"Paciente: {NomePaciente}.\n" +
                                          $"Data e horário: {DataHoraConsulta:dd/MM/yyyy} às {DataHoraConsulta:HH:mm}.",

            ETipoMensangem.Cancelamento => $"Olá, Dr. {NomeMedico}!\n\n" +
                                            "Sua consulta foi cancelada!\n" +
                                           $"Paciente: {NomePaciente}.\n" +
                                           $"Data e horário: {DataHoraConsulta:dd/MM/yyyy} às {DataHoraConsulta:HH:mm}.",
            _ => throw new ArgumentOutOfRangeException()
        };
}
