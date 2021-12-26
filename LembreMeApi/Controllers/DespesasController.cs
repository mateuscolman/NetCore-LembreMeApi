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
        public ActionResult<dynamic> InserirDespesa(CadastrarDespesaSwagger model)
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
                return BadRequest( new { Erro = $"Não foi possível cadastrar a despesa | Motivo: {ex.Message}" } );
            }
        }

        [HttpGet]
        [Route("consultar")]
        [ProducesResponseType(typeof(IEnumerable<DespesaModel>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> ConsultarDespesas([FromQuery] ConsultarDespesaSwagger model)
        {
            try
            {
                model.Vencimento = model.Vencimento == DateTime.MinValue ? DateTime.Now : model.Vencimento;
                return Ok(_despesaServices.ConsultarDespesa(new ConsultarDespesaReq
                {
                    Baixado = model.Baixado,
                    IdUsuario = TokenId,
                    Vencimento = model.Vencimento
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = $"Não foi possível consultar a despesa | Motivo: {ex.Message}" });
            }
        }

        [HttpPut]
        [Route("baixar")]
        [ProducesResponseType(typeof(IEnumerable<DespesaModel>), StatusCodes.Status200OK)]
        public ActionResult<dynamic> BaixarDespesa(BaixarDespesaReq model)
        {
            try
            {
                return _despesaServices.BaixarDespesa(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = $"Não foi possível baixar a despesa | Motivo: {ex.Message}" });
            }
        }
    }
}
