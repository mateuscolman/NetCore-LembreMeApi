using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using LembreMeApi.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace LembreMeApi.Repository
{
    public class UsuarioRepository
    {
        private readonly AplicacaoContexto _aplicacaoContexto;

        public UsuarioRepository(AplicacaoContexto aplicacaoContexto)
        {
            _aplicacaoContexto = aplicacaoContexto;
        }

        public UsuarioModel ConsultarUsuario(LoginReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pEmail", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Email},
                new MySqlParameter("pSenha", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = CriptografiaService.Encrypt(model.Senha)}
                };

            var retornoDb = _aplicacaoContexto.Usuario.FromSqlRaw("call sp_usuario_login({0}, {1})", parameters).ToList().FirstOrDefault();
            if (retornoDb?.Id == "0") throw new Exception("Usuario ou senha invalido");
            return retornoDb;
        }

        public InserirComSPModel CadastrarUsuario(UsuarioReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pNome", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Nome},
                new MySqlParameter("pSenha", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = CriptografiaService.Encrypt(model.Senha)},
                new MySqlParameter("pEmail", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = model.Email }
                };

            var retornoDb =  _aplicacaoContexto.InserirComSP.FromSqlRaw("call sp_usuario_cadastrar({0}, {1}, {2})", parameters).ToList().FirstOrDefault();

            if (retornoDb.Id == "0") throw new Exception("Não foi possível cadastrar o usuario, por favor tente mais tarde.");

            return retornoDb;            
        }

    }
}
