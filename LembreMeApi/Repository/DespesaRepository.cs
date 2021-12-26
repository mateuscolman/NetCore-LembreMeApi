using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace LembreMeApi.Repository
{
    public class DespesaRepository
    {
        private readonly AplicacaoContexto _aplicacaoContexto;

        public DespesaRepository(AplicacaoContexto aplicacaoContexto)
        {
            _aplicacaoContexto = aplicacaoContexto;
        }

        public InserirComSPModel? CadastrarDespesa(CadastrarDespesaReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pTitulo", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Titulo},
                new MySqlParameter("pVencimento", MySqlDbType.Date) { Direction = ParameterDirection.Input, Value = model.Vencimento },
                new MySqlParameter("pValor", MySqlDbType.Decimal) { Direction = ParameterDirection.Input, Value = model.Valor },
                new MySqlParameter("pIdUsuario", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = model.IdUsuario }
                };

            return _aplicacaoContexto.InserirComSP.FromSqlRaw("call sp_despesa_inserir({0}, {1}, {2}, {3})", parameters).ToList().FirstOrDefault();                
        }

        public InserirComSPModel? BaixarDespesa(BaixarDespesaReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pId", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Id},
                new MySqlParameter("pDataPagamento", MySqlDbType.Date) { Direction = ParameterDirection.Input, Value = model.DataPagamento }
                };

            return _aplicacaoContexto.InserirComSP.FromSqlRaw("call sp_despesa_baixar({0}, {1})", parameters).ToList().FirstOrDefault();                                    
        }

        public List<DespesaModel> ConsultarDespesa(ConsultarDespesaReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pIdUsuario", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.IdUsuario},                
                new MySqlParameter("pBaixado", MySqlDbType.Int32) { Direction = ParameterDirection.Input, Value = model.Baixado },
                new MySqlParameter("pVencimento", MySqlDbType.Date) { Direction = ParameterDirection.Input, Value = model.Vencimento },
                };

            var retornoDb = _aplicacaoContexto.Despesa.FromSqlRaw("call sp_despesa_consultar({0}, {1}, {2})", parameters).ToList();            
            return retornoDb;
        }


    }
}
