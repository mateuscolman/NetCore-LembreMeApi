using LembreMeApi.Domains.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LembreMeApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/depesas/")]
    public class DespesasController : BaseController
    {
        [HttpGet]
        [Route("buscar")]
        [ProducesResponseType(typeof(IEnumerable<TokenResp>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> BuscarDespesas()
        {
            return Ok(new { Mensagem = $"Token: {TokenId}" });
        }
    }
}
