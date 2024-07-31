using HealthMed.Backend.Dominio.ObjetosDeValor;

namespace HealthMed.Backend.Dominio.Test;
public class EmailTest
{
    [Fact(DisplayName = "Teste Email Valido")]
    public void Cria_Email_Valido()
    {
        string emailValido = "email@mail.com";
         
        Email email = new Email(emailValido);

        Assert.NotEmpty(email.EnderecoEmail);
        Assert.True(Email.Validar(emailValido));
    }


    [Fact(DisplayName = "Teste Email Invalido")]
    public void Cria_Email_Invalido()
    {
        string emailValido = "emailmail.com";

        Assert.False(Email.Validar(emailValido));
    }
}
