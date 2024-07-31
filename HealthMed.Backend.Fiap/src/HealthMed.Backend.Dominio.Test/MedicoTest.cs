using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Dominio.Test;
public class MedicoTest
{
    [Fact(DisplayName = "Adiciona Medico Valido")]
    public void Adiciona_Medico_Valido()
    {
        // Arrange
        const string nome = "Medico Teste";
        const string cpf = "1234567890";
        const string senha = "123123";
        const string email = "medico@medico.com";
        const ETipoUsuario tipoUsuario = ETipoUsuario.Medico;
        const string crm = "12345";

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
        var medico = new Usuario("Medico Teste", "1234567890", "123123", "medico@medico.com", ETipoUsuario.Medico, "12345");

        medico.AlterarDadosDoUsuario("Medico Teste alterado", "1234567891", ETipoUsuario.Medico, "12346");

    }
  
}