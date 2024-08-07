﻿using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.DTOs.Horario;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;

namespace HealthMed.Backend.Aplicacao.Contratos.Servico
{
    public interface IUsuarioService
    {
        Task<ResponseResult<PacienteResponse>> CadastrarPaciente(CadastrarPacienteDto dto);
        Task<ResponseResult<MedicoResponse>> CadastrarMedico(CadastrarMedicoDto dto);
        Task<ResponseResult<bool>> AlterarUsuario(AlterarUsuarioDTO dto);
        Task<ResponseResult<IList<UsuarioDto>>> ListarUsuarios();
        Task<ResponseResult<UsuarioDto>> GetById(Guid Id);
        Task<ResponseResult<UsuarioLogadoResponse>> Login(string email, string senha);
        Task<ResponseResult<List<MedicoResponse>>> BuscarMedicos();
        Task<ResponseResult<List<AgendaResponse>>> ObterAgenda(Guid id);
    }
}
