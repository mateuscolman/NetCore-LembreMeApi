using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using LembreMeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LembreMeApi.Controllers
{
    [ApiController]
    [Route("api/v1/usuario/")]
    public class UsuarioController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(typeof(IEnumerable<TokenResp>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> GetUsuario([FromBody] LoginReq model)
        {
            try
            {
                var token = _usuarioService.GetUsuario(model);                
                return Ok(token);
            }
            catch (Exception ex)
            {             
                if (ex.Message == "Usuario ou senha invalido") return NotFound(new { Mensagem = "Usuário ou senha inválido!" });
                return BadRequest(new { Erro = $"Erro ao autenticar. Motivo: {ex.Message}" });
            }
        }

        
        [HttpPost]
        [Route("cadastrar")]
        [ProducesResponseType(typeof(IEnumerable<TokenResp>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> CadastarUsuario([FromBody] UsuarioReq model)
        {
            try
            {
                var id = _usuarioService.CadastrarUsuario(model);
                return Ok($"Usuario cadastrado com Sucesso! Id: {id}");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Usuario já cadastrado") return NotFound(new { Erro = ex.Message });
                return BadRequest(new { Erro = $"Erro ao cadastrar usuario. Motivo: {ex.Message}" });
            }
        }
    }
}
