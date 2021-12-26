using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using LembreMeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LembreMeApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/depesas/")]
    public class DespesasController : BaseController
    {
        private readonly DespesaServices _despesaServices;

        public DespesasController(DespesaServices despesaServices)
        {
            _despesaServices = despesaServices;
        }

        [HttpPost]
        [Route("inserir")]
        [ProducesResponseType(typeof(IEnumerable<InserirComSPModel>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> BuscarDespesas(CadastrarDespesaSwagger model)
        {
            try
            {
                return Ok(_despesaServices.InserirDespesa(new CadastrarDespesaReq
                {
                    IdUsuario = TokenId,
                    Titulo = model.Titulo,
                    Valor = model.Valor,
                    Vencimento = model.Vencimento
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
