using HealthMed.Backend.Dominio.Enum;
using HealthMed.Backend.Dominio.ObjetosDeValor;

namespace HealthMed.Backend.Dominio.Entidades;
public class Usuario : Base
{
    protected Usuario()
    {

    }

    public Usuario(string nome, string cpf, string senha, string email, ETipoUsuario tipoUsuario)
    {
        if (!UsuarioEhValido(nome, cpf, senha, email, tipoUsuario))
            Erros.Add($"É necessário informar todos os campos.");

        Nome = nome.Trim();        
        Senha = senha.Trim();
        Cpf = cpf.Trim();
        Email = ObterEmail(email.Trim());        
        TipoUsuario = ETipoUsuario.Paciente;
    }

    public Usuario(string nome, string cpf, string senha, string email, ETipoUsuario tipoUsuario, string crm)
    {
        if (!UsuarioEhValido(nome, cpf, senha, email, tipoUsuario, crm))
            Erros.Add($"É necessário informar todos os campos.");

        Nome = nome.Trim();
        Senha = senha.Trim();
        Cpf = cpf.Trim();
        Email = ObterEmail(email.Trim());
        CRM = crm.Trim();
        TipoUsuario = ETipoUsuario.Medico;
    }
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string CRM { get; private set; }
    public Email Email { get; private set; }
    public string Senha { get; private set; }
    public ETipoUsuario TipoUsuario { get; private set; }
    public ICollection<Agendamentos> Agendamentos { get; private set; }
    public ICollection<Horarios> Horarios { get; private set; }    

    private bool UsuarioEhValido(string nome, string cpf, string senha, string email, ETipoUsuario tipoUsuario, string crm = null)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            Erros.Add("O nome não pode estar vazio ou nulo.");
        }

        if (string.IsNullOrWhiteSpace(cpf))
        {
            Erros.Add("O cpf não pode estar vazio ou nulo.");
        }

        if (string.IsNullOrWhiteSpace(senha))
        {
            Erros.Add("A senha não pode estar vazio ou nula.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            Erros.Add("O email não pode estar vazio ou nula.");
        }

        if (string.IsNullOrWhiteSpace(crm) && tipoUsuario == ETipoUsuario.Medico)
        {
            Erros.Add("O crm não pode estar vazio ou nula.");
        }

        return !Erros.Any();
    }

    public void AlterarDadosDoUsuario(string nome, string cpf, ETipoUsuario tipoUsuario, string crm = null)
    {
        if (!UsuarioEhValido(nome, cpf, Senha, Email.EnderecoEmail, tipoUsuario, crm))
            Erros.Add($"É necessário informar todos os campos.");
        
        Nome = nome.Trim();
        Cpf = cpf.Trim();
        CRM = tipoUsuario == ETipoUsuario.Medico ? crm?.Trim() : null;
    }

    public void AlterarSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            Erros.Add($"A senha não pode estar vazio ou nula.");

        Senha = senha;
    }
    public bool EhValido()
    {
        return !Erros.Any();
    }
    public string GerarNovaSenha()
    {
        string caracteres = "abcdefghjkmnpqrstuvwxyz023456789";
        string senha = "";
        Random random = new Random();
        for (int f = 0; f < 6; f++)
        {
            senha = senha + caracteres.Substring(random.Next(0, caracteres.Length - 1), 1);
        }

        return senha;
    }

    private Email ObterEmail(string email)
    {
        try
        {
            return new Email(email.Trim());
        }
        catch (Exception)
        {
            Erros.Add("Email inválido");
            return null;
        }
    }
}
