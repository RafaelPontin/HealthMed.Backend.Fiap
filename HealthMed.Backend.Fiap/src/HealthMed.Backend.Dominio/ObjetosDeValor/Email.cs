using System.Text.RegularExpressions;

namespace HealthMed.Backend.Dominio.ObjetosDeValor
{
    public class Email
    {
        public string EnderecoEmail { get; private set; } = string.Empty;

        protected Email() { }

        public Email(string enderecoEmail)
        {
            if (!Validar(enderecoEmail)) throw new Exception("E-mail inválido");
            EnderecoEmail = enderecoEmail;
        }

        public static bool Validar(string enderecoEmail)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(enderecoEmail);
        }
    }
}
