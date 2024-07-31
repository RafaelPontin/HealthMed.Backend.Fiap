using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Servico;
public interface IEmailService
{
    Task<bool> EnviarEmailAsync(EmailAgendamento dadosDoEmail);
}
