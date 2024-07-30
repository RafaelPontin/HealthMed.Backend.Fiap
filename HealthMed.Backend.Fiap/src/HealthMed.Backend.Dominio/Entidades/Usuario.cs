using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Dominio.Entidades;
public class Usuario : Base
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string CRM { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public ETipoUsuario tipoUsuario { get; private set; }
    public ICollection<Agendamentos> Agendamentos { get; private set; }
    public ICollection<Horarios> Horarios { get; private set; }
}
