using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Dominio.Test;
public class UsuarioTest
{
    [Fact(DisplayName = "Adiciona Medico Valido")]
    public void Adiciona_Medico_Valido()
    {
        // Arrange
        string nome = "Medico Teste";
        string cpf = "1234567890";
        string senha = "123123";
        string email = "medico@medico.com";
        ETipoUsuario tipoUsuario = ETipoUsuario.Medico;
        string crm = "12345";

        // Act
        var medico = new Usuario(nome, cpf, senha, email, tipoUsuario, crm);

        // Assert
        Assert.NotNull(medico);
        Assert.False(medico.Erros.Any());
        Assert.Equal(nome, medico.Nome);
        Assert.Equal(cpf, medico.Cpf);
        Assert.Equal(senha, medico.Senha);
        Assert.NotNull(medico.Email);
        Assert.Equal(email, medico.Email.EnderecoEmail);
        Assert.Equal(tipoUsuario, medico.TipoUsuario);
        Assert.Equal(crm, medico.CRM);
        Assert.True(medico.EhValido());
    }


    [Fact(DisplayName = "Adiciona Paciente Valido")]
    public void Adiciona_Paciente_Valido()
    {
        // Arrange
        string nome = "paciente Teste";
        string cpf = "1234567890";
        string senha = "123123";
        string email = "paciente@mail.com";
        ETipoUsuario tipoUsuario = ETipoUsuario.Paciente;

        // Act
        var paciente = new Usuario(nome, cpf, senha, email, tipoUsuario);

        // Assert
        Assert.NotNull(paciente);
        Assert.False(paciente.Erros.Any());
        Assert.Equal(nome, paciente.Nome);
        Assert.Equal(cpf, paciente.Cpf);
        Assert.Equal(senha, paciente.Senha);
        Assert.NotNull(paciente.Email);
        Assert.Equal(email, paciente.Email.EnderecoEmail);
        Assert.Equal(tipoUsuario, paciente.TipoUsuario);
        Assert.True(paciente.EhValido());
    }

    [Fact(DisplayName = "Adiciona Medico Invalido")]
    public void Adicionar_Medico_Invalido()
    {
        // Arrange
        string nome = "Medico Teste";
        string cpf = "1234567890";
        string senha = "123123";
        string email = "medico@medico.com";
        ETipoUsuario tipoUsuario = ETipoUsuario.Medico;
        string crmInvalido = string.Empty;

        // Act
        var medico = new Usuario(nome, cpf, senha, email, tipoUsuario, crmInvalido);

        // Assert
        Assert.True(medico.Erros.Any());

    }

    [Fact(DisplayName = "Alterar dados Medicos")]
    public void Alterar_Dados_Medicos()
    {

        string nome = "Medico Teste";
        string cpf = "1234567890";
        string senha = "123123";
        string email = "medico@medico.com";
        ETipoUsuario tipoUsuario = ETipoUsuario.Medico;
        string crm = "12345";

        var medico = new Usuario(nome, cpf, senha, email, tipoUsuario, crm);

        medico.AlterarDadosDoUsuario("Medico Teste alterado", cpf, tipoUsuario, crm);

        Assert.False(medico.Erros.Any());
        Assert.NotEqual(medico.Nome, nome);
        Assert.Equal(cpf, medico.Cpf);
        Assert.Equal(senha, medico.Senha);
        Assert.Equal(email, medico.Email.EnderecoEmail);
        Assert.Equal(tipoUsuario, medico.TipoUsuario);
        Assert.Equal(crm, medico.CRM);
    }

    [Fact(DisplayName = "Alterar Senha Medicos")]
    public void Alterar_Senha()
    {
        // Arrange
        string nome = "Medico Teste";
        string cpf = "1234567890";
        string senha = "123123";
        string email = "medico@medico.com";
        ETipoUsuario tipoUsuario = ETipoUsuario.Medico;
        string crm = "12345";
      
        // Act
        var medico = new Usuario(nome, cpf, senha, email, tipoUsuario, crm);
        string senhaNova = medico.GerarNovaSenha();

        medico.AlterarSenha(senhaNova);

        Assert.False(medico.Erros.Any());
        Assert.Equal(medico.Senha, senhaNova);

    }
  
}