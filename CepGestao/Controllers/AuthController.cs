using CepGestao.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CepGestao.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string senha)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(x =>
                    x.User == username &&
                    x.Senha == senha);
    
            if (usuario == null)
            {
                ViewBag.Erro = "Usuário ou senha inválidos";
                return View();
            }

            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            return Content($"Usuário logado: {usuarioId}");
        }
    }
}