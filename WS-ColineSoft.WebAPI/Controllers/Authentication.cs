using Microsoft.AspNetCore.Mvc;
using WS_ColineSoft.Domain.DTO;
using WS_ColineSoft.Domain.Interfaces.Services;
using WS_ColineSoft.WebAPI.Service;

namespace WS_ColineSoft.WebAPI.Controllers
{
    [ApiController]
    public class Authentication : Controller
    {
        private readonly IUsuarioService _usuario;
        public Authentication(IUsuarioService usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("Login")]
        public IActionResult Login(string nome, string password)
        {
            //Tenta localiar o usuário            
            var usr = _usuario.GetBy(e => e.Nome == nome && e.Senha == password).FirstOrDefault();
            if(usr != null)
            {
                var token = TokenService.GenerateToken(usr);
                return Ok(token);
            }
            return BadRequest("Usuário não encontrado");
        }
    }
}
