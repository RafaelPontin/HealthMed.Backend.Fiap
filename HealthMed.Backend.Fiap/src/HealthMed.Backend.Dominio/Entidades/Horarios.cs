using HealthMed.Backend.Dominio.Enum;
using System.Data;

namespace HealthMed.Backend.Dominio.Entidades;
public class Horarios : Base
{
    public DateTime HorarioInicio { get; private set; }
    public DateTime HorarioFinal {  get; private set; }
    public DateTime? HorarioCriacao { get; private set; }
    public bool Disponivel {  get; private set; }

    public Usuario Medico { get; private set; }


    public void Adicionar(Usuario medico, DateTime dataInicio, DateTime dataFinal)
    {
        SetMedico(medico);
        SetHorario(dataInicio, dataFinal);
        SetCriacao();
        Disponivel = true;
    }


    public void Alterar(Usuario medico, DateTime dataInicio, DateTime dataFinal, Guid idHorario)
    {
        SetId(idHorario);
        SetMedico(medico);
        SetHorario(dataInicio, dataFinal);
        SetCriacao();
    }

    private void SetId(Guid idHorario)
    {
        if (idHorario == Guid.Empty) AddErro($"Id vazio {idHorario}");
        DefinirId(idHorario);
    }

    private void SetHorario(DateTime horarioInicio, DateTime horarioFinal)
    {
        if (horarioFinal < horarioInicio) AddErro($"O Horario final {horarioFinal.ToString("dd/MM/yyyy hh:mm")} é maior que data final {HorarioInicio.ToString("dd/MM/yyyy hh:mm")}");
        else if (horarioInicio == horarioFinal) AddErro($"Data final {horarioFinal.ToString("dd/MM/yyyy hh:mm")} e data inicio {horarioInicio.ToString("dd/MM/yyyy hh:mm")} são iguais");
        else
        {
            HorarioInicio = horarioInicio;
            HorarioFinal = horarioFinal;
        }
    }

    private void SetMedico(Usuario medico)
    {
        if (medico == null) AddErro("Medico vazio");
        else if (medico.TipoUsuario != ETipoUsuario.Medico) AddErro($"Usuario não e do tipo Medico {medico.TipoUsuario}");
        else Medico = medico;
    }


    private void SetCriacao()
    {
        if (!Erros.Any()) HorarioCriacao = DateTime.Now;
    }
}
