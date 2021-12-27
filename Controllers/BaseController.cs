using LembreMeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LembreMeApi.Controllers
{
    public class BaseController : Controller
    {
        public string? Token => Request.Headers["Authorization"];

        public string? TokenId => TokenService.BuscarChaveToken(Token, "Id") == null ? throw new UnauthorizedAccessException("Sessão de usuário ínvalida")
            : TokenService.BuscarChaveToken(Request.Headers["Authorization"], "Id");
    }
}