using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Horario;
using HealthMed.Backend.Aplicacao.DTOs.Usuarios;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthMed.Backend.Aplicacao
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
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
            VerificarSenha(usuarioDto, response);

            if (usuario.EhValido())
            {
                response.Data = usuario;
                response.Status = 201;
                return response;
            }

            response.Status = 400;
            usuario.Erros.ToList().ForEach(x => response.Erros.Add(x));

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

            VerificarSenha(usuarioDto, response);

            var usuario = NovoUsuario(usuarioDto, ETipoUsuario.Paciente);

            if (usuario.EhValido())
            {
                response.Data = usuario;
                response.Status = 201;
                return response;
            }

            response.Status = 400;
            usuario.Erros.ToList().ForEach(x => response.Erros.Add(x));


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

        public async Task<ResponseResult<List<AgendaResponse>>> ObterAgenda(Guid id)
        {
            try
            {
                var response = new ResponseResult<List<AgendaResponse>>();
                var agendas = await _repository.ObterAgenda(id);
                var listaDeAgendas = new List<AgendaResponse>();

                foreach (var agenda in agendas)
                {
                    var agendaDto = new AgendaResponse().ConvertToDto(agenda);
                    listaDeAgendas.Add(agendaDto);
                }

                return new ResponseResult<List<AgendaResponse>>() { Status = 200, Data = listaDeAgendas };
            }
            catch (Exception)
            {

                return new ResponseResult<List<AgendaResponse>>() { Status = 500, Data = null };

            }

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

        private ResponseResult<Usuario> VerificarSenha(CadastrarUsuarioDto usuarioDto, ResponseResult<Usuario> response)
        {
            if (usuarioDto.Senha != usuarioDto.ConfirmacaoSenha)
            {
                response.Erros.Add("A senha não confere");
                response.Status = 400;                
            }
            return response;
        }

        public async Task<ResponseResult<UsuarioLogadoResponse>> Login(string email, string senha)
        {
            try
            {
                var response = new ResponseResult<UsuarioLogadoResponse>();
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                {
                    response.Status = 400;
                    response.Erros.Add("Informe usuario e senha");
                    return response;
                }

                var usuario = await _repository.Login(email, senha);
                if (usuario == null)
                {
                    response.Status = 400;
                    response.Erros.Add("Usuario/senha inválidos");
                    return response;
                }

                var token = GerarToken(usuario);
                response.Data = new UsuarioLogadoResponse
                {
                    AccessToken = token,
                    Email = usuario.Email.EnderecoEmail,
                    Nome = usuario.Nome,
                    Id = usuario.Id,
                };

                return response;
            }
            catch (Exception)
            {
                return new ResponseResult<UsuarioLogadoResponse>() { Data = null, Status = 500 };

            }

        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretApi"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email.ToString(), usuario.Email.EnderecoEmail),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()),
                    new Claim("Tipo", usuario.TipoUsuario.ToString()),
                    new Claim("Id", usuario.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<ResponseResult<List<MedicoResponse>>> BuscarMedicos()
        {
            var response = new ResponseResult<List<MedicoResponse>>();
            try
            {
                var medicos = await _repository.BuscarMedicos();
                var listaDeMedicos = new List<MedicoResponse>();
                if (medicos != null)
                {
                    foreach (var medico in medicos)
                    {
                        var medicoDto = new MedicoResponse().ConvertToDto(medico) as MedicoResponse;
                        listaDeMedicos.Add(medicoDto);
                    }
                }

                return new ResponseResult<List<MedicoResponse>>() { Status = 200, Data = listaDeMedicos };
            }
            catch (Exception)
            {

                return new ResponseResult<List<MedicoResponse>>() { Status = 500, Data = null };
            }
        }
    }
}
