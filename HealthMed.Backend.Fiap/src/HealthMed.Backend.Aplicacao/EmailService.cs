using HealthMed.Backend.Aplicacao.Contratos.Servico;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EnviarEmailAsync(EmailAgendamento dadosDoEmail )
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(
                    _configuration["EmailSettings:SenderName"],
                    _configuration["EmailSettings:SenderEmail"]));
                emailMessage.To.Add(new MailboxAddress("", dadosDoEmail.EmailMedico.EnderecoEmail.ToString()));
                emailMessage.Subject = dadosDoEmail.Assunto;
                emailMessage.Body = new TextPart("plain") { Text = dadosDoEmail.Mensagem };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(
                        _configuration["EmailSettings:SmtpServer"],
                        int.Parse(_configuration["EmailSettings:SmtpPort"]),
                        false);
                    await client.AuthenticateAsync(
                        _configuration["EmailSettings:SenderEmail"],
                        _configuration["EmailSettings:SenderPassword"]);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
