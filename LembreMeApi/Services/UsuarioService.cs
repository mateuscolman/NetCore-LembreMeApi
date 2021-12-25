using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using LembreMeApi.Repository;

namespace LembreMeApi.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;        

        public UsuarioService(UsuarioRepository usuarioRepository)
        {            
            _usuarioRepository = usuarioRepository;
        }

        public TokenResp GetUsuario(LoginReq model)
        {
            var usuario = _usuarioRepository.GetUsuario(model);            
            var token = TokenService.GenerateToken(usuario);
            return new TokenResp { Token = token };
        }

        public string? CadastrarUsuario(UsuarioReq model)
        {
            InserirComSPModel idUsario = _usuarioRepository.CadastrarUsuario(model);
            if (idUsario.Id == "0") throw new Exception("Usuario já cadastrado");
            return idUsario.Id;
        }
    }
}
