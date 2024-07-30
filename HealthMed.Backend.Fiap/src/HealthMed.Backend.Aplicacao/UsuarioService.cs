using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Aplicacao
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<ResponseResult<bool>> AlterarUsuario(AlterarUsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResult<MedicoResponse>> CadastrarMedico(CadastrarMedicoDto dto)
        {
            try
            {
                var response = new ResponseResult<MedicoResponse>();

                var novoUsuario = await NovoMedico(dto);

                if (novoUsuario.Erros.Any())
                {
                    response.Status = novoUsuario.Status;
                    response.Erros = novoUsuario.Erros;
                    return response;
                }

                await _repository.AdicionarAsync(novoUsuario.Data);
                var usuarioresponse = new MedicoResponse();
                response.Data = usuarioresponse.ConvertToDto(novoUsuario.Data) as MedicoResponse;

                return response;
            }
            catch (Exception)
            {
                return new ResponseResult<MedicoResponse>() { Data = null, Status = 500 };
            }

        }
        public async Task<ResponseResult<Usuario>> NovoMedico(CadastrarMedicoDto usuarioDto)
        {

            var response = new ResponseResult<Usuario>();

            if (await VerificarEmailCadastrado(usuarioDto.Email))
            {
                response.Erros.Add("Email ja cadastrado");
                response.Status = 400;
                return response;
            }

            var usuario = NovoUsuario(usuarioDto, ETipoUsuario.Medico);


            if (usuario.EhValido())
            {
                response.Data = usuario;
                response.Status = 201;
                return response;
            }

            response.Status = 400;
            response.Erros = usuario.Erros;

            return response;
        }

        public async Task<ResponseResult<PacienteResponse>> CadastrarPaciente(CadastrarPacienteDto dto)
        {
            try
            {
                var response = new ResponseResult<PacienteResponse>();

                var novoUsuario = await NovoPaciente(dto);

                if (novoUsuario.Erros.Any())
                {
                    response.Status = novoUsuario.Status;
                    response.Erros = novoUsuario.Erros;
                    return response;
                }

                await _repository.AdicionarAsync(novoUsuario.Data);
                var usuarioresponse = new PacienteResponse();
                response.Data = usuarioresponse.ConvertToDto(novoUsuario.Data) as PacienteResponse;

                return response;
            }
            catch (Exception)
            {
                return new ResponseResult<PacienteResponse>() { Data = null, Status = 500 };
            }
        }
        public async Task<ResponseResult<Usuario>> NovoPaciente(CadastrarPacienteDto usuarioDto)
        {
            var response = new ResponseResult<Usuario>();

            if (await VerificarEmailCadastrado(usuarioDto.Email))
            {
                response.Erros.Add("Email ja cadastrado");
                response.Status = 400;
                return response;
            }

            var usuario = NovoUsuario(usuarioDto, ETipoUsuario.Paciente);

            if (usuario.EhValido())
            {
                response.Data = usuario;
                response.Status = 201;
                return response;
            }

            response.Status = 400;
            response.Erros = usuario.Erros;

            return response;
        }
        public Task<ResponseResult<UsuarioDto>> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<IList<UsuarioDto>>> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        private async Task<bool> VerificarEmailCadastrado(string email)
        {
            var usuario = await _repository.ObterPorEmail(email);
            return usuario != null;
        }


        private Usuario NovoUsuario(CadastrarUsuarioDto usuarioDto, ETipoUsuario tipoUsuario)
        {
            if (tipoUsuario == ETipoUsuario.Paciente)
            {
                return new Usuario(usuarioDto.Nome, usuarioDto.Cpf, usuarioDto.Senha, usuarioDto.Email, ETipoUsuario.Paciente);
            }
            else
            {
                return new Usuario(usuarioDto.Nome, usuarioDto.Cpf, usuarioDto.Senha, usuarioDto.Email, ETipoUsuario.Medico, (usuarioDto as CadastrarMedicoDto).CRM);
            }
        }
    }
}
