using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Horario;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Aplicacao;
public class HorarioService : IHorarioService
{
    private readonly IUsuarioRepository _usuariosRepository;
    private readonly IHorarioRepository _horarioRepository;
    public HorarioService(IHorarioRepository horarioRepository, IUsuarioRepository usuarioRepository)
    {
        _horarioRepository = horarioRepository;
        _usuariosRepository = usuarioRepository; 
    }

    public async Task<ResponseResult<HorarioResponse>> CadastraHorario(AdicionarHorarioDto dto, Guid idMedico)
    {
        var medico = await _usuariosRepository.ObterPorIdAsync(idMedico);

        var response = new ResponseResult<HorarioResponse>();

        if (medico?.TipoUsuario == ETipoUsuario.Medico)
        {
            var horario = new Horarios();
            horario.Adicionar(medico, dto.HorarioInicio, dto.HorarioFinal);
            if (horario.Erros.Any())
            {
                response.Erros.Add(string.Join("|",horario.Erros)); ;
                response.Status = 400;
                return response;
            }

            int quantidadeHorarios = await _horarioRepository.GetQuantidadeHorariosPorMedico(dto.HorarioInicio, dto.HorarioFinal, idMedico);

            if (quantidadeHorarios  == 0)
            {
                await _horarioRepository.AdicionarAsync(horario);
                response.Status = 201;
                response.Data = new HorarioResponse(horario);
            }
            else
            {
                response.Status = 400;
                response.Erros.Add($"Horario {dto.HorarioInicio} á {dto.HorarioFinal} não esta disponivel");
            }    
        }
        else
        {
            response.Erros.Add($"Usuario {medico.Nome} não é medico");
            response.Status = 400;
            return response;
        }

        return response;
    }

    public async Task<ResponseResult<HorarioResponse>> AlterarHorario(AlterarHorarioDto dto, Guid idMedico)
    {
        var medico = await _usuariosRepository.ObterPorIdAsync(idMedico);
        var response = new ResponseResult<HorarioResponse>();

        if (medico?.TipoUsuario == ETipoUsuario.Medico)
        {
            
            var horario = await _horarioRepository.ObterPorIdAsync(dto.IdHorario);

            if (horario == null)
            {
                response.Erros.Add($"Horario: {dto.IdHorario} não encontrato");
                response.Status = 404;
                return response;
            }

            horario.Alterar(medico, dto.HorarioInicio, dto.HorarioFinal, dto.IdHorario);

            if (horario.Erros.Any())
            {
                response.Erros.Add(string.Join("|", horario.Erros)); ;
                response.Status = 400;
                return response;
            }

            await _horarioRepository.AlterarAsync(horario);
            response.Data = new HorarioResponse(horario);
            response.Status = 201;

        }

        return response;
    }
}