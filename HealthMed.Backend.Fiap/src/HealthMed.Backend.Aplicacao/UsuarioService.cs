using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using HealthMed.Backend.Dominio.Entidades;

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

        public async Task<ResponseResult<UsuarioResponse>> CadastraUsuario(CadastrarUsuarioDto dto)
        {
            var response = new ResponseResult<UsuarioResponse>();

            var novoUsuario = await NovoPaciente(dto);

            if (novoUsuario.Erros.Any())
            {
                response.Status = novoUsuario.Status;
                response.Erros = novoUsuario.Erros;
                return response;
            }

            await _repository.AdicionarAsync(novoUsuario.Data);
            var usuarioresponse = new UsuarioResponse();
            response.Data = usuarioresponse.ConvertToDto(novoUsuario.Data);            

            return response;
        }
        public async Task<ResponseResult<Usuario>> NovoPaciente(CadastrarUsuarioDto usuarioDto)
        {
            var response = new ResponseResult<Usuario>();

            if (await VerificarEmailCadastrado(usuarioDto.Email))
            {
                response.Erros.Add("Email ja cadastrado");
                response.Status = 400;
                return response;
            }

            var usuario = new Usuario(usuarioDto.Nome, usuarioDto.Cpf, usuarioDto.Senha, usuarioDto.Email, Dominio.Enum.ETipoUsuario.Paciente);
            
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

        public async Task<bool> VerificarEmailCadastrado(string email)
        {
            var usuario = await _repository.ObterPorEmail(email);
            return usuario != null;
        }
    }
}
