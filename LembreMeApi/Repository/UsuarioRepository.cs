using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
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

        public UsuarioModel GetUsuario(LoginReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pEmail", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Email},
                new MySqlParameter("pSenha", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = model.Senha }
                };

            var retornoDb = _aplicacaoContexto.Usuario.FromSqlRaw("call sp_usuario_login({0}, {1})", parameters).ToList();
            if (retornoDb.Count == 0) throw new Exception("Usuario ou senha invalido");
            return new UsuarioModel
            {
                Email = retornoDb[0].Email,
                Id = retornoDb[0].Id,
                Nome = retornoDb[0].Nome,
                Senha = retornoDb[0].Senha
            };
        }

        public InserirComSPModel CadastrarUsuario(UsuarioReq model)
        {
            var parameters = new[] {
                new MySqlParameter("pNome", MySqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = model.Nome},
                new MySqlParameter("pSenha", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = model.Senha },
                new MySqlParameter("pEmail", MySqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = model.Email }
                };

            var retornoDb =  _aplicacaoContexto.InserirComSP.FromSqlRaw("call sp_usuario_cadastrar({0}, {1}, {2})", parameters).ToList();

            if (retornoDb.Count == 0) throw new Exception("Não foi possível cadastrar o usuario, por favor tente mais tarde.");

            return new InserirComSPModel
            {
                Id = retornoDb[0].Id,
            };
            
        }

    }
}
